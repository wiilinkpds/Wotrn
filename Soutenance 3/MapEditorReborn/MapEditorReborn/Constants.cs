namespace MapEditorReborn
{
    public class Constants
    {
        public const int MapHeight = 100;
        public const int MapWidth = 100;
        public const int TileWidth = 32;
        public const int TileHeight = 32;

        public static int TotalHeight
        {
            get
            {
                return MapHeight * TileWidth;
            }
        }

        public static int TotalWidth
        {
            get
            {
                return MapWidth * TileWidth;
            }
        }

        public static int CellCount
        {
            get
            {
                return MapHeight*MapWidth;
            }
        }
    }
}