using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Screens.Windows
{
    class PanelMenu : Window
    {
        private ShowInfo showInfoWindow;
        private Button infoPlayerButton;

        public PanelMenu(Screen parent, Vector2 position, Texture2D texture,Player player) : base(parent, position, texture)
        {
            showInfoWindow = new ShowInfo(parent, new Vector2(MainGame.ScreenX - 200, 5), TexturesManager.Window ,player);
            infoPlayerButton = new Button(position, TexturesManager.InfoButton);

            infoPlayerButton.MouseClick += OnInfoPlayerMouseClick;
        }

        public override void Update(GameTime gameTime)
        {
            infoPlayerButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            infoPlayerButton.Draw(gameTime, spriteBatch);
        }

        public void OnInfoPlayerMouseClick(object sender, MouseClickEventArgs e)
        {
            showInfoWindow.IsOpened = !showInfoWindow.IsOpened;
            if (showInfoWindow.IsOpened)
                Parent.Windows.Add(showInfoWindow);
            else
                Parent.Windows.Remove(showInfoWindow);
        }
    }
}
