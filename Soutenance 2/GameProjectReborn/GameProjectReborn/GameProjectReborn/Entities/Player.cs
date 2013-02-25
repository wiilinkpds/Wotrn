using System;
using System.Collections.Generic;
using System.Linq;
using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.Spells;
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

        public Vector2 AstralPosition { get; set; }
        public Monster Target { get; set; } // Cible du Player
        public Vector2 coord { get; set; }

        public bool CanMove { get; set; } // Booleen indiquant si le Player peut se deplacer

        public int ExperienceNeeded { get; set; }
        public int Level { get; set; }

        private int experience;
        // private int caracPoint;

        private int targetIndex;
        private readonly IList<Spell> spells;
        private Rectangle[] spellsRect;

        public Player(GameScreen game, Texture2D texture)
            : base(game)
        {
            Stats = new PlayerStats();
            Position = new Vector2(480, 332);
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
            Stats.PowerRegenaration = 1.0;

            ExperienceNeeded = 100;
            Level = 1;

            experience = 0;
            // caracPoint = 0;

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
                                              (int)(MainGame.ScreenY - TexturesManager.PowerBar.Height + 5 + delta.Y * i),
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

            Keys[] keys = new[] {Keys.Q, Keys.A, Keys.E, Keys.R, Keys.D2 };

            for (int i = 0; i < spells.Count; i++)
            {
                if (keys.Length < i) break;
                if (!KeyboardManager.IsPressed(keys[i]) && !(MouseManager.IsInRectangle(spellsRect[i]) && MouseManager.IsLeftClicked())) continue;

                if (spells[i].Type == SpellType.Buff) // Si le sort est un Buff...
                {
                    if (spells[i].IsActivated)
                        spells[i].Unbuff();
                    else
                        spells[i].Buff();
                }
                else
                    spells[i].Cast();
            }

            if (KeyboardManager.IsPressed(Keys.Tab) || MouseManager.IsLeftClicked()) // Change de cible
            {
                if (Target != null)
                    Target.Targeter = null;

                if (KeyboardManager.IsPressed(Keys.Tab))
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
                        Vector2 mouseRealPosition = Game.ScreenToGameCoords(MouseManager.Position);
                        if (MouseManager.IsInRectangle(mouseRealPosition, monster.Bounds))
                            Target = monster;
                    }
                }

                if (Target != null)
                    Target.Targeter = this;
            }

            if (KeyboardManager.IsPressed(Keys.Escape)) // Deselectionne une cible
            {
                if (Target != null)
                    Target.Targeter = null;
                Target = null;
            }

            // Insérer tout le cheat
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
                Power = Stats.PowerMax;
            // Insérer tout le cheat

            foreach (Spell spell in spells) // Update tout les spells
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
                spriteBatch.DrawUI(TexturesManager.Level, "Vie : " + (int)Life, pos - new Vector2(0, TexturesManager.Level.MeasureString("Vie : " + Life).Y), Color.Red);

            // Draw la barre de Power
            size = (int)Power * PowerBarSize / Stats.PowerMax;
            pos = new Vector2(position.X + PowerBarSize, position.Y - TexturesManager.Power.Height);
            for (int i = 0; i < size; i++)
                spriteBatch.DrawUI(TexturesManager.Power, pos + new Vector2(i ,0) , Color.White);
            for (int i = size; i < PowerBarSize; i++)
                spriteBatch.DrawUI(TexturesManager.Power, pos + new Vector2(i, 0), Color.Gray);
            bounds = new Rectangle((int)pos.X, (int)pos.Y, PowerBarSize, TexturesManager.Power.Height);
            if (MouseManager.IsInRectangle(bounds))
                spriteBatch.DrawUI(TexturesManager.Level, "Power : " + (int)Power, pos - new Vector2(0, TexturesManager.Level.MeasureString("Power : " + Power).Y), Color.MediumPurple);


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

            // Fais clignoter les sorts actifs
            foreach (Spell spell in spells)
            {
                if (!spell.IsActivated || gameTime.TotalGameTime.TotalMilliseconds % 1000 < 500) // Draw si non actif || Draw pendant 500 ms si actif sur 1000 ms
                    spriteBatch.DrawUI(spell.Icon, position);
                position += delta;
            }
        }

        private void InternalMove(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 10.0f;
            Vector2 move = Vector2.Zero;

            if (KeyboardManager.IsDown(Keys.Right))
                move.X += 1;
            else if (KeyboardManager.IsDown(Keys.Left))
                move.X -= 1;
            else if (KeyboardManager.IsDown(Keys.Down))
                move.Y += 1;
            else if (KeyboardManager.IsDown(Keys.Up))
                move.Y -= 1;

            if (move == Vector2.Zero)
            {
                Step = 1;
                return;
            }

            // Defini la Direction du Player
            if ((int)move.Y == 1)
                Direction = Direction.Down;
            if ((int)move.Y == -1)
                Direction = Direction.Up;
            if ((int)move.X == 1)
                Direction = Direction.Right;
            if ((int)move.X == -1)
                Direction = Direction.Left;

            move.Normalize(); // Donne au vecteur la taille d'un pixel

            Position = Game.MapFirst.Move(this, Position, move * Speed * time);
        }

        public void GainXp(int gain)
        {
            experience += gain;
            if (experience >= ExperienceNeeded)
            {
                Level++;
                // caracPoint++;
                experience -= ExperienceNeeded;
                ExperienceNeeded += (int)(100 * Math.Log10(Level * 2 + 10));
            }
        }

        public void Regeneration(GameTime gameTime)
        {
            if (Math.Floor(Power + Stats.PowerRegenaration) <= Stats.PowerMax)
                    Power += Stats.PowerRegenaration / 60;
        }
    }
}
