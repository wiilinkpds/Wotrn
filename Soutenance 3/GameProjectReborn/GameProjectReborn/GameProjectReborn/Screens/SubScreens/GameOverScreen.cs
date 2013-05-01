using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using GameProjectReborn.Resources;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens.SubScreens
{
    public class GameOverScreen : Screen
    {
        private Button loadButton;
        private Button mainButton;

        public GameOverScreen()
        {
            string load = Res.LoadLastSave;
            string main = Res.ReturnMainMenu;

            loadButton = new Button(new Vector2(100, MainGame.ScreenY / 4f), load);
            mainButton = new Button(new Vector2(100, MainGame.ScreenY / 2f), main);

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
