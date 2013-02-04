using System;
using System.Collections.Generic;
using System.Linq;
using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Maps;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens
{
    public class GameScreen : Screen
    {
        public Map MapFirst { get; set; }
        public static Player Player { get; set; }
        public IList<Entity> Entities { get; set; }

        private IList<Entity> deletedEntities;

        private double timeSpent;

        public GameScreen()
        {
            Player = new Player(this, TexturesManager.Player); // Charge le Joueur

            Entities = new List<Entity> // Charge les ennemis
                {
                    new Monster(this, TexturesManager.Ennemy),
                    new Monster(this, TexturesManager.Ennemy)

                };
            Entities[1].Position = new Vector2(10, 100);
            Entities[1].Bounds = new Rectangle((int)Entities[1].Position.X, (int)Entities[1].Position.Y, (int)Entities[1].TextureSize.X, (int)Entities[1].TextureSize.Y);


            deletedEntities = new List<Entity>(); // On transfere un Monster deleted a l'interieur puis on le detruit dans cette liste

            MapData mapData = new MapData();
            if (!mapData.FromFile("Content/Maps/map.mrm"))
                throw new Exception();
            MapFirst = new Map(mapData);
        }

        public override void Update(GameTime gameTime)
        {
            Player.Update(gameTime);

            foreach (Monster entity in Entities.OfType<Monster>()) // Si liste modifiée pendant la boucle -> exception
                entity.Update(gameTime);

            while (deletedEntities.Count > 0)
            {
                Entities.Remove(deletedEntities[0]); // Remove dans la liste des ennemis les ennemis deleted grâce à la fonction Delete() dans la fonction Damage()
                deletedEntities.RemoveAt(0); // Pour éviter que cela le fasse deux fois.
            }

            Spawn(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Position = -ScreenToGameCoords(Vector2.Zero);

            spriteBatch.DrawUI(TexturesManager.Menu, "Count : " + Entities.Count, new Vector2(MainGame.ScreenX - 200, 0), Color.White);
            spriteBatch.DrawUI(TexturesManager.Menu, "FPS : " + (int)Math.Ceiling(1000 / gameTime.ElapsedGameTime.TotalMilliseconds), new Vector2(MainGame.ScreenX - 200, 100), Color.White);

            MapFirst.Draw(spriteBatch, true);
            foreach (Monster entity in Entities.OfType<Monster>())
                entity.Draw(gameTime, spriteBatch);
            Player.Draw(gameTime, spriteBatch);

            MapFirst.Draw(spriteBatch, false);
            foreach (Entity entity in Entities)
                entity.DrawUI(gameTime, spriteBatch);
            Player.DrawUI(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public Vector2 ScreenToGameCoords(Vector2 vector) // Position convertie de l'ecran en position du Jeu
        {
            Vector2 center = Player.CanMove ? Player.Position : Player.AstralPosition;
            Vector2 delta = -center + new Vector2(MainGame.ScreenX / 2, MainGame.ScreenY / 2) - new Vector2(Player.TextureSize.X / 2.0f, Player.TextureSize.Y / 2.0f);
            return (vector - delta);
        }

        public void Spawn(GameTime gameTime)
        {
            timeSpent += gameTime.ElapsedGameTime.TotalMilliseconds;

            while (timeSpent >= 1)
            {
                timeSpent -= 1;
                Monster monster = new Monster(this, TexturesManager.Ennemy);
                monster.Position = new Vector2(RandomManager.Next(0, MainGame.ScreenX - 100), RandomManager.Next(0, MainGame.ScreenY - 100));
                Entities.Add(monster);
            }
        }

        public void DeleteEntity(Entity entity)
        {
            deletedEntities.Add(entity); // Ajoute à la liste pour qu'à la fin de la frame tout les monstres à l'intèrieur soit Remove
        }
    }
}
