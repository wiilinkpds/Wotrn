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
using GameProject.BackGrounds;

namespace GameProject
{
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        public const int ScreenX = 1024;
        public const int ScreenY = 768;

        private GraphicsDeviceManager graphics;
        private SpriteBatch SpriteBatch;
        private SpriteAnimation loading;

        static private LoadM TexturesMenu;
        static private LoadBack TexturesBack;
        static private bool noHold = true;

        // Teddy
        private bool MenuLaunch = true;

        private static Sprite[] Decor = new Sprite[1];
        private Vector2 posJoueur = new Vector2(ScreenX / 2, ScreenY / 2 + 50);
        private Sprite joueur;

        // Teddy

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this) { PreferredBackBufferWidth = ScreenX, PreferredBackBufferHeight = ScreenY };
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Teddy
            joueur = new Sprite();
            joueur.Initialize(posJoueur);

            Decor = new Sprite[1000];

            Random rand = new Random();
            for (int i = 0; i < Decor.Length; i++)
            {
                Decor[i] = new Sprite();
                Decor[i].Initialize(new Vector2(rand.Next(-5 * ScreenX, 5 * ScreenX), rand.Next(-5 * ScreenY, 5 * ScreenY)));
            }

            // Teddy
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Teddy
            joueur.LoadContent(Content, "Sprites/Joueur");

            for (int i = 0; i < Decor.Length; i++)
                Decor[i].LoadContent(Content, "Sprites/Arbrebeta");
            // Teddy

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            TexturesMenu = new LoadM();
            TexturesMenu.LoadMenu(Content);

            TexturesBack = new LoadBack();
            TexturesBack.LoadBackground(Content);

            // Animation

            loading = new SpriteAnimation(Content.Load<Texture2D>("figure_6_13"), 8);
            loading.Position = new Vector2(100, 100);
            loading.FramesPerSecond = 10;

            // Animation
        }

        protected override void Update(GameTime gameTime)
        {
            if (Utils.Down(Keys.Enter) && (MainM.ChoiceMenu() == 5 || IngameM.ingameMenuPos[IngameM.ChoiceIngameMenu()] == "Quitter vers le Bureau"))
             Exit();

            // Conditions du Menu (a changer)
            if (MenuLaunch && MainM.ChoiceMenu() == 0 && Utils.Down(Keys.Enter) && noHold)
            {
                MenuLaunch = false;
                noHold = false;
            }

            if (Utils.Down(Keys.Enter) && IngameM.ingameMenuPos[IngameM.ChoiceIngameMenu()] == "Quitter vers le Menu Principal")
            {
                IngameM.InitIngameMenu();
                MenuLaunch = true;
            }
            if (Utils.Up(Keys.Enter))
                noHold = true;
            
            // Teddy
            joueur.Update(Decor);
            // Teddy

            loading.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin();

            if (MenuLaunch) // Dessine le MainMenu
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
                    IngameM.IngameMenu(ScreenX, ScreenY, SpriteBatch); // Dessine le MenuIngame
                }
                else
                {
                    Background.Back(SpriteBatch);
                    for (int i = 0; i < Decor.Length; i++) // Dessine le tableau de Decor choisi
                    {
                        Decor[i].Draw(SpriteBatch, gameTime);
                    }
                    joueur.Draw(SpriteBatch, gameTime); // Dessine le Joueur
                    loading.Draw(SpriteBatch);
                }
            }

            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
