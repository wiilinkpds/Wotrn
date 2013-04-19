using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Managers
{
    public static class CursorManager
    {
        public static Texture2D CurrentTexture { get; set; }
        public static MouseState currentState { get; set; }
        public static Vector2 Position { get; set; }

        public static void Update(GameTime gameTime)
        {
            currentState = Mouse.GetState();
            Position = new Vector2(currentState.X, currentState.Y);
        }

        public static void Draw(UberSpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(CurrentTexture, Position);
            spriteBatch.End();
        }
    }
}
