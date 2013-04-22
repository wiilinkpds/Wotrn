using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using GameProjectReborn.Windows.SubWindows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Windows
{
    class Panel : Window
    {
        private ShowInfo showInfoWindow;

        private Button infoPlayerButton;

        public Panel(Screen parent, Vector2 position, Texture2D texture,Player player) : base(parent, position, texture)
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
