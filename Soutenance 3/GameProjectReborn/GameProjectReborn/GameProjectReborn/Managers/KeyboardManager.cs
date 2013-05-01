using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;
using GameProjectReborn.Resources;

namespace GameProjectReborn.Managers
{
    public static class KeyboardManager
    {
        private static bool IsCapsLock;
        private static KeyboardState lastState;
        private static KeyboardState currentState;

        public static Dictionary<Keys, string> altKeys = new Dictionary<Keys, string>
            {
                {Keys.D0, "@"},
                {Keys.OemPeriod, "."}
            };

        public static Dictionary<Keys, string> MajKeys = new Dictionary<Keys, string>
            {
                {Keys.D0, "0"},
                {Keys.D1, "1"},
                {Keys.D2, "2"},
                {Keys.D3, "3"},
                {Keys.D4, "4"},
                {Keys.D5, "5"},
                {Keys.D6, "6"},
                {Keys.D7, "7"},
                {Keys.D8, "8"},
                {Keys.D9, "9"},
                {Keys.A, "A"},
                {Keys.B, "B"},
                {Keys.C, "C"},
                {Keys.D, "D"},
                {Keys.E, "E"},
                {Keys.F, "F"},
                {Keys.G, "G"},
                {Keys.H, "H"},
                {Keys.I, "I"},
                {Keys.J, "J"},
                {Keys.K, "K"},
                {Keys.L, "L"},
                {Keys.M, "M"},
                {Keys.N, "N"},
                {Keys.O, "O"},
                {Keys.P, "P"},
                {Keys.Q, "Q"},
                {Keys.R, "R"},
                {Keys.S, "S"},
                {Keys.T, "T"},
                {Keys.U, "U"},
                {Keys.V, "V"},
                {Keys.W, "W"},
                {Keys.X, "X"},
                {Keys.Y, "Y"},
                {Keys.Z, "Z"},
                {Keys.OemPeriod, "."},
                {Keys.OemComma, "?"},
                {Keys.OemQuestion, "/"},
                {Keys.Oem8, "§"},
                {Keys.OemPlus, "+"},
                {Keys.OemPipe, "µ"},
                {Keys.OemTilde, "%"},
                {Keys.OemSemicolon, "£"},
                {Keys.OemOpenBrackets, "°"},
                {Keys.OemCloseBrackets, "¨"},             
                {Keys.OemMinus, "-"},
                {Keys.Subtract, "-"},
                {Keys.Space, " "},
                {Keys.Multiply, "*"},
                {Keys.Divide, "/"},
                {Keys.Decimal, "."},
                {Keys.Add, "+"},
                {Keys.OemBackslash, "\\"},
                {Keys.OemQuotes, "²"},
            };
        public static Dictionary<Keys, string> SimpleKeys = new Dictionary<Keys, string>
            {
                {Keys.NumPad0, "0"},
                {Keys.NumPad1, "1"},
                {Keys.NumPad2, "2"},
                {Keys.NumPad3, "3"},
                {Keys.NumPad4, "4"},
                {Keys.NumPad5, "5"},
                {Keys.NumPad6, "6"},
                {Keys.NumPad7, "7"},
                {Keys.NumPad8, "8"},
                {Keys.NumPad9, "9"},
                {Keys.D1, "&"},
                {Keys.D2, "é"},
                {Keys.D3, "\""},
                {Keys.D4, "'"},
                {Keys.D5, "("},
                {Keys.D6, "-"},
                {Keys.D7, "è"},
                {Keys.D8, "_"},
                {Keys.D9, "ç"},
                {Keys.D0, "à"},
                {Keys.A, "a"},
                {Keys.B, "b"},
                {Keys.C, "c"},
                {Keys.D, "d"},
                {Keys.E, "e"},
                {Keys.F, "f"},
                {Keys.G, "g"},
                {Keys.H, "h"},
                {Keys.I, "i"},
                {Keys.J, "j"},
                {Keys.K, "k"},
                {Keys.L, "l"},
                {Keys.M, "m"},
                {Keys.N, "n"},
                {Keys.O, "o"},
                {Keys.P, "p"},
                {Keys.Q, "q"},
                {Keys.R, "r"},
                {Keys.S, "s"},
                {Keys.T, "t"},
                {Keys.U, "u"},
                {Keys.V, "v"},
                {Keys.W, "w"},
                {Keys.X, "x"},
                {Keys.Y, "y"},
                {Keys.Z, "z"},
                {Keys.OemPeriod, ";"},
                {Keys.OemPipe, "*"},
                {Keys.OemPlus, "="},
                {Keys.OemQuotes, "²"},
                {Keys.OemTilde, "ù"},
                {Keys.OemQuestion, ":"},
                {Keys.OemSemicolon, "$"},
                {Keys.OemBackslash, "\\"},
                {Keys.OemOpenBrackets, ")"},
                {Keys.OemCloseBrackets, "^"},
                {Keys.OemComma, ","},
                {Keys.OemMinus, "-"},
                {Keys.Subtract, "-"},
                {Keys.Space, " "},
                {Keys.Multiply, "*"},
                {Keys.Oem8, "!"},
                {Keys.Divide, "/"},
                {Keys.Decimal, "."},
                {Keys.Add, "+"},
            };
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
            if (IsPressed(Keys.CapsLock))
                IsCapsLock = !IsCapsLock;
            lastState = currentState; // A ce moment la, lastState == currentState
            currentState = Keyboard.GetState(); // A ce moment la, lastState != de currentState
        }

        public static Keys[] GetPressedKeys()
        {
            if (currentState.GetPressedKeys().Length > 0)
                if (lastState.GetPressedKeys().Length == 0 || currentState.GetPressedKeys()[0] != lastState.GetPressedKeys()[0])
                    return currentState.GetPressedKeys();
            return null;
        }

        public static string RecupClavier()
        {
            string str = "";
            Keys[] pressed = GetPressedKeys();
            if (pressed != null && pressed.Length > 0)
            {
                if ((pressed.Length > 1 && (pressed[1] == Keys.LeftShift || pressed[1] == Keys.RightShift) || IsCapsLock))
                    str = pressed.Where(keyse => MajKeys.ContainsKey(keyse)).Aggregate(str, (current, keyse) => current + MajKeys[keyse]);
                else if (pressed.Length > 2 && (pressed[2] == Keys.RightAlt || pressed[2] == Keys.LeftAlt) && (pressed[1] == Keys.LeftControl || pressed[1] == Keys.RightControl)) //Alt Gr pour @
                    str = pressed.Where(keyse => altKeys.ContainsKey(keyse)).Aggregate(str, (current, keyse) => current + altKeys[keyse]);
                else if (SimpleKeys.ContainsKey(pressed[0]))
                    str += SimpleKeys[pressed[0]];
                if (pressed[0] == Keys.Back && str.Length > 0)
                    str = str.Remove(str.Length - 1);
            }
            return str;
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
