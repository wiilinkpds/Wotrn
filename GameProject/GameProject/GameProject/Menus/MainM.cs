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
        private static bool noHold = true;

        private static int choiceNumber = 0;
        private static int posX = 0;
        private static int posY = 0;

        private static Color colorTextMenu = Color.Ivory; 
        private static string[] menuPos = new string[] { "Lancer une nouvelle partie", "Charger une partie", "Rejoindre une partie Multijoueur", "Editeur de map", "Options", "Quitter le jeu" };
        

        // Empeche le choix de se "téléporter" grace à la modification de la variable isHold.
        static public int ChoiceMenu()
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

        // Envoie l'appel de la selection du menu. En gros, si vous cliquez sur entrez et que Lancer le jeu est en surbrillance, vous lancerez le jeu.
        static public bool ChoiceMade(bool mainMenuLaunched)
        {
            if (Utils.Down(Keys.Enter) && mainMenuLaunched && (ChoiceMenu() == 0 || ChoiceMenu() == 5))
                mainMenuLaunched = false;
            else if (Utils.Down(Keys.Escape) && Utils.Down(Keys.LeftShift) && !mainMenuLaunched)
                mainMenuLaunched = true;

            return mainMenuLaunched;

        }

        // Dessine le Menu. posX est la position de départ des choix du menu sur l'axe X.
        static public void MainMenu(int ScreenX, int ScreenY, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < menuPos.Length; i++)
            {
                posX = menuPos[i].Length * 7 + 60;
                posY = i * 95 + 140; ;

                if (i == ChoiceMenu())
                {
                    colorTextMenu = Color.Red;
                    spriteBatch.Draw(LoadM.Rack, new Vector2(ScreenY / 2 + 80 + posX, posY), Color.White); // Rack droit
                    spriteBatch.Draw(LoadM.Rack, new Vector2(ScreenY / 2  - posX, posY), Color.White); // Rack gauche
                }
                else
                    colorTextMenu = Color.Ivory;
                spriteBatch.DrawString(LoadM.Menu, menuPos[i], new Vector2(ScreenX / 2 - menuPos[i].Length * 7, ScreenY / 4 + 95 * i), colorTextMenu);
            }
        }

    }
}
