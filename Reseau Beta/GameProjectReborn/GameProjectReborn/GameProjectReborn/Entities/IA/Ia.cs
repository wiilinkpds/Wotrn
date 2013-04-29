using System;
using GameProjectReborn.Managers;
using GameProjectReborn.Maps;
using GameProjectReborn.Maps.Path;
using GameProjectReborn.Screens;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Entities.IA
{
    class Ia
    {
        private MapData map;
        private Monster monster;
        private Direction direction { get; set; }

        private bool inVision { get; set; }
        private bool OutRange { get; set; }
        private bool isPatrolling { get; set; }

        public Ia(MapData mapData, Monster monster)
        {
            map = mapData;
            this.monster = monster;
            direction = Direction.Down;

            inVision = false;
            OutRange = true;
            isPatrolling = true;
        }

        public void Moving(GameTime gameTime, Player player)
        {
            if (GameScreen.Reseau)
                new Pathfinding(gameTime, player.Position, monster, map);
            else
            {
                if (monster.Bounds.Intersects(player.Bounds))
                    return;
                if (ConversionManager.VectToId(map, monster.InitialPos) ==
                    ConversionManager.VectToId(map, monster.Position))
                {
                    OutRange = false;
                    isPatrolling = true;
                }

                inVision = false;
                if (Math.Sqrt((Math.Pow(Math.Abs(monster.Position.X - player.Position.X), 2)
                               + Math.Pow(Math.Abs(monster.Position.Y - player.Position.Y), 2))) < monster.VisionSight &&
                    !OutRange)
                {
                    inVision = true;
                    isPatrolling = false;
                }
                if (Math.Sqrt((Math.Pow(Math.Abs(monster.Position.X - monster.InitialPos.X), 2)
                               + Math.Pow(Math.Abs(monster.Position.Y - monster.InitialPos.Y), 2))) >
                    monster.MovingScope)
                {
                    OutRange = true;
                    inVision = false;
                }

                if (monster.Life < monster.LifeMax)
                {
                    inVision = true;
                    OutRange = false;
                    isPatrolling = false;
                }

                if (inVision)
                    new Pathfinding(gameTime, player.Position, monster, map);
                else if (!isPatrolling)
                    new Pathfinding(gameTime, monster.InitialPos, monster, map);
                else
                    Patrol(gameTime);
            }
        }

        public void Patrol(GameTime gameTime)
        {
            if (ConversionManager.VectToId(map, monster.Position) == ConversionManager.VectToId(map, monster.InitialPos))
                direction = Direction.Down;
            else if (ConversionManager.VectToId(map, monster.Position) == ConversionManager.VectToId(map, monster.InitialPos) + 4 * map.MapWidth)
                direction = Direction.Left;
            else if (ConversionManager.VectToId(map, monster.Position) == ConversionManager.VectToId(map, monster.InitialPos) + 4 * map.MapWidth - 4)
                direction = Direction.Up;
            else if (ConversionManager.VectToId(map, monster.Position) == ConversionManager.VectToId(map, monster.InitialPos) - 4)
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
