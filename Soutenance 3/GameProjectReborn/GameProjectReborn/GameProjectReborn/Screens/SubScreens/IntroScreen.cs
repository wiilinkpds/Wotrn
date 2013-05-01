using GameProjectReborn.Managers;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameProjectReborn.Screens.SubScreens
{
    public class IntroScreen : Screen
    {
        private Video intro;
        private VideoPlayer videoPlayer;

        public IntroScreen()
        {
            XactManager.CurrentSong.Stop(AudioStopOptions.Immediate);
            intro = MainGame.GetInstance().Content.Load<Video>("Video\\Introduction");
            videoPlayer = new VideoPlayer();
            videoPlayer.Play(intro);
        }

        public override void Update(GameTime gameTime)
        {
            if (KeyboardManager.IsDown(Keys.Enter) || KeyboardManager.IsDown(Keys.Escape))
                videoPlayer.Stop();
            if (videoPlayer.State == MediaState.Stopped)
                MainGame.GetInstance().SetScreen(new PlayerEditor());
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(videoPlayer.GetTexture(), new Rectangle(0, 0, MainGame.ScreenX, MainGame.ScreenY));
            spriteBatch.End();
        }
    }
}
