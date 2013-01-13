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
            for (int j = 0; j < vitesse; j++)
            {
                bool ColDroit = false, ColGauche = false, ColHaut = false, ColBas = false;

                Col(ref ColDroit, ref ColGauche, ref ColHaut, ref ColBas, TextTab, TextJ);
                Col(ref ColDroit, ref ColGauche, ref ColHaut, ref ColBas, Enemis, TextJ);

                if (Utils.Down(Keys.Up) && !ColHaut)
                    DeplacementDecor(TextTab, Keys.Up, Back, Enemis);
                if (Utils.Down(Keys.Down) && !ColBas)
                    DeplacementDecor(TextTab, Keys.Down, Back, Enemis);
                if (Utils.Down(Keys.Right) && !ColDroit)
                    DeplacementDecor(TextTab, Keys.Right, Back, Enemis);
                if (Utils.Down(Keys.Left) && !ColGauche)
                    DeplacementDecor(TextTab, Keys.Left, Back, Enemis);
            }
        }

        // Cette fonction va comme son nom l'indique déplacer le decors en laissant le joueur imobile (il déplace aussi les enemis)
        static private void DeplacementDecor(Sprite[] SpritTab, Keys Key, Sprite back, Sprite[] Enemis)
        {
            for (int i = 0; i < SpritTab.Length; i++)
            {  
                //Deplace le décors
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
                //Deplace les ennemis
                if (Key == Keys.Up)
                    Enemis[i].Position = new Vector2(Enemis[i].Position.X, Enemis[i].Position.Y + 1);
                if (Key == Keys.Down)
                    Enemis[i].Position = new Vector2(Enemis[i].Position.X, Enemis[i].Position.Y - 1);
                if (Key == Keys.Right)
                    Enemis[i].Position = new Vector2(Enemis[i].Position.X - 1, Enemis[i].Position.Y);
                if (Key == Keys.Left)
                    Enemis[i].Position = new Vector2(Enemis[i].Position.X + 1, Enemis[i].Position.Y);
            }

            //Deplace le fond
            if (Key == Keys.Up)  
                back.Position = new Vector2(back.Position.X, back.Position.Y + 1);
            if (Key == Keys.Down)
                back.Position = new Vector2(back.Position.X, back.Position.Y - 1);
            if (Key == Keys.Right)
                back.Position = new Vector2(back.Position.X - 1, back.Position.Y);
            if (Key == Keys.Left)
                back.Position = new Vector2(back.Position.X + 1, back.Position.Y);
        }

        // Verifie si le Perso est en colision avec quelque chose a modifie les bools en fonction d'ou il est en colision
        static public void Col(ref bool ColDroit, ref bool ColGauche, ref bool ColHaut, ref bool ColBas, Sprite[] Entité, Sprite Perso)
        {
            for (int i = 0; i < Entité.Length; i++)
            {
                // Verifie respectivement Si le perso est en contact avec un element du décors a Droite, a Gauche, au dessus ou en dessous de lui alors Col... True
                if (Perso.Position.Y > Entité[i].Position.Y - Perso.Height() && Perso.Position.Y < Entité[i].Position.Y + Entité[i].Height())
                {
                    if (Perso.Position.X == Entité[i].Position.X - Perso.Width())
                        ColDroit = true;
                    if (Perso.Position.X == Entité[i].Position.X + Entité[i].Width())
                        ColGauche = true;
                }
                if (Perso.Position.X > Entité[i].Position.X - Perso.Width() && Perso.Position.X < Entité[i].Position.X + Entité[i].Width())
                {
                    if (Perso.Position.Y == Entité[i].Position.Y - Perso.Height())
                        ColBas = true;
                    if (Perso.Position.Y == Entité[i].Position.Y + Entité[i].Height())
                        ColHaut = true;
                }
            }
        }

        // Cette fonction va parcourir tout le chemin sur X et Y que le J2 doit faire pour arriver au J1 et renvoie faux si obstacle
        static public void ColEntre2(ref bool ColX, ref bool ColY, Sprite[] Entité, Sprite J1, Sprite J2)
        {
            ColX = false; ColY = false;
            for (int i = 0; i < Entité.Length; i++)
            {
                if (J1.Position.X < J2.Position.X)
                {
                    if (J1.Position.Y < J2.Position.Y)
                    {
                        if (    J1.Position.X <= Entité[i].Position.X 
                            &&  J2.Position.X >= Entité[i].Position.X - J2.Width()
                            &&  J2.Position.Y <  Entité[i].Position.Y + Entité[i].Height()
                            &&  J2.Position.Y >  Entité[i].Position.Y - J2.Height())
                            ColX = true;
                        if (    J1.Position.Y <= Entité[i].Position.Y 
                            &&  J2.Position.Y >= Entité[i].Position.Y + Entité[i].Height()
                            &&  J2.Position.X <  Entité[i].Position.X + Entité[i].Width()
                            &&  J2.Position.X >  Entité[i].Position.X - J2.Width())
                            ColY = true;
                    }
                    else
                    {
                        if (    J1.Position.X <= Entité[i].Position.X 
                            &&  J2.Position.X >= Entité[i].Position.X - J2.Width()
                            &&  J2.Position.Y <  Entité[i].Position.Y + Entité[i].Height()
                            &&  J2.Position.Y >  Entité[i].Position.Y - J2.Height())
                            ColX = true;
                        if (    J1.Position.Y <= Entité[i].Position.Y - J1.Height() 
                            &&  J2.Position.Y >= Entité[i].Position.Y
                            &&  J2.Position.X <  Entité[i].Position.X + Entité[i].Width()
                            &&  J2.Position.X >  Entité[i].Position.X - J2.Width())
                            ColY = true;
                    }
                }
                else
                {
                    if (J1.Position.Y < J2.Position.Y)
                    {
                        if (    J1.Position.X >= Entité[i].Position.X - J1.Width() 
                            &&  J2.Position.X <= Entité[i].Position.X 
                            &&  J2.Position.Y <  Entité[i].Position.Y + Entité[i].Height()
                            &&  J2.Position.Y >  Entité[i].Position.Y - J2.Height())
                            ColX = true;
                        if (    J1.Position.Y <= Entité[i].Position.Y 
                            &&  J2.Position.Y >= Entité[i].Position.Y + Entité[i].Height()
                            &&  J2.Position.X <  Entité[i].Position.X + Entité[i].Width()
                            &&  J2.Position.X >  Entité[i].Position.X - J2.Width())
                            ColY = true;
                    }
                    else
                    {
                        if (    J1.Position.X >= Entité[i].Position.X - J1.Width() 
                            &&  J2.Position.X <= Entité[i].Position.X
                            &&  J2.Position.Y <  Entité[i].Position.Y + Entité[i].Height()
                            &&  J2.Position.Y >  Entité[i].Position.Y - J2.Height())
                            ColX = true;
                        if (    J1.Position.Y >= Entité[i].Position.Y - J1.Height() 
                            &&  J2.Position.Y <= Entité[i].Position.Y
                            &&  J2.Position.X <  Entité[i].Position.X + Entité[i].Width()
                            &&  J2.Position.X >  Entité[i].Position.X - J2.Width())
                            ColY = true;
                    }
                }
            }
        }
    }
}