using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;

namespace GameProjectReborn
{
    public class MainGame : Game
    {
        public const int ScreenX = 1280;
        public const int ScreenY = 1080;

        public static float SongVolume;

        public static GraphicsDeviceManager graphics;
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
            Content.RootDirectory = "Content";
            Components.Add(new GamerServicesComponent(this));
            //graphics.IsFullScreen = true;
            IsMouseVisible = false;
        }

        protected override void LoadContent()
        {
            spriteBatch = new UberSpriteBatch(GraphicsDevice); // Charge notre spriteBatch personnalise
            TexturesManager.Load(Content); // Charge les textures
            CursorManager.CurrentTexture = TexturesManager.Cursor;
            RandomManager.Init();
            XactManager.Load();
            currentScreen = new StartMenu();

            SongVolume = 0.5f;
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardManager.Update();
            MouseManager.Update();
            CursorManager.Update(gameTime);
            currentScreen.Update(gameTime);
            if (!(currentScreen is GameScreen))
                CursorManager.Update(gameTime);
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

        public static MainGame GetInstance() // Retourne la derni�re instance mainGame cr��, ici toujours la m�me
        {
            return instance;
        }
    }
}