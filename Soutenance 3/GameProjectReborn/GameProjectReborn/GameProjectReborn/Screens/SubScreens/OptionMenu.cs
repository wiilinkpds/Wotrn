using System.Linq;
using GameProjectReborn.Managers;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using GameProjectReborn.Windows;
using GameProjectReborn.Windows.SubWindows;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens.SubScreens
{
    public class OptionMenu : Screen
    {
        private Button soundButton;
        private Button resolutionButton;
        private Button backStartButton;

        private Window soundProperties;

        public OptionMenu()
        {
            soundButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 50), "Son");
            resolutionButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 100), "Résolution");
            backStartButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 150), "Retour");

            soundProperties = new SoundProperties(this, new Vector2(soundButton.Bounds.Top + 10, soundButton.Bounds.Y), TexturesManager.Window);

            soundButton.MouseClick += OnSoundMouseClick;
            resolutionButton.MouseClick += OnResolutionMouseClick;
            backStartButton.MouseClick += OnBackStartMouseClick;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Window win in Windows.ToArray())
                win.Update(gameTime);

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

            foreach (Window win in Windows)
                win.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
        private void OnSoundMouseClick(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {
            soundProperties.IsOpened = !soundProperties.IsOpened;

            if (soundProperties.IsOpened)
                Windows.Add(soundProperties);
            else
                Windows.Remove(soundProperties);
        }

        private void OnResolutionMouseClick(object sender, MouseClickEventArgs e)
        {

        }

        private void OnBackStartMouseClick(object sender, MouseClickEventArgs e)
        {
            MainGame.GetInstance().SetScreen(new StartMenu());
        }
    }
}
