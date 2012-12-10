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

        static public Vector2 Colision (Vector2[] VectTab,Sprite[] TextTab,Vector2 VectJ,Texture2D TextJ)
        {
            bool ColDroit = false, ColGauche = false , ColHaut = false , ColBas = false;
            for (int i = 0; i < VectTab.Length; i++)
            {
                /* Verifie respectivement si le joueurs est en contact avec un element du décors a Droite, a Gauche, au dessus ou en dessous de lui 
                 Si c'est le cas Col... est true */
                if (VectJ.X + TextJ.Width == VectTab[i].X && Vect.Y + TextJ.Height > VectTab[i].Y && Vect.Y + TextJ.Height < VectTab[i].Y + TextTab[i].Height()) 
                    ColDroit = true;
                if (VectJ.X == VectTab[i].X + VectTab[i].Width() && Vect.Y + TextJ.Height > VectTab[i].Y && Vect.Y + TextJ.Height < VectTab[i].Y + TextTab[i].Height())
                    ColGauche = true;
                if (VectJ.Y == VectTab[i].Y + VectTab[i].Height() && Vect.X > VectTab[i].X && Vect.X < VectTab[i].X + TextTab[i].Width())
                    ColHaut = true;
                if (VectJ.Y + TextJ.Height == VectTab[i].Y && Vect.X > VectTab[i].X && Vect.X < VectTab[i].X + TextTab[i].Width())
                    ColBas = true;
            }

                if (Utils.Down(Keys.Up) &&  !ColHaut)
                            VectJ.Y -= vitesse;
                if (Utils.Down(Keys.Down) && !ColBas)
                            VectJ.Y += vitesse;
                if (Utils.Down(Keys.Right) && !ColDroit)
                            VectJ.X += vitesse;
                if (Utils.Down(Keys.Left) && !ColGauche)
                            VectJ.X -= vitesse;
            return VectJ;
        }
    }
}
