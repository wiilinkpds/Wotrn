using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Spells.SpellList
{
    class AstralMove : Spell
    {
        private Vector2 position
        {
            get { return Caster.AstralPosition; }
            set { Caster.AstralPosition = value; }
        }

        public AstralMove(Entity owner) : base(owner, TexturesManager.AstralMove,SpellType.Buff, 1)
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

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                move.X += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                move.X -= 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                move.Y += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                move.Y -= 1;

            if (move == Vector2.Zero)
                return;

            move.Normalize();

            position = Owner.Game.MapFirst.Move(Owner, position, move * Owner.Speed * time * 1.5f);
        }

        public override void Draw(UberSpriteBatch spriteBatch, GameTime gameTime)
        {
            Rectangle source = new Rectangle((int) Owner.TextureSize.X * Owner.Step,
                                             (int) Owner.TextureSize.Y*(int) Owner.Direction, (int) Owner.TextureSize.X,
                                             (int) Owner.TextureSize.Y);
            if (IsActivated)
                spriteBatch.Draw(Owner.Texture, position, source, Color.FromNonPremultiplied(255, 255, 255, 128));
        }
    }
}
