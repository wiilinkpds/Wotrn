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

        public static CursoManagers cursor;

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
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {  
            spriteBatch = new UberSpriteBatch(GraphicsDevice); // Charge notre spriteBatch personnalise
            TexturesManager.Load(Content); // Charge les textures
            cursor = new CursoManagers(TexturesManager.Cursor);
            RandomManager.Init();

            currentScreen = new StartMenu();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardManager.Update();
            MouseManager.Update(cursor);
            currentScreen.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            currentScreen.Draw(gameTime, spriteBatch);
            spriteBatch.Begin();
            cursor.Draw(spriteBatch);
            spriteBatch.End();
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
