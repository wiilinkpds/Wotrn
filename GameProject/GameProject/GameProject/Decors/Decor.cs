using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using GameProject.Managers;

namespace GameProject.Decors
{
    public class Decor
    {
        private static Sprite Back;
        private static Sprite[] Entité;

        static public void LoadDecors(ContentManager content, int DecorNum) //Load le décors en fonction du int
        {
             Back = new Sprite();
             if (DecorNum == 1)
                 Decors1(content);
             else if (DecorNum == 2)
                 Decors2(content);
        }

        static public void DrawDecors(SpriteBatch spritebatch) //Draw le décors load dans la fonction précedente
        {
            Back.Draw(spritebatch);
            for (int i = 0; i < Entité.Length; i++)
                Entité[i].Draw(spritebatch);
        }

        static public Sprite[] DecorCol() //renvoie le tableau correspondant au entité pouvant être colisionner (sert pour le moteur physique)
        {
            return Entité;
        }

        static public Sprite back() //renvoie le fond (pas de colision) (sert pour le moteur physique)
        {
            return Back;
        }
        static private void Decors1(ContentManager content) //Definie les caractéristiques du décors 1
        {
            Back.Initialize(Vector2.Zero);
            Entité = new Sprite[100];
            Back.LoadContent(content, "Sprites/BackGrounds/Fond2");
            for (int i = 0; i < Entité.Length - 10; i++)
            {
                Entité[i] = new Sprite();
                Entité[i].Initialize(new Vector2(80 * i));
            }
            for (int i = 0; i < Entité.Length - 10; i++)
                Entité[i].LoadContent(content, "Sprites/Arbrebeta");
        }
        static private void Decors2(ContentManager content) //Definie les caractéristique du décors 2
        {
            Back.Initialize(Vector2.Zero);
            Entité = new Sprite[100];
            Back.LoadContent(content, "Sprites/BackGrounds/Fond2");
            for (int i = 0; i < 40; i++)
            {
                Entité[i] = new Sprite();
                Entité[i].Initialize(new Vector2(80 * i, 0));
            }
            for (int i = 0; i < Entité.Length - 60; i++)
            {
                Entité[i + 50] = new Sprite();
                Entité[i + 50].Initialize(new Vector2(0, 80 * i));
            }
            for (int i = 0; i < Entité.Length - 10; i++)
                Entité[i].LoadContent(content, "Sprites/Arbrebeta");
        }
    }
}
