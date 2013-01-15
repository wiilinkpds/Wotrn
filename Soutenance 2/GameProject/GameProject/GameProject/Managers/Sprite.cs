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
        public Texture2D Texture { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle rectangleColision
        {
            get {
                if (SourceRectangle != null)
                    return new Rectangle((int)Position.X, (int)Position.Y + SourceRectangle.Value.Height / 2, SourceRectangle.Value.Width, SourceRectangle.Value.Height / 2);
                else
                    return new Rectangle((int)Position.X, (int)Position.Y + this.Height / 2, this.Width, this.Height / 2);
            }
        }
        public Rectangle rectangle { get { return new Rectangle((int)Position.X, (int)Position.Y, this.Width, this.Height); }}

        public Rectangle? SourceRectangle { get; set; }

        public int maXindex { get; set; }
        public int maYindex {get;set;}
        float Xindex = 0 , Yindex = 0;
        public string readingDimension { get; set; }

        public virtual void Initialize(Vector2 Position_init)
        {
            SourceRectangle = null;
            Position = Position_init;
        }
        public virtual void Initialize(Vector2 Position_init, Rectangle? SourceRectangle)
        {
            Position = Position_init;
            this.SourceRectangle = SourceRectangle;
            maXindex = 0;
            maYindex = 0;
        }

        public virtual void LoadContent(ContentManager content, string assetName)
        {
            Texture = content.Load<Texture2D>(assetName);
        }
        public virtual void LoadContent(ContentManager content, string assetName, int maXindex, int maYindex, string readingDimension)
        {
            Texture = content.Load<Texture2D>(assetName);
            this.maXindex = maXindex;
            this.maYindex = maYindex;
            this.readingDimension = readingDimension;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,Position,SourceRectangle, Color.White);
        }
        public virtual void Draw(SpriteBatch spriteBatch, Rectangle _rectangle)
        {
            spriteBatch.Draw(Texture, _rectangle, Color.White);
        }

        public int Height { get { return Texture.Height; }}

        public int Width { get { return Texture.Width; }}

        public virtual void UpdateAnimation(GameTime gameTime)
        {
            if (maXindex != 0)
            {
                Xindex += gameTime.ElapsedGameTime.Milliseconds * 0.004f;

                if (Xindex > maXindex)
                    Xindex = 0;
                if (readingDimension == "h")
                    SourceRectangle = new Rectangle((int)Xindex * SourceRectangle.Value.Width, SourceRectangle.Value.Y, SourceRectangle.Value.Width, SourceRectangle.Value.Height);
                else if (readingDimension == "v")
                    SourceRectangle = new Rectangle(SourceRectangle.Value.X, (int)Yindex * SourceRectangle.Value.Height, SourceRectangle.Value.Width, SourceRectangle.Value.Height);
            }
        }
        public void UpdateSetStateAnimation(int index)
        {
            if (readingDimension == "h")
                SourceRectangle = new Rectangle(index * SourceRectangle.Value.Width, SourceRectangle.Value.Y, SourceRectangle.Value.Width, SourceRectangle.Value.Height);
            else if (readingDimension == "v")
                SourceRectangle = new Rectangle(SourceRectangle.Value.X, index * SourceRectangle.Value.Height, SourceRectangle.Value.Width, SourceRectangle.Value.Height);
        }

        public void UpdateSetStateAnimation(int indexX, int indexY)
        {
            SourceRectangle = new Rectangle(indexX * SourceRectangle.Value.Width, indexY * SourceRectangle.Value.Height, SourceRectangle.Value.Width, SourceRectangle.Value.Height);
        }
    }
}
