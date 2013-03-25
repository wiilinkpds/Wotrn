using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens.Option
{
    public class Resolution : Screen
    {
        private Button fullScreen;
        private Button windowed;

        public Resolution()
        {
            fullScreen = new Button(new Vector2(100, MainGame.ScreenY / 4 + 50), "Passer en mode Plein Ecran");
            windowed = new Button(new Vector2(100, MainGame.ScreenY / 4 + 100), "Passer en mode Fenetre");
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {

        }
    }
}
