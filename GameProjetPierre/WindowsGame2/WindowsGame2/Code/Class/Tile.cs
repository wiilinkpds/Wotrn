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

namespace Jeux
{
    class Tile
    {
        Rectangle colisionRectangle;
        bool colision;
        bool collisionRectangleIsVisible = false;
        Texture2D texture;
        Texture2D rectangleTexture;
        Vector2 position;
        string assetName;

        public bool CollisionRectangleIsVisible
        {
            get { return collisionRectangleIsVisible; }
            set { collisionRectangleIsVisible = value; }
        }

        public string AssetName
        {
            get { return assetName; }
            set { assetName = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Size
        {
            get { return new Vector2(texture.Width, texture.Height); }
        }

        public Vector2 PixelPosition
        {
            get { return new Vector2(texture.Width * position.X, texture.Height * position.Y); }
        }

        public Rectangle ColisionRectangle
        {
            get { return colisionRectangle; }
            set { colisionRectangle = value; }
        }

        public bool Colision
        {
            get { return colision; }
            set { colision = value; }
        }

        public Tile(Vector2 position)
        {
            this.position = position;
        }

        public Tile( string assetName, Vector2 position)
        {
            this.assetName = assetName;
            this.position = position;
        }

        public Tile(Vector2 position, Rectangle colisionRectangle)
        {
            colision = true;
            this.colisionRectangle = colisionRectangle;
            this.position = position;
        }

        public Tile(string assetName, Vector2 position, Rectangle colisionRectangle)
        {
            colision = true;
            this.colisionRectangle = colisionRectangle;
            this.assetName = assetName;
            this.position = position;
        }

        public void LoadContent(TextureManager textureManager, string assetName)
        {
            this.assetName = assetName;
            this.texture = textureManager.GetTexture(assetName);
            if (collisionRectangleIsVisible == true & colisionRectangle != null)
            {
                rectangleTexture = textureManager.GetTexture("rectangle");
            }
        }

        public void LoadContent(TextureManager textureManager)
        {
            this.texture = textureManager.GetTexture(assetName);
            if (collisionRectangleIsVisible == true & colisionRectangle != null)
            {
                rectangleTexture = textureManager.GetTexture("rectangle");
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, new Vector2(position.X * texture.Width, position.Y * texture.Height), Color.White);
            spriteBatch.Draw(texture, new Vector2(position.X * texture.Width, position.Y * texture.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            if (collisionRectangleIsVisible == true & colisionRectangle != null)
            {
                spriteBatch.Draw(rectangleTexture, colisionRectangle, Color.White);
            }
        }
    }
}
