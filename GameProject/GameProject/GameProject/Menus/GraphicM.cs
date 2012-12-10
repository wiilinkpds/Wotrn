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

namespace GameProject.Menus
{
    public class GraphicM
    {
        // Desing du Menu
        public static void graphMenu(int ScreenX, int ScreenY, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(LoadM.Ville, new Vector2(0, 0), Color.White); // Image de fond
            spriteBatch.Draw(LoadM.Rack, new Vector2(500, 400), Color.White); // Rack
            spriteBatch.DrawString(LoadM.Titre, "Wrath of the Rack Ninja", new Vector2(80, 50), Color.Red); // Titre
        }

    }
}
