using GameProjectReborn.Entities;
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

        public static Vector2 ScreenToGameCoords(Player player, Vector2 vector) // Position convertie de l'ecran en position du Jeu
        {
            Vector2 center = player.CanMove ? player.Position : player.AstralPosition;
            Vector2 delta = -center + new Vector2(MainGame.ScreenX / 2, MainGame.ScreenY / 2) - new Vector2(player.TextureSize.X / 2.0f, player.TextureSize.Y / 2.0f);
            return (vector - delta);
        }
    }
}