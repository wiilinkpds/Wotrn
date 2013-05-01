using System;
using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Spells.SpellList
{
    public class Basic : Spell
    {
        private Monster target;
        private int range;

        public Basic(Entity owner) : base(owner, TexturesManager.Basic, SpellType.Cast, 0, 1)
        {
            range = 40;
        }

        public override bool Cast()
        {
            target = ((Player)Owner).Target;

            if (target == null || !base.Cast())
                return false;

            double distance = Math.Sqrt(
                              Math.Pow(Owner.Position.X - target.Position.X, 2) +
                              Math.Pow(Owner.Position.Y - target.Position.Y, 2));

            if (distance > range) // Portee de l'attaque
                return false;
            if (Owner.Direction == target.Direction) // Cast uniquement si le joueur est tourne vers l'entite
                return false;

            // Créer un vecteur directeur
            Vector2 move = target.Position + new Vector2(target.TextureSize.X, target.TextureSize.Y) / 2;

            move -= Owner.Position + new Vector2(Owner.TextureSize.X, Owner.TextureSize.Y) / 2;
            move.Normalize(); // Donne au vecteur la taille d'un pixel

            target.Position += move * 5;
            target.Damage(Owner, 10);

            return true;
        }
    }
}
