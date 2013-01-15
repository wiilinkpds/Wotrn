using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Jeux
{
    class Sprite
    {
        Texture2D texture;
        Vector2 position;
        Vector2 origin = Vector2.Zero;
        Vector2 scale = Vector2.One;
        Rectangle destinationRectangle;
        Rectangle? sourceRectangle = null;
        Rectangle? colisionRectangle = null;
        Color color;
        SpriteEffects effect = SpriteEffects.None;
        bool colisionRectangleVisible = false;
        bool colision = false;
        Texture2D textureColisionRectangle;
        float indexX = 0;
        float indexY = 0;
        float rotation = 0;
        float layerDepth = 0;
        int maxIndexX = 0;
        int maxIndexY = 0;
        string readingDimension;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Rectangle DestinationRectangle
        {
            get
            {
                if (destinationRectangle == null)
                {
                    this.destinationRectangle = new Rectangle((int)position.X, (int)position.Y, SourceRectangle.Value.Width, SourceRectangle.Value.Height);
                    return (Rectangle)destinationRectangle;
                }
                else
                    return (Rectangle)destinationRectangle;
            }
            set { this.destinationRectangle = value; }
        }

        public Rectangle? SourceRectangle
        {
            get
            {
                if (sourceRectangle == null)
                {
                    this.destinationRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
                    return (Rectangle)sourceRectangle;
                }
                else
                    return (Rectangle)sourceRectangle;
            }
            set { sourceRectangle = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Vector2 RotationOrigin
        {
            get { return origin; }
            set { origin = value; }
        }

        public Vector2 Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public SpriteEffects Effect
        {
            get { return effect; }
            set { effect = value; }
        }

        public float LayerDepth
        {
            get { return layerDepth; }
            set { layerDepth = value; }
        }

        public bool ColisionRectangleIsVisible
        {
            get { return colisionRectangleVisible; }
            set { colisionRectangleVisible = value; }
        }

        public bool Colision
        {
            get { return colision; }
            set { colision = value; }
        }

        public Sprite(Vector2 position)
        {
            this.position = position;
        }

        public Sprite(float x, float y)
        {
            position = new Vector2(x, y);
        }

        public Sprite(Rectangle destinationRectangle)
        {
            this.destinationRectangle = destinationRectangle;
        }

        public Sprite(Rectangle destinationRectangle, Rectangle? sourceRectangle)
        {
            this.destinationRectangle = destinationRectangle;
            this.SourceRectangle = sourceRectangle;
        }

        public Sprite(Vector2 position, Rectangle? sourceRectangle)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
        }

        public Sprite(float x, float y, Rectangle? sourceRectangle)
        {
            position = new Vector2(x, y);
            this.sourceRectangle = sourceRectangle;
        }

        public Sprite(Vector2 position, Rectangle? sourceRectangle, float rotation, Vector2 origin, Vector2 scale)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
        }

        public void LoadContent(TextureManager textureManager, string assetName)
        {
            texture = textureManager.GetTexture(assetName);
        }

        public Texture2D Texture
        {
            get { return texture; }
        }

        public Rectangle ColisionRectangle
        {
            get
            {
                if (colisionRectangle == null)
                {
                    this.colisionRectangle = new Rectangle((int)position.X, (int)position.Y, SourceRectangle.Value.Width, SourceRectangle.Value.Height);
                    return (Rectangle)colisionRectangle;
                }
                else
                    return (Rectangle)colisionRectangle;
            }
            set { colisionRectangle = value; }
        }

        public Rectangle ColisionRectangle2
        {
            get { return new Rectangle((int)position.X, (int)position.Y, SourceRectangle.Value.Width, SourceRectangle.Value.Height); }
            set { colisionRectangle = value; }
        }

        public void Update(Vector2 translation)
        {
            position += translation;
            if (colision)
            {
                colisionRectangle = new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Value.Width, sourceRectangle.Value.Height);
            }
        }

        public void LoadContent(TextureManager textureManager, string assetName, int maxIndexX, int maxIndexY, string readingDimension)
        {
            if (colisionRectangleVisible)
            {
                textureColisionRectangle = textureManager.GetTexture("rectangle");
            }
            texture = textureManager.GetTexture(assetName);
            this.maxIndexX = maxIndexX;
            this.maxIndexY = maxIndexY;
            this.readingDimension = readingDimension;
        }

        public void UpdateAnimation(GameTime gameTime)
        {
            if (maxIndexX != 0)
            {
                indexX += gameTime.ElapsedGameTime.Milliseconds * 0.007f;

                if (indexX > maxIndexX)
                {
                    indexX = 0;
                }
                if (readingDimension == "h")
                {
                    sourceRectangle = new Rectangle((int)indexX * sourceRectangle.Value.Width, sourceRectangle.Value.Y, sourceRectangle.Value.Width, sourceRectangle.Value.Height);
                }
                if (readingDimension == "v")
                {
                    sourceRectangle = new Rectangle(sourceRectangle.Value.X, (int)indexY * sourceRectangle.Value.Height, sourceRectangle.Value.Width, sourceRectangle.Value.Height);
                }
            }
        }

        public void UpdateSetStateAnimation(int index)
        {
            if (readingDimension == "h")
            {
                sourceRectangle = new Rectangle(index * sourceRectangle.Value.Width, sourceRectangle.Value.Y, sourceRectangle.Value.Width, sourceRectangle.Value.Height);
            }
            if (readingDimension == "v")
            {
                sourceRectangle = new Rectangle(sourceRectangle.Value.X, index * sourceRectangle.Value.Height, sourceRectangle.Value.Width, sourceRectangle.Value.Height);
            }
        }

        public void UpdateSetStateAnimation(int indexX, int indexY)
        {
            sourceRectangle = new Rectangle(indexX * sourceRectangle.Value.Width, indexY * sourceRectangle.Value.Height, sourceRectangle.Value.Width, sourceRectangle.Value.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, scale, effect, layerDepth);
            if (colisionRectangleVisible)
            {
                spriteBatch.Draw(textureColisionRectangle,(Rectangle)colisionRectangle, Color.White);
            }
        }
    }
}
