using GameProject._UtilsFun;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameProject.Managers
{
    public class MoteurPhysique
    {
        static public void Colision(Sprite[] TextTab, Personnage joueur, Sprite Back, Sprite[] Enemis, GameTime gameTime)
        {
            float vitesse = joueur.Vitesse;

            //Sprint 
            if (Utils.Down(Keys.Space) && vitesse < joueur.Vitesse + 1f && joueur.Fatigue > 0 && (Utils.Down(Keys.Left) || Utils.Down(Keys.Right) || Utils.Down(Keys.Up) || Utils.Down(Keys.Down)))
            {
                vitesse += 1f;
                joueur.Fatigue--;
            }
            else if (Utils.Up(Keys.Space))
                vitesse = joueur.Vitesse;

            for (int j = 0; j < vitesse; j++)
            {
                bool ColDroit = false, ColGauche = false, ColHaut = false, ColBas = false;
                Col(ref ColDroit, ref ColGauche, ref ColHaut, ref ColBas, TextTab, joueur);
                Col(ref ColDroit, ref ColGauche, ref ColHaut, ref ColBas, Enemis, joueur);

                //Deplacement du joueur avec animation
                if (Utils.Down(Keys.Up))
                {
                    if (!ColHaut)
                        joueur.Move("U", gameTime);
                    else
                        joueur.UpdateSetStateAnimation(0, 3);
                }
                else if (Utils.Down(Keys.Down))
                {
                    if (!ColBas)
                        joueur.Move("D", gameTime);
                    else
                        joueur.UpdateSetStateAnimation(0, 0);
                }
                else if (Utils.Down(Keys.Right))
                {
                    if (!ColDroit)
                        joueur.Move("R", gameTime);
                    else
                        joueur.UpdateSetStateAnimation(0, 2);
                }
                else if (Utils.Down(Keys.Left))
                {
                    if (!ColGauche)
                        joueur.Move("L", gameTime);
                    else
                        joueur.UpdateSetStateAnimation(0, 1);
                }
                else
                    joueur.UpdateSetStateAnimation(0);
            }  
        }

        static public void Col(ref bool ColDroit, ref bool ColGauche, ref bool ColHaut, ref bool ColBas, Sprite[] Entité, Sprite Perso)
        {
            if (Perso.RectangleColision.Top == Decors.Decor.BackRectangle.Top)
                ColHaut = true;
            else if (Perso.RectangleColision.Bottom == Decors.Decor.BackRectangle.Bottom)
                ColBas = true;
            if (Perso.RectangleColision.Right == Decors.Decor.BackRectangle.Right)
                ColDroit = true;
            else if (Perso.RectangleColision.Left == Decors.Decor.BackRectangle.Left)
                ColGauche = true;
            /* Verifie si le Perso est en colision avec quelque chose a modifie les bools en fonction d'ou il est en colision */
            for (int i = 0; i < Entité.Length; i++)
            {
                /*Verifie respectivement si le perso est en contact avec un element du décors a Droite, a Gauche, au dessus ou en dessous de lui 
                 Si c'est le cas Col... est true */
                if (Perso.RectangleColision.Right == Entité[i].RectangleColision.Left && Perso.RectangleColision.Bottom > Entité[i].RectangleColision.Top && Perso.RectangleColision.Top < Entité[i].RectangleColision.Bottom)
                    ColDroit = true;
                if (Perso.RectangleColision.Left == Entité[i].RectangleColision.Right && Perso.RectangleColision.Bottom > Entité[i].RectangleColision.Top && Perso.RectangleColision.Top < Entité[i].RectangleColision.Bottom)
                    ColGauche = true;
                if (Perso.RectangleColision.Top == Entité[i].RectangleColision.Bottom && Perso.RectangleColision.Right > Entité[i].RectangleColision.Left && Perso.RectangleColision.Left < Entité[i].RectangleColision.Right)
                    ColHaut = true;
                if (Perso.RectangleColision.Bottom == Entité[i].RectangleColision.Top && Perso.RectangleColision.Right > Entité[i].RectangleColision.Left && Perso.RectangleColision.Left < Entité[i].RectangleColision.Right)
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
                    if (J1.RectangleColision.Left < J2.RectangleColision.Left)
                    {   
                        if (J1.RectangleColision.Top < J2.RectangleColision.Top)
                        {
                            if (J1.RectangleColision.Left < Entité[i].RectangleColision.Left && Entité[i].RectangleColision.Left < J2.RectangleColision.Right && J2.RectangleColision.Top < Entité[i].RectangleColision.Bottom && J2.RectangleColision.Bottom > Entité[i].RectangleColision.Top)
                                ColX = true;
                            if (J1.RectangleColision.Top < Entité[i].RectangleColision.Top && Entité[i].RectangleColision.Bottom < J2.RectangleColision.Top && J2.RectangleColision.Left < Entité[i].RectangleColision.Right && J2.RectangleColision.Right > Entité[i].RectangleColision.Left)
                                ColY = true;
                        }
                        else
                        {
                            if (J1.RectangleColision.Left < Entité[i].RectangleColision.Left && Entité[i].RectangleColision.Left < J2.RectangleColision.Right && J2.RectangleColision.Top < Entité[i].RectangleColision.Bottom && J2.RectangleColision.Bottom > Entité[i].RectangleColision.Top)
                                ColX = true;
                            if (J1.RectangleColision.Bottom > Entité[i].RectangleColision.Top && Entité[i].RectangleColision.Top > J2.RectangleColision.Top && J2.RectangleColision.Left < Entité[i].RectangleColision.Right && J2.RectangleColision.Right > Entité[i].RectangleColision.Left)
                                ColY = true;
                        }
                    }
                    else
                    {
                        if (J1.RectangleColision.Top < J2.RectangleColision.Top)
                        {
                            if (J1.RectangleColision.Right > Entité[i].RectangleColision.Left && Entité[i].RectangleColision.Left > J2.RectangleColision.Left && J2.RectangleColision.Top < Entité[i].RectangleColision.Bottom && J2.RectangleColision.Bottom > Entité[i].RectangleColision.Top)
                                ColX = true;
                            if (J1.RectangleColision.Top < Entité[i].RectangleColision.Top && Entité[i].RectangleColision.Bottom < J2.RectangleColision.Top && J2.RectangleColision.Left < Entité[i].RectangleColision.Right && J2.RectangleColision.Right > Entité[i].RectangleColision.Left)
                                ColY = true;
                        }
                        else
                        {
                            if (J1.RectangleColision.Right >= Entité[i].RectangleColision.Left && Entité[i].RectangleColision.Left >= J2.RectangleColision.Left && J2.RectangleColision.Top < Entité[i].RectangleColision.Bottom && J2.RectangleColision.Bottom > Entité[i].RectangleColision.Top)
                                ColX = true;
                            if (J1.RectangleColision.Bottom >= Entité[i].RectangleColision.Top && Entité[i].RectangleColision.Top >= J2.RectangleColision.Top && J2.RectangleColision.Left < Entité[i].RectangleColision.Right && J2.RectangleColision.Right > Entité[i].RectangleColision.Left)
                                ColY = true;
                        }
                    }
                }
        }
    }
}