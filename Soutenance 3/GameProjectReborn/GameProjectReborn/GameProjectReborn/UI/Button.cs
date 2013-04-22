using GameProjectReborn.Managers;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.UI
{
    public class Button : Control
    {
        public int BoundLeft;
        public int BoundRight;

        private Vector2 textSize;
        private Texture2D texture;
        private string text;

        public Button(Vector2 position, string text) : base (position)
        {
            textSize = TexturesManager.Menu.MeasureString(text);
            Bounds = new Rectangle((int)position.X, (int)position.Y, (int)textSize.X, (int)textSize.Y);
            this.text = text;
        }

        public Button(Vector2 position, Texture2D texture)
            : base(position)
        {
            textSize = new Vector2(texture.Width, texture.Height);
            Bounds = new Rectangle((int)position.X, (int)position.Y, (int)textSize.X, (int)textSize.Y);
            this.texture = texture;
        }

        public Button(Vector2 position, Texture2D texture, int boundLeft, int boundRight) : base(position)
        {
            textSize = new Vector2(texture.Width, texture.Height);
            Bounds = new Rectangle((int)position.X, (int)position.Y, (int)textSize.X, (int)textSize.Y);
            this.texture = texture;
            BoundLeft = boundLeft;
            BoundRight = boundRight;
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            if (texture == null)
            {
                spriteBatch.DrawUI(MouseManager.IsInRectangle(Bounds) ? TexturesManager.Zoom : TexturesManager.Menu, text, Position, MouseManager.IsInRectangle(Bounds) ? Color.Red : Color.White);
            }
            else
                spriteBatch.DrawUI(texture, Position, MouseManager.IsInRectangle(Bounds) ? Color.Gray : Color.White);
        }
    }
}
