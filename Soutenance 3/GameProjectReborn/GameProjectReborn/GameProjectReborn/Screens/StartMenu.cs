using GameProjectReborn.Managers;
using GameProjectReborn.Resources;
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
            startButton = new Button(new Vector2(100, MainGame.ScreenY / 4), Res.Create);
            multiplayerButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 1 * MainGame.ScreenY / 10), Res.Multi);
            optionButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 2 * MainGame.ScreenY / 10), Res.Options);
            storyButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 3 * MainGame.ScreenY / 10), Res.History);
            exitButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 4 * MainGame.ScreenY / 10), Res.LeaveGame);

            startButton.MouseClick += OnStartButtonMouseClick;
            multiplayerButton.MouseClick += OnMultiplayerButtonMouseClick;
            optionButton.MouseClick += OnOptionButtonMouseClick;
            storyButton.MouseClick += OnStoryButtonMouseClick;
            exitButton.MouseClick += OnExitButtonMouseClick;
        }

        public override void Update(GameTime gameTime)
        {
            startButton.Update(gameTime);
            optionButton.Update(gameTime);
            exitButton.Update(gameTime);
            multiplayerButton.Update(gameTime);
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
            MainGame.GetInstance().SetScreen(new IntroScreen());
        }

        private void OnMultiplayerButtonMouseClick(object sender, MouseClickEventArgs e)
        {
            MainGame.GetInstance().SetScreen(new MultiMenu());
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
            MainGame.MainExit();
        }
    }
}