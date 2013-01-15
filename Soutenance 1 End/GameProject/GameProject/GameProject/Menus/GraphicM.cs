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
        static private Vector2 posGoutte = new Vector2(0, 0);

        // Design du Menu
        public static void MainGraph(int ScreenX, int ScreenY, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(LoadM.Ville, new Rectangle(0, 0,ScreenX,ScreenY), Color.White); // Image de fond
            Vector2 titre = LoadM.Titre.MeasureString("Wrath of the Rack Ninja"); //Taille du titre dans le vector2
            spriteBatch.DrawString(LoadM.Titre, "Wrath of the Rack Ninja", new Vector2(ScreenX / 2 -titre.X / 2, ScreenY / 10), Color.Red); // Titre
            spriteBatch.Draw(LoadM.Flamme, new Vector2(ScreenX / 2 - titre.X / 2 + 10 ,ScreenY / 10 + titre.Y - 40), Color.White);
            spriteBatch.Draw(LoadM.Flamme, new Vector2(ScreenX / 2 ,ScreenY / 10 + titre.Y - 40), Color.White);
            spriteBatch.Draw(LoadM.Goutte, posGoutte, Color.White);
        }

    }
}
