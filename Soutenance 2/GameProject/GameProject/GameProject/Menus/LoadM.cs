using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameProject.UtilsFun;

namespace GameProject.Menus
{
    public class LoadM
    {
        // Charge les entites du Menu
        static public Texture2D Rack { get; private set; }
        static public Texture2D Flamme { get; private set; }
        static public Texture2D Goutte { get; private set; }
        static public Texture2D Ville { get; private set; }

        static public SpriteFont Menu { get; private set; }
        static public SpriteFont Titre { get; private set; }

        public void LoadMenu(ContentManager content)
        {
            Rack = content.Load<Texture2D>("Sprites/Menu/Rack");
            Ville = content.Load<Texture2D>("Sprites/Menu/Ville");
            Flamme = content.Load<Texture2D>("Sprites/Menu/Flamme");
            Goutte = content.Load<Texture2D>("Sprites/Menu/Goutte");

            Menu = content.Load<SpriteFont>("Sprites/Menu/SpriteFonts/Menu");
            Titre = content.Load<SpriteFont>("Sprites/Menu/SpriteFonts/Titre");
        }
    }
}
