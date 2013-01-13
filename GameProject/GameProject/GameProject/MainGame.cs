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
using GameProject.Camera;

namespace GameProject
{
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        /* Les fleches servent a ce déplacer
         * La touche espace sert a sprinter
         * */

        static public Camera.Camera _camera;

        static public int ScreenX = 1280; //Il faudra changer la resolution un jour
        static public int ScreenY = 1000;

        public const float VitesseJoueurInit = 2f;

        static public int life = 100;

        private GraphicsDeviceManager graphics;
        private SpriteBatch SpriteBatch;
        private SpriteAnimation loading;

        static private LoadM TexturesMenu;
        static private bool noHold = true;

        // Teddy
        private bool MenuLaunch = true;

        private Sprite joueur;

        private Sprite[] Enemis;

        static public Sprite[] SLife;

        private Sprite GameOver;
        private SpriteFont GameOverString;

        private Random rand = new Random();

        // Teddy

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this) { PreferredBackBufferWidth = ScreenX, PreferredBackBufferHeight = ScreenY };
            //graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            //ScreenX = graphics.PreferredBackBufferWidth;
            //ScreenY = graphics.PreferredBackBufferHeight;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Teddy
            joueur = new Sprite();
            joueur.Initialize(new Vector2(ScreenX / 2 , ScreenY / 2),new Rectangle(0,0,50,69));
            SLife = new Sprite[life];
            for (int i = 0; i < SLife.Length; i++)
            {
                SLife[i] = new Sprite();
                SLife[i].Initialize(new Vector2(i * 2.5F,0));
            }
            // Teddy
            GameOver = new Sprite();
            GameOver.Initialize(Vector2.Zero);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Decor.LoadDecors(Content, 2);

            GameOverString = Content.Load<SpriteFont>("Sprites/GameOver/GameOverString");
            GameOver.LoadContent(Content, "Sprites/GameOver/Game Over");
            //Sound : 
            //Song song = Content.Load<Song>("Kalimba");
            //MediaPlayer.Play(song);

            // Teddy
            joueur.LoadContent(Content, "Sprites/Perso/mario",4,4,"h");
            Enemis = new Sprite[1];
            for (int i = 0; i < Enemis.Length; i++)
            {
                Enemis[i] = new Sprite();
                Enemis[i].LoadContent(Content, "Sprites/Arbrebeta");
            }
            for (int i = 0; i < Enemis.Length; i++) //On initialise ici car l'on a besoin de la taille du fond et des enemis donc il faut qu'il soit load
                Enemis[i].Initialize(new Vector2(rand.Next(0, Decor.back.rectangle.Right - Enemis[i].Width), rand.Next(0, Decor.back.rectangle.Bottom - Enemis[i].Height)));
            // Teddy
            for (int i = 0; i < SLife.Length; i++)
                SLife[i].LoadContent(Content, "Sprites/Life");

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            TexturesMenu = new LoadM();
            TexturesMenu.LoadMenu(Content);
            
            _camera = new Camera.Camera(Decor.backRectangle.Width, Decor.backRectangle.Height, GraphicsDevice);

            // Animation

            loading = new SpriteAnimation(Content.Load<Texture2D>("figure_6_13"), 8);
            loading.Position = new Vector2(100, 100);
            loading.FramesPerSecond = 10;

            // Animation
        }

        protected override void Update(GameTime gameTime)
        {
            if ((Utils.Down(Keys.Enter) && (MainM.ChoiceMenu() == 5 || IngameM.ingameMenuPos[IngameM.ChoiceIngameMenu()] == "Quitter vers le Bureau")) || (life <=0 && Utils.Down(Keys.Enter)))
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
            if (MenuLaunch == false)
            {
                joueur.Update(Decor.DecorCol, Decor.back, Enemis, gameTime);
                IA.MovIA(joueur, Enemis, Decor.DecorCol);
                _camera.CameraMouvement(joueur);
            }
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
                    SpriteBatch.End();
                    SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _camera.GetTransformation());
                    Decor.DrawDecors(SpriteBatch);
                    for (int i = 0; i < Enemis.Length; i++)
                        Enemis[i].Draw(SpriteBatch);
                    joueur.Draw(SpriteBatch); // Dessine le Joueur
                    loading.Draw(SpriteBatch);
                    for (int i = 0; i < life; i++)
                        SLife[i].Draw(SpriteBatch);
                    if (life <= 0)
                    {
                        
                        SpriteBatch.Draw(GameOver.Texture, new Rectangle((int)_camera.Position.X - ScreenX / 2,(int) _camera.Position.Y - ScreenY / 2, ScreenX, ScreenY), Color.White);
                        SpriteBatch.DrawString(GameOverString, "Appuyer sur Entree pour quitter", new Vector2(_camera.Position.X - ScreenX / 4, _camera.Position.Y - 60), Color.Green);
                    }
                }
            }

            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
