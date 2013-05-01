using GameProjectReborn.Maps;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Managers
{
    public class ConversionManager
    {
        public static int VectToId(MapData map, Vector2 pos)
        {
            return (int)(pos.X / 32) + (int)(pos.Y / 32) * map.MapWidth;
        }
    }
}