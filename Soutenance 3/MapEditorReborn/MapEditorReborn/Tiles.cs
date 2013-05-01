using System.Collections.Generic;
using System.Drawing;

namespace MapEditorReborn
{
    public class Tiles
    {
        private static Tiles thisOne;
        private Dictionary<int,Bitmap> tiles = new Dictionary<int, Bitmap>();

        public static Bitmap Get(int tileId)
        {
            if (thisOne == null)
                thisOne = new Tiles();

            return thisOne.tiles[tileId];
        }

        public Tiles()
        {
            Bitmap b = new Bitmap("tiles.png");
            int i = 0;

            for (int y = 0; y < b.Height; y += Constants.TileWidth)
            {
                for (int x = 0; x < b.Width; x += Constants.TileWidth)
                {
                    Bitmap a = new Bitmap(Constants.TileWidth, Constants.TileWidth);

                    for (int xa = 0; xa < Constants.TileWidth; xa++)
                        for (int ya = 0; ya < Constants.TileWidth; ya++)
                        {
                            Color c = b.GetPixel(x + xa, y + ya);
                            a.SetPixel(xa, ya, c);
                        }
                    tiles.Add(i , a);
                    i += 1;
                }
            }

         }
    }
}
