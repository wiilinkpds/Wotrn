using System.Collections.Generic;
using System.Linq;
using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Maps;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using GameProjectReborn.Camera;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn
{
    public class MainGame : Game
    {
        public const int ScreenX = 1280;
        public const int ScreenY = 800;

        public Map MapFirst { get; private set; }

        public Player Player { get; private set; } 
        public IList<Entity> Entities { get; private set; }

        private IList<Entity> deletedEntities;
        private GraphicsDeviceManager graphics;
        private UberSpriteBatch spriteBatch;
        private Cam camera;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this) { PreferredBackBufferWidth = ScreenX, PreferredBackBufferHeight = ScreenY };
            Content.RootDirectory = "Content";
            //graphics.IsFullScreen = true;
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new UberSpriteBatch(GraphicsDevice); // Charge notre spriteBatch personnalise
            TexturesManager.Load(Content); // Charge les textures

            Player = new Player(this, TexturesManager.Player); // Charge le Joueur
            Entities = new List<Entity> // Charge les ennemis
                {
                    new Monster(this, TexturesManager.Ennemy),
                    new Monster(this, TexturesManager.Ennemy)
                };
            Entities[1].Position = new Vector2(10, 100);
            deletedEntities = new List<Entity>(); // On transfere un Monster deleted a l'interieur puis on le detruit dans cette liste
            
            MapData mapData = new MapData();
            if (!mapData.FromFile("Content/Maps/map.mrm"))
                Exit();
            MapFirst = new Map(mapData);
            Player.Position = new Vector2(33,0);
            camera = new Cam(mapData.MapWidth * 32 , mapData.MapHeight * 32 ,GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardManager.Update();
            MouseManager.Update();

            Player.Update(gameTime, camera);

            foreach (Monster entity in Entities.OfType<Monster>()) // Si liste modifiée pendant la boucle -> exception
                entity.Update(gameTime, Player,MapFirst.Data);

            while (deletedEntities.Count > 0)
            {
                Entities.Remove(deletedEntities[0]); // Remove dans la liste des ennemis les ennemis deleted grâce à la fonction Delete() dans la fonction Damage()
                deletedEntities.RemoveAt(0); // Pour éviter que cela le fasse deux fois.
            }

            camera.CameraMouvement(Player.CanMove ? Player.Position : Player.AstralPosition);
            base.Update(gameTime);
            if (KeyboardManager.IsDown(Keys.F1))
                camera.Zoom +=  0.01F;
            if (KeyboardManager.IsDown(Keys.F2))
                camera.Zoom -= 0.01F;
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.DrawCam(camera);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            MapFirst.Draw(spriteBatch, true);

            foreach (Monster entity in Entities.OfType<Monster>())
                entity.Draw(gameTime, spriteBatch);
            Player.Draw(gameTime, spriteBatch);

            MapFirst.Draw(spriteBatch, false);
            foreach (Entity entity in Entities)
                entity.DrawUI(gameTime, spriteBatch);

            spriteBatch.End();

            spriteBatch.Begin();
            Player.DrawUI(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void DeleteEntity(Entity entity)
        {
            deletedEntities.Add(entity); // Ajoute à la liste pour qu'à la fin de la frame tout les monstres à l'intèrieur soit Remove
        }
    }
}
