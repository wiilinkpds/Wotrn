using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Managers
{
    public static class TexturesManager
    {
        public static Texture2D Player { get; private set; }
        public static Texture2D Ennemy { get; private set; }

        public static Texture2D Power { get; private set; }
        public static Texture2D Life { get; private set; }
        public static Texture2D Xp { get; private set; }
        public static Texture2D PowerBar { get; private set; }

        public static Texture2D SpeedUp { get; private set; }
        public static Texture2D MegaBlast { get; private set; }
        public static Texture2D UberBlast { get; private set; }
        public static Texture2D AstralMove { get; private set; }

        public static Texture2D MapTiles { get; private set; }

        public static Texture2D BackgroundMenu { get; private set; }

        public static SpriteFont Level { get; private set; }
        public static SpriteFont Menu { get; private set; }
        public static SpriteFont Title { get; private set; }

        public static void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("Player");
            Ennemy = content.Load<Texture2D>("Ennemy");

            Power = content.Load<Texture2D>("UI/Power");
            Life = content.Load<Texture2D>("UI/Life");
            Xp = content.Load<Texture2D>("UI/Xp");
            PowerBar = content.Load<Texture2D>("UI/PowerBar");

            SpeedUp = content.Load<Texture2D>("SpellsIcon/SpeedUp");
            MegaBlast = content.Load<Texture2D>("SpellsIcon/MegaBlast");
            UberBlast = content.Load<Texture2D>("SpellsIcon/UberBlast");
            AstralMove = content.Load<Texture2D>("SpellsIcon/AstralMove");

            MapTiles = content.Load<Texture2D>("MapTiles");

            BackgroundMenu = content.Load<Texture2D>("Menu/BackgroundMenu");

            Level = content.Load<SpriteFont>("Ui/Level");
            Menu = content.Load<SpriteFont>("Menu/MainFont");
            Title = content.Load<SpriteFont>("Menu/Title");
        }
    }
}
