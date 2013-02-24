using System;
using GameProjectReborn.Entities;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Spells
{
    public abstract class Spell
    {
        protected Entity Owner { get; private set; }

        protected Player Caster
        {
            get { return Owner as Player; }
        }

        public Texture2D Icon { get; private set; }
        public SpellType Type { get; private set; }
        public bool IsActivated { get; private set; }

        private readonly int manaCost;
        private DateTime last;

        
        protected Spell(Entity owner, Texture2D icon , SpellType type, int cost)
        {
            Owner = owner;
            manaCost = cost;
            Icon = icon;
            Type = type;
        }

        public virtual void Buff()
        {
            IsActivated = true;
            last = DateTime.Now;
        }

        public virtual void Unbuff()
        {
            IsActivated = false;
        }

        public virtual bool Cast()
        {
            if (Owner.Power < manaCost)
                return false;
            Owner.Power -= manaCost;
            return true;
        }

        public virtual void Draw(UberSpriteBatch spriteBatch)
        {
        }

        public virtual void Update(GameTime gameTime)
        {
            if (IsActivated && Owner.Power == 0)
                Unbuff();
            if (!IsActivated)
                return;

            TimeSpan elapsed = DateTime.Now - last;

            if (elapsed.TotalMilliseconds < 100) 
                return;

            Owner.Power -= manaCost;

            if (Owner.Power < 0)
                Owner.Power = 0;

            last = DateTime.Now;
        }
    }
}
