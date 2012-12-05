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
    class MainMenu
    {
        // Initialisation du Menu
        static string[] menuPos = new string[] { "Lancer le Jeu", "Rejoindre une partie Multijoueur","Rejoindre une partie en coop", "Editeur de map","Options","Quitter le jeu" };
        static bool isHold = false;
        static int choiceNumber = 0;
        
        // Dessine le Menu. posX est la position de départ des choix du menu sur l'axe X.
        static public void mainMenu()
        {
            // Generation du menu des choix
            for (int i = 0; i < menuPos.Length; i++)
            {
                Color colorTextMenu = Color.White;
                mainMenuBis();
                if (i == choiceMenu())
                    colorTextMenu = Color.Red;
                else
                    colorTextMenu = Color.White;
                MainGame.SpriteBatch.DrawString(MainGame.TexturesMenu.Test, menuPos[i], new Vector2(50, 200 + 80 * i), colorTextMenu);
            }
        }

        // Pour ajouter du contenu non modifiable InGame au Menu
        static void mainMenuBis()
        {
            // Le Titre, Les flammes de l'Enfer, L'Image flippante, La Puchline (si possible en dessous de l'image).
            MainGame.SpriteBatch.DrawString(MainGame.TexturesMenu.Titre, "Wrath of the Rack Ninja", new Vector2(80, 50), Color.Red);
            MainGame.SpriteBatch.Draw(MainGame.TexturesMenu.Flammes, new Vector2(400, 300), Color.White);
            MainGame.SpriteBatch.Draw(MainGame.TexturesMenu.Rack, new Vector2(500, 450), Color.White);
            MainGame.SpriteBatch.DrawString(MainGame.TexturesMenu.Test, "Il a envahi le monde\nmais personne ne le sait...", new Vector2(530, 400), Color.White);
        }
        /* Retourne le choix de l'utilisateur dans le menu sous forme de string. Envoyé à MainMenu()
           Empeche le choix de se "téléporter" grace à la modification de la variable isHold. */
        static public int choiceMenu()
        {
            if (isHold == false)
            {
                if ((Utils.Down(Keys.Down) || Utils.Down(Keys.S)) && choiceNumber < menuPos.Length - 1)
                    choiceNumber += 1;
                else if ((Utils.Down(Keys.Up) || Utils.Down(Keys.Z)) && choiceNumber > 0)
                    choiceNumber -= 1;
                isHold = true;
            }
            if (Utils.Up(Keys.Down) && Utils.Up(Keys.Up) && Utils.Up(Keys.Z) && Utils.Up(Keys.S))
                isHold = false;

            return choiceNumber;
        }

        // Envoie l'appel de la selection du menu. En gros, si vous cliquez sur entrez et que Lancer le jeu est en surbrillance, vous lancerez le jeu.
        static public bool choiceMade(bool mainMenuLaunched)
        {
            if (Utils.Down(Keys.Enter) && mainMenuLaunched && choiceMenu() == 0)
                return false;
            else if (Utils.Down(Keys.Enter) && mainMenuLaunched && choiceMenu() == 5)
                return false;
            else if (Utils.Down(Keys.Escape) && Utils.Down(Keys.LeftShift) && mainMenuLaunched == false)
                return true;
            else
                return mainMenuLaunched;
        }
    }
}
