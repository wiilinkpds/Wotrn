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

namespace GameProject.Managers
{
    public class Personnage : Sprite
    {
        public string Name { get; set; }

        public int Life { get; set; }

        public int Mana { get; set; }

        public Texture2D LifeT { get; set; }
        public Texture2D ManaT { get; set; }

        public virtual void Initialize(Vector2 Position_init, Rectangle? SourceRectangle, int Life, int Mana, float Vitesse, string Name)
        {
            this.Position = Position_init;
            this.SourceRectangle = SourceRectangle;
            this.Life = Life;
            this.Mana = Mana;
            this.Vitesse = Vitesse;
            this.maXindex = 0;
            this.maYindex = 0;
            this.Name = Name;
        }

        public virtual void LoadContent(ContentManager content, string assetName,int maXindex, int maYindex, string readingDimension, string LifeName, string ManaName)
        {
            this.Texture = content.Load<Texture2D>(assetName);
            LifeT = content.Load<Texture2D>(LifeName);
            ManaT = content.Load<Texture2D>(ManaName);
            this.maXindex = maXindex;
            this.maYindex = maYindex;
            this.readingDimension = readingDimension;
        }

        public float Vitesse { get; set; }

        public void Move(string direction, GameTime gameTime)
        {
            if (direction == "U")
            {
                this.UpdateSetStateAnimation(0, 3);
                this.UpdateAnimation(gameTime);
                this.Position = new Vector2(this.Position.X, this.Position.Y - 1);
            }
            else if (direction == "D")
            {
                this.UpdateSetStateAnimation(0, 0);
                this.UpdateAnimation(gameTime);
                this.Position = new Vector2(this.Position.X, this.Position.Y + 1);
            }
            else if (direction == "R")
            {
                this.UpdateSetStateAnimation(0, 2);
                this.UpdateAnimation(gameTime);
                this.Position = new Vector2(this.Position.X + 1, this.Position.Y);
            }
            else if (direction == "L")
            {
                this.UpdateSetStateAnimation(0, 1);
                this.UpdateAnimation(gameTime);
                this.Position = new Vector2(this.Position.X - 1, this.Position.Y);
            }
        }

    }
}
