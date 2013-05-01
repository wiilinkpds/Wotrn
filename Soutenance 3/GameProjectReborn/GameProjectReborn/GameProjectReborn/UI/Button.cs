using GameProjectReborn.Managers;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.UI
{
    public class Button : Control
    {
        public int SlideSize;
        public float BoundLeft;

        private Vector2 textSize;
        private Texture2D texture;
        private string text;

        public Button(Vector2 position, string text) : base (position)
        {
            textSize = TexturesManager.Menu.MeasureString(text);
            Bounds = new Rectangle((int)position.X, (int)position.Y, (int)textSize.X, (int)textSize.Y);
            this.text = text;
        }

        public Button(Vector2 position, Texture2D texture) : base(position)
        {
            textSize = new Vector2(texture.Width, texture.Height);
            Bounds = new Rectangle((int)position.X, (int)position.Y, (int)textSize.X, (int)textSize.Y);
            this.texture = texture;
        }

        public Button(Vector2 position, Texture2D texture, int slideSize) : base(position)
        {
            textSize = new Vector2(texture.Width, texture.Height);
            Bounds = new Rectangle((int)position.X, (int)position.Y, (int)textSize.X, (int)textSize.Y);
            this.texture = texture;
            SlideSize = slideSize - 2 * texture.Width;
            BoundLeft = Position.X - slideSize/2 + texture.Width;
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            if (texture == null)
            {
                spriteBatch.DrawUI(MouseManager.IsInRectangle(Bounds) && !MouseManager.IsClicking() ? TexturesManager.Zoom : TexturesManager.Menu,
                                   text, Position, MouseManager.IsInRectangle(Bounds) ? Color.Red : Color.White);
            }
            else if (SlideSize == 0)
                spriteBatch.DrawUI(texture, Position, MouseManager.IsInRectangle(Bounds) ? Color.Gray : Color.White);
            else
            {
                spriteBatch.DrawUI(TexturesManager.SlideBar,
                                   new Rectangle((int) BoundLeft, (int) Position.Y,
                                                 SlideSize + TexturesManager.MovingCursor.Width - 1,
                                                 TexturesManager.MovingCursor.Height));
                spriteBatch.DrawUI(texture, Position, MouseManager.IsInRectangle(Bounds) ? Color.Gray : Color.White);
            }
        }

        public void SetText(string newText)
        {
            text = newText;
        }
    }
}
