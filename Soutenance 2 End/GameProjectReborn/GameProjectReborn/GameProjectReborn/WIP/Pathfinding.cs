using System;
using GameProjectReborn.Maps;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.WIP
{
    public class Pathfinding
    {
        private Map map;

        public Pathfinding(Map map)
        {
            this.map = map;
        }

        public MovementPath Find(Vector2 start, Vector2 end)
        {
            Point p1 = new Point((int)Math.Floor(start.X / Map.TileSize), (int)Math.Floor(start.Y / Map.TileSize));
            Point p2 = new Point((int)Math.Floor(end.X / Map.TileSize), (int)Math.Floor(end.Y / Map.TileSize));
            return Find(p1, p2);
        }

        private MovementPath Find(Point start, Point end)
        {
            MovementPath path = new MovementPath();
            Point current = start;

            while (current != end)
            {
                if (end.X > current.X)
                {
                    current.X++;
                }
                else if (end.X < current.X)
                {
                    current.X--;
                }

                if (end.Y > current.Y)
                {
                    current.Y++;
                }
                else if (end.Y < current.Y)
                {
                    current.Y--;
                }
                path.Cells.Add(current);
            }

            return path;
        }
    }
}