using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Windows.SubWindows
{
    public class ShowInfo : Window
    {
        private Player actualPlayer;
        private Texture2D texture;

        private bool isMoving;

        public ShowInfo(Screen parent, Vector2 position, Texture2D texture, Player player) : base(parent, position, texture)
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
            spriteBatch.DrawUI(TexturesManager.Level, "Niveau du Heros : " + actualPlayer.Level, Position + new Vector2(5, 10), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, "Vie Maximum : " + actualPlayer.Stats.LifeMax, Position + new Vector2(5,30), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, "Power Maximum : " + actualPlayer.Stats.PowerMax, Position + new Vector2(5, 50), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, "Force : " + actualPlayer.Stats.Strength, Position + new Vector2(5, 70), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, "Dexterite : " + actualPlayer.Stats.Dexterity, Position + new Vector2(5, 90), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, "Intelligence : " + actualPlayer.Stats.Intelligence, Position + new Vector2(5, 110), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, "Vie / Seconde : " + actualPlayer.Stats.LifeRegeneration, Position + new Vector2(5, 130), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, "Power / Seconde: " + actualPlayer.Stats.PowerRegenaration, Position + new Vector2(5, 150), Color.White);
        }
    }
}
