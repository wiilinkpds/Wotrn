using System;
using GameProjectReborn.Managers;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Maps.Path
{
    public class Node
    {
        public int Id { get; set; }
        public bool CanGo { get; set; }

        public double DistanceVol { get; set; }
        public double DistanceParcourue { get; set; }
        public double Weight { get; set; }                                 

        public Vector2 Position { get; set; }
        public Vector2 Start { get; set; }
        public Vector2 Arrival { get; set; }

        public Node Parent { get; set; }

        public Node()
        {
        }

        public Node(Vector2 pos, Vector2 start, Vector2 arrival, MapData map)
        {
            DistanceParcourue = 0;
            Position = pos;
            Start = start;
            Arrival = arrival;
            Update(map);
        }

        public Node(Node copie, NodePos direction, MapData map, Vector2 size)
        {
            CanGo = true;
            Start = copie.Start;
            Arrival = copie.Arrival;

            switch (direction)
            {
                case NodePos.U:
                    Position = new Vector2(copie.Position.X, copie.Position.Y - 32);
                    break;
                case NodePos.D:
                    Position = new Vector2(copie.Position.X, copie.Position.Y + 32);
                    break;
                case NodePos.R:
                    Position = new Vector2(copie.Position.X + 32, copie.Position.Y);
                    break;
                case NodePos.L:
                    Position = new Vector2(copie.Position.X - 32, copie.Position.Y);
                    break;
            }

            Update(map);
            if (Id < 0 || Id > map.MapWidth * map.MapHeight || !Can(direction, map, size))
                CanGo = false;
        }

        public void Update(MapData map)
        {
            DistanceVol = Math.Sqrt((Math.Pow(Math.Abs(Position.X - Arrival.X), 2) + Math.Pow(Math.Abs(Position.Y - Arrival.Y), 2)));
            Id = ((int)(Position.X / 32) + (int)(Position.Y / 32) * map.MapWidth);
            Weight = DistanceParcourue + DistanceVol;
        }

        private bool Can(NodePos direction, MapData map, Vector2 size)
        {
            bool isNearNode = ConversionManager.VectToId(map, new Vector2(Position.X + size.X, Position.Y)) < map.MapHeight*map.MapWidth;
            switch (direction)
            {
                case NodePos.U:
                    if (map.Accessibility[Id] == 1 ||
                        (isNearNode && map.Accessibility[ConversionManager.VectToId(map, new Vector2(Position.X + size.X, Position.Y))] == 1) ||
                        (map.SideAccess[Id] & 2) == 2 ||
                        (isNearNode &&(map.SideAccess[ConversionManager.VectToId(map, new Vector2(Position.X + size.X, Position.Y))] & 2) == 2))
                        return false;
                    break;
                case NodePos.D:
                    if (map.Accessibility[Id] == 1 ||
                        (isNearNode && map.Accessibility[ConversionManager.VectToId(map, new Vector2(Position.X + size.X, Position.Y))] == 1 )||
                        (map.SideAccess[Id] & 1) == 1 ||
                        (isNearNode && (map.SideAccess[ConversionManager.VectToId(map, new Vector2(Position.X + size.X, Position.Y))] & 1) == 1))
                        return false;
                    break;
                case NodePos.L:
                    if (map.Accessibility[Id] == 1 ||
                        (isNearNode && map.Accessibility[ConversionManager.VectToId(map, new Vector2(Position.X, Position.Y + size.Y))] == 1) ||
                        (map.SideAccess[Id] & 8) == 8 ||
                        (isNearNode && (map.SideAccess[ConversionManager.VectToId(map, new Vector2(Position.X, Position.Y + size.Y))] & 8) == 8))
                        return false;
                    break;
                case NodePos.R:
                    if (map.Accessibility[Id] == 1 ||
                        (isNearNode && map.Accessibility[ConversionManager.VectToId(map, new Vector2(Position.X, Position.Y + size.Y))] == 1) ||
                        (map.SideAccess[Id] & 4) == 4 ||
                        (isNearNode && (map.SideAccess[ConversionManager.VectToId(map, new Vector2(Position.X, Position.Y + size.Y))] & 4) == 4))
                        return false;
                    break;
            }
            return true;
        }
    }
}
