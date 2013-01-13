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

        public virtual void LoadDecors(ContentManager content, int DecorNum, Vector2 PosDepart) //Load le decor en fonction du int en parametre
        {
            Back = new Sprite();
            DesignDecors.Decors(content, Back, out Entite, DecorNum, PosDepart);
        }

        public virtual void DrawDecors(SpriteBatch spritebatch) //Draw le decor loader dans la fonction precedente
        {
            Back.Draw(spritebatch);
            for (int i = 0; i < Entite.Length; i++)
                Entite[i].Draw(spritebatch);
        }

        static public Sprite[] DecorCol() //Renvoie le tableau correspondant aux entites pouvant être colisionnées (sert pour le moteur physique)
        {
            return Entite;
        }

        static public Sprite back() //Renvoie le fond (pas de colision) (sert pour le moteur physique)
        {
            return Back;
        }
    }
}
