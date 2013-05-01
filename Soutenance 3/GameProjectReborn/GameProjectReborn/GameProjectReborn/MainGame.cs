using GameProjectReborn.Managers;
using GameProjectReborn.Resources;
using GameProjectReborn.Screens;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Globalization;
using Microsoft.Xna.Framework.GamerServices;

namespace GameProjectReborn
{
    public class MainGame : Game
    {
        public static int ScreenX = 1280;
        public static int ScreenY = 1080;

        public GraphicsDeviceManager graphics { get; set; }

        private UberSpriteBatch spriteBatch;

        private Screen currentScreen;

        private static MainGame instance;

        public MainGame()
        {
            instance = this;
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = ScreenX,
                PreferredBackBufferHeight = ScreenY
            };
            Components.Add(new GamerServicesComponent(this));
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;

            Res.Culture = new CultureInfo("fr");
        }

        protected override void LoadContent()
        {
            spriteBatch = new UberSpriteBatch(GraphicsDevice); // Charge notre spriteBatch personnalise
            TexturesManager.Load(Content); // Charge les textures
            CursorManager.CurrentTexture = TexturesManager.Cursor;
            RandomManager.Init();
            XactManager.Load();
            currentScreen = new StartMenu();

            XactManager.PlaySong("Menu01");
            XactManager.Engine.GetCategory("Music").SetVolume(0.5f);
            XactManager.Engine.GetCategory("SoundEffect").SetVolume(0.5f);
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardManager.Update();
            MouseManager.Update();
            CursorManager.Update(gameTime);
            currentScreen.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            currentScreen.Draw(gameTime, spriteBatch);
            CursorManager.Draw(spriteBatch);

            base.Draw(gameTime);
        }

        public void SetScreen(Screen screen)
        {
            currentScreen = screen;
        }

        public static MainGame GetInstance() // Retourne la dernière instance mainGame créé, ici toujours la même
        {
            return instance;
        }

        public static void SetGraphics(int screenX, int screenY)
        {
            ScreenX = screenX;
            ScreenY = screenY;
            GetInstance().graphics.PreferredBackBufferWidth = screenX;
            GetInstance().graphics.PreferredBackBufferHeight = screenY;
            GetInstance().graphics.ApplyChanges();
        }

        public static void MainExit()
        {
            XactManager.Engine.GetCategory("Music").Stop(AudioStopOptions.Immediate);
            XactManager.Engine.GetCategory("SoundEffect").Stop(AudioStopOptions.Immediate);
            XactManager.Engine.Dispose();
            GetInstance().Exit();
        }
    }
}
