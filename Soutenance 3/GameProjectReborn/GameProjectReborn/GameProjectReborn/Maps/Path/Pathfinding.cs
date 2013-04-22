using System.Collections.Generic;
using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Maps.Path
{   
    public class Pathfinding
    {
        public List<int> list { get; set; }

        private List<Node> openedList { get; set; }
        private List<Node> closedList { get; set; }

        private Node start { get; set; }
        private Node arrival { get; set; }
        private Node test { get; set; }
        private Node current { get; set; }

        private MapData mapData { get; set; }
        private Entity monster { get; set; }
        private Vector2 move;

        public Pathfinding(GameTime gameTime, Vector2 player, Entity monster, MapData map)
        {
            this.monster = monster;

            openedList = new List<Node>();
            closedList = new List<Node>();
            mapData = map;

            if (player.X < 0 || player.X > mapData.MapWidth * 32 || player.Y < 0 || player.Y > mapData.MapHeight * 32 || mapData.Accessibility[ConversionManager.VectToId(map, player)] == 1)
                return;

            start = new Node(monster.Position, monster.Position, player, mapData) { Parent = null };
            arrival = new Node(player, monster.Position, player, mapData);

            openedList.Add(start);
            PathFind(gameTime, map);
        }

        public void Movement(GameTime gameTime, Entity entitie, MapData map)
        {
            int id = (int)(entitie.Position.X / 32) + (int)(entitie.Position.Y / 32) * mapData.MapWidth;
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 10.0f;
            move = Vector2.Zero;

            if (list != null)
                list.Remove(id);

            if (list != null && list.Count > 0)
            {
                if (list[list.Count - 1] == id - mapData.MapWidth)
                {
                    if (gameTime.TotalGameTime.TotalMilliseconds % 500 < 10 || !(entitie is Monster))
                        entitie.Direction = Direction.Up;
                    move.Y--;
                    move.Normalize();
                    if (ConversionManager.VectToId(map, new Vector2(entitie.Position.X, entitie.Position.Y + entitie.TextureSize.Y + (move.Y * entitie.Speed * time))) == id - mapData.MapWidth)
                        list.Remove(id - mapData.MapWidth);
                }
                else if (list[list.Count - 1] == id + mapData.MapWidth)
                {
                    if (gameTime.TotalGameTime.TotalMilliseconds % 1000 < 10 || !(entitie is Monster))
                        entitie.Direction = Direction.Down;
                    move.Y++;
                    move.Normalize();
                    if (ConversionManager.VectToId(map, new Vector2(entitie.Position.X, entitie.Position.Y + (move.Y * entitie.Speed * time))) == id + mapData.MapWidth)
                        list.Remove(id + mapData.MapWidth);
                }
                else if (list[list.Count - 1] == id - 1)
                {
                    if (gameTime.TotalGameTime.TotalMilliseconds % 1000 < 10 || !(entitie is Monster))
                        entitie.Direction = Direction.Left;
                    move.X--;
                    move.Normalize();
                    if (ConversionManager.VectToId(map, new Vector2(entitie.Position.X + entitie.TextureSize.X + (move.X * entitie.Speed * time), entitie.Position.Y)) == id - 1)
                        list.Remove(id - 1);
                }
                else if (list[list.Count - 1] == id + 1)
                {
                    if (gameTime.TotalGameTime.TotalMilliseconds % 1000 < 10 || !(entitie is Monster))
                        entitie.Direction = Direction.Right;
                    move.X++;
                    move.Normalize();
                    if (ConversionManager.VectToId(map, new Vector2(entitie.Position.X + (move.X * entitie.Speed * time), entitie.Position.Y)) == id + 1)
                        list.Remove(id + 1);
                }
                if (move == Vector2.Zero)
                    return;

                entitie.Position = entitie.Position + move * entitie.Speed * time;
            }
        }

        public void PathFind(GameTime gameTime, MapData map)
        {
            while (!Contains(arrival, closedList) && openedList.Count != 0)
            {
                current = new Node();
                current = FindMinPoids(openedList);
                openedList.Remove(current);
                if (current.Position.X >= 0 && current.Position.X + monster.TextureSize.X <= mapData.MapWidth*32 && current.Position.Y >= 0 && current.Position.Y + monster.TextureSize.Y <= 32 * mapData.MapHeight)
                {
                    closedList.Add(current);
                    FindNode(current);
                }
            }
            if (Contains(arrival, closedList))
            {
                list = new List<int>();
                test = new Node();
                test = closedList.Find(node => node.Id == arrival.Id);
                list.Add(test.Id);
                while (test.Parent != null)
                {
                    test = test.Parent;
                    list.Add(test.Id);
                }
                if (monster is Monster)
                    Movement(gameTime, monster, map);
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

        private void FindNode(Node curr)
        {
            Node u = new Node(curr, NodePos.U, mapData, monster.TextureSize);
            Node d = new Node(curr, NodePos.D, mapData, monster.TextureSize);
            Node r = new Node(curr, NodePos.R, mapData, monster.TextureSize);
            Node l = new Node(curr, NodePos.L, mapData, monster.TextureSize);

            if (l.CanGo && !Contains(l, closedList))
            {
                if (!Contains(l, openedList))
                {
                    l.Parent = curr;
                    l.DistanceParcourue = curr.DistanceParcourue + 32;
                    openedList.Add(l);
                }
            }
            if (r.CanGo && !Contains(r, closedList))
            {
                if (!Contains(r, openedList))
                {
                    r.Parent = curr;
                    r.DistanceParcourue = curr.DistanceParcourue + 32;
                    openedList.Add(r);
                }
            }
            if (u.CanGo && !Contains(u, closedList))
            {
                if (!Contains(u, openedList))
                {
                    u.Parent = curr;
                    u.DistanceParcourue = curr.DistanceParcourue + 32;
                    openedList.Add(u);
                }
            }
            if (d.CanGo && !Contains(d, closedList))
            {
                if (!Contains(d, openedList))
                {
                    d.Parent = curr;
                    d.DistanceParcourue = curr.DistanceParcourue + 32;
                    openedList.Add(d);
                }
            }
        }

        private bool Contains(Node node, List<Node> nodes)
        {
            foreach (Node n in nodes)
                if (n.Id == node.Id)
                    return true;
            return false;
        }
    }
}
