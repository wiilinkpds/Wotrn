using GameProjectReborn.Screens;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Entities
{
    public class WorldEffect
    {
        private const int StepDelay = 150;

        public GameScreen Game { get; private set; }
        public double LifeSpan;

        private Vector2 textureSize;
        private Texture2D effect;

        private Entity entityBind;
        private Vector2 entityDelta;
        private Vector2 position;

        private int[] frameCount;
        private int step;
        private double stepTime;

        public WorldEffect(GameScreen game, Texture2D effect, Entity entity, Vector2 delta, int lifeSpan, int frameX, int frameY)
        {
            this.effect = effect;
            LifeSpan = lifeSpan;

            InitEffect(effect, frameX, frameY);

            BindTo(entity, delta);

            Game = game;
            Game.WorldEffects.Add(this);
        }

        public void BindTo(Entity entity, Vector2 delta)
        {
            entityBind = entity;
            entityDelta = delta;
        }

        public void Update(GameTime gameTime)
        {
            position = entityBind.Position + entityDelta;

            stepTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            LifeSpan -= stepTime;
            while (stepTime >= StepDelay)
            {
                stepTime -= StepDelay;
                if (++step >= frameCount[0])
                    step = 0;
            }

        }

        public void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            InternalDraw(spriteBatch, Color.White);
        }

        public void InitEffect(Texture2D texture, int frameX, int frameY)
        {
            effect = texture;
            textureSize = new Vector2(texture.Width / (float)frameX, texture.Height / (float)frameY);
            frameCount = new[] { frameX, frameY };
        }

        public void InternalDraw(UberSpriteBatch spriteBatch, Color color)
        {
            Rectangle source = new Rectangle((int)textureSize.X * step, (int)textureSize.Y, (int)textureSize.X, (int)textureSize.Y);
            spriteBatch.Draw(effect, GameScreen.camera.MapLocation(position), source, color);
        }
    }
}
