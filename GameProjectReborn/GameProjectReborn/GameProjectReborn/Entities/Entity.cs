using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Entities
{
    // abstract empêche les boulets de faire des trucs inutiles.
    public abstract class Entity
    {
        public MainGame Game { get; private set; }

        public int Life { get; set; }
        public int LifeMax { get; set; }

        public int Power { get; set; }
        public int PowerMax { get; set; }

        public Vector2 Position { get; set; }
        public float Speed { get; set; }

        public Texture2D Texture { get; private set; }

        protected Entity(MainGame game, Texture2D texture)
        {
            Texture = texture;
            Game = game;
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position);
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
