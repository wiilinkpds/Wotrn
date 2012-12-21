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
        static public void Back(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(LoadBack.Fond1, new Vector2(0,0), Color.White);
        }
    }
}
