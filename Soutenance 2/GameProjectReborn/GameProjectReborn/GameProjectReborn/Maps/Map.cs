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
        public const int TileSize = 32; //pixels

        public readonly MapData Data;

        public Map(MapData map)
        {
            Data = map;
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

        public bool IsCollidedPath(Point point)
        {
            point.X = point.X / TileSize;
            point.Y = point.Y / TileSize;

            int id = point.X + point.Y * Data.MapWidth;

            if (Data.Accessibility[id] == 1) // Si la case est rouge dans l'editeur
                return true;
            return false;
        }

        private bool IsCollidedAt(Entity entity, Vector2 position, Point point)
        {
            point.X = point.X / TileSize;
            point.Y = point.Y / TileSize;

            int id = point.X + point.Y * Data.MapWidth;

            if (point.X >= Data.MapWidth || point.Y >= Data.MapHeight || point.X < 0 || point.Y < 0)
                return true;

            if (Data.Accessibility[id] == 1) // Si la case est rouge dans l'editeur
                return true;

            // 0000 1111
            // [0][0][0][0] [Droite] [Gauche] [Bas] [Haut]

            // 0000 0101 = 5
            // et
            // 0000 0001 = 1
            // =
            // 0000 0001 = 1

            // 0000 0101 = 5
            // et
            // 0000 0100 = 4
            // =
            // 0000 0100 = 4

            IList<Vector2> intersect = new List<Vector2>();

            // Haut
            if ((Data.SideAccess[id] & 1) == 1)
            {
                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize));
                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize));
            }

            // Bas
            if ((Data.SideAccess[id] & 2) == 2)
            {
                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize + TileSize));
                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize + TileSize));
            }

            // Gauche
            if ((Data.SideAccess[id] & 4) == 4)
            {
                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize));
                intersect.Add(new Vector2(point.X * TileSize, point.Y * TileSize + TileSize));
            }

            // Droite
            if ((Data.SideAccess[id] & 8) == 8)
            {
                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize));
                intersect.Add(new Vector2(point.X * TileSize + TileSize, point.Y * TileSize + TileSize));
            }

            foreach (Vector2 vect in intersect)
                if (vect.X >= position.X && vect.X <= position.X + entity.TextureSize.X)
                    if (vect.Y >= position.Y && vect.Y <= position.Y + entity.TextureSize.Y)
                        return true;

            return false;
        }

        public void Draw(UberSpriteBatch spriteBatch, bool isBackground)
        {
            for (int x = 0; x < Data.MapWidth; x++)
                for (int y = 0; y < Data.MapHeight; y++)
                    DrawTile(spriteBatch, x, y, isBackground);
        }

        private void DrawTile(UberSpriteBatch spriteBatch, int x, int y, bool isBackground)
        {
            int cellId = y * Data.MapWidth + x;
            int tileId = Data.MapTilesLow[cellId];

            if (isBackground)
                DrawTile(spriteBatch, tileId, x, y);

            bool isBackgroundCell = Data.Accessibility[cellId] == 0;
            bool canDraw = (isBackground ^ !isBackgroundCell);

            if (!canDraw) return;

            tileId = Data.MapTilesMiddle[cellId];
            DrawTile(spriteBatch, tileId, x, y);

            tileId = Data.MapTilesHigh[cellId];
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
