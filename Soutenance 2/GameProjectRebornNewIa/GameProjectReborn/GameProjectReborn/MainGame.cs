using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn
{
    public class MainGame : Game
    {
        public static int ScreenX = 1024;
        public const int ScreenY = 768;

        private GraphicsDeviceManager graphics;
        private UberSpriteBatch spriteBatch;

        private Screen currentScreen;

        private static MainGame instance;

        public MainGame()
        {
            instance = this;
            graphics = new GraphicsDeviceManager(this) { PreferredBackBufferWidth = ScreenX, PreferredBackBufferHeight = ScreenY };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new UberSpriteBatch(GraphicsDevice); // Charge notre spriteBatch personnalise
            TexturesManager.Load(Content); // Charge les textures
            RandomManager.Init();

            currentScreen = new StartMenu();
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
