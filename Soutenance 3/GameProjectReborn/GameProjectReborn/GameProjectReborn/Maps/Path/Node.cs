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

        public bool CanGo { get; set; }

        private MapData map = null;

        public Node(Vector2 pos, Vector2 start, Vector2 arrival, MapData map)
        {
            this.map = map;
            DistanceParcourue = 0;
            Position = pos;
            Start = start;
            Arrival = arrival;
            Update(map);
        }

        public Node()
        {

        }

        public Node(Node copie, NodePos direction, MapData map, Vector2 size)
        {
            CanGo = true;
            Start = copie.Start;
            Arrival = copie.Arrival;
            this.map = map;
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
            if (Id < 0 || Id > map.MapWidth * map.MapHeight || !Can(direction,size))
                CanGo = false;
        }

        public void Update(MapData map)
        {
            DistanceVol = Math.Sqrt((Math.Pow(Math.Abs(Position.X - Arrival.X), 2) + Math.Pow(Math.Abs(Position.Y - Arrival.Y), 2)));
            Id = (int)(Position.X / 32) + (int)(Position.Y / 32) * map.MapWidth;
            Weight = DistanceParcourue + DistanceVol;
        }

        private bool Can(NodePos direction, Vector2 size)
        {
            if (direction == NodePos.U)
            {
                if (map.Accessibility[Id] == 1 || map.Accessibility[VectToId(new Vector2(Position.X + size.X, Position.Y))] == 1 || (map.SideAccess[Id] & 2) == 2 || (map.SideAccess[VectToId(new Vector2(Position.X + size.X,Position.Y))] & 2)==2)
                    return false;
            }
            else if (direction == NodePos.D)
            {
                if (map.Accessibility[Id] == 1 || map.Accessibility[VectToId(new Vector2(Position.X + size.X, Position.Y))] == 1 || (map.SideAccess[Id] & 1) == 1 || (map.SideAccess[VectToId(new Vector2(Position.X + size.X, Position.Y))] & 1) == 1)
                    return false;
            }
            else if (direction == NodePos.L)
            {
                if (map.Accessibility[Id] == 1 || map.Accessibility[VectToId(new Vector2(Position.X, Position.Y + size.Y))] == 1 || (map.SideAccess[Id] & 8) == 8 || (map.SideAccess[VectToId(new Vector2(Position.X, Position.Y + size.Y))] & 8) == 8)
                    return false;
            }
            else if (direction == NodePos.R)
            {
                if (map.Accessibility[Id] == 1 || map.Accessibility[VectToId(new Vector2(Position.X, Position.Y + size.Y))] == 1 || (map.SideAccess[Id] & 4) == 4 || (map.SideAccess[VectToId(new Vector2(Position.X, Position.Y + size.Y))] & 4) == 4)
                    return false;
            }
            return true;
        }

        private int VectToId(Vector2 Pos)
        {
            return (int)(Pos.X / 32) + (int)(Pos.Y / 32) * map.MapWidth;
        }
    }
}
