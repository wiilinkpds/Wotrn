using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameProject.UtilsFun
{
    class Utils
    {
        // Verifie si la "key" donnée est relâchée sur le clavier
        static public bool Up(Keys key)
        {
            KeyboardState etatClavier = Keyboard.GetState();
            return etatClavier.IsKeyUp(key);
        }

        // Verifie si l'utilisateur appuie sur la "key"
        static public bool Down(Keys key)
        {
            KeyboardState etatClavier = Keyboard.GetState();
            return etatClavier.IsKeyDown(key);
        }
    }
}
