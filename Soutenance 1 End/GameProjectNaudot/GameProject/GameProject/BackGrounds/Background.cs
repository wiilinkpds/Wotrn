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
using GameProject.UtilsFun;

namespace GameProject.BackGrounds
{
    class Background
    {
        static public void Back(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(LoadBack.Fond1, position, Color.White);
        }
    }
}
