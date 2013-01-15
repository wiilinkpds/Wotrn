using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameProject.Managers;

namespace GameProject.Decors
{
    public class DesignDecors
    {
        static public void Decors(ContentManager content, Sprite Back, out Sprite[] Entite, int numbDecor, Vector2 PosDepart) //Definie les caracteristiques du decor choisi
        {
            Back.Initialize(Vector2.Zero + PosDepart);
            Back.LoadContent(content, "Sprites/BackGrounds/Fond2");
            // Decor 1 : Arbres en Diagonales
            if (numbDecor == 1)
            {
                Entite = new Sprite[15];
                Back.LoadContent(content, "Sprites/BackGrounds/Fond2");

                for (int i = 0; i < Entite.Length; i++)
                {
                    Entite[i] = new Sprite();
                    Entite[i].Initialize(new Vector2(80 * i) + PosDepart);
                }
                for (int i = 0; i < Entite.Length; i++)
                    Entite[i].LoadContent(content, "Sprites/Decors/Arbrebeta");
            }
            // Decor 2 : Axe d'arbres
            else if (numbDecor == 2)
            {
                Entite = new Sprite[50];
                Back.LoadContent(content, "Sprites/BackGrounds/Fond2");

                for (int i = 0; i < Entite.Length / 2; i++)
                {
                    Entite[i] = new Sprite();
                    Entite[i].Initialize(new Vector2(80 * i + PosDepart.X, PosDepart.Y));
                }
                for (int i = 0; i < Entite.Length / 2 ; i++)
                {
                    Entite[i + Entite.Length / 2] = new Sprite();
                    Entite[i + Entite.Length / 2].Initialize(new Vector2(PosDepart.X, 80 * i + PosDepart.Y));
                }
                for (int i = 0; i < Entite.Length / 2; i++)
                    Entite[i].LoadContent(content, "Sprites/Decors/Arbrebeta");
                for (int i = 0; i < Entite.Length / 2; i++)
                    Entite[i + Entite.Length /2].LoadContent(content, "Sprites/Decors/cailloux");

            }
            else
            {
                Entite = new Sprite[30];
                Vector2 pos = new Vector2(MainGame.rand.Next(MainGame.ScreenX,Back.Width),MainGame.rand.Next(MainGame.ScreenY,Back.Height));
                bool posDif = false;
                Entite[0] = new Sprite();
                Entite[0].Initialize(pos);
                posDif = !(Entite[0].Position == pos);
                for (int j = 1; j < Entite.Length; j++)
                {
                    pos = new Vector2(MainGame.rand.Next(MainGame.ScreenX, Back.Width), MainGame.rand.Next(MainGame.ScreenY, Back.Height));
                    posDif = false;
                    while (!posDif)
                    {
                        pos = new Vector2(MainGame.rand.Next(MainGame.ScreenX, Back.Width), MainGame.rand.Next(MainGame.ScreenY, Back.Height));
                        for (int i = 0; i < j; i++)
                            posDif = !(Entite[i].Position == pos);
                    }
                    Entite[j] = new Sprite();
                    Entite[j].Initialize(pos);
                }
                for (int i = 0; i < Entite.Length; i++)
                {
                    if (i % 2 == 0)
                        Entite[i].LoadContent(content, "Sprites/Decors/Arbrebeta");
                    else
                        Entite[i].LoadContent(content, "Sprites/Decors/cailloux");
                }

            }           
        }
    }
}
