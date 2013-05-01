using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Windows.SubWindows
{
    public class SoundProperties : Window
    {
        private Texture2D texture;
        private Button soundCursor;

        public SoundProperties(Screen parent, Vector2 position, Texture2D texture) : base(parent, position, texture)
        {
            this.texture = texture;
            soundCursor = new Button(position + new Vector2(TexturesManager.Window.Width / 2, TexturesManager.MovingCursor.Height + 5) - new Vector2(TexturesManager.MovingCursor.Width / 2, 0), TexturesManager.MovingCursor, Bounds.X, Bounds.X + TexturesManager.Window.Width, 90f);

            soundCursor.MouseClicking += OnSoundCursorClicking;
        }

        public override void Update(GameTime gameTime)
        {
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);

            soundCursor.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.DrawUI(TexturesManager.Window, Position);
            spriteBatch.DrawUI(TexturesManager.Level, "Musique : " + MainGame.SongVolume * 100 + " %", Position + new Vector2(TexturesManager.Window.Width / 2, 0) - new Vector2(TexturesManager.Level.MeasureString("Musique : 100 %").X / 2, -5), Color.White);

            soundCursor.Draw(gameTime, spriteBatch);
        }

        private void OnSoundCursorClicking(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {
            if (soundCursor.Position.X < Bounds.Left)
                soundCursor.Position = new Vector2(Bounds.Left + 1, soundCursor.Position.Y);
            else
                soundCursor.Position = new Vector2(MouseManager.Position.X, soundCursor.Position.Y);
        }
    }
}
