using GameProjectReborn.Managers;
using GameProjectReborn.Screens.Windows;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens
{
    public class PlayerEditor : Screen
    {
        private Button goButton;
        private Button addButton;

        private DialogWindow intro;

        public PlayerEditor()
        {
            goButton = new Button(new Vector2(MainGame.ScreenX / 2, MainGame.ScreenY - 50) - TexturesManager.Level.MeasureString("Se reveiller !"), "Se reveiller !");
            addButton = new Button(new Vector2(0, 0), TexturesManager.AddButton);

            intro = new DialogWindow(this, new Vector2(MainGame.ScreenX / 2 - TexturesManager.WinDial.Width / 2, 100), TexturesManager.WinDial);

            goButton.MouseClick += OnGoMouseClick;
            addButton.MouseClick += OnAddMouseClick;

        }

        public override void Update(GameTime gameTime)
        {
            goButton.Update(gameTime);
            addButton.Update(gameTime);
            intro.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            intro.Draw(gameTime, spriteBatch);
            goButton.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public void OnGoMouseClick(object sender, MouseClickEventArgs e)
        {
            MainGame.GetInstance().SetScreen(new GameScreen());
        }

        // Pour les points de carac
        private void OnAddMouseClick(object sender, MouseClickEventArgs e)
        {

        }
    }
}
