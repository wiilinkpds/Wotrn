using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditorReborn
{
    public partial class Modfrm : Form
    {
        public List<Point> SelectedPoints;
        public List<int> SelectedCells;

        private Bitmap Base;
        private Bitmap basePlusGrid;

        private Point start;
        private Point end;
        private bool selecting;

        private int tilesHeight
        {
            get { return (int)Math.Floor((double)Base.Height / Constants.TileWidth); }
        }

        private int tilesWidth
        {
            get { return (int)Math.Floor((double)Base.Width / Constants.TileWidth); }
        }

        public Modfrm()
        {
            InitializeComponent();
            start = new Point(0, 0);
            end = new Point(0, 0);
            selecting = false;

            SelectedPoints = new List<Point>();
            SelectedCells = new List<int>();
        }

        public void DrawGrid(Graphics g)
        {
            for (int i = 0; i < Base.Height; i++)
                g.DrawLine(Pens.Blue, 0, i * Constants.TileWidth, Base.Width, i * Constants.TileWidth);

            for (int i = 0; i < Base.Width; i++)
                g.DrawLine(Pens.Blue, i * Constants.TileWidth, 0, i * Constants.TileWidth, Base.Height);
            foreach (Point p in SelectedPoints)
            {
                g.DrawRectangle(Pens.Red, p.X * Constants.TileWidth, p.Y * Constants.TileWidth, Constants.TileWidth, Constants.TileWidth);
            }
        }

        private void modfrm_Load(object sender, EventArgs e)
        {
            SelectedPoints.Add(new Point(0, 0));
            SelectedCells.Add(0);
            Base = new Bitmap("tiles.png");
            RepaintBox();
            Location = new Point(100, 100);
        }

        private void PaintSelection()
        {
            SelectedPoints.Clear();
            SelectedCells.Clear();

            for (int i = start.X; i <= end.X; i += (start.X > end.X ? -1 : 1))
            {
                for (int j = start.Y; j <= end.Y; j += (start.Y > end.Y ? -1 : 1))
                {
                    if (i < Constants.TileWidth && j < Constants.TileHeight)
                    {
                        SelectedPoints.Add(new Point(i, j));
                        SelectedCells.Add(j * (int)Math.Floor((double)Base.Width / Constants.TileWidth) + i);
                    }
                }
            }
            RepaintBox();
            ArrangePoints();
        }

        private void RepaintBox()
        {
            basePlusGrid = new Bitmap(Base.Width + 1, Base.Height + 1);
            Graphics g = Graphics.FromImage(basePlusGrid);
            g.DrawImage(Base, 0, 0);
            DrawGrid(g);
            PaintBox.Image = basePlusGrid;
        }

        private void ArrangePoints()
        {
            Point firstPoint = new Point(500, 500);
            Point lastPoint = new Point(-1, -1);

            foreach (Point p in SelectedPoints)
            {
                if (p.X < firstPoint.X || p.Y < firstPoint.Y)
                    firstPoint = p;
                if (p.X > lastPoint.X || p.Y > lastPoint.Y)
                    lastPoint = p;
            }

            SelectedPoints.Clear();
            SelectedCells.Clear();

            Point decalage = firstPoint;
            lastPoint.X -= firstPoint.X;
            lastPoint.Y -= firstPoint.Y;
            firstPoint = new Point(0,0);

            for (int i = firstPoint.X; i <= lastPoint.X; i++)
                for (int j = firstPoint.Y; j <= lastPoint.Y; j++)
                {
                    SelectedPoints.Add(new Point(i, j));
                    SelectedCells.Add((j + decalage.Y) * (int)Math.Floor(Base.Width / (double)Constants.TileWidth) +
                                      (i + decalage.X));
                }
        }

        private void PaintBox_Click(object sender, EventArgs e)
        {

        }

        private void PaintBox_MouseDown(object sender, MouseEventArgs e)
        {
            start = new Point((int)Math.Floor((double)e.X / Constants.TileWidth), (int)Math.Floor((double)e.Y / Constants.TileWidth));
            selecting = true;
        }

        private void PaintBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (selecting)
            {
                end = new Point((int)Math.Floor((double)e.X / Constants.TileWidth),
                            (int)Math.Floor((double)e.Y / Constants.TileWidth));
                PaintSelection();
            }
        }

        private void PaintBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (selecting)
            {
                end = new Point((int)Math.Floor((double)e.X / Constants.TileWidth),
                            (int)Math.Floor((double)e.Y / Constants.TileWidth));
                PaintSelection();
            }
            selecting = false;
        }
    }
}
