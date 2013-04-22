using GameProjectReborn.Entities.IA;
using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Entities
{
    public class Monster : Entity
    {
        public Player Targeter { private get; set; }
        public Vector2 InitialPos { get; set; } 

        public int MovingScope { get; set; }
        public int LifeMax { get; set; }
        public int PowerMax { get; set; }

        private const int LifeBarSize = 100;
        private Ia ia;

        protected int xp { private get; set; }

        public Monster(GameScreen game, Texture2D texture, int horizontal, int vertical) : base(game)
        {
            InitTexture(texture, horizontal, vertical);

            Speed = 1.0f;
            MovingScope = 500;
            VisionSight = 200;

            xp = 100;
            Life = 100;
            LifeMax = 100;
            VisionSight = 200;

            ia = new Ia(game.MapFirst.Data, this);
        }

        public override void Update(GameTime gameTime, Player player)
        {
            ia.Moving(gameTime, player);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            InternalDraw(spriteBatch, Targeter == null ? Color.White : Color.SkyBlue); // Draw le monstre et change la couleur de la cible
            
            if (Targeter == null && !KeyboardManager.IsDown(Keys.LeftControl))
                return;

            Vector2 position = Position - new Vector2(0, TexturesManager.Life.Height);

            int size = (int)Life *(int)TextureSize.X / LifeMax;
            for (int i = 0; i < size; i++)
                spriteBatch.Draw(TexturesManager.Life, position + new Vector2(i, 0), Color.White);
            for (int i = size; i < (int)TextureSize.X; i++)
                spriteBatch.Draw(TexturesManager.Life, position + new Vector2(i, 0), Color.Gray);
        }

        public override void DrawUI(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            if (Targeter == null)
                return;

            // Draw la barre de Vie si Targeter est non null
            int size = (int)Life * LifeBarSize / LifeMax;
            for (int i = 0; i < size; i++)
                spriteBatch.DrawUI(TexturesManager.Life, new Vector2(MainGame.ScreenX - LifeBarSize + i, 0), Color.White);
            for (int i = size; i < LifeBarSize; i++)
                spriteBatch.DrawUI(TexturesManager.Life, new Vector2(MainGame.ScreenX - LifeBarSize + i, 0), Color.Gray);
        }

        public void Damage(Entity source, int life) 
        {
            Life -= life;
            if (Life <= 0)
            {
                if (source is Player)
                {
                    ((Player) source).GainXp(xp);
                    ((Player) source).Stats.AmountKilled++;
                }

                Delete(); // Appelle la fonction Delete() qui supprime le Monster et envoie ce dernier dans la liste deletedEntities
                if (Targeter != null && ReferenceEquals(Targeter.Target, this)) // Si Game.Player.Target == Ce Monster (celui qui vient d'etre detruit) alors le joueur n'a plus de cible
                    Targeter.Target = null;
            }
        }
    }
}
