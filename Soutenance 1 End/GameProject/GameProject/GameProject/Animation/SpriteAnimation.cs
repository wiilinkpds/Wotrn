using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameProject
{
    class SpriteAnimation : SpriteManager
    {
        public bool IsLooping = true;

        private float timeElapsed;

        // Initialise à 20 images par seconde
        private float timeToUpdate = 1/20f;

        public int FramesPerSecond
        {
            set { timeToUpdate = (1f / value); }
        }

        public SpriteAnimation(Texture2D Texture, int frames)
            : base(Texture, frames)
        {

        }

        public void Update(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                if (FrameIndex < Rectangles.Length - 1)
                    FrameIndex++;
                else if (IsLooping)
                    FrameIndex = 0;
            }
        }
    }
}
