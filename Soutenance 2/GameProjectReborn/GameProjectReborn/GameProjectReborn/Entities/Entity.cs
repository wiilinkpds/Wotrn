using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Entities
{
    // abstract empêche les boulets de faire des trucs inutiles.
    public abstract class Entity
    {
        public const int StepDelay = 150;

        public MainGame Game { get; private set; }

        public int Life { get; set; }
        public int LifeMax { get; set; }

        public int Power { get; set; }
        public int PowerMax { get; set; }

        public Vector2 Position { get; set; }
        public float Speed { get; set; }

        public Texture2D Texture { get; private set; }
        public Vector2 TextureSize { get; private set; }

        protected Direction direction;
        protected int step;
        private int[] frameCount;
        private double stepTime;

        protected Entity(MainGame game)
        {
            Game = game;
        }

        protected void InitTexture(Texture2D texture, int frameX, int frameY)
        {
            Texture = texture;
            TextureSize = new Vector2(texture.Width / (float)frameX, texture.Height / (float)frameY);
            frameCount = new[] { frameX, frameY };
        }

        public virtual void Update(GameTime gameTime)
        {
            stepTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            while (stepTime >= StepDelay)
            {
                stepTime -= StepDelay;
                if (++step >= frameCount[0])
                    step = 0;
            }
        }

        public virtual void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            InternalDraw(spriteBatch, Color.White);
        }

        protected void InternalDraw(UberSpriteBatch spriteBatch, Color color)
        {
            Rectangle source = new Rectangle((int)TextureSize.X * step, (int)TextureSize.Y * (int)direction, (int)TextureSize.X, (int)TextureSize.Y);
            spriteBatch.Draw(Texture, Position, source, color);
        }

        public virtual void DrawUI(GameTime gameTime, UberSpriteBatch spriteBatch)
        {

        }

        protected void Delete()
        {
            Game.DeleteEntity(this);
        }
    }
}
