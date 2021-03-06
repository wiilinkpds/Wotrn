﻿using System;
using System.Collections.Generic;
using System.Linq;
using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Maps;
using GameProjectReborn.Screens.Windows;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Screens
{
    public class GameScreen : Screen
    {
        public Map MapFirst { get; set; }
        public Player Player { get; set; }
        public IList<Entity> Entities { get; set; }
        public IList<WorldEffect> WorldEffects { get; set; }
        public static Cam camera;

        public bool IsPaused { get; set; }
        
        private IList<Entity> deletedEntities;
        private EscapeMenu escapeMenu;

        private double timeSpent;
        private double timeSpawn;
        private bool isShown;
        private int i = 0; //Sert pour le temps(pluie neige ...)

        public GameScreen()
        {
            timeSpawn = 10000;
            WorldEffects = new List<WorldEffect>();

            Player = new Player(this, TexturesManager.Player); // Charge le Joueur

            Windows.Add(new PanelMenu(this, new Vector2(0, MainGame.ScreenY / 2), TexturesManager.Window, Player));
            escapeMenu = new EscapeMenu(this, new Vector2(100, MainGame.ScreenY / 4 + 50));

            IsPaused = false;

            Entities = new List<Entity>();
            deletedEntities = new List<Entity>(); // On transfere un Monster deleted a l'interieur puis on le detruit dans cette liste

            MapData mapData = new MapData();
            if (!mapData.FromFile("Content/Maps/map.mrm"))
                throw new Exception();
            MapFirst = new Map(mapData);

            camera = new Cam(mapData.MapWidth * 32, mapData.MapHeight * 32, MainGame.graphics);

        }

        public override void Update(GameTime gameTime)
        {
            if (!escapeMenu.IsOpened)
            {
                Player.Update(gameTime);

                foreach (Monster entity in Entities.OfType<Monster>())
                    entity.Update(gameTime, MapFirst.Data, Player);

                while (deletedEntities.Count > 0)
                {
                    Entities.Remove(deletedEntities[0]);
                    deletedEntities.RemoveAt(0);
                }

                foreach (WorldEffect worldEffect in WorldEffects)
                    worldEffect.Update(gameTime);

                List<WorldEffect> deletedEffects = new List<WorldEffect>();

                foreach (WorldEffect worldEffect in WorldEffects)
                    if (worldEffect.LifeSpan <= 0)
                        deletedEffects.Add(worldEffect);

                while (deletedEffects.Count > 0)
                {
                    WorldEffects.Remove(deletedEffects[0]);
                    deletedEffects.RemoveAt(0);
                }

                camera.Update(Player.CanMove ? Player.Position : Player.AstralPosition);
                Spawn(gameTime);
            }

            foreach (Window win in Windows.ToArray())
                win.Update(gameTime);

            if (KeyboardManager.IsPressed(Keys.F1))
                isShown = !isShown;
            if (KeyboardManager.IsPressed(Keys.Escape))
                ToggleWindow(escapeMenu);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.BeginCam(camera);

            MapFirst.Draw(spriteBatch, true);
            if (isShown)
                if (Player.pos.X >= 0 && Player.pos.Y >= 0)
                    spriteBatch.Draw(TexturesManager.Tile, Player.pos);
            foreach (Monster entity in Entities.OfType<Monster>())
                entity.Draw(gameTime, spriteBatch);

            Player.Draw(gameTime, spriteBatch);

            MapFirst.Draw(spriteBatch, false);

            foreach (WorldEffect worldEffect in WorldEffects)
                worldEffect.Draw(gameTime, spriteBatch);

            if (gameTime.TotalGameTime.TotalMilliseconds % 10000 < 10)
                i = RandomManager.Next(0, 2);
            Temps.Pluie(spriteBatch, gameTime, MapFirst.Data, i == 1 ? false : true);
            Temps.Neige(spriteBatch, gameTime, MapFirst.Data, i == 2 ? false : true);
            spriteBatch.End();

            spriteBatch.Begin();
            MainGame.cursor.Draw(spriteBatch);
            foreach (Entity entity in Entities)
                entity.DrawUI(gameTime, spriteBatch);
            Player.DrawUI(gameTime, spriteBatch);

            foreach (Window win in Windows)
                win.Draw(gameTime, spriteBatch);

            if (isShown)
                DrawInfo(gameTime, spriteBatch, Color.White);

            spriteBatch.End();
        }

        public void DrawInfo(GameTime gameTime, UberSpriteBatch spriteBatch, Color color)
        {
            spriteBatch.DrawUI(TexturesManager.Menu, "Count : " + Entities.Count, new Vector2(MainGame.ScreenX / 2, 5), color);
            spriteBatch.DrawUI(TexturesManager.Menu, "FPS : " + (int)Math.Ceiling(1000 / gameTime.ElapsedGameTime.TotalMilliseconds), new Vector2(MainGame.ScreenX / 2, 25), color);
            spriteBatch.DrawUI(TexturesManager.Menu, "Coord : " + Player.coord.Y + " Y, " + Player.coord.X + " X", new Vector2(MainGame.ScreenX / 2, 45), color);
            spriteBatch.DrawUI(TexturesManager.Menu, "Id : " + (Player.coord.Y * 32 + Player.coord.X), new Vector2(MainGame.ScreenX / 2, 65), color);
            if (Player.Target != null)
            {
                Vector2 coordTarget = new Vector2((int)Math.Ceiling(Player.Target.Position.X * 32 / 1000) - 1, (int)Math.Ceiling(Player.Target.Position.Y * 32 / 1000) - 1);
                spriteBatch.DrawUI(TexturesManager.Menu, "Id target: " + (coordTarget.Y * 32 + coordTarget.X), new Vector2(MainGame.ScreenX / 2, 85), color);
            }
        }

        public void Spawn(GameTime gameTime)
        {
            timeSpent += gameTime.ElapsedGameTime.TotalMilliseconds;

            while (timeSpent >= timeSpawn)
            {
                timeSpent -= timeSpawn;
                Monster monster = RandomManager.Next(0, 1) == 0 ? new Monster(this, TexturesManager.Rack, 4, 1) : new Monster(this, TexturesManager.RackNinja, 4, 3);
                monster.Position = new Vector2(RandomManager.Next(500, MapFirst.Data.MapWidth * 32 - 100), RandomManager.Next(500, MapFirst.Data.MapHeight * 32 - 100));
                Entities.Add(monster);
            }
        }

        public void DeleteEntity(Entity entity)
        {
            deletedEntities.Add(entity); // Ajoute à la liste pour qu'à la fin de la frame tout les monstres à l'intèrieur soit Remove
        }
    }
}
