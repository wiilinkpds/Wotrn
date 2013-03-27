using System;
using GameProjectReborn.Maps;
using GameProjectReborn.Maps.Path;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Entities.Ia
{
    
    class IA
    {
        private MapData map;
        private Monster monster;
        private bool inVision { get; set; }
        private bool OutRange { get; set; }
        private bool Patroui { get; set; }
        private Direction direction { get; set; }

        public IA(MapData mapData, Monster monster)
        {
            map = mapData;
            inVision = false;
            OutRange = true;
            Patroui = true;
            this.monster = monster;
            direction = Direction.Down;

        }

        private int VectToId(Vector2 Pos)
        {
            return (int)(Pos.X / 32) + (int)(Pos.Y / 32) * map.MapWidth;
        }

        public void Moving(GameTime gameTime, Player player)
        {
            if (VectToId(monster.InitialPos) == VectToId(monster.Position))
            {
                OutRange = false;
                Patroui = true;
            }

            inVision = false;
            if (Math.Sqrt((Math.Pow(Math.Abs(monster.Position.X - player.Position.X), 2)
                + Math.Pow(Math.Abs(monster.Position.Y - player.Position.Y), 2))) < monster.Vision && !OutRange)
            {
                inVision = true;
                Patroui = false;
            }
            if (Math.Sqrt((Math.Pow(Math.Abs(monster.Position.X - monster.InitialPos.X), 2)
       + Math.Pow(Math.Abs(monster.Position.Y - monster.InitialPos.Y), 2))) > monster.Range)
            {
                OutRange = true;
                inVision = false;
            }

            if (inVision)
                new Pathfinding(gameTime, player.Position, monster, map);
            else if (!Patroui) 
                new Pathfinding(gameTime, monster.InitialPos, monster, map);
            else 
                Patrouille(gameTime);      
        }

        public void Patrouille(GameTime gameTime)
        {
            if (VectToId(monster.Position) == VectToId(monster.InitialPos))
                direction = Direction.Down;
            else if (VectToId(monster.Position) == VectToId(monster.InitialPos) + 4 * map.MapWidth)
                direction = Direction.Left;
            else if (VectToId(monster.Position) == VectToId(monster.InitialPos) + 4 * map.MapWidth - 4)
                direction = Direction.Up;
            else if (VectToId(monster.Position) == VectToId(monster.InitialPos) - 4)
                direction = Direction.Right;

            switch (direction)
            {
                case Direction.Down:
                    new Pathfinding(gameTime, new Vector2(monster.Position.X, monster.Position.Y + 32), monster, map);
                    break;
                case Direction.Up:
                    new Pathfinding(gameTime, new Vector2(monster.Position.X, monster.Position.Y - 32), monster, map);
                    break;
                case Direction.Right:
                    new Pathfinding(gameTime, new Vector2(monster.Position.X + 32, monster.Position.Y), monster, map);
                    break; 
                case Direction.Left:
                    new Pathfinding(gameTime, new Vector2(monster.Position.X - 32, monster.Position.Y), monster, map);
                    break;
            }
        }
    }
}
