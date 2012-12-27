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
using GameProject.Joueurs;

namespace GameProject
{
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        public const int ScreenX = 1280;
        public const int ScreenY = 1024;

        static public int life = 500;

        private GraphicsDeviceManager graphics;
        private SpriteBatch SpriteBatch;
        private SpriteAnimation loading;

        static private LoadM TexturesMenu;
        static private bool noHold = true;

        // Teddy
        private bool MenuLaunch = true;

        private Sprite joueur;

        private Sprite[] Enemis;

        private Sprite[] SLife;

        // Teddy

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this) { PreferredBackBufferWidth = ScreenX, PreferredBackBufferHeight = ScreenY };
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Random rand = new Random();
            // Teddy
            joueur = new Sprite();
            joueur.Initialize(new Vector2(ScreenX / 2 , ScreenY / 2));
            Enemis = new Sprite[10];
            for (int i = 0; i < Enemis.Length;i++)
            {
                Enemis[i] = new Sprite();
                Enemis[i].Initialize(new Vector2(rand.Next(- 5 *ScreenX , 5 * ScreenX),rand.Next(-5 * ScreenY, 5 * ScreenY)));
            }
            SLife = new Sprite[life];
            for (int i = 0; i < SLife.Length; i++)
            {
                SLife[i] = new Sprite();
                SLife[i].Initialize(new Vector2(i * 2.5F,0));
            }
            // Teddy
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Teddy
            joueur.LoadContent(Content, "Sprites/Joueur");
            for (int i = 0; i < Enemis.Length; i++)
                Enemis[i].LoadContent(Content, "Sprites/Arbrebeta");
            // Teddy
            for (int i = 0; i < SLife.Length; i++)
                SLife[i].LoadContent(Content, "Sprites/Life");

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            TexturesMenu = new LoadM();
            TexturesMenu.LoadMenu(Content);

            Decor.LoadDecors(Content,1);

            // Animation

            loading = new SpriteAnimation(Content.Load<Texture2D>("figure_6_13"), 8);
            loading.Position = new Vector2(100, 100);
            loading.FramesPerSecond = 10;

            // Animation
        }

        protected override void Update(GameTime gameTime)
        {
            if ((Utils.Down(Keys.Enter) && (MainM.ChoiceMenu() == 5 || IngameM.ingameMenuPos[IngameM.ChoiceIngameMenu()] == "Quitter vers le Bureau")) || life == 0)
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
            joueur.Update(Decor.DecorCol(), Decor.back(), Enemis);
            IA.MovIA(joueur,Enemis,Decor.DecorCol());
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
                    Decor.DrawDecors(SpriteBatch);
                    joueur.Draw(SpriteBatch); // Dessine le Joueur
                    loading.Draw(SpriteBatch);
                    for (int i = 0; i < life; i++)
                        SLife[i].Draw(SpriteBatch);
                }
            }

            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
