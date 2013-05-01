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

        public const int StepDelay = 200;

        public Texture2D Icon { get; private set; }
        public SpellType Type { get; private set; }
        public bool IsActivated { get; private set; }
        public int CoolDown { get; private set; } // En millisecondes
        
        private DateTime last;
        private readonly int powerCost;
        private double coolDown;

        protected Spell(Entity owner, Texture2D icon, SpellType type, int cost) : this(owner, icon, type, cost, 0) {}

        protected Spell(Entity owner, Texture2D icon, SpellType type, int cost, int coolDown)
        {
            CoolDown = coolDown;
            Owner = owner;
            powerCost = cost;
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
            if (Owner.Power < powerCost)
                return false;
            if (coolDown > 0)
                return false;

            coolDown = CoolDown;

            Owner.Power -= powerCost;
            return true;
        }

        public bool IsReady()
        {
            return coolDown <= 0;
        }

        public virtual void Draw(UberSpriteBatch spriteBatch,GameTime gameTime)
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            if (Type == SpellType.Cast && coolDown > 0)
            {
                coolDown -= gameTime.ElapsedGameTime.TotalMilliseconds;
                if (coolDown < 0)
                    coolDown = 0;
            }
            if (IsActivated && Owner.Power < powerCost)
                Unbuff();
            if (!IsActivated)
                return;

            TimeSpan elapsed = DateTime.Now - last;

            if (elapsed.TotalMilliseconds < 100) 
                return;

            Owner.Power -= powerCost;

            if (Owner.Power < 0)
                Owner.Power = 0;

            last = DateTime.Now;
        }
    }
}
