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
            Vector2[] oldPos = new Vector2[Enemis.Length];
            Sprite[] entité = new Sprite[EntitéDecors.Length + 1];
            entité = EntitéDecors;
            entité[entité.Length - 1] = Joueur;
            bool touchJ = false;
                for (int j = 0; j < Enemis.Length; j++)
                {
                    oldPos[j] = Enemis[j].Position;
                    for (int i = 0; i < vitesse; i++)
                    {
                        if (Joueur.Position.X < Enemis[j].Position.X)
                            MoteurPhysique.ColisionIa(entité, Enemis[j], "L");
                        else if (Joueur.Position.X > Enemis[j].Position.X)
                            MoteurPhysique.ColisionIa(entité, Enemis[j], "R");
                        if (Joueur.Position.Y < Enemis[j].Position.Y)
                            MoteurPhysique.ColisionIa(entité, Enemis[j], "U");
                        else if (Joueur.Position.Y > Enemis[j].Position.Y)
                            MoteurPhysique.ColisionIa(entité, Enemis[j], "D");
                    }
                    if ((Joueur.Position.X - 1 <= Enemis[j].Position.X + Enemis[j].Width() && Enemis[j].Position.X <= Joueur.Position.X + Joueur.Height() + 1) && (Joueur.Position.Y - 1 <= Enemis[j].Position.Y + Enemis[j].Height() && Enemis[j].Position.Y <= Joueur.Position.Y + Joueur.Height() + 1))
                        touchJ = true;

                }
            if (touchJ)
                MainGame.life--;
        }
    }
}
