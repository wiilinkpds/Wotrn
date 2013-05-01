using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Windows.SubWindows
{
    public class DialogWindow : Window
    {
        private Vector2 position;
        private Texture2D texture;
        private Button printNext;

        public DialogWindow(Screen parent, Vector2 position, Texture2D texture) : base(parent, position, texture)
        {
            this.position = position;
            this.texture = texture;

            printNext = new Button(position + new Vector2(texture.Width - TexturesManager.Next.Width - 10, texture.Height - TexturesManager.Next.Height - 10), TexturesManager.Next);

            printNext.MouseClick += OnPrintNextGameMouseClick;
        }

        public override void Update(GameTime gameTime)
        {
            printNext.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.DrawUI(texture, position);

            printNext.Draw(gameTime, spriteBatch);
        }

        private void OnPrintNextGameMouseClick(object sender, MouseClickEventArgs e) // object sender renvoie le type du parametre, ici un Button
        {

        }
    }
}
