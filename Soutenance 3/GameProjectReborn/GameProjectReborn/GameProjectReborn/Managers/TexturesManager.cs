using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Managers
{
    public static class TexturesManager
    {
        // Player, Ennemi, Pnj
        public static Texture2D Player { get; private set; }
        public static Texture2D Rack { get; private set; }
        public static Texture2D RackNinja { get; private set; }

        // UI
        public static Texture2D Power { get; private set; }
        public static Texture2D Life { get; private set; }
        public static Texture2D Xp { get; private set; }
        public static Texture2D PowerBar { get; private set; }
        public static Texture2D Window { get; private set; }


        public static Texture2D MovingCursor { get; private set; }
        public static Texture2D AddButton { get; private set; }
        public static Texture2D InfoButton { get; private set; }

        // Souris
        public static Texture2D Cursor { get; private set; }

        // Effets de sorts

        public static Texture2D Lightning02 { get; private set; }
        public static Texture2D BuffEffect { get; private set; }
        public static Texture2D WindEffect { get; private set; }

        // Icones de sorts
        public static Texture2D Basic { get; private set; }
        public static Texture2D SpeedUp { get; private set; }
        public static Texture2D MegaBlast { get; private set; }
        public static Texture2D UberBlast { get; private set; }
        public static Texture2D AstralMove { get; private set; }

        // Dialogue
        public static Texture2D WinDial { get; private set; }
        public static Texture2D Next { get; private set; }

        // Map
        public static Texture2D Tile { get; private set; }
        public static Texture2D MapTiles { get; private set; }

        // Menu
        public static Texture2D BackgroundMenu { get; private set; }
        public static Texture2D OptionMenu { get; private set; }

        // Spritefonts
        public static SpriteFont Level { get; private set; }
        public static SpriteFont Menu { get; private set; }
        public static SpriteFont Title { get; private set; }
        public static SpriteFont Zoom { get; private set; }

        public static void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("Player");
            Rack = content.Load<Texture2D>("Rack");
            RackNinja = content.Load<Texture2D>("RackNinja");

            Power = content.Load<Texture2D>("UI/Power");
            Life = content.Load<Texture2D>("UI/Life");
            Xp = content.Load<Texture2D>("UI/Xp");
            PowerBar = content.Load<Texture2D>("UI/PowerBar");
            Window = content.Load<Texture2D>("UI/Window");

            MovingCursor = content.Load<Texture2D>("UI/MovingCursor");
            AddButton = content.Load<Texture2D>("UI/AddButton");
            InfoButton = content.Load<Texture2D>("UI/InfoButton");

            Cursor = content.Load<Texture2D>("UI/Cursor");

            Lightning02 = content.Load<Texture2D>("SpellsIcon/Effect/Lightning02");
            BuffEffect = content.Load<Texture2D>("SpellsIcon/Effect/Buff");
            WindEffect = content.Load<Texture2D>("SpellsIcon/Effect/Wind");

            Basic = content.Load<Texture2D>("SpellsIcon/Basic");
            SpeedUp = content.Load<Texture2D>("SpellsIcon/SpeedUp");
            MegaBlast = content.Load<Texture2D>("SpellsIcon/MegaBlast");
            UberBlast = content.Load<Texture2D>("SpellsIcon/UberBlast");
            AstralMove = content.Load<Texture2D>("SpellsIcon/AstralMove");

            WinDial = content.Load<Texture2D>("UI/Dialog/WinDial");
            Next = content.Load<Texture2D>("UI/Dialog/Next");

            Tile = content.Load<Texture2D>("Maps/Tile");
            MapTiles = content.Load<Texture2D>("MapTiles");

            BackgroundMenu = content.Load<Texture2D>("Menu/BackgroundMenu");
            OptionMenu = content.Load<Texture2D>("Menu/OptionMenu");

            Level = content.Load<SpriteFont>("Ui/Level");
            Menu = content.Load<SpriteFont>("Menu/Menu");
            Title = content.Load<SpriteFont>("Menu/Title");
            Zoom = content.Load<SpriteFont>("Menu/Zoom");
        }
    }
}
