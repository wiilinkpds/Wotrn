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
            if (Utils.Down(Keys.Up))
                {
                for (int i = 0; i < VectTab.Length; i++)
                    {
                        if (VectTab[i].Y + TextTab[i].Height() < VectJ.Y || VectJ.Y + TextJ.Height < VectTab[i].Y)
                            VectJ.Y = VectJ.Y - vitesse;
                     }
                }
            if (Utils.Down(Keys.Down))
            {
                for (int i = 0; i < VectTab.Length; i++)
                {
                    if (VectJ.Y + TextJ.Height < VectTab[i].Y || VectTab[i].Y + TextTab[i].Height() < VectJ.Y)
                        VectJ.Y = VectJ.Y + vitesse;
                }
            }
            if (Utils.Down(Keys.Right))
            {
                for (int i = 0; i < VectTab.Length; i++)
                {
                    if (VectTab[i].X < VectJ.X + TextJ.Width || VectTab[i].X < VectJ.X)
                        VectJ.X = VectJ.X +vitesse;
                }
            }
            if (Utils.Down(Keys.Left))
            {
                for (int i = 0; i < VectTab.Length; i++)
                {
                    if (VectTab[i].X < VectJ.X + TextJ.Width || VectTab[i].X + TextTab[i].Width() > VectJ.X)
                        VectJ.X = VectJ.X - vitesse;
                }
            }
            return VectJ;
        }
    }
}
