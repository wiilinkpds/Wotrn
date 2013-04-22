using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens.SubScreens
{
    public class GameOverScreen : Screen
    {
        private Button mainButton;
        private Button loadButton;

        public GameOverScreen()
        {
            mainButton = new Button(new Vector2(MainGame.ScreenX / 1.5f, MainGame.ScreenY / 1.5f), "Fuir au Menu Principal");
            loadButton = new Button(new Vector2(MainGame.ScreenX / 4, MainGame.ScreenY / 1.5f), "Recharger la dernière sauvegarde");

            mainButton.MouseClick += OnMainButtonMouseClick;
            loadButton.MouseClick += OnQuitButtonMouseClick;
        }

        public override void Update(GameTime gameTime)
        {
            mainButton.Update(gameTime);
            loadButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            mainButton.Draw(gameTime, spriteBatch);
            loadButton.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public void OnMainButtonMouseClick(object sender, MouseClickEventArgs e)
        {
            MainGame.GetInstance().SetScreen(new StartMenu());
        }

        public void OnQuitButtonMouseClick(object sender, MouseClickEventArgs e)
        {
            MainGame.GetInstance().Exit();
        }
    }
}
