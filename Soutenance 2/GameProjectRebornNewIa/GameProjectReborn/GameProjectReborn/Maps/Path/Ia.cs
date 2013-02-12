﻿using System;
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

        public Ia(GameTime gameTime, Player player, Monster monster)
        {
            this.monster = monster;
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
                if (gameTime.TotalGameTime.TotalMilliseconds % 500 < 1)
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
                else if (list[list.Count - 1].Y > monster.Position.Y )
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

            Node u = new Node(curr, NodePos.U, mapData, monster.TextureSize);
            Node d = new Node(curr, NodePos.D, mapData, monster.TextureSize);
            Node r = new Node(curr, NodePos.R, mapData,monster.TextureSize);
            Node l = new Node(curr, NodePos.L, mapData,monster.TextureSize);
            Node ul = new Node(curr, NodePos.UL, mapData,monster.TextureSize);
            Node ur = new Node(curr, NodePos.UR, mapData, monster.TextureSize);
            Node dl = new Node(curr, NodePos.DL, mapData,monster.TextureSize);
            Node dr = new Node(curr, NodePos.DR, mapData, monster.TextureSize);

            if (l.Id >= 0 && !Contains(l, ClosedList))
            {
                if (mapData.Accessibility[/*(int)(l.Position.X/32) + ((int)(l.Position.Y/32) + (int)(monster.TextureSize.Y/32)) * mapData.MapWidth*/ l.Id + mapData.MapWidth] != 1 //Condition de carrer
                    && (mapData.SideAccess[l.Id] & 8) != 8 && /*(l.Id == (int)(l.Position.X/32) +((int)(monster.TextureSize.Y / 32) + (int)(l.Position.Y/32)) * mapData.MapWidth ||*/ (mapData.SideAccess[l.Id + mapData.MapWidth] & 1) != 1) //Condition pour les barres de collision
                    if (!Contains(l, OpenedList))
                    {
                        l.Parent = curr;
                        l.DistanceParcourue = curr.DistanceParcourue + 32;
                        OpenedList.Add(l);
                    }
            }
            if (r.Id >= 0 && !Contains(r, ClosedList))
            {
                if (mapData.Accessibility[/*(int)(r.Position.X/32) + ((int)(monster.TextureSize.Y / 32) + (int)(r.Position.Y/32)) * mapData.MapWidth*/ r.Id + mapData.MapWidth] != 1 && mapData.Accessibility[/*(int)(r.Position.X/32) + (int)(monster.TextureSize.X/32) + (int)(r.Position.Y/32) * mapData.MapWidth*/ r.Id + 1] != 1 //Carrer
                    && (mapData.SideAccess[r.Id] & 4) != 4 && /*(r.Id == (int)(r.Position.X/32) + ((int)(monster.TextureSize.Y / 32) + (int)(r.Position.Y/32)) * mapData.MapWidth ||*/ (mapData.SideAccess[r.Id + mapData.MapWidth] & 1) != 1 && /*(r.Id == (int)(r.Position.X/32) + (int)(monster.TextureSize.X / 32) + (int)(r.Position.Y/32) *mapData.MapWidth ||*/ (mapData.SideAccess[r.Id + 1] & 4) != 4) //Barre
                    if (!Contains(r, OpenedList))
                    {
                        r.Parent = curr;
                        r.DistanceParcourue = curr.DistanceParcourue + 32;
                        OpenedList.Add(r);
                    }
            }
            if (u.Id>=0 && !Contains(u, ClosedList))
            {
                if (mapData.Accessibility[/*(int)(u.Position.X/32) + (int)(monster.TextureSize.X/32) + (int)(r.Position.Y/32) * mapData.MapWidth*/ u.Id +1] != 1 //Carrer
                    && (mapData.SideAccess[u.Id] & 2) != 2 && /*(u.Id == (int)(u.Position.X/32) + (int)(monster.TextureSize.X / 32) + (int)(u.Position.Y/32) * mapData.MapWidth ||*/ (mapData.SideAccess[u.Id + 1] & 4) != 4)
                    if (!Contains(u, OpenedList))
                    {
                        u.Parent = curr;
                        u.DistanceParcourue = curr.DistanceParcourue + 32;
                        OpenedList.Add(u);
                    }
            }
            if (d.Id >=0 && !Contains(d, ClosedList))
            {
                if (mapData.Accessibility[/*(int)(d.Position.X/32) + ((int)(monster.TextureSize.Y/32) + (int)(d.Position.Y/32)) *mapData.MapWidth*/ d.Id + mapData.MapWidth] != 1 && mapData.Accessibility[/*(int)(d.Position.X/32) + (int)(monster.TextureSize.X/32) + (int)(d.Position.Y/32) * mapData.MapWidth*/ d.Id + 1] != 1
                    && (mapData.SideAccess[d.Id] & 1) != 1 && /*(d.Id == (int)(d.Position.X/32) + ((int)(monster.TextureSize.Y / 32) + (int)(d.Position.Y/32)) * mapData.MapWidth ||*/ (mapData.SideAccess[d.Id + mapData.MapWidth] & 1) != 1 && /*(d.Id == (int)(d.Position.X/32) + (int)(monster.TextureSize.X / 32) + (int)(d.Position.Y/32) * mapData.MapWidth ||*/ (mapData.SideAccess[d.Id + 1] & 4) != 4)
                if (!Contains(d, OpenedList))
                {
                    d.Parent = curr;
                    d.DistanceParcourue = curr.DistanceParcourue + 32;
                    OpenedList.Add(d);
                }
            }
            /*if (ul.Id >= 0 && !Contains(ul, ClosedList))
            {
                if (!Contains(ul, OpenedList))
                {
                    ul.Parent = curr;
                    ul.DistanceParcourue = curr.DistanceParcourue + Math.Sqrt(2048); //A modifie
                    OpenedList.Add(ul);
                }
            }
            if (ur.Id >=0 && !Contains(ur, ClosedList))
            {
                if (!Contains(ur, OpenedList))
                {
                    ur.Parent = curr;
                    ur.DistanceParcourue = curr.DistanceParcourue + Math.Sqrt(2048);
                    OpenedList.Add(ur);
                }
            }
            if (dl.Id >=0 && !Contains(dl, ClosedList))
            {
                if (!Contains(dl, OpenedList))
                {
                    dl.Parent = curr;
                    dl.DistanceParcourue = curr.DistanceParcourue + Math.Sqrt(2048);
                    OpenedList.Add(dl);
                }
            }
            if (dr.Id >=0 && !Contains(dr, ClosedList))
            {
                if (!Contains(dr, OpenedList))
                {
                    dr.Parent = curr;
                    dr.DistanceParcourue = curr.DistanceParcourue + Math.Sqrt(2048);
                    OpenedList.Add(dr);
                }
            }*/
        }
    }
}
