using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace Jeux
{
    class Map
    {
        Tile[,] tiles;
        Vector2 size;

        public Tile[,] Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }

        public Vector2 Size
        {
            get { return size; }
        }

        public Vector2 PixelSize
        {
            get { return size * tiles[0, 0].Size; }
        }

        public Map()
        {
        }

        public Map(Vector2 size)
        {
            this.size = size;
            tiles = new Tile[(int)size.X, (int)size.Y];
        }

        public void DefaultLoadContent(TextureManager textureManager, string defaulTextureName)
        {
            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
                {
                    Tiles[i, j] = new Tile(new Vector2(i, j));
                    tiles[i, j].LoadContent(textureManager, defaulTextureName);
                }
            }
        }
        /*
        public void LoadFileContent(string fileName, ref Map map)
        {
            StreamReader SR;
            string line = "";
            int j = 0;
            try
            {
                SR = new StreamReader(fileName);
            }
            catch (Exception)
            {

            }
            while ((line = SR.ReadLine()) != null && j < map.tiles.GetLength(1))
            {
                if (line.Length < map.tiles.GetLength(0))
                {
                    SR.Close();
                }
            }
        }
        */
        public void LoadContent(TextureManager textureManager)
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    tiles[i, j].LoadContent(textureManager);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    tiles[i, j].Draw(spriteBatch);
                }
            }
        }
    }
}