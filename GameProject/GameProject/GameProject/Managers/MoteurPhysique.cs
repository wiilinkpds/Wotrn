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

        static public void Colision(Sprite[] TextTab, Sprite TextJ, Sprite Back)
        {
            bool saut = false;
            for (int j = 0; j < vitesse; j++)
            {
                bool ColDroit = false, ColGauche = false, ColHaut = false, ColBas = false;
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


                if (Utils.Down(Keys.Up) && !ColHaut)
                    DeplacementDecor(TextTab, Keys.Up, Back);
                //TextJ.Position = new Vector2(TextJ.Position.X, TextJ.Position.Y - vitesse);
                if (Utils.Down(Keys.Down) && !ColBas)
                    DeplacementDecor(TextTab, Keys.Down, Back);
                //TextJ.Position = new Vector2(TextJ.Position.X, TextJ.Position.Y + vitesse);
                if (Utils.Down(Keys.Right) && !ColDroit)
                    DeplacementDecor(TextTab, Keys.Right, Back);
                //TextJ.Position = new Vector2(TextJ.Position.X + vitesse, TextJ.Position.Y);
                if (Utils.Down(Keys.Left) && !ColGauche)
                    DeplacementDecor(TextTab, Keys.Left, Back);
                //TextJ.Position = new Vector2(TextJ.Position.X - vitesse, TextJ.Position.Y);

                if (Utils.Down(Keys.Space))
                {
                    saut = true;
                    DeplacementDecor(TextTab, Keys.Up, Back);
                }
            }
            if (saut)
                for (int i = 0; i < vitesse;i++)
                    DeplacementDecor(TextTab, Keys.Down, Back);
        }
        static private void DeplacementDecor(Sprite[] SpritTab, Keys Key, Sprite back)
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
            if (Key == Keys.Up)
                back.Position = new Vector2(back.Position.X, back.Position.Y + 1);
            if (Key == Keys.Down)
                back.Position = new Vector2(back.Position.X, back.Position.Y - 1);
            if (Key == Keys.Right)
                back.Position = new Vector2(back.Position.X - 1, back.Position.Y);
            if (Key == Keys.Left)
                back.Position = new Vector2(back.Position.X + 1, back.Position.Y);
        }

        static public void ColisionIa (Sprite[] Entité, Sprite IA, string direct)
        {
            bool ColDroit = false, ColGauche = false, ColHaut = false, ColBas = false;
            for (int i = 0; i < Entité.Length; i++)
            {
                /*Verifie respectivement si le joueurs est en contact avec un element du décors a Droite, a Gauche, au dessus ou en dessous de lui 
                 Si c'est le cas Col... est true */
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
        }
    }
}