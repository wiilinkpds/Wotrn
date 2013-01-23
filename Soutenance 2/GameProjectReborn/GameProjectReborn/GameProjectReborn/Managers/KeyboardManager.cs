using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Managers
{
    public static class KeyboardManager
    {
        private static KeyboardState lastState;
        private static KeyboardState currentState;

        public static void Update()
        {
            lastState = currentState; // A ce moment la, lastState == currentState
            currentState = Keyboard.GetState(); // A ce moment la, lastState != de currentState
        }

        public static bool IsPressed(Keys key) // Ne retourne qu'une seule fois true car lastState est Up a la premiere frame uniquement
        {
            return lastState.IsKeyUp(key) && currentState.IsKeyDown(key);
        }

        public static bool IsDown(Keys key)
        {
            return currentState.IsKeyDown(key);
        }
    }
}
