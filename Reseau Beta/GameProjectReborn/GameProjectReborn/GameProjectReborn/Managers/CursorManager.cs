using GameProjectReborn.Entities;
using GameProjectReborn.Screens;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Managers
{
    public static class CursorManager
    {
        public static Texture2D CurrentTexture { get; set; }
        public static Vector2 Position { get; set; }

        public static void Update(GameTime gameTime)
        {
            Position = MouseManager.Position;
        }
        public static void Draw(UberSpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(CurrentTexture, Position);
            spriteBatch.End();
        }
    }
}
