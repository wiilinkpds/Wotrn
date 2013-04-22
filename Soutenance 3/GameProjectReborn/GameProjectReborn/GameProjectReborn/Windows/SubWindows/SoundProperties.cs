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
            soundCursor = new Button(position + new Vector2(TexturesManager.Window.Width / 2, TexturesManager.MovingCursor.Height + 5) - new Vector2(TexturesManager.MovingCursor.Width / 2, 0), TexturesManager.MovingCursor, Bounds.X, Bounds.X + TexturesManager.Window.Width);

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
            spriteBatch.DrawUI(TexturesManager.Level, "Volume de la musique : ", Position + new Vector2(TexturesManager.Window.Width / 2, 0) - new Vector2(TexturesManager.Level.MeasureString("Volume de la musique : ").X / 2, -5), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, MainGame.SongVolume * 100 + " %", new Vector2(Position.X + 15, Position.Y + 25), Color.White);

            soundCursor.Draw(gameTime, spriteBatch);
        }

        private void OnSoundCursorClicking(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {
            if (soundCursor.Position.X >= soundCursor.BoundLeft && soundCursor.Position.X <= soundCursor.BoundRight)
                soundCursor.Position = new Vector2(MouseManager.Position.X, soundCursor.Position.Y);
            else
            {
                soundCursor.Position = new Vector2(MouseManager.Position.X - 1, soundCursor.Position.Y - 1);
            }
            XactManager.Engine.GetCategory("Music").SetVolume(MainGame.SongVolume);
        }
    }
}
