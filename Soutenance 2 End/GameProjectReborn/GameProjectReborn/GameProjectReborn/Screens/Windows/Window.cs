using GameProjectReborn.Managers;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Screens.Windows
{
    public abstract class Window
    {
        public Screen Parent { get; private set; }
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; set; }

        public bool IsOpened { get; set; }

        protected Window(Screen parent, Vector2 position)
        {
            Parent = parent;
            Position = position;
        }

        protected Window(Screen parent, Vector2 position, Texture2D texture)
        {
            Parent = parent;
            Position = position;
            Bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public static Vector2 MoveWindow(Vector2 winPos)
        {
            return winPos + MouseManager.Move();
        }

        public abstract void Update(GameTime gameTime); // Abstract est obligatoirement overridee sinon elle n'existe pas... Tandis que virtual peut quand meme fonctionner :D
        public abstract void Draw(GameTime gameTime, UberSpriteBatch spriteBatch);
    }
}