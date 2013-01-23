using GameProject._UtilsFun;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject.Menus
{
    public class IngameM
    {
        // Initialisation
        private static bool inGameMenu, hold, noHold = true;
        private static int choiceNumber;

        private static Color colorTextMenu = Color.Ivory;
        public static readonly string[] IngameMenuPos = new[] { "Retourner sur le Jeu", "Sauvegarder", "Quitter vers le Menu Principal", "Quitter vers le Bureau" };

        // Initialisation
        static public void InitIngameMenu()
        {
            inGameMenu = false;
            choiceNumber = 0;
        }

        // Empeche le choix de se "téléporter" grace à la modification de la variable noHold.
        static public int ChoiceIngameMenu()
        {
            if (noHold)
            {
                if (Utils.Down(Keys.Down) && choiceNumber < IngameMenuPos.Length - 1 && inGameMenu)
                    choiceNumber += 1;
                else if (Utils.Down(Keys.Up) && choiceNumber > 0 && inGameMenu)
                    choiceNumber -= 1;
                noHold = false;
            }
            if (Utils.Up(Keys.Down) && Utils.Up(Keys.Up))
            {
                noHold = true;
            }
            return choiceNumber;
        }

        // Retourne un booléen, vrai si le IngameMenu est lancé.
        public static bool IngameLaunched()
        {
            if ((Utils.Down(Keys.Escape) || (Utils.Down(Keys.Enter) && choiceNumber == 0 && inGameMenu)) && !hold)
            {
                choiceNumber = 0;
                inGameMenu = !inGameMenu;
                hold = true;
            }
            else if (Utils.Up(Keys.Escape))
                hold = false;
            return inGameMenu;
        }

        // Dessine le Menu Ingame
        static public void IngameDraw(SpriteBatch sprite_batch)
        {
            for (int i = 0; i < IngameMenuPos.Length; i++)
            {
                colorTextMenu = i == ChoiceIngameMenu() ? Color.Red : Color.Ivory;
                sprite_batch.DrawString(LoadM.Menu, IngameMenuPos[i], new Vector2(350, 300 + 80 * i), colorTextMenu);
            }
        }
    }
}
