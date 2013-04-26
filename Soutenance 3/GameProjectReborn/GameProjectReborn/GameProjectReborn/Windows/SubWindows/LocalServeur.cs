using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Windows.SubWindows
{
    class LocalServeur : Window
    {
        private Texture2D texture;
        private string IpAddress;

        public LocalServeur(Screen parent, Vector2 position, Texture2D texture) : base(parent, position, texture)
        {
            IpAddress = "";
            this.texture = texture;
            Bounds = new Rectangle((int) position.X, (int) position.Y, MainGame.ScreenX/2, MainGame.ScreenY/2);
        }

        public override void Update(GameTime gameTime)
        {
            Keys[] pressed = KeyboardManager.GetPressedKeys();
            if (pressed != null && pressed.Length > 0)
            {
                if (pressed.Length > 1 && (pressed[1] == Keys.LeftShift || pressed[1] == Keys.RightShift))
                {
                    foreach (var keyse in pressed)
                        if (KeyboardManager.MajKeys.ContainsKey(keyse))
                            IpAddress += KeyboardManager.MajKeys[keyse];
                }
                else if (pressed[0] != Keys.LeftAlt && pressed[0] != Keys.RightAlt && KeyboardManager.SimpleKeys.ContainsKey(pressed[0]))
                    IpAddress += KeyboardManager.SimpleKeys[pressed[0]];
                else if (pressed[0] == Keys.Back && IpAddress.Length > 0)
                    IpAddress = IpAddress.Remove(IpAddress.Length - 1);

            }
            if (KeyboardManager.IsPressed(Keys.S))
                new MultiJoueurs.Serveur(true).Update();
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.DrawUI(texture, Bounds); 
            spriteBatch.DrawUI(TexturesManager.Menu, IpAddress, new Vector2(Bounds.X + 20, Bounds.Y + 10), Color.Red);
            spriteBatch.DrawUI(TexturesManager.Menu,"Serveur :", new Vector2(Bounds.X + Bounds.Width / 2 - TexturesManager.Menu.MeasureString("Serveur :").X / 2, Bounds.Y + TexturesManager.Menu.MeasureString("Serveur :").Y / 2),Color.Red );
        }
    }
}
