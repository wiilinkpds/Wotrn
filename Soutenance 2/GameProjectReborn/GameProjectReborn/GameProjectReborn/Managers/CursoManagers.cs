using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Managers
{
    public class CursoManagers
    {
        private Texture2D texture;
        public Vector2 position { get; set; }

        public CursoManagers(Texture2D texture)
        {
            this.texture = texture;
            position = new Vector2(MainGame.ScreenX/2, MainGame.ScreenY/2);
        }

        public void Draw(UberSpriteBatch sprite_batch)
        {
            sprite_batch.Draw(texture,position);
        }
    }
}
