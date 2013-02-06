using System;
using System.Collections.Generic;
using GameProjectReborn.Maps;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Entities
{
    public class IA
    {
        private List<node> ListOuverte { get; set; }
        private List<node> ListFermer { get; set; }
        private node Depart { get; set; }
        private node Arrivé { get; set; }
        private node test { get; set; }
        private node current { get; set; }
        private List<Vector2> list { get; set; }
        private MapData map { get; set; }
        private Player player { get; set; }
        private Monster monster { get; set; }
        private Vector2 move;

        public IA(Monster Monster, Player Player, MapData Map, GameTime gameTime)
        {
            map = Map;
            monster = Monster;
            player = Player;
            Depart = new node(monster.Position, monster.Position, player.Position, map);
            Depart.Parent = null;
            Arrivé = new node(player.Position, monster.Position, player.Position, map);
            ListOuverte = new List<node>();
            ListFermer = new List<node>();
            ListOuverte.Add(Depart);
            pathfinding(gameTime);
        }
        public void mouvement(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 10.0f;
            move = Vector2.Zero;
            if (list != null && list.Remove(monster.Position) && list.Count > 0)
            {
                if (gameTime.TotalGameTime.TotalMilliseconds % 1000 < 5 )
                {
                    if (list[list.Count - 1].Y < monster.Position.Y)
                        monster.direction = Direction.Up;
                    else if (list[list.Count - 1].Y > monster.Position.Y)
                        monster.direction = Direction.Down;
                    else if (list[list.Count - 1].X < monster.Position.X)
                        monster.direction = Direction.Left;
                    else if (list[list.Count - 1].X > monster.Position.X)
                        monster.direction = Direction.Right;
                }

                if (list[list.Count - 1].Y < monster.Position.Y)
                    move.Y -= 1;
                else if (list[list.Count - 1].Y > monster.Position.Y)
                    move.Y += 1;
                if (list[list.Count - 1].X < monster.Position.X)
                    move.X -= 1;
                else if (list[list.Count - 1].X > monster.Position.X)
                    move.X += 1;
                move.Normalize();
            }
            monster.Position = monster.Position + move * monster.Speed * time;

        }

        public void pathfinding(GameTime gameTime)
        {
            while (!contains(Arrivé, ListFermer) && ListOuverte.Count != 0)
            {
                current = new node();
                current = FindMinPoids(ListOuverte);
                ListOuverte.Remove(current);
                if (current.Position.X >= 0 && current.Position.X + monster.TextureSize.X <= map.MapWidth*32 && current.Position.Y >= 0 && current.Position.Y + monster.TextureSize.Y <= 32 * map.MapHeight)
                {
                    ListFermer.Add(current);
                    findNode(map, current, monster);
                }
            }
            if (contains(Arrivé, ListFermer))
            {
                list = new List<Vector2>();
                test = new node();
                test = ListFermer.Find(node => node.id == Arrivé.id);
                list.Add(test.Position);
                while (test.Parent != null)
                {
                    test = test.Parent;
                    list.Add(test.Position);
                }
                mouvement(gameTime);
            }
        }

        private node FindMinPoids(List<node> list)
        {
            node MinPoids = new node();
            MinPoids = list[0];
            for (int i = 1; i < list.Count; i++)
                if (list[i].Poids <= MinPoids.Poids)
                    MinPoids = list[i];
            return MinPoids;
        }

        private bool contains(node node , List<node> list)
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i].id == node.id)
                    return true;
            return false;
        }
        private void findNode(MapData map, node curr, Monster monster)
        {
            node L, R, U, D, UL, UR, DL, DR;
            L = new node(curr,"L",map);
            R = new node(curr, "R", map);
            U = new node(curr, "U", map);
            D = new node(curr, "D", map);
            UL = new node(curr, "UL", map);
            UR = new node(curr, "UR", map);
            DL = new node(curr, "DL", map);
            DR = new node(curr, "DR", map);
            if (L.Position.X >= 0 && L.Position.X + monster.TextureSize.X <= map.MapWidth * 32 && L.Position.Y >= 0 && L.Position.Y + monster.TextureSize.Y <= 32 * map.MapHeight && !(map.Accessibility[L.id] == 1  || contains(L, ListFermer)))
            {
                if (!contains(L, ListOuverte))
                {
                    L.Parent = curr;
                    L.DistanceParcourue = curr.DistanceParcourue + 32;
                    ListOuverte.Add(L);
                }
            }
            if (R.Position.X >= 0 && R.Position.X + monster.TextureSize.X <= map.MapWidth*32 && R.Position.Y >= 0 && R.Position.Y + monster.TextureSize.Y <= 32 * map.MapHeight && !(map.Accessibility[R.id] == 1 || contains(R, ListFermer)))
            {
                if (!contains(R, ListOuverte))
                {
                    R.Parent = curr;
                    R.DistanceParcourue = curr.DistanceParcourue + 32;
                    ListOuverte.Add(R);
                }
            }
            if (U.Position.X >= 0 && U.Position.X + monster.TextureSize.X <= map.MapWidth * 32 && U.Position.Y >= 0 && U.Position.Y + monster.TextureSize.Y <= 32 * map.MapHeight && !(map.Accessibility[U.id] == 1 || contains(U, ListFermer)))
            {
                if (!contains(U, ListOuverte))
                {;
                    U.Parent = curr;
                    U.DistanceParcourue = curr.DistanceParcourue + 32;
                    ListOuverte.Add(U);
                }
            }
            if (D.Position.X >= 0 && D.Position.X + monster.TextureSize.X <= map.MapWidth * 32 && D.Position.Y >= 0 && D.Position.Y + monster.TextureSize.Y <= 32 * map.MapHeight && !(map.Accessibility[D.id] == 1 || contains(D, ListFermer)))
            {
                if (!contains(D, ListOuverte))
                {
                    D.Parent = curr;
                    D.DistanceParcourue = curr.DistanceParcourue + 32;
                    ListOuverte.Add(D);
                }
            }
            if (UL.Position.X >= 0 && UL.Position.X + monster.TextureSize.X <= map.MapWidth * 32 && UL.Position.Y >= 0 && UL.Position.Y + monster.TextureSize.Y <= 32 * map.MapHeight && !(map.Accessibility[UL.id] == 1 || contains(UL, ListFermer)))
            {
                if (!contains(UL, ListOuverte))
                {
                    UL.Parent = curr;
                    UL.DistanceParcourue = curr.DistanceParcourue + Math.Sqrt(2048); //A modifie
                    ListOuverte.Add(UL);
                }
            }
            if (UR.Position.X >= 0 && UR.Position.X + monster.TextureSize.X <= map.MapWidth * 32 && UR.Position.Y >= 0 && UR.Position.Y + monster.TextureSize.Y <= 32 * map.MapHeight && !(map.Accessibility[UR.id] == 1 || contains(UR, ListFermer)))
            {
                if (!contains(UR, ListOuverte))
                {
                    UR.Parent = curr;
                    UR.DistanceParcourue = curr.DistanceParcourue + Math.Sqrt(2048);
                    ListOuverte.Add(UR);
                }
            }
            if (DL.Position.X >= 0 && DL.Position.X + monster.TextureSize.X <= map.MapWidth * 32 && DL.Position.Y >= 0 && DL.Position.Y + monster.TextureSize.Y <= 32 * map.MapHeight && !(map.Accessibility[DL.id] == 1 || contains(DL, ListFermer)))
            {
                if (!contains(DL, ListOuverte))
                {
                    DL.Parent = curr;
                    DL.DistanceParcourue = curr.DistanceParcourue + Math.Sqrt(2048);
                    ListOuverte.Add(DL);
                }
            }
            if (DR.Position.X >= 0 && DR.Position.X + monster.TextureSize.X <= map.MapWidth * 32 && DR.Position.Y >= 0 && DR.Position.Y + monster.TextureSize.Y <= 32 * map.MapHeight && !(map.Accessibility[DR.id] == 1 || contains(DR, ListFermer)))
            {
                if (!contains(DR, ListOuverte))
                {
                    DR.Parent = curr;
                    DR.DistanceParcourue = curr.DistanceParcourue + Math.Sqrt(2048);
                    ListOuverte.Add(DR);
                }
            }
        }
    }
}
