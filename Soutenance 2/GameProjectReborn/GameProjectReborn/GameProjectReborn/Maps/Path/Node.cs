using System;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Maps.Path
{
    public class Node
    {
        public int Id { get; set; }

        public double DistanceVol { get; set; }
        public double DistanceParcourue { get; set; }
        public double Weight { get; set; }                                 

        public Vector2 Position { get; set; }
        public Vector2 Start { get; set; }
        public Vector2 Arrival { get; set; }

        public Node Parent { get; set; }

        public Node(Vector2 pos, Vector2 start, Vector2 arrival, MapData map)
        {
            DistanceParcourue = 0;

            Position = pos;
            Start = start;
            Arrival = arrival;
            Update(map);
        }

        public Node()
        {
            
        }

        public Node(Node copie, NodePos direction, MapData map)
        {
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
                case NodePos.UL:
                    Position = new Vector2(copie.Position.X - 32, copie.Position.Y - 32);
                    break;
                case NodePos.UR:
                    Position = new Vector2(copie.Position.X + 32, copie.Position.Y - 32);
                    break;
                case NodePos.DL:
                    Position = new Vector2(copie.Position.X - 32, copie.Position.Y + 32);
                    break;
                case NodePos.DR:
                    Position = new Vector2(copie.Position.X + 32, copie.Position.Y + 32);
                    break;
            }
            Update(map);
        }

        public void Update(MapData map)
        {
            DistanceVol = Math.Sqrt((Math.Pow(Math.Abs(Position.X - Arrival.X), 2) + Math.Pow(Math.Abs(Position.Y - Arrival.Y), 2)));
            Id = ((int)(Position.X / 32) + (int)(Position.Y / 32) * map.MapWidth);
            Weight = DistanceParcourue + DistanceVol;
        }
    }
}
