using GameProjectReborn.Managers;
using GameProjectReborn.Screens.SubScreens;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens
{
    public class StartMenu : Screen
    {
        private Button startButton;
        private Button multiplayerButton;
        private Button optionButton;
        private Button storyButton;
        private Button exitButton;

        public StartMenu()
        {
            startButton = new Button(new Vector2(100, MainGame.ScreenY / 4), "Lancer une nouvelle partie");
            multiplayerButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 1 * MainGame.ScreenY / 10), "Multijoueur");
            optionButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 2 *MainGame.ScreenY / 10), "Options");
            storyButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 3 * MainGame.ScreenY / 10), "Histoire");
            exitButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 4 * MainGame.ScreenY / 10), "Quitter le jeu");

            startButton.MouseClick += OnStartButtonMouseClick;
            multiplayerButton.MouseClick += OnMultiplayerButtonMouseClick;
            optionButton.MouseClick += OnOptionButtonMouseClick;
            storyButton.MouseClick += OnStoryButtonMouseClick;
            exitButton.MouseClick += OnExitButtonMouseClick;

            XactManager.PlaySong("Menu01");
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

            spriteBatch.Draw(TexturesManager.BackgroundMenu, new Rectangle(0, 0, MainGame.ScreenX, MainGame.ScreenY));
            spriteBatch.DrawUI(TexturesManager.Title, "Wrath of the Rack Ninja", new Vector2(MainGame.ScreenX / 2, MainGame.ScreenY / 2 - 300), Color.Red);

            startButton.Draw(gameTime, spriteBatch);
            multiplayerButton.Draw(gameTime, spriteBatch);
            optionButton.Draw(gameTime, spriteBatch);
            storyButton.Draw(gameTime, spriteBatch);
            exitButton.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        private void OnStartButtonMouseClick(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {
            MainGame.GetInstance().SetScreen(new PlayerEditor());
        }

        private void OnMultiplayerButtonMouseClick(object sender, MouseClickEventArgs e)
        {

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