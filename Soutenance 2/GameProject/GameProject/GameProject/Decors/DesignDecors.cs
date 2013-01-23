using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using GameProject.Managers;

namespace GameProject.Decors
{
    public class DesignDecors
    {
        static public void Decors(ContentManager content, Sprite back, out Sprite[] entite, int numb_decor, Vector2 pos_depart) //Definie les caracteristiques du decor choisi
        {
            back.Initialize(Vector2.Zero + pos_depart);
            back.LoadContent(content, "Sprites/BackGrounds/Fond2");
            // Decor 1 : Arbres en Diagonales
            if (numb_decor == 1)
            {
                entite = new Sprite[15];
                back.LoadContent(content, "Sprites/BackGrounds/Fond2");

                for (int i = 0; i < entite.Length; i++)
                {
                    entite[i] = new Sprite();
                    entite[i].Initialize(new Vector2(80 * i) + pos_depart);
                }
                for (int i = 0; i < entite.Length; i++)
                    entite[i].LoadContent(content, "Sprites/Decors/Arbrebeta");
            }
            // Decor 2 : Axe d'arbres
            else if (numb_decor == 2)
            {
                entite = new Sprite[50];
                back.LoadContent(content, "Sprites/BackGrounds/Fond2");

                for (int i = 0; i < entite.Length / 2; i++)
                {
                    entite[i] = new Sprite();
                    entite[i].Initialize(new Vector2(80 * i + pos_depart.X, pos_depart.Y));
                }
                for (int i = 0; i < entite.Length / 2 ; i++)
                {
                    entite[i + entite.Length / 2] = new Sprite();
                    entite[i + entite.Length / 2].Initialize(new Vector2(pos_depart.X, 80 * i + pos_depart.Y));
                }
                for (int i = 0; i < entite.Length / 2; i++)
                    entite[i].LoadContent(content, "Sprites/Decors/Arbrebeta");
                for (int i = 0; i < entite.Length / 2; i++)
                    entite[i + entite.Length /2].LoadContent(content, "Sprites/Decors/cailloux");

            }
            else
            {
                entite = new Sprite[30];
                Vector2 pos = new Vector2(MainGame.Rand.Next(MainGame.ScreenX,back.Width),MainGame.Rand.Next(MainGame.ScreenY,back.Height));
                bool posDif = false;
                entite[0] = new Sprite();
                entite[0].Initialize(pos);
                posDif = !(entite[0].Position == pos);
                for (int j = 1; j < entite.Length; j++)
                {
                    pos = new Vector2(MainGame.Rand.Next(MainGame.ScreenX, back.Width), MainGame.Rand.Next(MainGame.ScreenY, back.Height));
                    posDif = false;
                    while (!posDif)
                    {
                        pos = new Vector2(MainGame.Rand.Next(MainGame.ScreenX, back.Width), MainGame.Rand.Next(MainGame.ScreenY, back.Height));
                        for (int i = 0; i < j; i++)
                            posDif = !(entite[i].Position == pos);
                    }
                    entite[j] = new Sprite();
                    entite[j].Initialize(pos);
                }
                for (int i = 0; i < entite.Length; i++)
                {
                    if (i % 2 == 0)
                        entite[i].LoadContent(content, "Sprites/Decors/Arbrebeta");
                    else
                        entite[i].LoadContent(content, "Sprites/Decors/cailloux");
                }

            }           
        }
    }
}
