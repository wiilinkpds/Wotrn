using System.Collections.Generic;
using GameProjectReborn.Utils;
using GameProjectReborn.Windows;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens
{
    public abstract class Screen
    {
        public IList<Window> Windows { get; private set; }

        protected Screen()
        {
            Windows = new List<Window>();
        }

        public void ToggleWindow(Window window)
        {
            if (!window.IsOpened)
                Windows.Add(window);
            else
                Windows.Remove(window);
            window.IsOpened = !window.IsOpened;
        }

        public abstract void Update(GameTime gameTime); // Abstract est obligatoirement override sinon elle n'existe pas... Tandis que virtual peut quand meme fonctionner :D
        public abstract void Draw(GameTime gameTime, UberSpriteBatch spriteBatch);
    }
}
