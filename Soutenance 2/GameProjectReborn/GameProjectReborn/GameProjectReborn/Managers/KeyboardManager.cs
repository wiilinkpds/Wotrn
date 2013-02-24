using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Managers
{
    public static class KeyboardManager
    {
        private static KeyboardState lastState;
        private static KeyboardState currentState;

        public static void Update()
        {
            lastState = currentState;
            currentState = Keyboard.GetState();
        }

        public static bool IsPressed(Keys key)
        {
            return lastState.IsKeyUp(key) && currentState.IsKeyDown(key);
        }

        public static bool IsDown(Keys key)
        {
            return currentState.IsKeyDown(key);
        }
    }
}
