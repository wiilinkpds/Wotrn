using System.Collections.Generic;
using System.Linq;
using GameProjectReborn.Managers;
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

        public Vector2 AstralPosition { get; set; }
        public Monster Target { get; set; } // Cible du Player

        public bool CanMove { get; set; } // Booleen indiquant si le Player peut se deplacer
        public int ExperienceNeeded { get; set; }
        public int Level { get; set; }

        private int experience;
        private int targetIndex;
        private readonly IList<Spell> spells;
        
        public Player(MainGame game, Texture2D texture) : base(game, texture)
        {
            Speed = 3.0f;
            Power = 600; // Mana
            PowerMax = 600; // Change uniquement en lvlUp

            Life = 600; // Vie
            LifeMax = 600; // Change uniquement en lvlUp

            experience = 0;
            ExperienceNeeded = 100;
            Level = 1;

            CanMove = true;

            spells = new List<Spell> // Liste des sorts
                {
                    new SpeedUp(this),
                    new AstralMove(this),
                    new MegaBlast(this)
                };
        }

        public void GainXp(int gain)
        {
            experience += gain;
            if (experience >= ExperienceNeeded)
            {
                Level++;
                experience -= ExperienceNeeded;
                ExperienceNeeded += ExperienceNeeded / 2;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (CanMove)
                InternalMove(gameTime);

            Keys[] keys = new[] { Keys.A, Keys.E, Keys.R };

            for (int i = 0; i < spells.Count; i++)
            {
                if (keys.Length < i) break;
                if (!KeyboardManager.IsPressed(keys[i])) continue;

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

            if (KeyboardManager.IsPressed(Keys.Tab)) // Change de cible
            {
                if (Target != null)
                    Target.Targeter = null;

                IList<Monster> monsters = Game.Entities.OfType<Monster>().ToList();
                ++targetIndex;
                if (targetIndex >= monsters.Count)
                    targetIndex = (monsters.Count > 0 ? 0 : -1);
                Target = targetIndex >= 0 ? monsters[targetIndex] : null;

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
                Power = PowerMax;
            // Insérer tout le cheat

            foreach (Spell spell in spells) // Update tout les spells
            {
                spell.Update(gameTime);
            }
        }

        private void InternalMove(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 10.0f;
            Vector2 move = Vector2.Zero;

            if (KeyboardManager.IsDown(Keys.Right))
                move.X += 1;
            if (KeyboardManager.IsDown(Keys.Left))
                move.X -= 1;
            if (KeyboardManager.IsDown(Keys.Down))
                move.Y += 1;
            if (KeyboardManager.IsDown(Keys.Up))
                move.Y -= 1;

            if (move == Vector2.Zero)
                return;

            move.Normalize(); // Donne au vecteur la taille d'un pixel

            Position = Game.Map.Move(this, Position, move * Speed * time);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            foreach (Spell spell in spells)
                spell.Draw(spriteBatch);
        }

        public override void DrawUI(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.DrawUI(TexturesManager.Level,"Heros " + Level, new Vector2(0, 0));

            // Draw la barre de Vie
            int size = Life * LifeBarSize / LifeMax;
            for (int i = 0; i < size; i++)
                spriteBatch.DrawUI(TexturesManager.Life, new Vector2(i, 25), Color.White);
            for (int i = size; i < LifeBarSize; i++)
                spriteBatch.DrawUI(TexturesManager.Life, new Vector2(i, 25), Color.Gray);

            // Draw la barre de Mana
            size = Power * PowerBarSize / PowerMax;
            for (int i = 0; i < size; i++)
                spriteBatch.DrawUI(TexturesManager.Power, new Vector2(i, 42), Color.White);
            for (int i = size; i < PowerBarSize; i++)
                spriteBatch.DrawUI(TexturesManager.Power, new Vector2(i, 42), Color.Gray);


            Vector2 position = new Vector2(MainGame.ScreenX / 2 - TexturesManager.PowerBar.Width / 2,
                                           MainGame.ScreenY - TexturesManager.PowerBar.Height);

            // Test
            // Draw la barre d'Xp
            size = experience * XpBarSize / ExperienceNeeded;
            for (int i = 0; i < size; i++)
                spriteBatch.DrawUI(TexturesManager.Xp, new Vector2(position.X + i, position.Y - TexturesManager.Xp.Height), Color.White);
            for (int i = size; i < XpBarSize; i++)
                spriteBatch.DrawUI(TexturesManager.Xp, new Vector2(position.X + i, position.Y - TexturesManager.Xp.Height), (i % 60 == 0 && i != 0) ? Color.Black : Color.Gray);
            // Test

            // Draw la barre de Sort
            spriteBatch.DrawUI(TexturesManager.PowerBar, position, Color.White);
            position += new Vector2(5, 5);
            Vector2 delta = new Vector2(TexturesManager.PowerBar.Width / 10.0f, 0);

            foreach (Spell spell in spells) // Fais clignoter les sorts actifs
            {
                if (!spell.IsActivated || gameTime.TotalGameTime.TotalMilliseconds % 1000 < 500) // Draw si non actif || Draw pendant 500 ms si actif sur 1000 ms
                    spriteBatch.DrawUI(spell.Icon, position);
                position += delta;
            }
        }


        //// Get et Set sont deux fonctions diff, get est appelé lorsque l'on fait truc = MaVariable, set est appelé lorsque l'on définit la variable
        //public double MaVariable
        //{
        //    get
        //    {
        //        return 0.0;
        //    }
        //    set
        //    {

        //    }
        //}

        //public double TestVar = 1.5;

        //public void Test()
        //{
        //    MaVariable = ;
        //    TestVar += MaVariable;

        //    MaVariable_set(13);
        //    TestVar = TestVar + MaVariable_get();
        //    TestVar = 1.5; Quand meme.
        //}

    }
}
