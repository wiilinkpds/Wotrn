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
using GameProject.Managers;

namespace GameProject.Joueurs
{
    public class IA
    {
        static private float vitesse = 2f;

        static public void MovIA(Joueur Joueur, Personnage[] Enemis , Sprite[]EntitéDecors,GameTime gameTime) //Pas encore au point
        {
            if (UtilsFun.Utils.Down(Keys.Tab) && Joueur.Mana > 0)
            {
                vitesse = 0f;
                Joueur.Mana--;
            }
            else
                vitesse = 2f;
            /* Cette fonction va gerer les mouvements de l'ia en evitant les obstacles */
            Vector2[] oldpos = new Vector2[Enemis.Length]; //Inutile pour le moment
            Sprite[] entité = new Sprite[EntitéDecors.Length + 1]; // Créer un nouveau tableau qui va contenir le joueurs permettant de gerer les collisions entres les enemis et le joueurs
            for (int i = 0; i < EntitéDecors.Length;i++)
                entité[i] = EntitéDecors[i];
            entité[entité.Length - 1] = Joueur; //On ajoute le joueur en derniere place
            bool coldroit = false, colgauch = false , colhaut = false, colbas = false; //Pleins de bool qui servent pas tous certain à supprimer.
            bool touchJ = false, left = false,right = false,down = false,up = false;
            bool Colx = false, Coly = false;
            int compteurfinX = 0, compteurfinY = 0; //Simple compteur verifiant quand on a fini dévité l'obstacle respectivement sur X et Y
            string dx = "R", dy = "U"; //Les directions que l'IA doit prendre (à changer)
                for (int j = 0; j < Enemis.Length; j++) //Parcours le tableau des enemis
                {
                    if (compteurfinY == 0)
                    {
                        if (Joueur.Position.X < Enemis[j].Position.X) //Verifie la position relative de l'enemis[j] et du joueurs
                        {
                            left = true; right = false;
                        }
                        else if (Joueur.Position.X > Enemis[j].Position.X)
                        {
                            right = true; left = false;
                        }
                    }
                    if (compteurfinX == 0)
                    {
                        if (Joueur.Position.Y < Enemis[j].Position.Y)
                        {
                            up = true; down = false;
                        }
                        else if (Joueur.Position.Y > Enemis[j].Position.Y)
                        {
                            down = true; up = false;
                        }
                    }
                    
                    for (int i = 0; i < vitesse; i++) //Répete le deplacement autant de fois que la vitesse
                    {
                        compteurfinX = compteurfinX * 2;
                        compteurfinY = compteurfinY * 2;
                        oldpos[j] = Enemis[j].Position; //Inutile
                        coldroit = false; colgauch = false; colhaut = false; colbas = false; //Initialise toutes les colisions a faux
                        MoteurPhysique.Col(ref coldroit, ref colgauch, ref colhaut, ref colbas, entité, Enemis[j]); //Verifie si l'enemis est en colision et où
                        MoteurPhysique.ColEntre2(ref Colx, ref Coly, EntitéDecors, Joueur, Enemis[j]); //Verifie si l'enemis rencontrerais quelque chose sur le chemin en X ou en Y (compliquer a expliquer un dessins serait plus simple ...)
                        if (!Joueur.rectangleColision.Intersects(Enemis[j].rectangleColision)) //Verifie si l'enemis n'est pas en contact avec le joueur
                        { //L'histoire du touche le joueurs je le changerais il y a plus simple je sais 
                            if (Coly && !touchJ && Joueur.Position.Y + Joueur.Height != Enemis[j].Position.Y + Enemis[j].Height) //Si il y a un obstacle entre l'enemis et le joueurs en Y ET que l'enemis ne touche pas le joueur ET que le joueurs et l'enemis ne sont pas au même point Y (A changer la fin aussi)
                            {
                                if (up) //Si le joueur est plus haut que l'enemis dy="U" (U = Up) respectivement dy ="D" (D = down)
                                    dy = "U";
                                else
                                    dy = "D";
                                compteurfinY = 1; //On met le compteur a 1 (A changer)
                                Enemis[j].Move(dx, gameTime);
                                //if (dx == "R") //Si R (Right) alors l'enemis se deplacement a droite sinon a gauche
                                    //Enemis[j].rectangleColision = new rectangleColision((int)Enemis[j].rectangleColision.X + 1, (int)Enemis[j].rectangleColision.Y, (int)Enemis[j].rectangleColision.Width, (int)Enemis[j].rectangleColision.Height);
                                    //Enemis[j].Position = new Vector2(Enemis[j].Position.X + 1, Enemis[j].Position.Y);
                                //else
                                    //Enemis[j].rectangleColision = new rectangleColision((int)Enemis[j].rectangleColision.X - 1, (int)Enemis[j].rectangleColision.Y, (int)Enemis[j].rectangleColision.Width, (int)Enemis[j].rectangleColision.Height);
                                    //Enemis[j].Position = new Vector2(Enemis[j].Position.X - 1, Enemis[j].Position.Y);
                                    MoteurPhysique.ColEntre2(ref Colx, ref Coly, EntitéDecors, Joueur, Enemis[j]); //On reverifie la position des 2
                                if (!Coly) //Si a ce moment la l'enemis n'est plus en colision avec un objet sur l'axe Y alors on ajoute 1 au compteur pour pouvoir bouger autre part (A changer)
                                    compteurfinY++;
                            }
                            else if (!Colx && right && !coldroit && (compteurfinY > 4 || compteurfinY == 0)) //Si pas de colision en X ET que le joueur est a droite de l'enemis ET qu'on est sortie de la boucle précedente
                            {
                                //Enemis[j].rectangleColision = new rectangleColision((int)Enemis[j].rectangleColision.X + 1, (int)Enemis[j].rectangleColision.Y, (int)Enemis[j].rectangleColision.Width, (int)Enemis[j].rectangleColision.Height); //L'enemis va à droite
                                //Enemis[j].Position = new Vector2(Enemis[j].Position.X + 1, Enemis[j].Position.Y);
                                Enemis[j].Move("R", gameTime);
                            }
                            else if (!Colx && left && !colgauch && (compteurfinY > 4 || compteurfinY == 0)) //De même que precedent mais pour la gauche
                            {
                                //Enemis[j].rectangleColision = new rectangleColision((int)Enemis[j].rectangleColision.X - 1, (int)Enemis[j].rectangleColision.Y, (int)Enemis[j].rectangleColision.Width, (int)Enemis[j].rectangleColision.Height); //L'enemis va à gauche
                                //Enemis[j].Position = new Vector2(Enemis[j].Position.X - 1, Enemis[j].Position.Y);
                                Enemis[j].Move("L", gameTime);
                            }
                            MoteurPhysique.ColEntre2(ref Colx, ref Coly, EntitéDecors, Joueur, Enemis[j]); //Verification a nouveau
                            if (Colx && !touchJ && Joueur.Position.X + Joueur.Width != Enemis[j].Position.X + Enemis[j].Width && compteurfinY == 0)
                            { //De même que pour avant mais pour aller en Haut ou en Bas
                                if (left)
                                    dx = "L";
                                else
                                    dx = "R";
                                compteurfinX = 1;
                                Enemis[j].Move(dy, gameTime);
                                //if (dy == "D")
                                    //Enemis[j].rectangleColision = new rectangleColision((int)Enemis[j].rectangleColision.X, (int)Enemis[j].rectangleColision.Y + 1, (int)Enemis[j].rectangleColision.Width, (int)Enemis[j].rectangleColision.Height);
                                    //Enemis[j].Position = new Vector2(Enemis[j].Position.X , Enemis[j].Position.Y + 1);
                                //else
                                    //Enemis[j].rectangleColision = new rectangleColision((int)Enemis[j].rectangleColision.X , (int)Enemis[j].rectangleColision.Y - 1, (int)Enemis[j].rectangleColision.Width, (int)Enemis[j].rectangleColision.Height);
                                    //Enemis[j].Position = new Vector2(Enemis[j].Position.X, Enemis[j].Position.Y - 1);
                                MoteurPhysique.ColEntre2(ref Colx, ref Coly, EntitéDecors, Joueur, Enemis[j]);
                                if (!Colx)
                                    compteurfinX++;
                            }
                            else if (!Coly && down && !colbas && (compteurfinX > 4 || compteurfinX == 0)) //De même pour déplacer le joueur en bas
                            {
                                //Enemis[j].rectangleColision = new rectangleColision((int)Enemis[j].rectangleColision.X, (int)Enemis[j].rectangleColision.Y + 1, (int)Enemis[j].rectangleColision.Width, (int)Enemis[j].rectangleColision.Height);
                                //Enemis[j].Position = new Vector2(Enemis[j].Position.X, Enemis[j].Position.Y + 1);
                                Enemis[j].Move("D", gameTime);
                            }
                            else if (!Coly && up && !colhaut && (compteurfinX > 4 || compteurfinX == 0)) //en Haut
                            {
                                //Enemis[j].rectangleColision = new rectangleColision((int)Enemis[j].rectangleColision.X, (int)Enemis[j].rectangleColision.Y - 1, (int)Enemis[j].rectangleColision.Width, (int)Enemis[j].rectangleColision.Height);
                                //Enemis[j].Position = new Vector2(Enemis[j].Position.X, Enemis[j].Position.Y - 1);
                                Enemis[j].Move("U", gameTime);
                            }
                        }
                        if (Joueur.rectangleColision.Intersects(new Rectangle(Enemis[j].rectangleColision.Left - 1, Enemis[j].rectangleColision.Top - 1, Enemis[j].rectangleColision.Width + 2, Enemis[j].rectangleColision.Height + 2)))
                            touchJ = true; //Si le joueur est en contact avec l'enemis touchJ est vrai
                    }
                }
            if (touchJ) //Si le joueur touche l'enemis alors on décremente la vie du joueur
                Joueur.Life--;
        }
    }
}
