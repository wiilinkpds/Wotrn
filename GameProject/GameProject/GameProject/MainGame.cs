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
using GameProject.Decors;

namespace GameProject
{
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        public const int ScreenX = 1280;
        public const int ScreenY = 1024;

        private GraphicsDeviceManager graphics;
        private SpriteBatch SpriteBatch;
        private SpriteAnimation loading;

        static private LoadM TexturesMenu;
        static private bool noHold = true;

        // Teddy
        private bool MenuLaunch = true;

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

            Random rand = new Random();


            // Teddy
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Teddy
            joueur.LoadContent(Content, "Sprites/Joueur");

            // Teddy

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            TexturesMenu = new LoadM();
            TexturesMenu.LoadMenu(Content);

            Decor.LoadDecors(Content,2);

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
            joueur.Update(Decor.DecorCol(), Decor.back());
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
                    Decor.DrawDecors(SpriteBatch, gameTime);
                    joueur.Draw(SpriteBatch, gameTime); // Dessine le Joueur
                    loading.Draw(SpriteBatch);
                }
            }

            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
