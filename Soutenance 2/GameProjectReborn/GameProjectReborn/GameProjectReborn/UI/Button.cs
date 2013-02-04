using GameProjectReborn.Managers;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.UI
{
    public class Button : Control
    {
        private Vector2 textSize;
        private string text;

        public Button(Vector2 position, string text) : base (position)
        {
            textSize = TexturesManager.Menu.MeasureString(text);
            Bounds = new Rectangle((int)position.X, (int)position.Y, (int)textSize.X, (int)textSize.Y);
            this.text = text;
        }

        public override void Update(GameTime gameTime)
        {   
            // Truc
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.DrawUI(TexturesManager.Menu, text, Position, MouseManager.IsInRectangle(Bounds) ? Color.Red : Color.White);
        } 
    }
}
