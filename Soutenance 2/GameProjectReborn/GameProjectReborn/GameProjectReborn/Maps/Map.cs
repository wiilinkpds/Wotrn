using System;
using System.Collections.Generic;
using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Maps
{
    public class Map
    {
        private const int TileSize = 32; //pixels

        private readonly MapData data;

        public Map(MapData map)
        {
            data = map;
        }

        public Vector2 Move(Entity entity, Vector2 position, Vector2 move)
        {
            Vector2 newPosition = position + move;

            if (!IsCollided(entity, newPosition))
                return newPosition;

            return position;
        }

        public bool IsCollided(Entity entity, Vector2 position)
        {
            if (position.X < 0 || position.Y < 0)
                return true;

            // Point Haut Gauche
            Point point = new Point((int)position.X, (int)position.Y);
            if (IsCollidedAt(entity, position, point)) return true;

            // Point Bas Gauche
            point = new Point((int)position.X + (int)entity.TextureSize.X, (int)position.Y);
            if (IsCollidedAt(entity, position, point)) return true;

            // Point Haut Droite
            point = new Point((int)position.X, (int)position.Y + (int)entity.TextureSize.Y);
            if (IsCollidedAt(entity, position, point)) return true;

            // Point Bas Droite
            point = new Point((int)position.X + (int)entity.TextureSize.X, (int)position.Y + (int)entity.TextureSize.Y);
            if (IsCollidedAt(entity, position, point)) return true;

            return false;
        }

        private bool IsCollidedAt(Entity entity, Vector2 position, Point point)
        {
            point.X = point.X / TileSize;
            point.Y = point.Y / TileSize;

            int id = point.X + point.Y * data.MapWidth;

            if (point.X >= data.MapWidth || point.Y >= data.MapHeight || point.X < 0 || point.Y < 0)
                return true;

            if (data.Accessibility[id] == 1) // Si la case est rouge dans l'editeur
                return true;

            // 0000 1111
            // [0][0][0][0] [Droite] [Gauche] [Bas] [Haut]

            IList<Vector2> intersect = new List<Vector2>();

            // Haut
            if (data.SideAccess[id] == 1)
            {
                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize));
                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize));
            }

            // Bas
            if (data.SideAccess[id] == 2)
            {
                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize + TileSize));
                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize + TileSize));
            }

            // Gauche
            if (data.SideAccess[id] == 4)
            {
                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize));
                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize + TileSize));
            }

            // Droite
            if (data.SideAccess[id] == 8)
            {
                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize));
                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize + TileSize));
            }

            // Haut + Gauche
            if (data.SideAccess[id] == 5)
            {
                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize));
                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize));

                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize));
                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize + TileSize));
            }

            // Haut + Droite
            if (data.SideAccess[id] == 9)
            {
                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize));
                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize));

                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize));
                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize + TileSize));
            }

            // Bas + Gauche
            if (data.SideAccess[id] == 6)
            {
                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize + TileSize));
                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize + TileSize));

                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize));
                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize + TileSize));
            }

            // Bas + Droite
            if (data.SideAccess[id] == 10)
            {
                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize + TileSize));
                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize + TileSize));

                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize));
                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize + TileSize));
            }

            foreach (Vector2 vect in intersect)
            {
                if (   vect.X >= position.X
                    && vect.X <= position.X + entity.TextureSize.X) // Si il est compris entre Position.X et Position.X + entity.Texture.Width !!!!
                {
                    if (   vect.Y >= position.Y
                        && vect.Y <= position.Y + entity.TextureSize.Y)
                        return true;
                }
            }
            return false;
        }

        public void Draw(UberSpriteBatch spriteBatch, bool isBackground)
        {
            for (int x = 0; x < data.MapWidth; x++)
                for (int y = 0; y < data.MapHeight; y++)
                    DrawTile(spriteBatch, x, y, isBackground);
        }

        private void DrawTile(UberSpriteBatch spriteBatch, int x, int y, bool isBackground)
        {
            int cellId = y * data.MapWidth + x;
            int tileId = data.MapTilesLow[cellId];

            if (isBackground)
                DrawTile(spriteBatch, tileId, x, y);

            bool isBackgroundCell = data.Accessibility[cellId] == 0;
            bool canDraw = (isBackground ^ !isBackgroundCell);

            if (!canDraw) return;

            tileId = data.MapTilesMiddle[cellId];
            DrawTile(spriteBatch, tileId, x, y);

            tileId = data.MapTilesHigh[cellId];
            DrawTile(spriteBatch, tileId, x, y);
        }

        private static void DrawTile(UberSpriteBatch spriteBatch, int tileId, int x, int y)
        {
            if (tileId < 0)
                return;

            int tileX = tileId % 8;
            int tileY = (int)Math.Floor(tileId / 8.0);

            Rectangle dest = new Rectangle(x * TileSize, y * TileSize, TileSize, TileSize);
            Rectangle src = new Rectangle(tileX * TileSize, tileY * TileSize, TileSize, TileSize);

            spriteBatch.Draw(TexturesManager.MapTiles, dest, src);
        }
    }
}
