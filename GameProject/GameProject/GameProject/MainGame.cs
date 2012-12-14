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
using GameProject.Managers;

namespace GameProject
{
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        public const int ScreenX = 1024;
        public const int ScreenY = 768;

        private GraphicsDeviceManager graphics;
        private SpriteBatch SpriteBatch;

        static private LoadM TexturesMenu;

        // Teddy
        private bool MenuLaunch = true;

        private static Sprite[] Decor = new Sprite[1];
        private Vector2[] posDec = new Vector2[1];
        private Vector2 posJoueur = new Vector2(ScreenX / 2, ScreenY / 2 + 50);
        
        private Sprite joueur;
        private Sprite Decor_0;
        // Teddy

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this) { PreferredBackBufferWidth = ScreenX, PreferredBackBufferHeight = ScreenY };
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Teddy
            posDec = new Vector2[1];
            posDec[0] = new Vector2 (500,300);

            Decor = new Sprite[1];

            joueur = new Sprite();
            joueur.Initialize(posJoueur);

            Decor[0] = new Sprite();
            Decor_0 = Decor[0];
            Decor_0.Initialize(posDec[0]);

            // Teddy
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Teddy
            joueur.LoadContent(Content, "Sprites/Joueur");
            Decor_0.LoadContent(Content, "Sprites/Arbrebeta");
            // Teddy

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            TexturesMenu = new LoadM();
            TexturesMenu.LoadMenu(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Utils.Down(Keys.Enter) && (MainM.ChoiceMenu() == 5 || IngameM.ChoiceIngameMenu() == 2))
             Exit();

            if (MenuLaunch && !MainM.ChoiceMade(MenuLaunch))
                MenuLaunch = false;
            if (Utils.Down(Keys.Enter) && IngameM.ChoiceIngameMenu() == 1)
                MenuLaunch = true;

            // Teddy
            joueur.Update(Decor, posDec);
            // Teddy

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin();

            // Teddy
            if (MenuLaunch)
            {
                /* Moi */
                GraphicM.graphMenu(ScreenX, ScreenY, SpriteBatch);
                MainM.MainMenu(ScreenX, ScreenY, SpriteBatch);
            }
            else
            {
                GraphicsDevice.Clear(Color.Blue);
                if (IngameM.ingameLaunched())
                {
                    IngameM.IngameMenu(ScreenX, ScreenY, SpriteBatch);
                }
                else
                {
                    joueur.Draw(SpriteBatch, gameTime);
                    Decor_0.Draw(SpriteBatch, gameTime);
                }
            }
            // Teddy
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
