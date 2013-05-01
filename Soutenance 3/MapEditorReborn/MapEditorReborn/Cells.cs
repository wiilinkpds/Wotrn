using System;
using System.Drawing;

namespace MapEditorReborn
{
    public class Cells
    {
        public static Point DeltaScrolling { get; set; }

        public static int GetId(int x, int y)
        {
            return y * Constants.MapWidth + x;
        }

        public static Point GetPos(int cellId)
        {
            return new Point(cellId - (int)(Math.Floor((double)cellId / Constants.MapWidth)) * Constants.MapWidth, (int)(Math.Floor((double)cellId / Constants.MapWidth)));
        }

        public static PointF GetScreenPos(int cellId)
        {
            Point p = GetPos(cellId);
            p = new Point(p.X + DeltaScrolling.X, p.Y + DeltaScrolling.Y);
            return new PointF(p.X * Constants.TileWidth, p.Y * Constants.TileWidth);
        }
    }
}
