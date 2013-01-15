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
using GameProject.Enemis;

namespace GameProject
{
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        /* Les fleches servent a ce déplacer
         * La touche espace sert a sprinter
         * */

        static public Camera.Camera _camera;

        static public int ScreenX = 1280; //Il faudra changer la resolution un jour
        static public int ScreenY = 1024;

        private GraphicsDeviceManager graphics;
        private SpriteBatch SpriteBatch;

        static private LoadM TexturesMenu;

        // Teddy
        private bool MenuLaunch = true;

        private Joueur joueur;

        private Ennemis[] Enemis;

        private Sprite GameOver;
        private SpriteFont GameOverString;

        static public Random rand = new Random();

        private Decor Decor;

        private float TimerLife = 3, TimerFatigue = 0.1f, TimerMana = 0.5f; //A changer

        // Teddy

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this) { PreferredBackBufferWidth = ScreenX, PreferredBackBufferHeight = ScreenY };
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            joueur = new Joueur();
            joueur.Initialize(new Vector2(ScreenX / 2, ScreenY / 2), new Rectangle(0, 0, 50, 69), 100, 200,100, 2f, "Hero");

            GameOver = new Sprite();
            GameOver.Initialize(Vector2.Zero);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Load Decors
            Decor = new Decor();
            Decor.LoadDecors(Content, 3);
            //Load Game Over
            GameOverString = Content.Load<SpriteFont>("Sprites/GameOver/GameOverString");
            GameOver.LoadContent(Content, "Sprites/GameOver/Game Over");

            //Sound : 
            //Song song = Content.Load<Song>("Kalimba");
            //MediaPlayer.Play(song);

            //Load Joueurs et Ennemis
            joueur.LoadContent(Content, "Sprites/Perso/Joueur/mario", 4, 4, "h", "Sprites/Perso/VieMana/barre");
            Enemis = new Ennemis[5];
            for (int i = 0; i < Enemis.Length; i++)
            {
                Enemis[i] = new Ennemis();
                Enemis[i].LoadContent(Content, "Sprites/Perso/Enemis/enemis", 1, 4, "h", "Sprites/Perso/VieMana/barre");
            }
            for (int i = 0; i < Enemis.Length; i++) //On initialise ici car l'on a besoin de la taille du fond et des ennemis donc il faut qu'il soit load
                Enemis[i].Initialize(new Vector2(rand.Next(0, Decor.back.rectangle.Right - Enemis[i].Width), rand.Next(0, Decor.back.rectangle.Bottom - Enemis[i].Height)),new Rectangle(0,0,69,110),100,0,0,2f,"Rack");

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            //Load le menu
            TexturesMenu = new LoadM();
            TexturesMenu.LoadMenu(Content);

            //Load la camera
            _camera = new Camera.Camera(Decor.backRectangle.Width, Decor.backRectangle.Height, GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Utils.Down(Keys.Enter) && (MainM.ChoiceMainMenu(MenuLaunch) == 5 || IngameM.ingameMenuPos[IngameM.ChoiceIngameMenu()] == "Quitter vers le Bureau") || (joueur.Life <=0 && Utils.Down(Keys.Enter)))
             Exit(); //On quitte si on est sur quitter dans l'un des menus ou si on est sur gameover et qu'on fait entrer

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
            
            if (MenuLaunch == false) //Verifie que le menu soit fermer
            {
                joueur.Update(Decor.DecorCol, Decor.back, Enemis, gameTime); //Update le joueur
                IA.MovIA(joueur, Enemis, Decor.DecorCol,gameTime); //Update l'enemis
                _camera.CameraMouvement(joueur); //Update la camera
            }

            TimerLife -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            TimerFatigue -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            TimerMana -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (TimerLife < 0)
            {
                if (joueur.Life < 100)
                    joueur.Life++;
                TimerLife = 1;
            }
            if (TimerFatigue < 0)
            {
                if (joueur.Fatigue < 100)
                    joueur.Fatigue++;
                TimerFatigue = 0.1f;
            }
            if (TimerMana < 0)
            {
                    if (joueur.Mana < 200)
                        joueur.Mana++;
                    TimerMana = 0.5f;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black); //Fond noir pour le debut
            SpriteBatch.Begin(); //Debut du draw
            if (MenuLaunch) //Si le menu est lancer
            {
                GraphicM.MainGraph(ScreenX, ScreenY, SpriteBatch); // Dessine les elements deco du MainMenu
                MainM.MainDraw(ScreenX, ScreenY, SpriteBatch); // Dessine les elements interactifs du MainMenu
            }
            else
            {
                GraphicsDevice.Clear(Color.Blue); //Fond bleu (on ne le voit pas donc pas forcement utile)
                if (IngameM.IngameLaunched())
                {
                    IngameM.IngameDraw(ScreenX, ScreenY, SpriteBatch); // Dessine le MenuIngame
                }
                else
                {
                    SpriteBatch.End(); //On arrete le draw en cours car l'on va maintenant utiliser la camera
                    SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _camera.GetTransformation()); //On recommence le draw mais avec la camera
                    Decor.DrawDecors(SpriteBatch); //Draw le decors
                    for (int i = 0; i < Enemis.Length; i++) //Dessine les enemis
                        Enemis[i].Draw(SpriteBatch);
                    joueur.Draw(SpriteBatch,_camera); // Dessine le Joueur
                    if (joueur.Life <= 0) //Dessine game over si on est plus de vie
                    {
                        SpriteBatch.Draw(GameOver.Texture, new Rectangle((int)_camera.Position.X - ScreenX / 2,(int) _camera.Position.Y - ScreenY / 2, ScreenX, ScreenY), Color.White);
                        SpriteBatch.DrawString(GameOverString, "Appuyer sur Entree pour quitter", new Vector2(_camera.Position.X - GameOverString.MeasureString("Appuyer sur Entree pour quitter").X / 2 , _camera.Position.Y - 60), Color.Green);
                    }
                }
            }

            SpriteBatch.End();  //Fin
            base.Draw(gameTime);
        }
    }
}
