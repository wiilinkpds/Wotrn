﻿using GameProjectReborn.Camera;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Managers
{
    public class MouseManager
    {
        private static MouseState lastState;
        private static MouseState currentState;
        private static Vector2 Position { get; set; }

        public static bool RightClic { get { return lastState.RightButton == ButtonState.Pressed && currentState.RightButton == ButtonState.Released; } }
        public static bool LeftClic { get { return lastState.LeftButton == ButtonState.Pressed && currentState.LeftButton == ButtonState.Released; } }

        public static void Update()
        {
            lastState = currentState; // A ce moment la, lastState == currentState
            currentState = Mouse.GetState(); // A ce moment la, lastState != de currentState
            Position = new Vector2(currentState.X, currentState.Y);
        }

        public static bool MouseIn(Rectangle rectangle)
        {
            return (Position.X > rectangle.Left && Position.X < rectangle.Right && Position.Y > rectangle.Top && Position.Y < rectangle.Bottom);
        }
        public static bool MouseIn(Rectangle rectangle, Cam camera)
        {
            return (camera.Location(Position).X > rectangle.Left &&
                camera.Location(Position).X < rectangle.Right &&
                camera.Location(Position).Y > rectangle.Top &&
                camera.Location(Position).Y < rectangle.Bottom);
        }
    }
}
