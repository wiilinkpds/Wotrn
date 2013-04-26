using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens.SubScreens
{
    public class GameOverScreen : Screen
    {
        private Button loadButton;
        private Button mainButton;

        public GameOverScreen()
        {
            loadButton = new Button(new Vector2(MainGame.ScreenX / 1.5f, MainGame.ScreenY / 1.5f), "Recharger la dernière sauvegarde");
            mainButton = new Button(new Vector2(MainGame.ScreenX / 4f, MainGame.ScreenY / 1.5f), "Fuir au Menu Principal");

            loadButton.MouseClick += OnLoadButtonMouseClick;
            mainButton.MouseClick += OnMainButtonMouseClick;
        }

        public override void Update(GameTime gameTime)
        {
            loadButton.Update(gameTime);
            mainButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            loadButton.Draw(gameTime, spriteBatch);
            mainButton.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public void OnLoadButtonMouseClick(object sender, MouseClickEventArgs e)
        {

        }

        public void OnMainButtonMouseClick(object sender, MouseClickEventArgs e)
        {
            MainGame.GetInstance().SetScreen(new StartMenu());
        }
    }
}
