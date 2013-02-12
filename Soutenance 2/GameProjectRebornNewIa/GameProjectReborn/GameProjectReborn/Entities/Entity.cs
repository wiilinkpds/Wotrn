using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Entities
{
    // abstract empêche les boulets de faire des trucs inutiles.
    public abstract class Entity
    {
        public const int StepDelay = 150;

        public GameScreen Game { get; private set; }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, (int)TextureSize.X, (int)TextureSize.Y);
            }
        }
        public Vector2 Position { get; set; }

        public Vector2 TextureSize { get; private set; }
        public Texture2D Texture { get; private set; }

        public int Life { get; set; }
        public int LifeMax { get; set; }
        public int Power { get; set; }
        public int PowerMax { get; set; }
        public float Speed { get; set; }

        public Direction Direction;
        public int Step;

        private int[] frameCount;
        private double stepTime;

        protected Entity(GameScreen game)
        {
            Game = game;
            // Juste pour les tests
            Position = new Vector2(RandomManager.Next(100, 200), RandomManager.Next(100, 200));
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
                if (++Step >= frameCount[0])
                    Step = 0;
            }
        }

        public virtual void Update(GameTime gameTime, Maps.MapData map, Player player) // Pour le pathfinding
        {
            stepTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            while (stepTime >= StepDelay)
            {
                stepTime -= StepDelay;
                if (++Step >= frameCount[0])
                    Step = 0;
            }
        }

        public virtual void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            InternalDraw(spriteBatch, Color.White);
        }

        protected void InternalDraw(UberSpriteBatch spriteBatch, Color color)
        {
            Rectangle source = new Rectangle((int)TextureSize.X * Step, (int)TextureSize.Y * (int)Direction, (int)TextureSize.X, (int)TextureSize.Y);
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
