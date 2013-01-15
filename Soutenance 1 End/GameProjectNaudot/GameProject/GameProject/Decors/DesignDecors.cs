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
                    Entite[i].LoadContent(content, "Sprites/Arbrebeta");
            }
            // Decor 2 : Axe d'arbres
            else
            {
                Entite = new Sprite[50];
                Back.LoadContent(content, "Sprites/BackGrounds/Fond2");

                for (int i = 0; i < Entite.Length / 2; i++)
                {
                    Entite[i] = new Sprite();
                    Entite[i].Initialize(new Vector2(80 * i + PosDepart.X, PosDepart.Y));
                }
                for (int i = 0; i < Entite.Length / 2; i++)
                {
                    Entite[i + Entite.Length / 2] = new Sprite();
                    Entite[i + Entite.Length / 2].Initialize(new Vector2(PosDepart.X, 80 * i + PosDepart.Y));
                }
                for (int i = 0; i < Entite.Length; i++)
                    Entite[i].LoadContent(content, "Sprites/Arbrebeta");
            }
        }
    }
}
