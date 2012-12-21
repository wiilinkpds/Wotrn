using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject.BackGrounds
{
    public class LoadBack
    {
        // Charge les entites du Menu
        static public Texture2D Fond1 { get; private set; }

        public void LoadBackground(ContentManager content)
        {
            Fond1 = content.Load<Texture2D>("Sprites/BackGrounds/Fond1");
        }
    }
}
