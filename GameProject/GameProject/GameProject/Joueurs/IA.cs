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
        static private int vitesse = 6;

        static public void MovIA(Sprite Joueur, Sprite[] Enemis , Sprite[]EntitéDecors)
        {
            Vector2[] oldpos = new Vector2[Enemis.Length];
            Sprite[] entité = new Sprite[EntitéDecors.Length + 1];
            for (int i = 0; i < EntitéDecors.Length;i++)
                entité[i] = EntitéDecors[i];
            entité[entité.Length - 1] = Joueur;
            bool coldroit = false, colgauch = false , colhaut = false, colbas = false;
            bool touchJ = false, left = false,right = false,down = false,up = false;
            bool Colx = false, Coly = false, col = false;
            int compteurfinX = 0, compteurfinY = 0;
            string dx = "R", dy = "U";
                for (int j = 0; j < Enemis.Length; j++)
                {
                    if (Joueur.Position.X < Enemis[j].Position.X)
                    {
                        left = true; dx = "L";
                    }
                    else if (Joueur.Position.X > Enemis[j].Position.X)
                    {
                        right = true; dx = "R";
                    }
                    if (Joueur.Position.Y < Enemis[j].Position.Y)
                    {
                        up = true; dy = "U";
                    }
                    else if (Joueur.Position.Y > Enemis[j].Position.Y)
                    {
                        down = true; dy = "D";
                    }
                    for (int i = 0; i < vitesse; i++)
                    {
                        compteurfinX = compteurfinX * 2;
                        compteurfinY = compteurfinY * 2;
                        oldpos[j] = Enemis[j].Position;
                        coldroit = false; colgauch = false; colhaut = false; colbas = false;
                        MoteurPhysique.Col(ref coldroit, ref colgauch, ref colhaut, ref colbas, entité, Enemis[j]);
                        MoteurPhysique.ColEntre2(ref Colx, ref Coly, EntitéDecors, Joueur, Enemis[j]);
                        if (Joueur.Position.X + Joueur.Width() < Enemis[j].Position.X || Joueur.Position.X > Enemis[j].Position.X + Enemis[j].Width() || Joueur.Position.Y + Joueur.Height() < Enemis[j].Position.Y || Joueur.Position.Y > Enemis[j].Position.Y + Enemis[j].Height())
                        {
                            if (Coly && !touchJ && Joueur.Position.Y + Joueur.Height() != Enemis[j].Position.Y + Enemis[j].Height() )
                            {
                                if (up)
                                    dy = "U";
                                else
                                    dy = "D";
                                compteurfinY = 0;
                                if (dx == "R")
                                    Enemis[j].Position = new Vector2(Enemis[j].Position.X + 1, Enemis[j].Position.Y);
                                else
                                    Enemis[j].Position = new Vector2(Enemis[j].Position.X + 1, Enemis[j].Position.Y);
                                MoteurPhysique.ColEntre2(ref Colx, ref Coly, EntitéDecors, Joueur, Enemis[j]);
                                if (!Coly)
                                    compteurfinY++;
                            }
                            else if (!Colx && right && !coldroit && (compteurfinY > 2 || compteurfinY == 0))
                            {
                                Enemis[j].Position = new Vector2(Enemis[j].Position.X + 1, Enemis[j].Position.Y);
                                compteurfinY = 0;
                            }
                            else if (!Colx && left && !colgauch && (compteurfinY > 2 || compteurfinY == 0))
                            {
                                Enemis[j].Position = new Vector2(Enemis[j].Position.X - 1, Enemis[j].Position.Y);
                                compteurfinY = 0;
                            }
                            MoteurPhysique.ColEntre2(ref Colx, ref Coly, EntitéDecors, Joueur, Enemis[j]);
                            if (Colx && !touchJ && Joueur.Position.X + Joueur.Width() != Enemis[j].Position.X + Enemis[j].Width())
                            {
                                if (left)
                                    dy = "L";
                                else
                                    dy = "R";
                                compteurfinX = 0;
                                if (dy == "D")
                                    Enemis[j].Position = new Vector2(Enemis[j].Position.X, Enemis[j].Position.Y + 1);
                                else
                                    Enemis[j].Position = new Vector2(Enemis[j].Position.X, Enemis[j].Position.Y - 1);
                                MoteurPhysique.ColEntre2(ref Colx, ref Coly, EntitéDecors, Joueur, Enemis[j]);
                                if (!Colx)
                                    compteurfinX++;
                            }
                            if (!Coly && down && !colbas && (compteurfinX > 2 || compteurfinX == 0))
                            {
                                Enemis[j].Position = new Vector2(Enemis[j].Position.X, Enemis[j].Position.Y + 1);
                                compteurfinX = 0;
                            }
                            else if (!Coly && up && !colhaut && (compteurfinX > 2 || compteurfinX == 0))
                            {
                                Enemis[j].Position = new Vector2(Enemis[j].Position.X, Enemis[j].Position.Y - 1);
                                compteurfinX = 0;
                            }
                        }
                        if ((Joueur.Position.X - 1 <= Enemis[j].Position.X + Enemis[j].Width() && Enemis[j].Position.X <= Joueur.Position.X + Joueur.Height() + 1) && (Joueur.Position.Y - 1 <= Enemis[j].Position.Y + Enemis[j].Height() && Enemis[j].Position.Y <= Joueur.Position.Y + Joueur.Height() + 1))
                            touchJ = true;
                         /*if ((Joueur.Position.X - 1 <= Enemis[j].Position.X + Enemis[j].Width() && Enemis[j].Position.X <= Joueur.Position.X + Joueur.Height() + 1) && (Joueur.Position.Y - 1 <= Enemis[j].Position.Y + Enemis[j].Height() && Enemis[j].Position.Y <= Joueur.Position.Y + Joueur.Height() + 1))
                            touchJ = true;
                         if (!coldroit && colhaut && !touchJ  && Joueur.Position.Y != Enemis[j].Position.Y && Coly)
                             Enemis[j].Position = new Vector2(Enemis[j].Position.X + 1, Enemis[j].Position.Y);
                         else if (!colgauch && colbas && !touchJ  && Joueur.Position.Y + Joueur.Height() != Enemis[j].Position.Y + Enemis[j].Height() && Coly)
                             Enemis[j].Position = new Vector2(Enemis[j].Position.X - 1, Enemis[j].Position.Y);
                         else if (right && ! coldroit)
                             Enemis[j].Position = new Vector2(Enemis[j].Position.X + 1, Enemis[j].Position.Y);
                         else if (left && !colgauch)
                             Enemis[j].Position = new Vector2(Enemis[j].Position.X - 1, Enemis[j].Position.Y);
                         MoteurPhysique.Col(ref coldroit, ref colgauch, ref colhaut, ref colbas, entité, Enemis[j]);
                         MoteurPhysique.ColEntre2(ref Colx, ref Coly, EntitéDecors, Joueur, Enemis[j]);
                         if (!colhaut && coldroit && !touchJ  && Joueur.Position.X + Joueur.Width() != Enemis[j].Position.X + Enemis[j].Width() && Colx)
                             Enemis[j].Position = new Vector2(Enemis[j].Position.X, Enemis[j].Position.Y - 1);
                         else if (!colbas && colgauch && !touchJ   && Joueur.Position.X != Enemis[j].Position.X && Colx)
                             Enemis[j].Position = new Vector2(Enemis[j].Position.X, Enemis[j].Position.Y + 1);
                         else if (up && !colhaut)
                             Enemis[j].Position = new Vector2(Enemis[j].Position.X, Enemis[j].Position.Y - 1);
                         else if (down && !colbas)
                             Enemis[j].Position = new Vector2(Enemis[j].Position.X, Enemis[j].Position.Y + 1);*/
                    }

                }
            if (touchJ)
                MainGame.life--;
        }
    }
}
