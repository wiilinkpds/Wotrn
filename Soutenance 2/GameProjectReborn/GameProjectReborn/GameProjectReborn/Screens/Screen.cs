using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens
{
    public abstract class Screen
    {
        public abstract void Update(GameTime gameTime); // Abstract est obligatoirement override sinon elle n'existe pas... Tandis que virtual peut quand meme fonctionner :D
        public abstract void Draw(GameTime gameTime, UberSpriteBatch spriteBatch);
    }
}
