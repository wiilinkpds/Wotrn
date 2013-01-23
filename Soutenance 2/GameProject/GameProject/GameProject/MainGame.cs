using System;
using GameProject._UtilsFun;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameProject.Menus;
using GameProject.Managers;
using GameProject.Decors;
using GameProject.Joueurs;
using GameProject.Enemis;
using GameProject.Camera;

namespace GameProject
{
    public class MainGame : Game
    {
        /* Les fleches servent a ce déplacer
         * La touche espace sert a sprinter
         * */

        private static Cam camera;

        public const int ScreenX = 1680; //Il faudra changer la resolution un jour
        public const int ScreenY = 1050;

        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        static private LoadM texturesMenu;

        // Teddy
        private bool menuLaunch = true;

        private Joueur joueur;

        private Ennemis[] enemis;

        private Sprite gameOver;
        private SpriteFont gameOverString;

        static public readonly Random Rand = new Random();

        private Decor decor;

        private float timerLife = 3, timerFatigue = 0.1f, timerMana = 0.5f; //A changer

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
            joueur.Initialize(new Vector2(ScreenX / 2, ScreenY / 2), new Rectangle(0, 0, 50, 69), 100, 100,100, 2f, "Hero");

            gameOver = new Sprite();
            gameOver.Initialize(Vector2.Zero);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Load Decors
            decor = new Decor();
            decor.LoadDecors(Content, 2);
            //Load Game Over
            gameOverString = Content.Load<SpriteFont>("Sprites/GameOver/GameOverString");
            gameOver.LoadContent(Content, "Sprites/GameOver/Game Over");

            //Sound : 
            //Song song = Content.Load<Song>("Kalimba");
            //MediaPlayer.Play(song);

            //Load Joueurs et Ennemis
            joueur.LoadContent(Content, "Sprites/Perso/Joueur/mario", 4, 4, "h", "Sprites/Perso/VieMana/barre");
            enemis = new Ennemis[1];
            for (int i = 0; i < enemis.Length; i++)
            {
                enemis[i] = new Ennemis();
                enemis[i].LoadContent(Content, "Sprites/Perso/Enemis/enemis", 1, 4, "h", "Sprites/Perso/VieMana/barre");
            }
            for (int i = 0; i < enemis.Length; i++) //On initialise ici car l'on a besoin de la taille du fond et des ennemis donc il faut qu'il soit load
                enemis[i].Initialize(new Vector2(Rand.Next(0, Decor.back.Rectangle.Right - enemis[i].Width), Rand.Next(0, Decor.back.Rectangle.Bottom - enemis[i].Height)),new Rectangle(0,0,69,110),100,0,0,2f,"Rack");

            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load le menu
            texturesMenu = new LoadM();
            texturesMenu.LoadMenu(Content);

            //Load la camera
            camera = new Cam(Decor.BackRectangle.Width, Decor.BackRectangle.Height, GraphicsDevice);
        }

        protected override void Update(GameTime game_time)
        {
            if (Utils.Down(Keys.Enter) && (MainM.ChoiceMainMenu(menuLaunch) == 5 || IngameM.IngameMenuPos[IngameM.ChoiceIngameMenu()] == "Quitter vers le Bureau") || (joueur.Life <=0 && Utils.Down(Keys.Enter)))
             Exit(); //On quitte si on est sur quitter dans l'un des menus ou si on est sur gameover et qu'on fait entrer

            if (menuLaunch && MainM.ChoiceMainMenu(menuLaunch) == 0 && Utils.Down(Keys.Enter))
            {
                menuLaunch = false; // Stop le MainMenu
                Initialize(); // Initialise le Jeu
            }
            else if (Utils.Down(Keys.Enter) && IngameM.IngameMenuPos[IngameM.ChoiceIngameMenu()] == "Quitter vers le Menu Principal")
            {
                menuLaunch = true; // Lance le MainMenu
                IngameM.InitIngameMenu(); // Initialise le IngameMenu
                MainM.InitMainMenu(); // Initialise le MainMenu
            }
            
            if (menuLaunch == false) //Verifie que le menu soit fermer
            {
                joueur.Update(Decor.DecorCol, Decor.back, enemis, game_time); //Update le joueur
                IA.MovIA(joueur, enemis, Decor.DecorCol,game_time); //Update l'enemis
                camera.CameraMouvement(joueur); //Update la camera
            }

            timerLife -= (float)game_time.ElapsedGameTime.TotalSeconds;
            timerFatigue -= (float)game_time.ElapsedGameTime.TotalSeconds;
            timerMana -= (float)game_time.ElapsedGameTime.TotalSeconds;
            if (timerLife < 0)
            {
                if (joueur.Life < 100)
                    joueur.Life++;
                timerLife = 1;
            }
            if (timerFatigue < 0)
            {
                if (joueur.Fatigue < 100)
                    joueur.Fatigue++;
                timerFatigue = 0.1f;
            }
            if (timerMana < 0)
            {
                    if (joueur.Mana < 100)
                        joueur.Mana++;
                    timerMana = 0.5f;
            }


            base.Update(game_time);
        }

        protected override void Draw(GameTime game_time)
        {
            GraphicsDevice.Clear(Color.Black); //Fond noir pour le debut
            spriteBatch.Begin(); //Debut du draw
            if (menuLaunch) //Si le menu est lancer
            {
                GraphicM.MainGraph(ScreenX, ScreenY, spriteBatch); // Dessine les elements deco du MainMenu
                MainM.MainDraw(ScreenX, ScreenY, spriteBatch); // Dessine les elements interactifs du MainMenu
            }
            else
            {
                GraphicsDevice.Clear(Color.Blue); //Fond bleu (on ne le voit pas donc pas forcement utile)
                if (IngameM.IngameLaunched())
                {
                    IngameM.IngameDraw(spriteBatch); // Dessine le MenuIngame
                }
                else
                {
                    spriteBatch.End(); //On arrete le draw en cours car l'on va maintenant utiliser la camera
                    spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera.GetTransformation()); //On recommence le draw mais avec la camera
                    decor.DrawDecors(spriteBatch); //Draw le decors
                    for (int i = 0; i < enemis.Length; i++) //Dessine les ennemis
                        enemis[i].Draw(spriteBatch);
                    joueur.Draw(spriteBatch,camera); // Dessine le Joueur
                    if (joueur.Life <= 0) //Dessine game over si on est plus de vie
                    {
                        spriteBatch.Draw(gameOver.Texture, new Rectangle((int)camera.Position.X - ScreenX / 2,(int) camera.Position.Y - ScreenY / 2, ScreenX, ScreenY), Color.White);
                        spriteBatch.DrawString(gameOverString, "Appuyer sur Entree pour quitter", new Vector2(camera.Position.X - gameOverString.MeasureString("Appuyer sur Entree pour quitter").X / 2 , camera.Position.Y - 60), Color.Green);
                    }
                }
            }

            spriteBatch.End();  //Fin
            base.Draw(game_time);
        }
    }
}
