using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.BackGrounds
{
    class Background
    {
        static public void Back(SpriteBatch sprite_batch, Vector2 position)
        {
            sprite_batch.Draw(LoadBack.Fond1, position, Color.White);
        }
    }
}
