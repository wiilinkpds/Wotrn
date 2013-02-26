using GameProjectReborn.Managers;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens.Option
{
    public class OptionMenu : Screen
    {
        private Button soundButton;
        private Button resolutionButton;
        private Button backStartButton;

        public OptionMenu()
        {
            soundButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 50), "Son : ");
            resolutionButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 100), "Resolution");
            backStartButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 150), "Retour");

            soundButton.MouseClick += OnSoundMouseClick;
            resolutionButton.MouseClick += OnResolutionMouseClick;
            backStartButton.MouseClick += OnBackStartMouseClick;
        }

        public override void Update(GameTime gameTime)
        {
            soundButton.Update(gameTime);
            resolutionButton.Update(gameTime);
            backStartButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(TexturesManager.OptionMenu, new Rectangle(0, 0, MainGame.ScreenX, MainGame.ScreenY));
            spriteBatch.DrawUI(TexturesManager.Title, "Wrath of the Rack Ninja", new Vector2(MainGame.ScreenX / 2, MainGame.ScreenY / 2 - 300), Color.Red);
            spriteBatch.DrawUI(TexturesManager.Title, "Options", new Vector2(100, MainGame.ScreenY / 2 - 300), Color.Red);

            soundButton.Draw(gameTime, spriteBatch);
            resolutionButton.Draw(gameTime, spriteBatch);
            backStartButton.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
        private void OnSoundMouseClick(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {

        }

        private void OnResolutionMouseClick(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {

        }

        private void OnBackStartMouseClick(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {
            MainGame.GetInstance().SetScreen(new StartMenu());
        }
    }
}
