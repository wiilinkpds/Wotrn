using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Spells
{
    public class SpeedUp : Spell
    {
        private float value;

        public SpeedUp(Entity owner) : base(owner, TexturesManager.SpeedUp, SpellType.Buff , 1, 200)
        {
            
        }

        public override void Buff()
        {
            // Appelle le Buff() du Spell
            base.Buff();

            new WorldEffect(Owner.Game, TexturesManager.BuffEffect, Owner, new Vector2(0, Owner.TextureSize.Y - 10), 2000, 7 , 2);

            value = Owner.Speed;
            Owner.Speed *= 1.5f;
            value = Owner.Speed - value;
        }

        public override void Unbuff()
        {
            // Appelle le Unbuff() du Spell
            base.Unbuff();
            Owner.Speed -= value;
        }
    }
}
