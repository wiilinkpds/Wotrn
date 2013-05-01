using System;
using System.Collections.Generic;
using System.Linq;
using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.Spells;
using GameProjectReborn.Spells.SpellList;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Entities
{
    public class Player : Entity
    {
        private const int LifeBarSize = 300; // Taille de la bar de Vie
        private const int PowerBarSize = 300; // Taille de la bar de Mana
        private const int XpBarSize = 600; // Taille de la bar d'Xp

        public PlayerStats Stats { get; private set; }

        public Monster Target { get; set; } // Cible du Player
        public Vector2 AstralPosition { get; set; }
        public Vector2 coord { get; set; }

        public bool CanMove { get; set; } // Booleen indiquant si le Player peut se deplacer

        public int ExperienceNeeded { get; set; }
        public int Level { get; set; }

        private int experience;

        private Rectangle[] spellsRect;
        public IList<Spell> spells { get; set; }
        private int targetIndex;

        public EntityMulti PlayerToMulti()
        {
            EntityMulti player = new EntityMulti();
            player.Life = Life;
            player.Power = Power;
            player.Position = Position;
            player.Direction = Direction;
            return player;
        }

        public Player(GameScreen game, Texture2D texture)
            : base(game)
        {
            Stats = new PlayerStats();
            Position = new Vector2(19*32, 18*32);
            InitTexture(texture, 3, 4);

            Speed = 3.0f;
            Power = 100.0; // Mana
            Life = 100.0; // Vie

            Stats.LifeMax = 100;
            Stats.PowerMax = 100;
            Stats.Strength = 10;
            Stats.Dexterity = 10;
            Stats.Intelligence = 10;
            Stats.LifeRegeneration = 1.0;
            Stats.PowerRegeneration = 1.0;
            Stats.AmountKilled = 0;

            ExperienceNeeded = 100;
            Level = 1;

            experience = 0;

            CanMove = true;

            spells = new List<Spell> // Liste des sorts
                {
                    new Basic(this),
                    new SpeedUp(this),
                    new AstralMove(this),
                    new MegaBlast(this),
                    new UberBlast(this)
                };

            Vector2 delta = new Vector2(TexturesManager.PowerBar.Width / 10.0f, 0);
            spellsRect = new Rectangle[spells.Count];
            for (int i = 0; i < spells.Count; i++)
            {
                spellsRect[i] = new Rectangle((int)(MainGame.ScreenX / 2 - TexturesManager.PowerBar.Width / 2 + 5 + delta.X * i),
                                              (int)(MainGame.ScreenY - TexturesManager.PowerBar.Height + 5 + delta.Y * i - TexturesManager.Xp.Height),
                                                spells[i].Icon.Width, spells[i].Icon.Height);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (CanMove)
            {
                base.Update(gameTime);
                InternalMove(gameTime);
            }

            coord = new Vector2((int)Math.Ceiling(Position.X * 32 / 1000) - 1, (int)Math.Ceiling(Position.Y * 32 / 1000) - 1);

            // Pour le lancement de spells
            for (int i = 0; i < spells.Count; i++)
            {
                if (!KeyboardManager.IsPressed(KeyboardManager.BindedKeys[(int) KeyboardManager.KeysEnum.Spell1 + i]) && !(MouseManager.IsInRectangle(spellsRect[i]) && MouseManager.IsLeftClicked())) continue;

                if (spells[i].Type == SpellType.Buff)
                {
                    if (spells[i].IsActivated)
                        spells[i].Unbuff();
                    else
                        spells[i].Buff();
                }
                else
                    spells[i].Cast();
            }

            // Change de cible
            if (KeyboardManager.IsPressed(KeyboardManager.BindedKeys[(int)KeyboardManager.KeysEnum.Target]) || MouseManager.IsLeftClicked())
            {
                if (Target != null)
                    Target.Targeter = null;

                if (KeyboardManager.IsPressed(KeyboardManager.BindedKeys[(int)KeyboardManager.KeysEnum.Target]))
                {
                    IList<Monster> monsters = Game.Entities.OfType<Monster>().ToList();
                    ++targetIndex;
                    if (targetIndex >= monsters.Count)
                        targetIndex = (monsters.Count > 0 ? 0 : -1);
                    Target = targetIndex >= 0 ? monsters[targetIndex] : null;
                }
                else
                {
                    foreach (Monster monster in Game.Entities.OfType<Monster>())
                    {
                        if (MouseManager.IsInRectangle(GameScreen.Camera.ScreenLocation(MouseManager.Position), monster.Bounds))
                            Target = monster;
                    }
                }

                if (Target != null)
                    Target.Targeter = this;
            }

            // Deselectionne une cible
            if (KeyboardManager.IsPressed(KeyboardManager.BindedKeys[(int)KeyboardManager.KeysEnum.Escape]))
            {
                if (Target != null)
                    Target.Targeter = null;
                Target = null;
            }

            // Insérer tout le cheat
            if (Keyboard.GetState().IsKeyDown(Keys.D0))
                Power = Stats.PowerMax;

            // Update tout les spells
            foreach (Spell spell in spells)
                spell.Update(gameTime);

            Regeneration(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            foreach (Spell spell in spells)
                spell.Draw(spriteBatch, gameTime);
        }

        public override void DrawUI(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            Vector2 position = new Vector2(MainGame.ScreenX / 2 - TexturesManager.PowerBar.Width / 2,
                                           MainGame.ScreenY - TexturesManager.PowerBar.Height) - new Vector2(0, TexturesManager.Xp.Height);

            // Draw la barre de Vie
            int size = (int)Life * LifeBarSize / Stats.LifeMax;
            Vector2 pos = new Vector2(position.X, position.Y - TexturesManager.Life.Height);
            for (int i = 0; i < size; i++)
                spriteBatch.DrawUI(TexturesManager.Life, pos + new Vector2(i, 0), Color.White);
            for (int i = size; i < LifeBarSize; i++)
                spriteBatch.DrawUI(TexturesManager.Life, pos + new Vector2(i, 0), Color.Gray);
            Rectangle bounds = new Rectangle((int)pos.X, (int)pos.Y, LifeBarSize, TexturesManager.Life.Height);
            if (MouseManager.IsInRectangle(bounds))
                spriteBatch.DrawUI(TexturesManager.Level, Resources.Res.Life + " : " + (int)Life, pos - new Vector2(0, TexturesManager.Level.MeasureString(Resources.Res.Life + " : " + Life).Y), Color.Red);

            // Draw la barre de Power
            size = (int)Power * PowerBarSize / Stats.PowerMax;
            pos = new Vector2(position.X + PowerBarSize, position.Y - TexturesManager.Power.Height);
            for (int i = 0; i < size; i++)
                spriteBatch.DrawUI(TexturesManager.Power, pos + new Vector2(i ,0) , Color.White);
            for (int i = size; i < PowerBarSize; i++)
                spriteBatch.DrawUI(TexturesManager.Power, pos + new Vector2(i, 0), Color.Gray);
            bounds = new Rectangle((int)pos.X, (int)pos.Y, PowerBarSize, TexturesManager.Power.Height);
            if (MouseManager.IsInRectangle(bounds))
                spriteBatch.DrawUI(TexturesManager.Level, Resources.Res.Power + " : " + (int)Power, pos - new Vector2(0, TexturesManager.Level.MeasureString(Resources.Res.Power + " : " + Power).Y), Color.MediumPurple);


            // Draw la barre d'Xp
            size = experience * XpBarSize / ExperienceNeeded;
            for (int i = 0; i < size; i++)
                spriteBatch.DrawUI(TexturesManager.Xp, new Vector2(position.X + i, position.Y + TexturesManager.PowerBar.Height), Color.White);
            for (int i = size; i < XpBarSize; i++)
                spriteBatch.DrawUI(TexturesManager.Xp, new Vector2(position.X + i, position.Y + TexturesManager.PowerBar.Height), (i % 60 == 0 && i != 0) ? Color.Black : Color.Gray);

            // Draw la barre de Sort
            spriteBatch.DrawUI(TexturesManager.PowerBar, position, Color.White);
            position += new Vector2(5, 5);
            Vector2 delta = new Vector2(TexturesManager.PowerBar.Width / 10.0f, 0);

            foreach (Spell spell in spells)
            {
                if (!spell.IsActivated || gameTime.TotalGameTime.TotalMilliseconds % 1000 < 500) // Draw si non actif || Draw pendant 500 ms si actif sur 1000 ms
                    spriteBatch.DrawUI(spell.Icon, position, spell.IsReady() ? Color.White : Color.Gray);

                position += delta;
            }
        }

        private void InternalMove(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 10.0f;
            Vector2 move = Vector2.Zero;

            if (KeyboardManager.IsDown(KeyboardManager.BindedKeys[(int)KeyboardManager.KeysEnum.Up]))
                move.Y -= 1;
            else if (KeyboardManager.IsDown(KeyboardManager.BindedKeys[(int)KeyboardManager.KeysEnum.Down]))
                move.Y += 1;
            else if (KeyboardManager.IsDown(KeyboardManager.BindedKeys[(int)KeyboardManager.KeysEnum.Left]))
                move.X -= 1;
            else if (KeyboardManager.IsDown(KeyboardManager.BindedKeys[(int)KeyboardManager.KeysEnum.Right]))
                move.X += 1;

            if (move == Vector2.Zero)
            {
                Step = 1;
                return;
            }

            // Defini la Direction du Player
            if ((int)move.Y == -1)
                Direction = Direction.Up;
            if ((int)move.Y == 1)
                Direction = Direction.Down;
            if ((int)move.X == -1)
                Direction = Direction.Left;
            if ((int)move.X == 1)
                Direction = Direction.Right;

            move.Normalize(); // Donne au vecteur la taille d'un pixel

            Position = Game.MapFirst.Move(this, Position, move * Speed * time);
        }

        public void GainXp(int gain)
        {
            experience += gain;
            if (experience >= ExperienceNeeded)
            {
                Level++;
                experience -= ExperienceNeeded;
                ExperienceNeeded += (int)(100 * Math.Log10(Level * 2 + 10));
            }
        }

        private double powerDelta;
        private double lifeDelta;

        public void Regeneration(GameTime gameTime)
        {
            if (Math.Floor(Power + Stats.PowerRegeneration) <= Stats.PowerMax)
                powerDelta += Stats.PowerRegeneration * gameTime.ElapsedGameTime.TotalMilliseconds;
            if (Math.Floor(Life + Stats.LifeRegeneration) <= Stats.LifeMax)
                lifeDelta += Stats.LifeRegeneration * gameTime.ElapsedGameTime.TotalMilliseconds;

            while (powerDelta > 1000.0)
            {
                Power++;
                powerDelta -= 1000.0;
            }
            while (lifeDelta > 1000.0)
            {
                Life++;
                lifeDelta -= 1000.0;
            }
        }
    }
}
