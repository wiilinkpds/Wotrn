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
        // Initialisation
        private static bool noHold = true;
        private static int choiceNumber = 0, posX = 0, posY = 0;

        private static Color colorTextMenu = Color.Ivory;
        private static string[] menuPos = new string[] { "Lancer une nouvelle partie", "Charger une partie", "Rejoindre une partie Multijoueur", "Editeur de map", "Options", "Quitter le jeu" };

        static public void InitMainMenu()
        {
            choiceNumber = -1;
        }
        // Initialisation

        // Empeche le choix de se "téléporter" grace à la modification de la variable noHold.
        static public int ChoiceMainMenu(bool MenuLaunch)
        {
            if (noHold)
            {
                if (Utils.Down(Keys.Down) && choiceNumber < menuPos.Length - 1 && MenuLaunch)
                    choiceNumber += 1;
                else if (Utils.Down(Keys.Up) && choiceNumber > 0)
                    choiceNumber -= 1;
                else if ((Utils.Down(Keys.Up) || Utils.Down(Keys.Down)) && choiceNumber == -1 && MenuLaunch)
                    choiceNumber = 0;
                noHold = false;
            }
            if (Utils.Up(Keys.Down) && Utils.Up(Keys.Up))
            {
                noHold = true;
            }
            return choiceNumber;
        }

        // Dessine le MainMenu. posX est la position de départ des choix du menu sur l'axe X.
        static public void MainDraw(int ScreenX, int ScreenY, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < menuPos.Length; i++)
            {
                posX = menuPos[i].Length * 7 + 60;
                posY = i * 95 + 140;

                if (i == ChoiceMainMenu(true))
                {
                    colorTextMenu = Color.Red;
                    spriteBatch.Draw(LoadM.Rack, new Vector2(ScreenY / 2 + 80 + posX, posY), Color.White); // Rack droit
                    spriteBatch.Draw(LoadM.Rack, new Vector2(ScreenY / 2 - posX, posY), Color.White); // Rack gauche
                }
                else
                    colorTextMenu = Color.Ivory;
                spriteBatch.DrawString(LoadM.Menu, menuPos[i], new Vector2(ScreenX / 2 - menuPos[i].Length * 7, ScreenY / 4 + 95 * i), colorTextMenu);
            }
        }
    }
}
