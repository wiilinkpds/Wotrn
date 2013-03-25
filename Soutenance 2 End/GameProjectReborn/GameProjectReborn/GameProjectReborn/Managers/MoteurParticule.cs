using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameProjectReborn.Entities;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Managers
{
    public class MoteurParticule
    {
        private Texture2D texture;
        public Vector2 position { get; set; }
        private Direction direction;
        public float lifetime { get; set; }
        private float speed;
        public bool IsDead { get; private set; }
        Random rand = new Random();

        public MoteurParticule(Texture2D Texture, Vector2 PosInitial, Direction Direction, float LifeTime, float Speed)
        {
            texture = Texture;
            position = PosInitial;
            direction = Direction;
            lifetime = LifeTime;
            IsDead = false;
            speed = Speed;
        }
        public void update()
        {
            if (direction == Direction.Down)
                position = new Vector2(position.X + rand.Next(2), position.Y + speed);
            else if (direction == Direction.Up)
                position = new Vector2(position.X, position.Y - 1);
            else if (direction == Direction.Left)
                position = new Vector2(position.X - 1, position.Y);
            else if (direction == Direction.Right)
                position = new Vector2(position.X + 1, position.Y);
            lifetime -= 0.1F;
            if (lifetime <= 0)
                IsDead = true;
        }
        public void Draw(UberSpriteBatch sprite_batch)
        {
            sprite_batch.Draw(texture, position);
        }

        ~MoteurParticule()
        {
        }
    }
}
