﻿using System;
using System.Linq;
using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Spells.SpellList
{
    public class UberBlast : Spell
    {
        public UberBlast(Entity owner)
            : base(owner, TexturesManager.UberBlast, SpellType.Cast, 1, 2000)
        {

        }

        public override bool Cast()
        {
            if (!base.Cast())
                return false;

            XactManager.SoundBank.GetCue("Bolt01").Play();

            new WorldEffect(Owner.Game, TexturesManager.WindEffect, Owner, new Vector2(0, Owner.TextureSize.Y), 2000, 2, 2);
            new WorldEffect(Owner.Game, TexturesManager.Lightning02, Owner, new Vector2(0, Owner.TextureSize.Y - TexturesManager.Lightning02.Height), 2000, 1, 1);

            foreach (Monster target in Owner.Game.Entities.OfType<Monster>())
            {
                // distance du joueur a l'ennemi grace a pythagore :)
                double distance = Math.Sqrt(
                                  Math.Pow(Owner.Position.X - target.Position.X, 2) +
                                  Math.Pow(Owner.Position.Y - target.Position.Y, 2));

                if (distance <= 300)
                {
                    // Créer un vecteur directeur
                    Vector2 move = target.Position + new Vector2(target.TextureSize.X, target.TextureSize.Y) / 2;
                    move -= Owner.Position + new Vector2(Owner.TextureSize.X, Owner.TextureSize.Y) / 2;
                    move.Normalize(); // Donne au vecteur la taille d'un pixel
                    target.Position += move * 20;

                    target.Damage(Owner, 20);
                }
            }
            return true;
        }
    }
}