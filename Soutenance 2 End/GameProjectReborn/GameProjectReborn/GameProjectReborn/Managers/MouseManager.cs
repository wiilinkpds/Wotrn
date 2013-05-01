using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Managers
{
    public static class MouseManager
    {
        public static Vector2 Position { get; set; }

        private static MouseState lastState;
        private static MouseState currentState;

        public static void Update(CursoManagers cursor)
        {
            lastState = currentState;
            currentState = Mouse.GetState(); // A ce moment la, lastState != de currentState
            Position = new Vector2(currentState.X, currentState.Y);
            cursor.position = Position;
        }

        public static bool IsInRectangle(Rectangle rectangle)
        {
            return (Position.X > rectangle.Left && Position.X < rectangle.Right && Position.Y > rectangle.Top && Position.Y < rectangle.Bottom);
        }

        public static bool IsInRectangle(Rectangle rectangle, Cam camera) //Real position
        {
            return (camera.Location(Position).X > rectangle.Left &&
                camera.Location(Position).X < rectangle.Right &&
                camera.Location(Position).Y > rectangle.Top &&
                camera.Location(Position).Y < rectangle.Bottom);
        }

        public static bool IsClicking()
        {
            return currentState.LeftButton == ButtonState.Pressed;
        }

        public static bool IsLeftClicked()
        {
            return lastState.LeftButton == ButtonState.Pressed && currentState.LeftButton == ButtonState.Released;
        }

        public static bool IsRightClicked()
        {
            return lastState.RightButton == ButtonState.Pressed && currentState.RightButton == ButtonState.Released;
        }

        public static bool IsScrollingUp()
        {
            return lastState.ScrollWheelValue < currentState.ScrollWheelValue;
        }
        public static bool IsScrollingDown()
        {
            return lastState.ScrollWheelValue > currentState.ScrollWheelValue;
        }

        public static Vector2 Move()
        {
            return new Vector2(currentState.X - lastState.X, currentState.Y - lastState.Y);
        }
    }
}