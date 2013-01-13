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
        public const int ScreenX = 1024;
        public const int ScreenY = 768;

        private GraphicsDeviceManager graphics;
        private SpriteBatch SpriteBatch;

        static private LoadM TexturesMenu;

        static public int life; 
        static public int mana;

        // Teddy
        static public bool MenuLaunch = true;

        private Sprite Joueur;

        private Sprite[] Ennemis;
        private Sprite[] SLife;
        private Sprite[] SMana;

        private Decor Decor1;
        private Decor Decor2;
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
            life = 100;
            mana = 200;

            SLife = new Sprite[life];
            SMana = new Sprite[mana];

            Joueur = new Sprite();
            Joueur.Initialize(new Vector2(ScreenX / 2, ScreenY / 2));

            Decor1 = new Decor();
            Decor1.LoadDecors(Content, 1, Vector2.Zero);

            Decor2 = new Decor();
            Decor2.LoadDecors(Content, 2, new Vector2(500, 500));

            Ennemis = new Sprite[10];

            for (int i = 0; i < Ennemis.Length; i++)
            {
                Ennemis[i] = new Sprite();
                Ennemis[i].Initialize(new Vector2(rand.Next(-5 * ScreenX, 5 * ScreenX), rand.Next(-5 * ScreenY, 5 * ScreenY)));
            }
            for (int i = 0; i < SLife.Length; i++)
            {
                SLife[i] = new Sprite();
                SLife[i].Initialize(new Vector2(i * 2.5F, 0));
            } 
            for (int i = 0; i < SMana.Length; i++)
            {
                SMana[i] = new Sprite();
                SMana[i].Initialize(new Vector2(i * 2.5F, 20));
            }
            // Teddy
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Teddy
            Joueur.LoadContent(Content, "Sprites/Joueur");
            for (int i = 0; i < Ennemis.Length; i++)
                Ennemis[i].LoadContent(Content, "Sprites/Ennemis/ArbreEnnemi");
            // Teddy
            for (int i = 0; i < SLife.Length; i++)
                SLife[i].LoadContent(Content, "Sprites/Life");
            for (int i = 0; i < SMana.Length; i++)
                SMana[i].LoadContent(Content, "Sprites/Mana");

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            TexturesMenu = new LoadM();
            TexturesMenu.LoadMenu(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Utils.Down(Keys.Enter) && (MainM.ChoiceMainMenu(MenuLaunch) == 5 || IngameM.ingameMenuPos[IngameM.ChoiceIngameMenu()] == "Quitter vers le Bureau"))
             Exit();

            if (MenuLaunch && MainM.ChoiceMainMenu(MenuLaunch) == 0 && Utils.Down(Keys.Enter))
            {
                MenuLaunch = false; // Stop le MainMenu
                Initialize(); // Initialise le Jeu
            }
            else if (Utils.Down(Keys.Enter) && IngameM.ingameMenuPos[IngameM.ChoiceIngameMenu()] == "Quitter vers le Menu Principal") 
            {
                MenuLaunch = true; // Lance le MainMenu
                IngameM.InitIngameMenu(); // Initialise le IngameMenu
                MainM.InitMainMenu(); // Initialise le MainMenu
            }

            Joueur.Update(Decor.DecorCol(), Decor.back(), Ennemis);
            IA.MoveIA(Joueur, Ennemis, Decor.DecorCol());

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin();

            if (MenuLaunch)
            {
                GraphicM.MainGraph(ScreenX, ScreenY, SpriteBatch); // Dessine les elements deco du MainMenu
                MainM.MainDraw(ScreenX, ScreenY, SpriteBatch); // Dessine les elements interactifs du MainMenu
            }
            else
            {
                GraphicsDevice.Clear(Color.Blue);
                if (IngameM.IngameLaunched())
                {
                    IngameM.IngameDraw(ScreenX, ScreenY, SpriteBatch); // Dessine le MenuIngame
                }
                else
                {
                    Decor1.DrawDecors(SpriteBatch); // Dessine le Decor1
                    Decor2.DrawDecors(SpriteBatch); // Dessine le Decor2
                    Joueur.Draw(SpriteBatch); // Dessine le Joueur

                    for (int i = 0; i < Ennemis.Length; i++)
                        Ennemis[i].Draw(SpriteBatch);
                    for (int i = 0; i < life; i++) // Dessine la Vie
                        SLife[i].Draw(SpriteBatch);
                    for (int i = 0; i < mana; i++) // Dessine le Mana
                        SMana[i].Draw(SpriteBatch);

                }
            }

            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
