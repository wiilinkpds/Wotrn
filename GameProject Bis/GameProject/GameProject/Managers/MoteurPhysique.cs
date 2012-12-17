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
using GameProject.Managers;

namespace GameProject.Managers
{
    public class MoteurPhysique
    {
        static private int vitesse = 1;

        static public void Colision (Sprite[] TextTab,Sprite TextJ)
        {
            bool ColDroit = false, ColGauche = false , ColHaut = false , ColBas = false;
            for (int i = 0; i < TextTab.Length; i++)
            {
                /*Verifie respectivement si le joueurs est en contact avec un element du décors a Droite, a Gauche, au dessus ou en dessous de lui 
                 Si c'est le cas Col... est true */
                if (TextJ.Position.X + TextJ.Width() == TextTab[i].Position.X && TextJ.Position.Y + TextJ.Height() > TextTab[i].Position.Y && TextJ.Position.Y < TextTab[i].Position.Y + TextTab[i].Height()) 
                    ColDroit = true;
                if (TextJ.Position.X == TextTab[i].Position.X + TextTab[i].Width() && TextJ.Position.Y + TextJ.Height() > TextTab[i].Position.Y && TextJ.Position.Y < TextTab[i].Position.Y + TextTab[i].Height())
                    ColGauche = true;
                if (TextJ.Position.Y == TextTab[i].Position.Y + TextTab[i].Height() && TextJ.Position.X + TextJ.Width() > TextTab[i].Position.X && TextJ.Position.X < TextTab[i].Position.X + TextTab[i].Width())
                    ColHaut = true;
                if (TextJ.Position.Y + TextJ.Height() == TextTab[i].Position.Y && TextJ.Position.X + TextJ.Width() > TextTab[i].Position.X && TextJ.Position.X < TextTab[i].Position.X + TextTab[i].Width())
                    ColBas = true;
            }

                if (Utils.Down(Keys.Up) &&  !ColHaut)
                            TextJ.Position = new Vector2 (TextJ.Position.X ,TextJ.Position.Y - vitesse);
                if (Utils.Down(Keys.Down) && !ColBas)
                            TextJ.Position = new Vector2(TextJ.Position.X, TextJ.Position.Y + vitesse);
                if (Utils.Down(Keys.Right) && !ColDroit)
                            TextJ.Position = new Vector2(TextJ.Position.X + vitesse, TextJ.Position.Y);
                if (Utils.Down(Keys.Left) && !ColGauche)
                            TextJ.Position = new Vector2(TextJ.Position.X - vitesse, TextJ.Position.Y);
            
        }
    }
}
