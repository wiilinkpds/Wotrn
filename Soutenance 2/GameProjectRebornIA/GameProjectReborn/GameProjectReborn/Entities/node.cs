using System;
using GameProjectReborn.Maps;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Entities
{
    public class node
    {
        public double DistanceVol { get; set; }
        public double DistanceParcourue { get; set; }
        public int id { get; set; }
        public node Parent { get; set; }
        public double Poids { get { return DistanceVol + DistanceParcourue; }}
        public Vector2 Position { get; set; }
        public Vector2 Depart { get; set; }
        public Vector2 Arrive { get; set; }


        public node(Vector2 pos, Vector2 depart, Vector2 arrivé, MapData map)
        {
            Position = pos;
            Depart = depart;
            Arrive = arrivé;
            DistanceParcourue = 0;
            Update(map);
        }
        public node() {}

        public node(node Copie, string direction, MapData map)
        {
            Depart = Copie.Depart;
            Arrive = Copie.Arrive;
            if (direction == "U")
            {
                //id = Copie.id - map.MapWidth;
                Position = new Vector2(Copie.Position.X, Copie.Position.Y - 32);
            }
            else if (direction == "D")
            {
                //id = Copie.id + map.MapWidth;
                Position = new Vector2(Copie.Position.X, Copie.Position.Y + 32);
            }
            else if (direction == "R")
            {
                //id = Copie.id + 1;
                Position = new Vector2(Copie.Position.X + 32, Copie.Position.Y);
            }
            else if (direction == "L")
            {
                //id = Copie.id - 1;
                Position = new Vector2(Copie.Position.X - 32, Copie.Position.Y);
            }
            else if (direction == "UL")
            {
                //id = Copie.id - map.MapWidth - 1;
                Position = new Vector2(Copie.Position.X - 32, Copie.Position.Y - 32);
            }
            else if (direction == "UR")
            {
                //id = Copie.id - map.MapWidth + 1;
                Position = new Vector2(Copie.Position.X + 32, Copie.Position.Y - 32);
            }
            else if (direction == "DL")
            {
                //id = Copie.id + map.MapWidth - 1;
                Position = new Vector2(Copie.Position.X - 32, Copie.Position.Y + 32);
            }
            else if (direction == "DR")
            {
                //id = Copie.id + map.MapWidth + 1;
                Position = new Vector2(Copie.Position.X + 32, Copie.Position.Y + 32);
            }
            Update(map);
        }

        public void Update(MapData map)
        {
            DistanceVol = Math.Sqrt((Math.Pow(Math.Abs(Position.X - Arrive.X), 2)
                + Math.Pow(Math.Abs(Position.Y - Arrive.Y), 2)));
            id = (int)((int)(Position.X / 32) + (int)(Position.Y / 32) * map.MapWidth);
        }
    }
}
