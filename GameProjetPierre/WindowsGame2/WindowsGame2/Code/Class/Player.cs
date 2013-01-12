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
    class Player: Sprite
    {
        float speed;
        int life;
        string name;

        public Player(Vector2 position) : base(position)
        {
            LayerDepth = 0;
            Colision = true;
            SourceRectangle = new Rectangle(0, 0,50,69);
            if (Colision)
            {
                ColisionRectangle = new Rectangle((int)Position.X, (int)Position.Y +(int)(SourceRectangle.Value.Height / 2.5), SourceRectangle.Value.Width, (int)(SourceRectangle.Value.Height / 2.5));
            }
            this.name = "Wiilink";
            this.life = 100;
            this.speed = 0.2f;
        }

        public Player(Vector2 position, Rectangle? sourceRectangle, string name, int life, float speed)
            : base(position, sourceRectangle)
        {
            Colision = true;
            LayerDepth = 0;
            if (Colision)
            {
                ColisionRectangle = new Rectangle((int)Position.X, (int)Position.Y + (SourceRectangle.Value.Height / 2), SourceRectangle.Value.Width, SourceRectangle.Value.Height / 2);
            }
            this.name = name;
            this.life = life;
            this.speed = speed;
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Life
        {
            get { return life; }
            set { life = value; }
        }
        public void PlayerUpdate(Vector2 translation)
        {
            Position += translation;
            if (Colision)
            {
                ColisionRectangle = new Rectangle((int)Position.X + SourceRectangle.Value.Width / 4, (int)Position.Y + (int)(SourceRectangle.Value.Height / 2), SourceRectangle.Value.Width / 2, (int)(SourceRectangle.Value.Height / 2.5));
            }
        }
    }
}
