using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Jeux
{
    class TextureManager
    {
        Dictionary<string, Texture2D> textureBank = new Dictionary<string, Texture2D>();

        ContentManager content;

        public TextureManager(ContentManager content)
        {
            this.content = content;
        }

        public Texture2D GetTexture(string assetName)
        {
            if (textureBank.ContainsKey(assetName))
            {
                return textureBank[assetName];
            }
            else
            {
                textureBank.Add(assetName, content.Load<Texture2D>(assetName));
                return textureBank[assetName];
            }
        }
    }
}
