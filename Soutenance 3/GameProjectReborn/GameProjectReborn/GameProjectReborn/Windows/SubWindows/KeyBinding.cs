using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Windows.SubWindows
{
    public class KeyBinding : Window
    {
        public KeyBinding(Screen parent, Vector2 position, Texture2D texture) : base(parent, position, texture)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.DrawUI(TexturesManager.Window, new Rectangle((int)Position.X, (int)Position.Y, TexturesManager.Window.Width + 100, KeyboardManager.BindedKeys.Length * 20 + 10));
            for (int i = 0; i < KeyboardManager.Description.Length; i++)
            {
                string str = KeyboardManager.Description[i];

                spriteBatch.DrawUI(TexturesManager.Level, str,
                                   Position + new Vector2(10, 5 + i*20), Color.White);
            }

            for (int i = 0; i < KeyboardManager.BindedKeys.Length; i++)
            {
                string str = KeyboardManager.BindedKeys[i].ToString();
                if (str[0] == 'D' && str.Length <= 2)
                    str = str.Substring(1);

                spriteBatch.DrawUI(TexturesManager.Level, str,
                    Position + new Vector2(205, 5 + i * 20), Color.White);
            }
        }
    }
}
