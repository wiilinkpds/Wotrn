using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn
{
    public class MainGame : Game
    {
        public const int ScreenX = 1680;
        public const int ScreenY = 1050;

        public static float SongVolume;

        private GraphicsDeviceManager graphics;
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
            //graphics.IsFullScreen = true;
            IsMouseVisible = true;
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
    }
}
