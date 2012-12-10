using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameProject.Menus;
using GameProject.UtilsFun;

namespace GameProject
{
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        public const int ScreenX = 1024;
        public const int ScreenY = 768;

        private GraphicsDeviceManager graphics;
        private SpriteBatch SpriteBatch;

        static private LoadM TexturesMenu;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this) { PreferredBackBufferWidth = ScreenX, PreferredBackBufferHeight = ScreenY };
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            TexturesMenu = new LoadM();
            TexturesMenu.LoadMenu(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Utils.Down(Keys.Enter) && MainM.choiceMenu() == 5)
              Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin();

            MainM.mainMenu(ScreenX, ScreenY, SpriteBatch);

            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
