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
    public class IngameM
    {
        // Initialisation
        private static bool InGameMenu = false;
        private static bool hold = false;
        private static bool noHold = true;

        private static int choiceNumber = 0;


        private static Color colorTextMenu = Color.Ivory;
        private static string[] ingameMenuPos = new string[] {"Retourner sur le Jeu" ,"Quitter vers le Menu Principal", "Quitter vers le Bureau" };


        // Empeche le choix de se "téléporter" grace à la modification de la variable isHold.
        static public int ChoiceIngameMenu()
        {
            if (noHold)
            {
                if (Utils.Down(Keys.Down) && choiceNumber < ingameMenuPos.Length - 1)
                    choiceNumber += 1;
                else if (Utils.Down(Keys.Up) && choiceNumber > 0)
                    choiceNumber -= 1;
                noHold = false;
            }
            if (Utils.Up(Keys.Down) && Utils.Up(Keys.Up))
                noHold = true;
            return choiceNumber;
        }

        // Retourne un booléen, vrai si le menu Ingame est lancé.
        public static bool ingameLaunched()
        {
            if ( (Utils.Down(Keys.Escape) || (Utils.Down(Keys.Enter) && ChoiceIngameMenu() == 0 && InGameMenu)) && !hold)
            {
                InGameMenu = !InGameMenu;
                hold = true;
            }
            else if (Utils.Up(Keys.Escape))
                hold = false;
            return InGameMenu;
        }

        // Dessine le Menu Ingame
        static public void IngameMenu(int ScreenX, int ScreenY, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < ingameMenuPos.Length; i++)
            {
                if (i == ChoiceIngameMenu())
                    colorTextMenu = Color.Red;
                else
                    colorTextMenu = Color.Ivory;
                spriteBatch.DrawString(LoadM.Menu, ingameMenuPos[i], new Vector2(350, 300 + 80 * i), colorTextMenu);
            }
        }

    }
}
