using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Spells
{
    class AstralMove : Spell
    {
        private Vector2 position
        {
            get { return Caster.AstralPosition; }
            set { Caster.AstralPosition = value; }
        }

        public AstralMove(Entity owner) : base(owner, TexturesManager.AstralMove,SpellType.Buff, 20)
        {
            position = owner.Position;
        }

        public override void Buff()
        {
            base.Buff();
            Caster.CanMove = false;
            position = Owner.Position;
        }

        public override void Unbuff()
        {
            base.Unbuff();
            Caster.CanMove = true;
            Owner.Position = position;
        }
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 10.0f;
            Vector2 move = Vector2.Zero;

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && position.X < MainGame.ScreenX - Owner.Texture.Width)
                move.X += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && position.X > 0)
                move.X -= 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && position.Y < MainGame.ScreenY - Owner.Texture.Height)
                move.Y += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && position.Y > 0)
                move.Y -= 1;

            if (move == Vector2.Zero)
                return;

            move.Normalize();

            position = Owner.Game.Map.Move(Owner, position, move * Owner.Speed * time * 1.5f);
        }
        public override void Draw(UberSpriteBatch spriteBatch)
        {
            if (IsActivated)
                spriteBatch.Draw(Owner.Texture, position, Color.FromNonPremultiplied(255, 255, 255, 128));
        }
    }
}
