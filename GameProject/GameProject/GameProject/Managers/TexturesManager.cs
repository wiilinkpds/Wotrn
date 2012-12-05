using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject.Managers
{
    public class TexturesManager
    {
        // Charge les entites du Menu
        public Texture2D Rack { get; private set; }
        public Texture2D Flammes { get; private set; }
        public SpriteFont Test { get; private set; }
        public SpriteFont Titre { get; private set; }
        public SpriteFont Dialogues { get; private set; }
        public void LoadMenu(ContentManager content)
        {
            Rack = content.Load<Texture2D>("Sprites/Rack");
            Flammes = content.Load<Texture2D>("Sprites/Flammes");
            Test = content.Load<SpriteFont>("Sprites/Test");
            Titre = content.Load<SpriteFont>("Sprites/Titre");
            Dialogues = content.Load<SpriteFont>("Sprites/Dialogues");
        }
    }
}
