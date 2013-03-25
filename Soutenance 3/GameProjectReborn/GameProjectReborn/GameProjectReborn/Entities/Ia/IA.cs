using System;
using GameProjectReborn.Maps;
using GameProjectReborn.Maps.Path;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Entities.Ia
{
    
    class IA
    {
        private MapData map;
        private bool inVision { get; set; }
        private bool OutRange { get; set; }

        public IA(MapData mapData)
        {
            map = mapData;
            inVision = false;
            OutRange = true;
        }

        private int VectToId(Vector2 Pos)
        {
            return (int)(Pos.X / 32) + (int)(Pos.Y / 32) * map.MapWidth;
        }

        public void Moving(Monster monster,GameTime gameTime, Player player)
        {
            if (VectToId(monster.InitialPos) == VectToId(monster.Position))
                OutRange = false;

            inVision = false;
            if (Math.Sqrt((Math.Pow(Math.Abs(monster.Position.X - player.Position.X), 2)
                + Math.Pow(Math.Abs(monster.Position.Y - player.Position.Y), 2))) < monster.Vision && !OutRange)
            {
                inVision = true;
            }
            if (Math.Sqrt((Math.Pow(Math.Abs(monster.Position.X - monster.InitialPos.X), 2)
       + Math.Pow(Math.Abs(monster.Position.Y - monster.InitialPos.Y), 2))) > monster.Range)
            {
                OutRange = true;
                inVision = false;
            }

            if (inVision)
                new Pathfinding(gameTime, player.Position, monster, map);
            else
                new Pathfinding(gameTime, monster.InitialPos, monster, map);
        }
    }
}
