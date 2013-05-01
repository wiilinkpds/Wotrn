using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.Spells;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Windows.SubWindows
{
    public class SpellList : Window
    {
        private Player actualPlayer;
        private Texture2D texture;

        private bool isMoving;

        public SpellList(Screen parent, Vector2 position, Texture2D texture, Player player) : base(parent, position, texture)
        {
            actualPlayer = player;
            this.texture = texture;

            isMoving = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (MouseManager.IsInRectangle(Bounds) && MouseManager.IsClicking())
                isMoving = true;
            if (!MouseManager.IsClicking())
                isMoving = false;

            if (isMoving)
                Position = MoveWindow(Position);

            Bounds = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);

        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.DrawUI(TexturesManager.Window, Position);
            for (int i = 0; i < actualPlayer.spells.Count; i++)
            {
                spriteBatch.DrawUI(actualPlayer.spells[i].Icon, new Rectangle(5 + Bounds.X,5 + Bounds.Y + 50 * i,50,50));
            }
        }
    }
}
