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
    class MainM
    {
        // Initialisation du Menu
        static private string[] menuPos = new string[] { "Lancer le Jeu", "Rejoindre une partie en coop","Rejoindre une partie Multijoueur", "Editeur de map","Options","Quitter le jeu" };
        static private bool noHold = true;
        static private int choiceNumber = 0;

        // Dessine le Menu. posX est la position de départ des choix du menu sur l'axe X.
        static public void mainMenu(int ScreenX, int ScreenY, SpriteBatch spriteBatch)
        {
            GraphicM.graphMenu(ScreenX, ScreenY, spriteBatch);

            for (int i = 0; i < menuPos.Length; i++)
            {
                Color colorTextMenu = Color.Ivory;
                if (i == choiceMenu())
                    colorTextMenu = Color.Red;
                else
                    colorTextMenu = Color.Ivory;
                spriteBatch.DrawString(LoadM.Menu, menuPos[i], new Vector2(50, ScreenY / 3 + 80 * i), colorTextMenu);
            }
        }

        // Empeche le choix de se "téléporter" grace à la modification de la variable isHold.
        static public int choiceMenu()
        {
            if (noHold)
            {
                if (Utils.Down(Keys.Down) && choiceNumber < menuPos.Length - 1)
                    choiceNumber += 1;
                else if (Utils.Down(Keys.Up) && choiceNumber > 0)
                    choiceNumber -= 1;
                noHold = false;
            }
            if (Utils.Up(Keys.Down) && Utils.Up(Keys.Up))
                noHold = true;

            return choiceNumber;
        }
    }
}
