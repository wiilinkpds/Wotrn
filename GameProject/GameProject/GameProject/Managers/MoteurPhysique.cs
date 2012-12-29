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
        static private int vitesse = 8;

        static public void Colision(Sprite[] TextTab, Sprite TextJ, Sprite Back, Sprite[] Enemis)
        {
            bool saut = false;
            for (int j = 0; j < vitesse; j++)
            {
                bool ColDroit = false, ColGauche = false, ColHaut = false, ColBas = false;
                Col(ref ColDroit, ref ColGauche, ref ColHaut, ref ColBas, TextTab, TextJ);
                Col(ref ColDroit, ref ColGauche, ref ColHaut, ref ColBas, Enemis, TextJ);
               /* for (int i = 0; i < Enemis.Length; i++)
                {
                    /*Verifie respectivement si le joueurs est en contact avec un element du décors a Droite, a Gauche, au dessus ou en dessous de lui 
                     Si c'est le cas Col... est true 
                    if (TextJ.Position.X + TextJ.Width() == Enemis[i].Position.X && TextJ.Position.Y + TextJ.Height() > Enemis[i].Position.Y && TextJ.Position.Y < Enemis[i].Position.Y + Enemis[i].Height())
                        ColDroit = true;
                    if (TextJ.Position.X == Enemis[i].Position.X + Enemis[i].Width() && TextJ.Position.Y + TextJ.Height() > Enemis[i].Position.Y && TextJ.Position.Y < Enemis[i].Position.Y + Enemis[i].Height())
                        ColGauche = true;
                    if (TextJ.Position.Y == Enemis[i].Position.Y + Enemis[i].Height() && TextJ.Position.X + TextJ.Width() > Enemis[i].Position.X && TextJ.Position.X < Enemis[i].Position.X + Enemis[i].Width())
                        ColHaut = true;
                    if (TextJ.Position.Y + TextJ.Height() == Enemis[i].Position.Y && TextJ.Position.X + TextJ.Width() > Enemis[i].Position.X && TextJ.Position.X < Enemis[i].Position.X + Enemis[i].Width())
                        ColBas = true;
                }*/


                if (Utils.Down(Keys.Up) && !ColHaut)
                    DeplacementDecor(TextTab, Keys.Up, Back,Enemis);
                //TextJ.Position = new Vector2(TextJ.Position.X, TextJ.Position.Y - vitesse);
                if (Utils.Down(Keys.Down) && !ColBas)
                    DeplacementDecor(TextTab, Keys.Down, Back,Enemis);
                //TextJ.Position = new Vector2(TextJ.Position.X, TextJ.Position.Y + vitesse);
                if (Utils.Down(Keys.Right) && !ColDroit)
                    DeplacementDecor(TextTab, Keys.Right, Back,Enemis);
                //TextJ.Position = new Vector2(TextJ.Position.X + vitesse, TextJ.Position.Y);
                if (Utils.Down(Keys.Left) && !ColGauche)
                    DeplacementDecor(TextTab, Keys.Left, Back,Enemis);
                //TextJ.Position = new Vector2(TextJ.Position.X - vitesse, TextJ.Position.Y);

                if (Utils.Down(Keys.Space))
                {
                    saut = true;
                    DeplacementDecor(TextTab, Keys.Up, Back, Enemis);
                }
            }
            if (saut)
                for (int i = 0; i < vitesse;i++)
                    DeplacementDecor(TextTab, Keys.Down, Back, Enemis);
        }
        static private void DeplacementDecor(Sprite[] SpritTab, Keys Key, Sprite back, Sprite[] Enemis)
        {
            for (int i = 0; i < SpritTab.Length; i++)
            {
                if (Key == Keys.Up)
                    SpritTab[i].Position = new Vector2(SpritTab[i].Position.X, SpritTab[i].Position.Y + 1);
                if (Key == Keys.Down)
                    SpritTab[i].Position = new Vector2(SpritTab[i].Position.X, SpritTab[i].Position.Y - 1);
                if (Key == Keys.Right)
                    SpritTab[i].Position = new Vector2(SpritTab[i].Position.X - 1, SpritTab[i].Position.Y);
                if (Key == Keys.Left)
                    SpritTab[i].Position = new Vector2(SpritTab[i].Position.X + 1, SpritTab[i].Position.Y);
            }
            for (int i = 0; i < Enemis.Length; i++)
            {
                if (Key == Keys.Up)
                    Enemis[i].Position = new Vector2(Enemis[i].Position.X, Enemis[i].Position.Y + 1);
                if (Key == Keys.Down)
                    Enemis[i].Position = new Vector2(Enemis[i].Position.X, Enemis[i].Position.Y - 1);
                if (Key == Keys.Right)
                    Enemis[i].Position = new Vector2(Enemis[i].Position.X - 1, Enemis[i].Position.Y);
                if (Key == Keys.Left)
                    Enemis[i].Position = new Vector2(Enemis[i].Position.X + 1, Enemis[i].Position.Y);
            }
            if (Key == Keys.Up)
                back.Position = new Vector2(back.Position.X, back.Position.Y + 1);
            if (Key == Keys.Down)
                back.Position = new Vector2(back.Position.X, back.Position.Y - 1);
            if (Key == Keys.Right)
                back.Position = new Vector2(back.Position.X - 1, back.Position.Y);
            if (Key == Keys.Left)
                back.Position = new Vector2(back.Position.X + 1, back.Position.Y);
        }

/*        static public void ColisionIa (Sprite[] Entité, Sprite IA, string direct)
        {
            bool ColDroit = false, ColGauche = false, ColHaut = false, ColBas = false;
            for (int i = 0; i < Entité.Length; i++)
            {
                /*Verifie respectivement si l'ia est en contact avec un element du décors a Droite, a Gauche, au dessus ou en dessous de lui 
                 Si c'est le cas Col... est true
                if (IA.Position.X + IA.Width() == Entité[i].Position.X && IA.Position.Y + IA.Height() > Entité[i].Position.Y && IA.Position.Y < Entité[i].Position.Y + Entité[i].Height())
                    ColDroit = true;
                if (IA.Position.X == Entité[i].Position.X + Entité[i].Width() && IA.Position.Y + IA.Height() > Entité[i].Position.Y && IA.Position.Y < Entité[i].Position.Y + Entité[i].Height())
                    ColGauche = true;
                if (IA.Position.Y == Entité[i].Position.Y + Entité[i].Height() && IA.Position.X + IA.Width() > Entité[i].Position.X && IA.Position.X < Entité[i].Position.X + Entité[i].Width())
                    ColHaut = true;
                if (IA.Position.Y + IA.Height() == Entité[i].Position.Y && IA.Position.X + IA.Width() > Entité[i].Position.X && IA.Position.X < Entité[i].Position.X + Entité[i].Width())
                    ColBas = true;
            }
            if (direct == "U" && !ColHaut)
                IA.Position = new Vector2(IA.Position.X, IA.Position.Y - 1);
            else if (direct == "D" && !ColBas)
                IA.Position = new Vector2(IA.Position.X, IA.Position.Y + 1);
            else if (direct == "L" && !ColGauche)
                IA.Position = new Vector2(IA.Position.X - 1, IA.Position.Y);
            else if (direct == "R" && !ColDroit)
                IA.Position = new Vector2(IA.Position.X + 1, IA.Position.Y);
        }*/

        static public void Col(ref bool ColDroit, ref bool ColGauche, ref bool ColHaut, ref bool ColBas, Sprite[] Entité, Sprite Perso)
        {
            for (int i = 0; i < Entité.Length; i++)
            {
                /*Verifie respectivement si le joueurs est en contact avec un element du décors a Droite, a Gauche, au dessus ou en dessous de lui 
                 Si c'est le cas Col... est true */
                if (Perso.Position.X + Perso.Width() == Entité[i].Position.X && Perso.Position.Y + Perso.Height() > Entité[i].Position.Y && Perso.Position.Y < Entité[i].Position.Y + Entité[i].Height())
                    ColDroit = true;
                if (Perso.Position.X == Entité[i].Position.X + Entité[i].Width() && Perso.Position.Y + Perso.Height() > Entité[i].Position.Y && Perso.Position.Y < Entité[i].Position.Y + Entité[i].Height())
                    ColGauche = true;
                if (Perso.Position.Y == Entité[i].Position.Y + Entité[i].Height() && Perso.Position.X + Perso.Width() > Entité[i].Position.X && Perso.Position.X < Entité[i].Position.X + Entité[i].Width())
                    ColHaut = true;
                if (Perso.Position.Y + Perso.Height() == Entité[i].Position.Y && Perso.Position.X + Perso.Width() > Entité[i].Position.X && Perso.Position.X < Entité[i].Position.X + Entité[i].Width())
                    ColBas = true;
            }
        }

        static public void ColEntre2(ref bool ColX, ref bool ColY, Sprite[] Entité, Sprite J1, Sprite J2)
        {
            ColX = false; ColY = false;
                for (int i = 0; i < Entité.Length; i++)
                {
                    if (J1.Position.X < J2.Position.X)
                    {   
                        if (J1.Position.Y < J2.Position.Y)
                        {
                            if (J1.Position.X <= Entité[i].Position.X && Entité[i].Position.X <= J2.Position.X + J2.Width() && J2.Position.Y < Entité[i].Position.Y + Entité[i].Height() && J2.Position.Y + J2.Height() > Entité[i].Position.Y)
                                ColX = true;
                            if (J1.Position.Y <= Entité[i].Position.Y && Entité[i].Position.Y + Entité[i].Height() <= J2.Position.Y&& J2.Position.X < Entité[i].Position.X + Entité[i].Width() && J2.Position.X + J2.Width() > Entité[i].Position.X)
                                ColY = true;
                        }
                        else
                        {
                            if (J1.Position.X <= Entité[i].Position.X && Entité[i].Position.X <= J2.Position.X + J2.Width() && J2.Position.Y < Entité[i].Position.Y + Entité[i].Height() && J2.Position.Y + J2.Height() > Entité[i].Position.Y)
                                ColX = true;
                            if (J1.Position.Y + J1.Height() >= Entité[i].Position.Y && Entité[i].Position.Y >= J2.Position.Y && J2.Position.X < Entité[i].Position.X + Entité[i].Width() && J2.Position.X + J2.Width() > Entité[i].Position.X)
                                ColY = true;
                        }
                    }
                    else
                    {
                        if (J1.Position.Y < J2.Position.Y)
                        {
                            if (J1.Position.X + J1.Width() >= Entité[i].Position.X && Entité[i].Position.X >= J2.Position.X && J2.Position.Y < Entité[i].Position.Y + Entité[i].Height() && J2.Position.Y + J2.Height() > Entité[i].Position.Y)
                                ColX = true;
                            if (J1.Position.Y <= Entité[i].Position.Y && Entité[i].Position.Y + Entité[i].Height() < J2.Position.Y && J2.Position.X < Entité[i].Position.X + Entité[i].Width() && J2.Position.X + J2.Width() > Entité[i].Position.X)
                                ColY = true;
                        }
                        else
                        {
                            if (J1.Position.X + J1.Width() >= Entité[i].Position.X && Entité[i].Position.X >= J2.Position.X && J2.Position.Y < Entité[i].Position.Y + Entité[i].Height() && J2.Position.Y + J2.Height() > Entité[i].Position.Y)
                                ColX = true;
                            if (J1.Position.Y + J1.Height() >= Entité[i].Position.Y && Entité[i].Position.Y >= J2.Position.Y && J2.Position.X < Entité[i].Position.X + Entité[i].Width() && J2.Position.X + J2.Width() > Entité[i].Position.X)
                                ColY = true;
                        }
                    }
                }
        }
    }
}