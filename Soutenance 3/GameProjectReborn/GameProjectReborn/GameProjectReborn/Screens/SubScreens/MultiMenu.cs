using System.Collections.Generic;
using System.Linq;
using GameProjectReborn.Managers;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using GameProjectReborn.Windows;
using GameProjectReborn.Windows.SubWindows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Screens.SubScreens
{
    public class MultiMenu : Screen
    {
        private Button backStartButton;
        private Button localButton;
        private string IpAddress = "";

        private Dictionary<Keys, string> cle;

        private Window localWindows;

        public MultiMenu()
        {
            backStartButton = new Button(new Vector2(100, MainGame.ScreenY / 4 + 150), "Retour");
            backStartButton.MouseClick += OnBackStartMouseClick;

            localButton = new Button(new Vector2(100,MainGame.ScreenY / 4),"Local" );
            localButton.MouseClick += OnLocalMouseClick;

            localWindows = new MultiLocalWindow(this, new Vector2(localButton.Bounds.Top + 10, localButton.Bounds.Y), TexturesManager.Window);
        }

        public override void Update(GameTime gameTime)
        {          
            foreach (Window win in Windows.ToArray())
                win.Update(gameTime);

            backStartButton.Update(gameTime);
            localButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.Begin();           
            spriteBatch.Draw(TexturesManager.MultiMenu, new Rectangle(0, 0, MainGame.ScreenX, MainGame.ScreenY));
            spriteBatch.DrawUI(TexturesManager.Title, "Wrath of the Rack Ninja", new Vector2(MainGame.ScreenX / 2, MainGame.ScreenY / 2 - 300), Color.Red);
            spriteBatch.DrawUI(TexturesManager.Title, "Multijoueurs", new Vector2(100, MainGame.ScreenY / 2 - 300), Color.Red);

            

            backStartButton.Draw(gameTime, spriteBatch);
            localButton.Draw(gameTime,spriteBatch);

            foreach (Window win in Windows)
                win.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        private void OnBackStartMouseClick(object sender, MouseClickEventArgs e)
        {
            MainGame.GetInstance().SetScreen(new StartMenu());
        }

        private void OnLocalMouseClick(object sender, MouseClickEventArgs e)
        {
            localWindows.IsOpened = !localWindows.IsOpened;

            if (localWindows.IsOpened)
                Windows.Add(localWindows);
            else
                Windows.Remove(localWindows);
        }
    }
}

