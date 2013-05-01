using Microsoft.Xna.Framework.Input;
using GameProjectReborn.Resources;

namespace GameProjectReborn.Managers
{
    public static class KeyboardManager
    {
        public enum KeysEnum
        {
            Up,
            Down,
            Left,
            Right,
            Spell1,
            Spell2,
            Spell3,
            Spell4,
            Spell5,
            Spell6,
            Spell7,
            Spell8,
            Target,
            Escape,
            ShowLife
        }

        private static KeyboardState lastState;
        private static KeyboardState currentState;

        public static Keys[] BindedKeys = 
            {
                Keys.Up,
                Keys.Down,
                Keys.Left,
                Keys.Right,
                Keys.D1,
                Keys.D2,
                Keys.D3,
                Keys.D4,
                Keys.D5,
                Keys.D6,
                Keys.D7,
                Keys.D8,
                Keys.Tab,
                Keys.Escape,
                Keys.LeftControl
            };

        public static string[] Description = 
            {
                Res.KeyUp,
                Res.KeyDown,
                Res.KeyLeft,
                Res.KeyRight,
                Res.KeySpell + " 1",
                Res.KeySpell + " 2",
                Res.KeySpell + " 3",
                Res.KeySpell + " 4",
                Res.KeySpell + " 5",
                Res.KeySpell + " 6",
                Res.KeySpell + " 7",
                Res.KeySpell + " 8",
                Res.KeyTab,
                Res.KeyEscape,
                Res.KeyShow
            };

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

        public static void RefreshDescription()
        {
            Description = new[]
            {
                Res.KeyUp,
                Res.KeyDown,
                Res.KeyLeft,
                Res.KeyRight,
                Res.KeySpell + " 1",
                Res.KeySpell + " 2",
                Res.KeySpell + " 3",
                Res.KeySpell + " 4",
                Res.KeySpell + " 5",
                Res.KeySpell + " 6",
                Res.KeySpell + " 7",
                Res.KeySpell + " 8",
                Res.KeyTab,
                Res.KeyEscape,
                Res.KeyShow
            };
        }
    }
}
