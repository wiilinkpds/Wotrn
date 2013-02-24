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

        public bool IsPaused { get; set; }
        
        private IList<Entity> deletedEntities;
        private EscapeMenu escapeMenu;

        private double timeSpent;
        private double timeSpawn;
        private bool isShown;

        public GameScreen()
        {
            timeSpawn = 500;

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

            }

            foreach (Window win in Windows.ToArray())
                win.Update(gameTime);

            if (KeyboardManager.IsPressed(Keys.F1))
                isShown = !isShown;
            if (KeyboardManager.IsPressed(Keys.Escape))
                ToggleWindow(escapeMenu);
            Spawn(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Position = -ScreenToGameCoords(Vector2.Zero);

            MapFirst.Draw(spriteBatch, true);

            foreach (Monster entity in Entities.OfType<Monster>())
                entity.Draw(gameTime, spriteBatch);

            Player.Draw(gameTime, spriteBatch);

            MapFirst.Draw(spriteBatch, false);
            foreach (Entity entity in Entities)
                entity.DrawUI(gameTime, spriteBatch);
            Player.DrawUI(gameTime, spriteBatch);

            foreach (WorldEffect worldEffect in WorldEffects)
                worldEffect.Draw(gameTime, spriteBatch);

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
                Monster monster = new Monster(this, TexturesManager.Ennemy);
                monster.Position = new Vector2(RandomManager.Next(500, MainGame.ScreenX - 100), RandomManager.Next(500, MainGame.ScreenY - 100));
                Entities.Add(monster);
            }
        }

        public Vector2 ScreenToGameCoords(Vector2 vector) // Position convertie de l'ecran en position du Jeu
        {
            Vector2 center = Player.CanMove ? Player.Position : Player.AstralPosition;
            Vector2 delta = -center + new Vector2(MainGame.ScreenX / 2, MainGame.ScreenY / 2) - new Vector2(Player.TextureSize.X / 2.0f, Player.TextureSize.Y / 2.0f);
            return (vector - delta);
        }

        public void DeleteEntity(Entity entity)
        {
            deletedEntities.Add(entity); // Ajoute à la liste pour qu'à la fin de la frame tout les monstres à l'intèrieur soit Remove
        }
    }
}
