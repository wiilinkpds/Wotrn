﻿using System;
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
        static private Vector2 posGoutte = new Vector2(0, 0);

        // Design du Menu
        public static void graphMenu(int ScreenX, int ScreenY, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(LoadM.Ville, new Rectangle(0, 0,ScreenX,ScreenY), Color.White); // Image de fond
            spriteBatch.DrawString(LoadM.Titre, "Wrath of the Rack Ninja", new Vector2(ScreenX / 5, ScreenY / 10), Color.Red); // Titre
            spriteBatch.Draw(LoadM.Flamme, new Vector2(ScreenX / 5 + 20, ScreenY / 10 + LoadM.Titre.MeasureString("Wrath of the Rack Ninja").Y - 40), Color.White);
            spriteBatch.Draw(LoadM.Flamme, new Vector2(ScreenX / 5 + 10 + LoadM.Flamme.Width, ScreenY / 10 + LoadM.Titre.MeasureString("Wrath of the Rack Ninja").Y - 40), Color.White);
            spriteBatch.Draw(LoadM.Goutte, posGoutte, Color.White);
        }

    }
}
