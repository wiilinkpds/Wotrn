using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Utils
{
    public class UberSpriteBatch
    {
        public Vector2 Position { get; set; }

        private readonly SpriteBatch spriteBatch;

        public UberSpriteBatch(GraphicsDevice graphicsDevice)
        {
            spriteBatch = new SpriteBatch(graphicsDevice);
        }

        public void Begin()
        {
            spriteBatch.Begin();
        }

        public void End()
        {
            spriteBatch.End();
        }

        public void Draw(Texture2D texture, Vector2 position)
        {
            Draw(texture, position, Color.White);
        }

        public void Draw(Texture2D texture, Vector2 position, Color color)
        {
            position += Position;
            spriteBatch.Draw(texture, new Vector2((int)position.X, (int)position.Y), color);
        }

        public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle)
        {
            destinationRectangle.X += (int)Position.X;
            destinationRectangle.Y += (int)Position.Y;
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void DrawUI(Texture2D texture, Vector2 position)
        {
            DrawUI(texture, position, Color.White);
        }

        public void DrawUI(Texture2D texture, Vector2 position, Color color)
        {
            spriteBatch.Draw(texture, new Vector2((int)position.X, (int)position.Y), color);
        }
    }
}
