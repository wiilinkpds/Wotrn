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
        public static Texture2D PowerBar { get; private set; }

        public static Texture2D MegaBlast { get; private set; }
        public static Texture2D AstralMove { get; private set; }

        public static Texture2D MapTiles { get; private set; }

        public static void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("Player");
            Ennemy = content.Load<Texture2D>("Ennemy");

            Power = content.Load<Texture2D>("UI/Power");
            Life = content.Load<Texture2D>("UI/Life");
            PowerBar = content.Load<Texture2D>("UI/PowerBar");

            MegaBlast = content.Load<Texture2D>("SpellsIcon/MegaBlast");
            AstralMove = content.Load<Texture2D>("SpellsIcon/AstralMove");

            MapTiles = content.Load<Texture2D>("MapTiles");
        }
    }
}
