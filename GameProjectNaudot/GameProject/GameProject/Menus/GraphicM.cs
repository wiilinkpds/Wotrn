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
        // Design du Menu
        public static void MainGraph(int ScreenX, int ScreenY, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(LoadM.Ville, new Vector2(0, 0), Color.White); // Image de fond
            spriteBatch.DrawString(LoadM.Titre, "Wrath of the Rack Ninja", new Vector2(80, 50), Color.Red); // Titre
            spriteBatch.Draw(LoadM.Flamme, new Vector2(100, 120), Color.White);
            spriteBatch.Draw(LoadM.Flamme, new Vector2(90 + LoadM.Flamme.Width, 120), Color.White);
        }
    }
}
