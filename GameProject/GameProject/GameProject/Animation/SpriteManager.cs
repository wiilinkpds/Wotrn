﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameProject
{
    public class SpriteManager
    {
        protected Texture2D Texture;
        protected Rectangle[] Rectangles;
        protected int FrameIndex = 0;

        public Vector2 Position = Vector2.Zero;
        public Color Color = Color.White;
        public Vector2 Origin;

        public float Rotation = 0f;
        public float Scale = 1f;

        public SpriteEffects SpriteEffect;

        public SpriteManager(Texture2D Texture, int frames)
        {
            this.Texture = Texture;
            int width = Texture.Width / frames;
            Rectangles = new Rectangle[frames];

            for (int i = 0; i < frames; i++)
                Rectangles[i] = new Rectangle(i * width, 0, width, Texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Rectangles[FrameIndex], Color, Rotation, Origin, Scale, SpriteEffect, 0f);
        }
    }
}
