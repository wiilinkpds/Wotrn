using System.Collections.Generic;
using System.Linq;
using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Maps;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn
{
    public class MainGame : Game
    {
        public const int ScreenX = 1024;
        public const int ScreenY = 768;

        public Map Map { get; private set; }
        public Player Player { get; private set; } 
        public IList<Entity> Entities { get; private set; }

        private IList<Entity> deletedEntities; 
        private GraphicsDeviceManager graphics;
        private UberSpriteBatch spriteBatch;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this) { PreferredBackBufferWidth = ScreenX, PreferredBackBufferHeight = ScreenY };
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            spriteBatch = new UberSpriteBatch(GraphicsDevice);

            TexturesManager.Load(Content);

            Player = new Player(this, TexturesManager.Player);
            Entities = new List<Entity>
                {
                    new Monster(this, TexturesManager.Ennemy),
                    new Monster(this, TexturesManager.Ennemy)
                };
            Entities[1].Position = new Vector2(10, 100);
            deletedEntities = new List<Entity>();

            MapData mapData = new MapData();

            if (!mapData.FromFile("Content/Maps/map.mrm"))
                Exit();

            Map = new Map(mapData);
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardManager.Update();

            Player.Update(gameTime);

            foreach (Monster entity in Entities.OfType<Monster>())
                entity.Update(gameTime);

            while (deletedEntities.Count > 0)
            {
                Entities.Remove(deletedEntities[0]);
                deletedEntities.RemoveAt(0);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Vector2 center = Player.CanMove ? Player.Position : Player.AstralPosition;
            spriteBatch.Position = -center + new Vector2(ScreenX / 2, ScreenY / 2) - new Vector2(Player.Texture.Width / 2.0f, Player.Texture.Height / 2.0f);

            Map.Draw(spriteBatch, true);
            
            foreach (Monster entity in Entities.OfType<Monster>())
                entity.Draw(gameTime, spriteBatch);

            Player.Draw(gameTime, spriteBatch);
            Map.Draw(spriteBatch, false);

            foreach (Entity entity in Entities)
                entity.DrawUI(gameTime, spriteBatch);
            Player.DrawUI(gameTime, spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void DeleteEntity(Entity entity)
        {
            deletedEntities.Add(entity);
        }
    }
}
