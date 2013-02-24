using GameProjectReborn.Entities;
using GameProjectReborn.Managers;

namespace GameProjectReborn.Spells
{
    public class SpeedUp : Spell
    {
        private float value;

        public SpeedUp(Entity owner) : base(owner, TexturesManager.AstralMove, SpellType.Buff , 1)
        {
        }

        public override void Buff()
        {
            // Appelle le Buff() du Spell
            base.Buff();
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
