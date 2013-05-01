using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.Screens.SubScreens;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using GameProjectReborn.Resources;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Windows
{
    public class EscapeMenu : Window
    {
        private Button launchMainButton;
        private Button optionButton;
        private Button suicideButton;
        private Button quitGameButton;

        public EscapeMenu(Screen parent, Vector2 position) : base(parent, position)
        {
            launchMainButton = new Button(new Vector2(position.X, position.Y + 50), Res.ReturnMainMenu);
            optionButton = new Button(new Vector2(position.X, position.Y + 100), Res.Options);
            suicideButton = new Button(new Vector2(position.X, position.Y + 150), Res.GiveUp);
            quitGameButton = new Button(new Vector2(position.X, position.Y + 200), Res.LeaveGame);

            launchMainButton.MouseClick += OnLaunchMainButtonMouseClick;
            optionButton.MouseClick += OnOptionButtonMouseClick;
            suicideButton.MouseClick += OnSuicideButtonMouseClick;
            quitGameButton.MouseClick += OnQuitGameMouseClick;
        }

        public override void Update(GameTime gameTime)
        {
            launchMainButton.Update(gameTime);
            optionButton.Update(gameTime);
            suicideButton.Update(gameTime);
            quitGameButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            launchMainButton.Draw(gameTime, spriteBatch);
            optionButton.Draw(gameTime, spriteBatch);
            suicideButton.Draw(gameTime, spriteBatch);
            quitGameButton.Draw(gameTime, spriteBatch);
        }

        private void OnLaunchMainButtonMouseClick(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {
            XactManager.PlaySong("Menu01");
            MainGame.GetInstance().SetScreen(new StartMenu());
        }

        private void OnOptionButtonMouseClick(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {

        }

        private void OnSuicideButtonMouseClick(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {
            XactManager.PlaySong("Menu01");
            MainGame.GetInstance().SetScreen(new GameOverScreen());
        }

        private void OnQuitGameMouseClick(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {
            MainGame.MainExit();
        }
    }
}