using Microsoft.Xna.Framework;

namespace GameProjectReborn.UI
{
    public class MouseClickEventArgs
    {
        public int Button { get; private set; }
        public Vector2 Position { get; private set; }

        public MouseClickEventArgs(int button, Vector2 position)
        {
            Button = button;
            Position = position;
        }
    }
}