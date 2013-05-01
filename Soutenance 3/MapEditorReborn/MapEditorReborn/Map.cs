using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MapEditorReborn
{
    public class Map
    {
        public Dictionary<int, int> MapTilesHigh = new Dictionary<int, int>();
        public Dictionary<int, int> MapTilesMiddle = new Dictionary<int, int>();
        public Dictionary<int, int> MapTilesLow = new Dictionary<int, int>();
        public Dictionary<int, int> Accessibility = new Dictionary<int, int>();
        public Dictionary<int, int> SideAccess = new Dictionary<int, int>();

        public Pen RedPen = new Pen(Color.Red, 2);
        public SolidBrush BlueBrush = new SolidBrush(Color.FromArgb(60, Color.Blue));
        public SolidBrush RedBrush = new SolidBrush(Color.FromArgb(60, Color.Red));
        public SolidBrush YellowBrush = new SolidBrush(Color.FromArgb(60, Color.Yellow));

        private Mainfrm window;

        public Map(Mainfrm window)
        {
            this.window = window;
        }

        public void Init()
        {
            MapTilesHigh.Clear();
            MapTilesMiddle.Clear();
            MapTilesLow.Clear();
            Accessibility.Clear();
            SideAccess.Clear();

            for (int i = 0; i < Constants.CellCount; i++)
            {
                MapTilesHigh.Add(i, -1);
                MapTilesMiddle.Add(i, -1);
                MapTilesLow.Add(i, 0);
                Accessibility.Add(i, 0);
                SideAccess.Add(i, 0);
            }
        }

        private void FromData(Dictionary<int,int>  dic, BinaryReader reader)
        {
            dic.Clear();
            for (int i = 0; i < Constants.CellCount; i++)
                dic.Add(i, reader.ReadInt16());
        }

        public bool FromFile(string file)
        {
            BinaryReader reader = new BinaryReader(new FileStream(file, FileMode.Open));
            int header = reader.ReadInt32();
            int version = reader.ReadInt16();

            if (header != 1196446285)
                return false;

            if (version >= 2)
            {
                reader.ReadInt16();
                reader.ReadInt16();
            }

            FromData(MapTilesHigh, reader);
            FromData(MapTilesMiddle, reader);
            FromData(MapTilesLow, reader);
            FromData(Accessibility, reader);
            FromData(SideAccess, reader);

            reader.Close();

            return true;
        }

        private void ToData(Dictionary<int, int> dic, BinaryWriter writer)
        {
            for (int i = 0; i < Constants.CellCount; i++)
                writer.Write((short)(dic[i]));
        }

        public bool ToFile(string file)
        {
            BinaryWriter writer = new BinaryWriter(new FileStream(file, FileMode.Create));

            writer.Write(1196446285);
            writer.Write((short)2);
            writer.Write((short)Constants.MapWidth);
            writer.Write((short)Constants.MapHeight);

            ToData(MapTilesHigh, writer);
            ToData(MapTilesMiddle, writer);
            ToData(MapTilesLow, writer);
            ToData(Accessibility, writer);
            ToData(SideAccess, writer);

            writer.Close();

            return true;
        }

        public void DrawGrid(Graphics g)
        {
            for (int i = 0; i <= Constants.MapHeight; i++)
                g.DrawLine(Pens.Blue, 0, i * Constants.TileWidth, Constants.TotalWidth, i * Constants.TileWidth);

            for (int i = 0; i <= Constants.MapWidth; i++)
                g.DrawLine(Pens.Blue, i * Constants.TileWidth, 0, i * Constants.TileWidth, Constants.TotalHeight);
        }

        public void DrawHigh(Graphics g)
        {
            for (int i =  0; i < Constants.CellCount; i++)
                if (MapTilesHigh[i] != -1)
                    if (IsInBound(i))
                        g.DrawImage(Tiles.Get(MapTilesHigh[i]), Cells.GetScreenPos(i));
        }

        public void DrawMiddle(Graphics g)
        {
            for (int i = 0; i < Constants.CellCount; i++)
                if (MapTilesMiddle[i] != -1)
                    if (IsInBound(i))
                        g.DrawImage(Tiles.Get(MapTilesMiddle[i]), Cells.GetScreenPos(i));
        }

        public void DrawLow(Graphics g)
        {
            for (int i = 0; i < Constants.CellCount; i++)
                if (MapTilesLow[i] != -1)
                    if (IsInBound(i))
                        g.DrawImage(Tiles.Get(MapTilesLow[i]), Cells.GetScreenPos(i));
        }

        public bool IsInBound(int cellId)
        {
            Point p = Cells.GetPos(cellId);

            if (p.X < -Cells.DeltaScrolling.X || p.Y < -Cells.DeltaScrolling.Y)
                return false;
            if (p.X > -Cells.DeltaScrolling.X + window.MainPicture.Size.Width / Constants.TileWidth || p.Y > -Cells.DeltaScrolling.Y + window.MainPicture.Size.Height / Constants.TileWidth)
                return false;

            return true;
        }

        public void DrawAccess(Graphics g)
        {
            for (int i = 0; i < Constants.CellCount; i++)
            {
                PointF pos = Cells.GetScreenPos(i);
                SolidBrush brush = BlueBrush;

                switch (Accessibility[i])
                {
                    case 1:
                        brush = RedBrush;
                        break;
                    case 2:
                        brush = YellowBrush;
                        break;
                }

                g.FillRectangle(brush, pos.X, pos.Y, Constants.TileWidth, Constants.TileWidth);

                if (SideAccess[i] != 0)
                {
                    if ((SideAccess[i] & 1) == 1)
                            g.DrawLine(RedPen, pos.X, pos.Y, pos.X + Constants.TileWidth, pos.Y);
                    if ((SideAccess[i] & 2) == 2)
                            g.DrawLine(RedPen, pos.X, pos.Y + Constants.TileWidth, pos.X + Constants.TileWidth, pos.Y + Constants.TileWidth);
                    if ((SideAccess[i] & 4) == 4)
                            g.DrawLine(RedPen, pos.X, pos.Y, pos.X, pos.Y + Constants.TileWidth);
                    if ((SideAccess[i] & 8) == 8)
                            g.DrawLine(RedPen, pos.X + Constants.TileWidth, pos.Y, pos.X + Constants.TileWidth, pos.Y + Constants.TileWidth);
                }
            }
        }

        public bool IsOnMap(int x, int y)
        {
            return !(x < 0 || y < 0 || x >= Constants.MapWidth|| y >= Constants.MapHeight);
        }
    }
}
