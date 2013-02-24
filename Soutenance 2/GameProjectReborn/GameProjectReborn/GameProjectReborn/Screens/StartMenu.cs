using GameProjectReborn.Managers;
using GameProjectReborn.Screens.Option;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens
{
    public class StartMenu : Screen
    {
        private Button startButton;
        private Button optionButton;
        private Button storyButton;
        private Button exitButton;

        public StartMenu()
        {
            startButton = new Button(new Vector2(100, MainGame.ScreenY/4), "Demarrer une nouvelle partie");
            optionButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 50), "Options");
            storyButton = new Button(new Vector2(100, MainGame.ScreenY/4 + 100), "Histoire");
            exitButton = new Button(new Vector2(100, MainGame.ScreenY/4 + 150), "Quitter le jeu");

            startButton.MouseClick += OnStartButtonMouseClick;
            optionButton.MouseClick += OnOptionButtonMouseClick;
            storyButton.MouseClick += OnStoryButtonMouseClick;
            exitButton.MouseClick += OnExitButtonMouseClick;
        }

        public override void Update(GameTime gameTime)
        {
            startButton.Update(gameTime);
            optionButton.Update(gameTime);
            exitButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.DrawUI(TexturesManager.BackgroundMenu, Vector2.Zero);
            spriteBatch.DrawUI(TexturesManager.Title, "Wrath of the Rack Ninja", new Vector2(MainGame.ScreenX / 2, MainGame.ScreenY / 2 - 300), Color.Red);

            startButton.Draw(gameTime, spriteBatch);
            optionButton.Draw(gameTime, spriteBatch);
            storyButton.Draw(gameTime, spriteBatch);
            exitButton.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        private void OnStartButtonMouseClick(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {
            MainGame.GetInstance().SetScreen(new PlayerEditor());
        }

        private void OnOptionButtonMouseClick(object sender, MouseClickEventArgs e)
        {
            MainGame.GetInstance().SetScreen(new OptionMenu());
        }

        private void OnStoryButtonMouseClick(object sender, MouseClickEventArgs e)
        {
            
        }

        private void OnExitButtonMouseClick(object sender, MouseClickEventArgs e)
        {
            MainGame.GetInstance().Exit();
        }
    }
}