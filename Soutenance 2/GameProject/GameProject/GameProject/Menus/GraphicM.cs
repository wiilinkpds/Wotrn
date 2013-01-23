using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.Menus
{
    public class GraphicM
    {
        static private readonly Vector2 posGoutte = new Vector2(0, 0);

        // Design du Menu
        public static void MainGraph(int screen_x, int screen_y, SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(LoadM.Ville, new Rectangle(0, 0,screen_x,screen_y), Color.White); // Image de fond
            Vector2 titre = LoadM.Titre.MeasureString("Wrath of the Rack Ninja"); //Taille du titre dans le vector2
            sprite_batch.DrawString(LoadM.Titre, "Wrath of the Rack Ninja", new Vector2(screen_x / 2 -titre.X / 2, screen_y / 10), Color.Red); // Titre
            sprite_batch.Draw(LoadM.Flamme, new Vector2(screen_x / 2 - titre.X / 2 + 10 ,screen_y / 10 + titre.Y - 40), Color.White);
            sprite_batch.Draw(LoadM.Flamme, new Vector2(screen_x / 2 ,screen_y / 10 + titre.Y - 40), Color.White);
            sprite_batch.Draw(LoadM.Goutte, posGoutte, Color.White);
        }

    }
}
