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
using GameProject.Joueurs;

namespace GameProject.Managers
{
    public class Sprite
    {
        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }
        private Texture2D _texture;

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        private Vector2 _position;

        public Rectangle rectangleColision
        {
            get {
                if (sourceRectangle != null)
                    return new Rectangle((int)_position.X, (int)_position.Y + sourceRectangle.Value.Height / 2, sourceRectangle.Value.Width, sourceRectangle.Value.Height / 2);
                else
                    return new Rectangle((int)_position.X, (int)_position.Y + this.Height / 2, this.Width, this.Height / 2);
            }
        }
        public Rectangle rectangle
        {
            get { return new Rectangle((int)_position.X, (int)_position.Y, this.Width, this.Height); }
        }

        Rectangle? sourceRectangle = null;
        public Rectangle? SourceRectangle
        {
            get { return sourceRectangle; }
            set { sourceRectangle = value; }
        }
        float Xindex = 0, Yindex = 0;
        int maXindex = 0, maYindex = 0;
        string readingDimension;

        public virtual void Initialize(Vector2 Position_init)
        {
            _position = Position_init;
        }
        public virtual void Initialize(Vector2 Position_init, Rectangle? sourceRectangle)
        {
            _position = Position_init;
            this.sourceRectangle = sourceRectangle;
        }

        public virtual void LoadContent(ContentManager content, string assetName)
        {
            _texture = content.Load<Texture2D>(assetName);
        }
        public virtual void LoadContent(ContentManager content, string assetName, int maXindex, int maYindex, string readingDimension)
        {
            _texture = content.Load<Texture2D>(assetName);
            this.maXindex = maXindex;
            this.maYindex = maYindex;
            this.readingDimension = readingDimension;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,_position,sourceRectangle, Color.White);
        }
        public virtual void Draw(SpriteBatch spriteBatch, Rectangle _rectangle)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);
        }

        public int Height
        {
            get { return _texture.Height; }
        }
        public int Width
        {
            get { return _texture.Width; }
        }
        public virtual void Update(Sprite[] textTab, Sprite background, Sprite[] enemis, GameTime gameTime)
        {
            MoteurPhysique.Colision(textTab ,this, background, enemis, gameTime);
        }

        public virtual void UpdateAnimation(GameTime gameTime)
        {
            if (maXindex != 0)
            {
                Xindex += gameTime.ElapsedGameTime.Milliseconds * 0.007f;

                if (Xindex > maXindex)
                {
                    Xindex = 0;
                }
                if (readingDimension == "h")
                {
                    sourceRectangle = new Rectangle((int)Xindex * sourceRectangle.Value.Width, sourceRectangle.Value.Y, sourceRectangle.Value.Width, sourceRectangle.Value.Height);
                }
                if (readingDimension == "v")
                {
                    sourceRectangle = new Rectangle(sourceRectangle.Value.X, (int)Yindex * sourceRectangle.Value.Height, sourceRectangle.Value.Width, sourceRectangle.Value.Height);
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
    }
}
