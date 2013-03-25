using System;
using GameProjectReborn.Maps;
using GameProjectReborn.Maps.Path;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Entities.Ia
{
    
    class IA
    {
        private bool inVision;
        private bool OutRange = true;
        public void Moving(Monster monster,GameTime gameTime, Player player, MapData map)
        {
            if (Math.Sqrt((Math.Pow(Math.Abs(monster.Position.X - player.Position.X), 2)
               + Math.Pow(Math.Abs(monster.Position.Y - player.Position.Y), 2))) < monster.Vision)
            {
                inVision = true;
                OutRange = false;
            }
            if (OutRange)
            {
                new Pathfinding(gameTime, monster.InitialPos, monster, map);
                return;
            }
            if (Math.Sqrt((Math.Pow(Math.Abs(monster.Position.X - monster.InitialPos.X), 2)
               + Math.Pow(Math.Abs(monster.Position.Y - monster.InitialPos.Y), 2))) > monster.Range)
            {
                OutRange = true;
                inVision = false;
            }

            if (inVision)
                new Pathfinding(gameTime, player.Position, monster, map);
        }
    }
}
