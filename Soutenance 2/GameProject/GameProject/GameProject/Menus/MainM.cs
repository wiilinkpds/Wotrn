using GameProject._UtilsFun;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject.Menus
{
    public class MainM
    {
        // Initialisation
        private static bool noHold = true;
        private static int choiceNumber, posX , posY ;

        private static Color colorTextMenu = Color.Ivory;
        private static readonly string[] menuPos = new[] { "Lancer une nouvelle partie ", "Charger une partie ", "Rejoindre une partie Multijoueur ", "Editeur de map ", "Options ", "Quitter le jeu " };

        static public void InitMainMenu()
        {
            choiceNumber = -1;
        }
        // Initialisation

        // Empeche le choix de se "téléporter" grace à la modification de la variable noHold.
        static public int ChoiceMainMenu(bool menulaunch)
        {
            if (noHold)
            {
                if (Utils.Down(Keys.Down) && choiceNumber < menuPos.Length - 1 && menulaunch)
                    choiceNumber += 1;
                else if (Utils.Down(Keys.Up) && choiceNumber > 0)
                    choiceNumber -= 1;
                else if ((Utils.Down(Keys.Up) || Utils.Down(Keys.Down)) && choiceNumber == -1 && menulaunch)
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
        static public void MainDraw(int screen_x, int screen_y, SpriteBatch sprite_batch)
        {
            for (int i = 0; i < menuPos.Length; i++)
            {
                posX = (int)LoadM.Menu.MeasureString(menuPos[i]).X;
                posY = i * 95 + screen_y / 3;

                if (i == ChoiceMainMenu(true))
                {
                    colorTextMenu = Color.Red;
                    sprite_batch.Draw(LoadM.Rack, new Vector2(screen_x / 2 + posX / 2, posY), Color.White); // Rack droit
                    sprite_batch.Draw(LoadM.Rack, new Vector2(screen_x / 2 - posX / 2 - LoadM.Rack.Width, posY), Color.White); // Rack gauche
                }
                else
                    colorTextMenu = Color.Ivory;
                sprite_batch.DrawString(LoadM.Menu, menuPos[i], new Vector2(screen_x / 2 - posX / 2 , posY), colorTextMenu);
            }
        }
    }
}
