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
        private const int LifeBarSize = 100; // Taille de la bar de Vie du Monstre

        public Player Targeter { private get; set; }

        protected int xp { private get; set; }

        public Monster(GameScreen game, Texture2D texture) : base(game) // Constructeur avec pour paramètres les mêmes que sa classe père
        {
            InitTexture(texture, 3, 4);
            
            Speed = 1.0f;
            Position = new Vector2(100, 100);
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, (int)TextureSize.X, (int)TextureSize.Y);

            xp = 100;
            Life = 100;
            LifeMax = 100;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 10.0f;
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            InternalDraw(spriteBatch, Targeter == null ? Color.White : Color.SkyBlue); // Draw le monstre et change la couleur de la cible
            
            if (Targeter == null && !KeyboardManager.IsDown(Keys.LeftControl))
                return;

            Vector2 position = Position - new Vector2(0, TexturesManager.Life.Height);

            int size = Life *(int)TextureSize.X / LifeMax;
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
            int size = Life * LifeBarSize / LifeMax;
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
                    ((Player)source).GainXp(xp);

                Delete(); // Appelle la fonction Delete() qui supprime le Monster et envoie ce dernier dans la liste deletedEntities
                if (ReferenceEquals(GameScreen.Player.Target, this)) // Si Game.Player.Target == Ce Monster (celui qui vient d'etre detruit) alors le joueur n'a plus de cible
                    GameScreen.Player.Target = null;
            }
        }
    }
}
