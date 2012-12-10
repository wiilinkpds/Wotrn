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
        private Sprite Decor_0;
        private Vector2[] posDec;
        private Vector2 posBal;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this) { PreferredBackBufferWidth = ScreenX, PreferredBackBufferHeight = ScreenY };
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            posDec = new Vector2[1];
            posDec[0] = Vector2.Zero;
            posBal = new Vector2(ScreenX/2,ScreenY/2);
            Decor = new Sprite[1];
            balle = new Sprite();
            balle.Initialize(posBal);
            Decor[0] = new Sprite();
            Decor_0 = Decor[0];
            Decor_0.Initialize(posDec[0]);
            MenuLaunch = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            balle.LoadContent(Content, "Sprites/Balle");
            Decor_0.LoadContent(Content,"Sprites/Arbrebeta");
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
            balle.Update(Decor, posDec);

            
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
                Decor_0.Draw(SpriteBatch, gameTime);
            }
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
