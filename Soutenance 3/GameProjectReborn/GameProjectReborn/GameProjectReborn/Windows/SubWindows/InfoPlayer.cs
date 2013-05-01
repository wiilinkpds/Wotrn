using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Windows.SubWindows
{
    public class InfoPlayer : Window
    {
        private Player actualPlayer;
        private Texture2D texture;

        private bool isMoving;

        public InfoPlayer(Screen parent, Vector2 position, Texture2D texture, Player player) : base(parent, position, texture)
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
            spriteBatch.DrawUI(TexturesManager.Level, Resources.Res.HeroLevel + " : " + actualPlayer.Level, Position + new Vector2(5, 10), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, Resources.Res.LifeMax + " : " + actualPlayer.Stats.LifeMax, Position + new Vector2(5, 30), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, Resources.Res.PowerMax + " : " + actualPlayer.Stats.PowerMax, Position + new Vector2(5, 50), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, Resources.Res.Strength + " : " + actualPlayer.Stats.Strength, Position + new Vector2(5, 70), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, Resources.Res.Dexterity + " : " + actualPlayer.Stats.Dexterity, Position + new Vector2(5, 90), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, Resources.Res.Intelligence + " : " + actualPlayer.Stats.Intelligence, Position + new Vector2(5, 110), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, Resources.Res.LifePerSeconde + " : " + actualPlayer.Stats.LifeRegeneration, Position + new Vector2(5, 130), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, Resources.Res.PowerPerSeconde + " : " + actualPlayer.Stats.PowerRegeneration, Position + new Vector2(5, 150), Color.White);
        }
    }
}
