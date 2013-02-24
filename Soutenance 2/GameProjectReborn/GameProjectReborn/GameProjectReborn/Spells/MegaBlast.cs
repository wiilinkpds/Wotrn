using System;
using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Spells
{
    public class MegaBlast : Spell
    {
        private Monster target;

        public MegaBlast(Entity owner) : base(owner, TexturesManager.MegaBlast, SpellType.Cast, 20)
        {

        }

        public override bool Cast()
        {
            target = ((Player)Owner).Target;

            if (target == null || !base.Cast())
                return false;

            // Créer un vecteur directeur
            Vector2 move = target.Position + new Vector2(target.Texture.Width, target.Texture.Height) / 2;

            move -= Owner.Position + new Vector2(Owner.Texture.Width, Owner.Texture.Height) / 2;
            move.Normalize(); // Donne au vecteur la taille d'un pixel

            target.Position += move * 20; // Donne au vecteur la taille de 20 pixels
            target.Damage(20);

            return true;
        }
    }
}
