using System;
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

        private Button songSlide;
        private Button soundEffectSlide;

        public SoundProperties(Screen parent, Vector2 position, Texture2D texture) : base(parent, position, texture)
        {
            this.texture = texture;

            songSlide = new Button(position + new Vector2(TexturesManager.Window.Width / 2, TexturesManager.MovingCursor.Height + 5) - new Vector2(TexturesManager.MovingCursor.Width / 2, 0), TexturesManager.MovingCursor, TexturesManager.Window.Width);
            soundEffectSlide = new Button(position + new Vector2(TexturesManager.Window.Width / 2, TexturesManager.MovingCursor.Height + 5) - new Vector2(TexturesManager.MovingCursor.Width / 2, 0) + new Vector2(0,50), TexturesManager.MovingCursor, TexturesManager.Window.Width);

            songSlide.MouseClicking += onSongSlideClicking;
            soundEffectSlide.MouseClicking += onSoundEffectSlideClicking;
        }

        public override void Update(GameTime gameTime)
        {
            XactManager.SongVolume = ((songSlide.Position.X - songSlide.BoundLeft) / songSlide.SlideSize);

            if (XactManager.SongVolume <= 0)
                XactManager.SongVolume = 0.0f;

            XactManager.Engine.GetCategory("Music").SetVolume(XactManager.SongVolume);

            XactManager.SoundEffectVolume = ((soundEffectSlide.Position.X - soundEffectSlide.BoundLeft) / soundEffectSlide.SlideSize);

            if (XactManager.SoundEffectVolume <= 0)
                XactManager.SoundEffectVolume = 0.0f;

            XactManager.Engine.GetCategory("SoundEffect").SetVolume(XactManager.SoundEffectVolume);

            songSlide.Update(gameTime);
            soundEffectSlide.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.DrawUI(TexturesManager.Window, new Rectangle((int)Position.X, (int)Position.Y, TexturesManager.Window.Width, TexturesManager.Window.Height));
            spriteBatch.DrawUI(TexturesManager.Level, Resources.Res.Music + " : " + Math.Floor(XactManager.SongVolume * 100) + " %", Position + new Vector2(TexturesManager.Window.Width / 2, 0) - new Vector2(TexturesManager.Level.MeasureString("Musique : 100 %").X / 2, -5), Color.White);
            spriteBatch.DrawUI(TexturesManager.Level, Resources.Res.SoundEffect + " : " + Math.Floor(XactManager.SoundEffectVolume * 100) + " %", Position + new Vector2(TexturesManager.Window.Width / 2, 50) - new Vector2(TexturesManager.Level.MeasureString("Effets Sonores : 100 %").X / 2, -5), Color.White);

            songSlide.Draw(gameTime, spriteBatch);
            soundEffectSlide.Draw(gameTime, spriteBatch);
        }

        private void onSongSlideClicking(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {
            if (MouseManager.Position.X < songSlide.BoundLeft)
                songSlide.Position = new Vector2(songSlide.BoundLeft, songSlide.Position.Y);
            else if (MouseManager.Position.X > songSlide.BoundLeft + songSlide.SlideSize)
                songSlide.Position = new Vector2(songSlide.BoundLeft + songSlide.SlideSize, songSlide.Position.Y);
            else
                songSlide.Position = new Vector2(MouseManager.Position.X, songSlide.Position.Y);
        }

        private void onSoundEffectSlideClicking(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {
            if (MouseManager.Position.X < soundEffectSlide.BoundLeft)
                soundEffectSlide.Position = new Vector2(soundEffectSlide.BoundLeft, soundEffectSlide.Position.Y);
            else if (MouseManager.Position.X > soundEffectSlide.BoundLeft + soundEffectSlide.SlideSize)
                soundEffectSlide.Position = new Vector2(soundEffectSlide.BoundLeft + soundEffectSlide.SlideSize, soundEffectSlide.Position.Y);
            else
                soundEffectSlide.Position = new Vector2(MouseManager.Position.X, soundEffectSlide.Position.Y);
        }
    }
}
