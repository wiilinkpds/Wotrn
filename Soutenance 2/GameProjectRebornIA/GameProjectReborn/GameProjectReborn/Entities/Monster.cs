using System;
using System.Collections.Generic;
using GameProjectReborn.Managers;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Entities
{
    public class Monster : Entity
    {
        private const int LifeBarSize = 100; // Taille de la bar de Vie du Monstre
        public Player Targeter { private get; set; }

        protected int xp { private get; set; }

        public Monster(MainGame game, Texture2D texture) : base(game) // Constructeur avec pour paramètres les mêmes que sa classe père
        {
            InitTexture(texture, 1, 4);

            Speed = 1.0f;
            Position = new Vector2(100, 100);

            xp = 100;
            Life = 100;
            LifeMax = 100;
        }

        public void Update(GameTime gameTime, Player player, Maps.MapData map)
        {
            if (Math.Sqrt((Math.Pow(Math.Abs(Position.X - player.Position.X), 2)
                           + Math.Pow(Math.Abs(Position.Y - player.Position.Y), 2))) < 10000)
            {
                new IA(this, player, map,gameTime);
            }
            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            InternalDraw(spriteBatch, Targeter == null ? Color.White : Color.SkyBlue); // Draw le monstre et change la couleur de la cible
        }

        public override void DrawUI(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            if (Targeter == null)
                return;

            // Draw la barre de Vie si Targeter est non null
            int size = Life * LifeBarSize / LifeMax;
            for (int i = 0; i < size; i++)
                spriteBatch.DrawUI(TexturesManager.Life, new Vector2(Position.X + i, Position.Y - TexturesManager.Life.Height), Color.White);
            for (int i = size; i < LifeBarSize; i++)
                spriteBatch.DrawUI(TexturesManager.Life, new Vector2(Position.X + i, Position.Y - TexturesManager.Life.Height), Color.Gray);
        }

        public void Damage(int life) 
        {
            Life -= life;
            if (Life <= 0)
            {
                if (Targeter != null)
                    Targeter.GainXp(xp);

                Delete(); // Appelle la fonction Delete() qui supprime le Monster et envoie ce dernier dans la liste deletedEntities
                if (ReferenceEquals(Game.Player.Target, this)) // Si Game.Player.Target == Ce Monster (celui qui vient d'etre detruit) alors le joueur n'a plus de cible
                    Game.Player.Target = null;
            }
        }
    }
}
