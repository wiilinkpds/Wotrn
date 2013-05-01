using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Spells.SpellList
{
    public class MegaBlast : Spell
    {
        private Monster target;

        public MegaBlast(Entity owner) : base(owner, TexturesManager.MegaBlast, SpellType.Cast, 1, 500)
        {

        }

        public override bool Cast()
        {
            target = ((Player)Owner).Target;

            if (target == null || !base.Cast())
                return false;

            // Créer un vecteur directeur
            Vector2 move = target.Position + new Vector2(target.TextureSize.X, target.TextureSize.Y) / 2;

            move -= Owner.Position + new Vector2(Owner.TextureSize.X, Owner.TextureSize.Y) / 2;
            move.Normalize(); // Donne au vecteur la taille d'un pixel
            target.Position += move * 10;

            target.Damage(Owner, 20);


            return true;
        }
    }
}
