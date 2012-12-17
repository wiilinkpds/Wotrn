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
using GameProject.Managers;
using GameProject.UtilsFun;

namespace GameProject
{
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        static public GraphicsDeviceManager graphics;
        static public SpriteBatch SpriteBatch;

        static public TexturesManager TexturesMenu { get; private set; }

        public const int ScreenX = 1024;
        public const int ScreenY = 768;

        private Sprite balle;
        private Sprite[] Decor;
        private bool MenuLaunch;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this) { PreferredBackBufferWidth = ScreenX, PreferredBackBufferHeight = ScreenY };
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Decor = new Sprite[10];
            balle = new Sprite();
            balle.Initialize(Vector2.Zero);
            Random rand = new Random();
            for (int i = 0; i < Decor.Length; i++)
            {
                Decor[i] = new Sprite();
                Decor[i].Initialize(new Vector2(rand.Next(0, ScreenX), rand.Next(0, ScreenY)));
            }
            MenuLaunch = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            balle.LoadContent(Content, "Sprites/Balle");
            for (int i = 0; i < Decor.Length;i++)
                Decor[i].LoadContent(Content, "Sprites/Arbrebeta");
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            TexturesMenu = new TexturesManager();
            TexturesMenu.LoadMenu(Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (MenuLaunch && !MainMenu.choiceMade(MenuLaunch) && MainMenu.choiceMenu() == 5)
              Exit();
            if (MenuLaunch && !MainMenu.choiceMade(MenuLaunch))
                MenuLaunch = false;
            balle.Update(Decor);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin();
            if (MenuLaunch)
                MainMenu.mainMenu();
            else
            {
                GraphicsDevice.Clear(Color.Blue);
                balle.Draw(SpriteBatch, gameTime);
                for (int i = 0; i < Decor.Length; i++)
                {
                    Decor[i].Draw(SpriteBatch, gameTime);
                }
            }
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
