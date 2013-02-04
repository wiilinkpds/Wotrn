using GameProjectReborn.Managers;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens
{
    public class StartMenu : Screen
    {
        private Button startButton;
        private Button exitButton;

        public StartMenu()
        {
            startButton = new Button(new Vector2(100, MainGame.ScreenY / 4), "Demarrer une nouvelle partie");
            exitButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 50), "Quitter le jeu");

            startButton.MouseClick += OnStartButtonMouseClick;
            exitButton.MouseClick += OnExitButtonMouseClick;
        }

        public override void Update(GameTime gameTime)
        {
            startButton.Update(gameTime);
            exitButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.DrawUI(TexturesManager.BackgroundMenu, Vector2.Zero);
            spriteBatch.DrawUI(TexturesManager.Title, "Wrath of the Rack Ninja", new Vector2(MainGame.ScreenX / 2, MainGame.ScreenY / 2 - 50), Color.Red);

            startButton.Draw(gameTime, spriteBatch);
            exitButton.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        private void OnStartButtonMouseClick(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {
            MainGame.GetInstance().SetScreen(new GameScreen());
        }

        private void OnExitButtonMouseClick(object sender, MouseClickEventArgs e)
        {
            MainGame.GetInstance().Exit();
        }
    }
}