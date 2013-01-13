/*using System;
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

        static public Rectangle backRectangle
        {
            get { return new Rectangle((int)Back.Position.X, (int)Back.Position.Y, Back.Width * 2, Back.Height * 2); }
        }
        

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
            Back.Draw(spritebatch,backRectangle);
            for (int i = 0; i < Entité.Length; i++)
                Entité[i].Draw(spritebatch);
        }

        static public Sprite[] DecorCol //renvoie le tableau correspondant au entité pouvant être colisionner (sert pour le moteur physique)
        {
            get { return Entité; }
        }

        static public Sprite back //renvoie le fond (pas de colision) (sert pour le moteur physique)
        {
            get { return Back; }
        }
        static private void Decors1(ContentManager content) //Definie les caractéristiques du décors 1
        {
            int nbArb = 41;
            Back.Initialize(Vector2.Zero);
            Entité = new Sprite[100];
            Back.LoadContent(content, "Sprites/BackGrounds/Fond2");
            for (int i = 0; i < nbArb; i++)
            {
                Entité[i] = new Sprite();
                Entité[i].Initialize(new Vector2(80 * i));
            }
            for (int i = 0; i < nbArb; i++)
                Entité[i].LoadContent(content, "Sprites/Arbrebeta");
            for (int i = nbArb; i < Entité.Length; i++)
            {
                Entité[i] = new Sprite();
                Entité[i].Initialize(new Vector2(80 * i));
            }
            for (int i = nbArb; i < Entité.Length; i++)
                Entité[i].LoadContent(content, "Sprites/cailloux");
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
            for (int i = 0; i < Entité.Length - 40; i++)
            {
                Entité[i + 40] = new Sprite();
                Entité[i + 40].Initialize(new Vector2(0, 80 * i));
            }
            for (int i = 0; i < 40; i++)
                Entité[i].LoadContent(content, "Sprites/Arbrebeta");
            for (int i = 40; i < Entité.Length; i++)
                Entité[i].LoadContent(content, "Sprites/cailloux");

        }
    }
}*/
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
    public class Decor
    {
        private static Sprite Back;
        private static Sprite[] Entite; // Tableau contenant toutes les entités tangibles (ennemis, décors, joueurs)

        static public Rectangle backRectangle
        {
            get { return new Rectangle((int)Back.Position.X, (int)Back.Position.Y, Back.Width * 2, Back.Height * 2); }
        }

        public virtual void LoadDecors(ContentManager content, int DecorNum) //Load le decor en fonction du int en parametre
        {
            Back = new Sprite();
            DesignDecors.Decors(content, Back, out Entite, DecorNum, Vector2.Zero);
        }

        public virtual void DrawDecors(SpriteBatch spritebatch) //Draw le decor loader dans la fonction precedente
        {
            Back.Draw(spritebatch,backRectangle);
            for (int i = 0; i < Entite.Length; i++)
                Entite[i].Draw(spritebatch);
        }

        static public Sprite[] DecorCol //Renvoie le tableau correspondant aux entites pouvant être colisionnées (sert pour le moteur physique)
        {
            get { return Entite; }
        }

        static public Sprite back //Renvoie le fond (pas de colision) (sert pour le moteur physique)
        {
            get {return Back; }
        }
    }
}

