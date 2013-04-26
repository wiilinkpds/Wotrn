using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Managers
{
    public static class KeyboardManager
    {
        private static KeyboardState lastState;
        public static KeyboardState currentState;

        public static Dictionary<Keys, string> altKeys = new Dictionary<Keys, string>
            {
                {Keys.D0, "@"}
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

        public static Keys[] GetPressedKeys()
        {
            if (currentState.GetPressedKeys().Length> 0)
                if (lastState.GetPressedKeys().Length == 0 || currentState.GetPressedKeys()[0] != lastState.GetPressedKeys()[0])
                    return currentState.GetPressedKeys();
            return null;
        }
    }
}