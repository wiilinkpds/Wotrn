﻿using System;
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

        static public void Colision(Sprite[] TextTab, Sprite TextJ, Sprite Back, Sprite[] Enemis)
        {
            for (int j = 0; j < MainGame.VitesseJoueur; j++)
            {
                bool ColDroit = false, ColGauche = false, ColHaut = false, ColBas = false;
                Col(ref ColDroit, ref ColGauche, ref ColHaut, ref ColBas, TextTab, TextJ);
                Col(ref ColDroit, ref ColGauche, ref ColHaut, ref ColBas, Enemis, TextJ);

                if (Utils.Down(Keys.Up) && !ColHaut)
                    TextJ.Position = new Vector2(TextJ.Position.X, TextJ.Position.Y - 1);
                if (Utils.Down(Keys.Down) && !ColBas)
                    TextJ.Position = new Vector2(TextJ.Position.X, TextJ.Position.Y + 1);
                if (Utils.Down(Keys.Right) && !ColDroit)
                    TextJ.Position = new Vector2(TextJ.Position.X + 1, TextJ.Position.Y);
                if (Utils.Down(Keys.Left) && !ColGauche)
                    TextJ.Position = new Vector2(TextJ.Position.X - 1, TextJ.Position.Y);
            }  
        }

        static public void Col(ref bool ColDroit, ref bool ColGauche, ref bool ColHaut, ref bool ColBas, Sprite[] Entité, Sprite Perso)
        {
            if (Perso.rectangleColision.Top == Decors.Decor.backRectangle.Top)
                ColHaut = true;
            else if (Perso.rectangleColision.Bottom == Decors.Decor.backRectangle.Bottom)
                ColBas = true;
            if (Perso.rectangleColision.Right == Decors.Decor.backRectangle.Right)
                ColDroit = true;
            else if (Perso.rectangleColision.Left == Decors.Decor.backRectangle.Left)
                ColGauche = true;
            /* Verifie si le Perso est en colision avec quelque chose a modifie les bools en fonction d'ou il est en colision */
            for (int i = 0; i < Entité.Length; i++)
            {
                /*Verifie respectivement si le perso est en contact avec un element du décors a Droite, a Gauche, au dessus ou en dessous de lui 
                 Si c'est le cas Col... est true */
                if (Perso.rectangleColision.Right == Entité[i].rectangleColision.Left && Perso.rectangleColision.Bottom > Entité[i].rectangleColision.Top && Perso.rectangleColision.Top < Entité[i].rectangleColision.Bottom)
                    ColDroit = true;
                if (Perso.rectangleColision.Left == Entité[i].rectangleColision.Right && Perso.rectangleColision.Bottom > Entité[i].rectangleColision.Top && Perso.rectangleColision.Top < Entité[i].rectangleColision.Bottom)
                    ColGauche = true;
                if (Perso.rectangleColision.Top == Entité[i].rectangleColision.Bottom && Perso.rectangleColision.Right > Entité[i].rectangleColision.Left && Perso.rectangleColision.Left < Entité[i].rectangleColision.Right)
                    ColHaut = true;
                if (Perso.rectangleColision.Bottom == Entité[i].rectangleColision.Top && Perso.rectangleColision.Right > Entité[i].rectangleColision.Left && Perso.rectangleColision.Left < Entité[i].rectangleColision.Right)
                    ColBas = true;
            }
        }

        static public void ColEntre2(ref bool ColX, ref bool ColY, Sprite[] Entité, Sprite J1, Sprite J2)
        {
            /* Cette fonction vas parcourir tous le chemin sur X et Y que le J2 doit faire pour arrivé au J1
             Si il rencontre quelque chose sur le chemin pour allez a la position du J1 en X colX devient faux de même pour Y*/
            ColX = false; ColY = false;
                for (int i = 0; i < Entité.Length; i++)
                {
                    if (J1.rectangleColision.Left < J2.rectangleColision.Left)
                    {   
                        if (J1.rectangleColision.Top < J2.rectangleColision.Top)
                        {
                            if (J1.rectangleColision.Left <= Entité[i].rectangleColision.Left && Entité[i].rectangleColision.Left <= J2.rectangleColision.Right && J2.rectangleColision.Top < Entité[i].rectangleColision.Bottom && J2.rectangleColision.Bottom > Entité[i].rectangleColision.Top)
                                ColX = true;
                            if (J1.rectangleColision.Top <= Entité[i].rectangleColision.Top && Entité[i].rectangleColision.Bottom <= J2.rectangleColision.Top && J2.rectangleColision.Left < Entité[i].rectangleColision.Right && J2.rectangleColision.Right > Entité[i].rectangleColision.Left)
                                ColY = true;
                        }
                        else
                        {
                            if (J1.rectangleColision.Left <= Entité[i].rectangleColision.Left && Entité[i].rectangleColision.Left <= J2.rectangleColision.Right && J2.rectangleColision.Top < Entité[i].rectangleColision.Bottom && J2.rectangleColision.Bottom > Entité[i].rectangleColision.Top)
                                ColX = true;
                            if (J1.rectangleColision.Bottom >= Entité[i].rectangleColision.Top && Entité[i].rectangleColision.Top >= J2.rectangleColision.Top && J2.rectangleColision.Left < Entité[i].rectangleColision.Right && J2.rectangleColision.Right > Entité[i].rectangleColision.Left)
                                ColY = true;
                        }
                    }
                    else
                    {
                        if (J1.rectangleColision.Top < J2.rectangleColision.Top)
                        {
                            if (J1.rectangleColision.Right >= Entité[i].rectangleColision.Left && Entité[i].rectangleColision.Left >= J2.rectangleColision.Left && J2.rectangleColision.Top < Entité[i].rectangleColision.Bottom && J2.rectangleColision.Bottom > Entité[i].rectangleColision.Top)
                                ColX = true;
                            if (J1.rectangleColision.Top <= Entité[i].rectangleColision.Top && Entité[i].rectangleColision.Bottom < J2.rectangleColision.Top && J2.rectangleColision.Left < Entité[i].rectangleColision.Right && J2.rectangleColision.Right > Entité[i].rectangleColision.Left)
                                ColY = true;
                        }
                        else
                        {
                            if (J1.rectangleColision.Right >= Entité[i].rectangleColision.Left && Entité[i].rectangleColision.Left >= J2.rectangleColision.Left && J2.rectangleColision.Top < Entité[i].rectangleColision.Bottom && J2.rectangleColision.Bottom > Entité[i].rectangleColision.Top)
                                ColX = true;
                            if (J1.rectangleColision.Bottom >= Entité[i].rectangleColision.Top && Entité[i].rectangleColision.Top >= J2.rectangleColision.Top && J2.rectangleColision.Left < Entité[i].rectangleColision.Right && J2.rectangleColision.Right > Entité[i].rectangleColision.Left)
                                ColY = true;
                        }
                    }
                }
        }
    }
}