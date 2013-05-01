using System.Globalization;
using System.Linq;
using GameProjectReborn.Managers;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using GameProjectReborn.Windows;
using GameProjectReborn.Windows.SubWindows;
using GameProjectReborn.Resources;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens.SubScreens
{
    public class OptionMenu : Screen
    {
        private Button soundButton;
        private Button bindButton;
        private Button languageButton;
        private Button resolutionButton;
        private Button backStartButton;

        private Window soundProperties;
        private Window keyBinding;

        public OptionMenu()
        {
            soundButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 100), Res.Sound);
            bindButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 150), Res.BindKeys);
            languageButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 200), Res.ChooseLanguage);
            resolutionButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 250), Res.Resolution);
            backStartButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 300), Res.Back);

            soundProperties = new SoundProperties(this, new Vector2(MainGame.ScreenX / 2 , MainGame.ScreenY / 4 + 50), TexturesManager.Window);
            keyBinding = new KeyBinding(this, new Vector2(MainGame.ScreenX / 2 + 50, MainGame.ScreenY / 4 + 50), TexturesManager.Window);

            soundButton.MouseClick += OnSoundMouseClick;
            bindButton.MouseClick += OnBindMouseClick;
            languageButton.MouseClick += OnLanguageMouseClick;
            resolutionButton.MouseClick += OnResolutionMouseClick;
            backStartButton.MouseClick += OnBackStartMouseClick;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Window win in Windows.ToArray())
                win.Update(gameTime);

            soundButton.Update(gameTime);
            bindButton.Update(gameTime);
            languageButton.Update(gameTime);
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
            bindButton.Draw(gameTime, spriteBatch);
            languageButton.Draw(gameTime, spriteBatch);
            resolutionButton.Draw(gameTime, spriteBatch);
            backStartButton.Draw(gameTime, spriteBatch);

            foreach (Window win in Windows)
                win.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
        private void OnSoundMouseClick(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {
            if (keyBinding.IsOpened)
                OnBindMouseClick(sender, e);

            soundProperties.IsOpened = !soundProperties.IsOpened;

            if (soundProperties.IsOpened)
                Windows.Add(soundProperties);
            else
                Windows.Remove(soundProperties);
        }

        private void OnBindMouseClick(object sender, MouseClickEventArgs e)
        {
            if (soundProperties.IsOpened)
                OnSoundMouseClick(sender, e);

            keyBinding.IsOpened = !keyBinding.IsOpened;

            if (keyBinding.IsOpened)
                Windows.Add(keyBinding);
            else
                Windows.Remove(keyBinding);
        }

        private void OnLanguageMouseClick(object sender, MouseClickEventArgs e)
        {
            Res.Culture =
                Res.Culture.DisplayName == "Français"
                    ? new CultureInfo("en")
                    : new CultureInfo("fr");

            soundButton.SetText(Res.Sound);
            bindButton.SetText(Res.BindKeys);
            languageButton.SetText(Res.ChooseLanguage);
            resolutionButton.SetText(Res.Resolution);
            backStartButton.SetText(Res.Back);

            KeyboardManager.RefreshDescription();
        }

        private void OnResolutionMouseClick(object sender, MouseClickEventArgs e)
        {
        //    if (MainGame.ScreenX != 1024)
        //    {
        //        MainGame.GetInstance().graphics.IsFullScreen = false;
        //        MainGame.SetGraphics(1024, 768);
        //    }
        //    else
        //    {
        //        MainGame.GetInstance().graphics.IsFullScreen = true;
        //        MainGame.SetGraphics(MainGame.GetInstance().graphics.GraphicsDevice.DisplayMode.Width, MainGame.GetInstance().graphics.GraphicsDevice.DisplayMode.Height);
        //    }
        }

        private void OnBackStartMouseClick(object sender, MouseClickEventArgs e)
        {
            MainGame.GetInstance().SetScreen(new StartMenu());
        }
    }
}
