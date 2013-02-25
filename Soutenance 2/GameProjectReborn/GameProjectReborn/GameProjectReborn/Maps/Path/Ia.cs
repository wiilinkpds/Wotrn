using System;
using System.Collections.Generic;
using GameProjectReborn.Entities;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Maps.Path
{
    public class Ia
    {
        private List<Node> OpenedList { get; set; }
        private List<Node> ClosedList { get; set; }

        private Node start { get; set; }
        private Node arrival { get; set; }
        private Node test { get; set; }
        private Node current { get; set; }

        private MapData mapData { get; set; }
        private List<Vector2> list { get; set; }
        private Monster monster { get; set; }
        private Vector2 move;

        // a changer
        public Ia(Monster monster)
        {
            this.monster = monster;
        }

        public void Update(GameTime gameTime, Player player)
        {
            OpenedList = new List<Node>();
            ClosedList = new List<Node>();

            mapData = player.Game.MapFirst.Data;
            start = new Node(monster.Position, monster.Position, player.Position, mapData) { Parent = null };
            arrival = new Node(player.Position, monster.Position, player.Position, mapData);

            OpenedList.Add(start);
            PathFinding(gameTime);
        }

        public void Mouvement(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 10.0f;
            if (list != null && list.Remove(monster.Position) && list.Count > 0)
            {
                if (time % 100 < 5 )
                {
                    if (list[list.Count - 1].Y < monster.Position.Y)
                        monster.Direction = Direction.Up;
                    else if (list[list.Count - 1].Y > monster.Position.Y)
                        monster.Direction = Direction.Down;
                    else if (list[list.Count - 1].X < monster.Position.X)
                        monster.Direction = Direction.Left;
                    else if (list[list.Count - 1].X > monster.Position.X)
                        monster.Direction = Direction.Right;
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

        public void PathFinding(GameTime gameTime)
        {
            while (!Contains(arrival, ClosedList) && OpenedList.Count != 0)
            {
                current = new Node();
                current = FindMinPoids(OpenedList);
                OpenedList.Remove(current);
                if (current.Position.X >= 0 && current.Position.X + monster.TextureSize.X <= mapData.MapWidth*32 && current.Position.Y >= 0 && current.Position.Y + monster.TextureSize.Y <= 32 * mapData.MapHeight)
                {
                    ClosedList.Add(current);
                    FindNode(current);
                }
            }
            if (Contains(arrival, ClosedList))
            {
                list = new List<Vector2>();
                test = new Node();
                test = ClosedList.Find(node => node.Id == arrival.Id);
                list.Add(test.Position);
                while (test.Parent != null)
                {
                    test = test.Parent;
                    list.Add(test.Position);
                }
                Mouvement(gameTime);
            }
        }

        private Node FindMinPoids(List<Node> nodes)
        {
            Node minPoids = nodes[0];
            for (int i = 1; i < nodes.Count; i++)
                if (nodes[i].Weight <= minPoids.Weight)
                    minPoids = nodes[i];
            return minPoids;
        }

        private bool Contains(Node node , List<Node> nodes)
        {
            foreach (Node n in nodes)
                if (n.Id == node.Id)
                    return true;
            return false;
        }

        private void FindNode(Node curr)
        {
            // A changer en liste pour des foreachs

            Node u = new Node(curr, NodePos.U, mapData);
            Node d = new Node(curr, NodePos.D, mapData);
            Node r = new Node(curr, NodePos.R, mapData);
            Node l = new Node(curr, NodePos.L, mapData);
            Node ul = new Node(curr, NodePos.UL, mapData);
            Node ur = new Node(curr, NodePos.UR, mapData);
            Node dl = new Node(curr, NodePos.DL, mapData);
            Node dr = new Node(curr, NodePos.DR, mapData);

            if (l.Position.X >= 0 && l.Position.X + monster.TextureSize.X <= mapData.MapWidth * 32 && l.Position.Y >= 0 && l.Position.Y + monster.TextureSize.Y <= 32 * mapData.MapHeight && !(mapData.Accessibility[l.Id] == 1 || Contains(l, ClosedList)))
            {
                if (!Contains(l, OpenedList))
                {
                    l.Parent = curr;
                    l.DistanceParcourue = curr.DistanceParcourue + 32;
                    OpenedList.Add(l);
                }
            }
            if (r.Position.X >= 0 && r.Position.X + monster.TextureSize.X <= mapData.MapWidth * 32 && r.Position.Y >= 0 && r.Position.Y + monster.TextureSize.Y <= 32 * mapData.MapHeight && !(mapData.Accessibility[r.Id] == 1 || Contains(r, ClosedList)))
            {
                if (!Contains(r, OpenedList))
                {
                    r.Parent = curr;
                    r.DistanceParcourue = curr.DistanceParcourue + 32;
                    OpenedList.Add(r);
                }
            }
            if (u.Position.X >= 0 && u.Position.X + monster.TextureSize.X <= mapData.MapWidth * 32 && u.Position.Y >= 0 && u.Position.Y + monster.TextureSize.Y <= 32 * mapData.MapHeight && !(mapData.Accessibility[u.Id] == 1 || Contains(u, ClosedList)))
            {
                if (!Contains(u, OpenedList))
                {
                    u.Parent = curr;
                    u.DistanceParcourue = curr.DistanceParcourue + 32;
                    OpenedList.Add(u);
                }
            }
            if (d.Position.X >= 0 && d.Position.X + monster.TextureSize.X <= mapData.MapWidth * 32 && d.Position.Y >= 0 && d.Position.Y + monster.TextureSize.Y <= 32 * mapData.MapHeight && !(mapData.Accessibility[d.Id] == 1 || Contains(d, ClosedList)))
            {
                if (!Contains(d, OpenedList))
                {
                    d.Parent = curr;
                    d.DistanceParcourue = curr.DistanceParcourue + 32;
                    OpenedList.Add(d);
                }
            }
            if (ul.Position.X >= 0 && ul.Position.X + monster.TextureSize.X <= mapData.MapWidth * 32 && ul.Position.Y >= 0 && ul.Position.Y + monster.TextureSize.Y <= 32 * mapData.MapHeight && !(mapData.Accessibility[ul.Id] == 1 || Contains(ul, ClosedList)))
            {
                if (!Contains(ul, OpenedList))
                {
                    ul.Parent = curr;
                    ul.DistanceParcourue = curr.DistanceParcourue + Math.Sqrt(2048); //A modifie
                    OpenedList.Add(ul);
                }
            }
            if (ur.Position.X >= 0 && ur.Position.X + monster.TextureSize.X <= mapData.MapWidth * 32 && ur.Position.Y >= 0 && ur.Position.Y + monster.TextureSize.Y <= 32 * mapData.MapHeight && !(mapData.Accessibility[ur.Id] == 1 || Contains(ur, ClosedList)))
            {
                if (!Contains(ur, OpenedList))
                {
                    ur.Parent = curr;
                    ur.DistanceParcourue = curr.DistanceParcourue + Math.Sqrt(2048);
                    OpenedList.Add(ur);
                }
            }
            if (dl.Position.X >= 0 && dl.Position.X + monster.TextureSize.X <= mapData.MapWidth * 32 && dl.Position.Y >= 0 && dl.Position.Y + monster.TextureSize.Y <= 32 * mapData.MapHeight && !(mapData.Accessibility[dl.Id] == 1 || Contains(dl, ClosedList)))
            {
                if (!Contains(dl, OpenedList))
                {
                    dl.Parent = curr;
                    dl.DistanceParcourue = curr.DistanceParcourue + Math.Sqrt(2048);
                    OpenedList.Add(dl);
                }
            }
            if (dr.Position.X >= 0 && dr.Position.X + monster.TextureSize.X <= mapData.MapWidth * 32 && dr.Position.Y >= 0 && dr.Position.Y + monster.TextureSize.Y <= 32 * mapData.MapHeight && !(mapData.Accessibility[dr.Id] == 1 || Contains(dr, ClosedList)))
            {
                if (!Contains(dr, OpenedList))
                {
                    dr.Parent = curr;
                    dr.DistanceParcourue = curr.DistanceParcourue + Math.Sqrt(2048);
                    OpenedList.Add(dr);
                }
            }
        }
    }
}
