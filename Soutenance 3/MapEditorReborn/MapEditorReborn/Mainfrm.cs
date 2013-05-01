using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditorReborn
{
    public partial class Mainfrm : Form
    {
        private Modfrm modfrm;
        public Map Map;
        private Accessfrm accessfrm;
        public Tiles Tiles = new Tiles();

        public int EditionType = 0;

        private bool painting;
        private string fileName;
        private int lastCell;

        public Mainfrm()
        {
            InitializeComponent();
            painting = false;
            fileName = "";
            lastCell = -1;
            modfrm = new Modfrm();
            accessfrm = new Accessfrm();
            Map = new Map(this);
        }


        private void MainFrm_Load(object sender, EventArgs e)
        {
            InitMap();
        }

        private void NouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitMap();
        }

        private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitProgram();
        }

        private void GrilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawAll();
        }

        private void Couche1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawAll();
        }

        private void Couche2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawAll();
        }

        private void Couche3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawAll();
        }

        private void MainPicture_MouseUp(object sender, MouseEventArgs e)
        {
            painting = false;
        }

        private void MainPicture_MouseDown(object sender, MouseEventArgs e)
        {
            painting = true;
        }

        private void MainPicture_MouseMove(object sender, MouseEventArgs e)
        {
            int x = (int)Math.Floor((double)e.X / Constants.TileWidth) - Cells.DeltaScrolling.X;
            int y = (int)Math.Floor((double)e.Y / Constants.TileWidth) - Cells.DeltaScrolling.Y;

            if (!Map.IsOnMap(x, y))
                return;

            int cell = Cells.GetId(x, y);

            if (cell != lastCell)
            {
                lastCell = cell;

                LabelStatus.Text = "X : " + x + "  Y: " + y + "  Id: " + cell + " DeltaScrolling: " + Cells.DeltaScrolling;

                if (EditionType == 0)
                {
                    if (painting && modfrm.BrushContinue.Checked)
                    {
                        if (e.Button == MouseButtons.Left)
                            PaintOnCell(cell, false);
                        else if (e.Button == MouseButtons.Right)
                            PaintOnCell(cell, true);
                    }
                }
            }
        }

        private void MainPicture_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (int)Math.Floor((double)e.X / Constants.TileWidth) - Cells.DeltaScrolling.X;
            int y = (int)Math.Floor((double)e.Y / Constants.TileWidth) - Cells.DeltaScrolling.Y;

            if (!Map.IsOnMap(x, y))
                return;

            int cell = Cells.GetId(x, y);

            if (EditionType == 0 && (modfrm.BrushNormal.Checked || modfrm.BrushContinue.Checked))
            {
                if (e.Button == MouseButtons.Left)
                    PaintOnCell(cell, false);
                else if (e.Button == MouseButtons.Right)
                    PaintOnCell(cell, true);

            }
            else if (EditionType == 1)
            {
                if (accessfrm.AccessGlobal.Checked)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        Map.Accessibility[cell] += 1;
                        if (Map.Accessibility[cell] > 2)
                            Map.Accessibility[cell] = 2;
                    }
                    else
                    {
                        Map.Accessibility[cell] -= 1;
                        if (Map.Accessibility[cell] < 0)
                            Map.Accessibility[cell] = 2;
                    }
                }
                else
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        int boolean = 0;
                        if (accessfrm.DoorTop.Checked)
                            boolean += 1;
                        if (accessfrm.DoorBottom.Checked)
                            boolean += 2;
                        if (accessfrm.DoorLeft.Checked)
                            boolean += 4;
                        if (accessfrm.DoorRight.Checked)
                            boolean += 8;
                        Map.SideAccess[cell] = boolean;
                    }
                    else
                        Map.SideAccess[cell] = 0;
                }
                DrawAll();
            }
        }

        private void InitMap()
        {
            Map.Init();
            DrawAll();
        }

        private void PaintOnCell(int cell, bool erase)
        {
            bool draw = false;
            int i = 0;
            Point startPoint = Cells.GetPos(cell);

            foreach (Point selected in (erase ? new List<Point> {startPoint} : modfrm.SelectedPoints))
            {
                Point actualPoint = erase ? startPoint :  new Point(startPoint.X + selected.X, startPoint.Y + selected.Y);

                if (actualPoint.X < Constants.MapWidth && actualPoint.Y < Constants.MapHeight)
                {
                    cell = Cells.GetId(actualPoint.X, actualPoint.Y);
                    int toWrite = erase ? -1 : modfrm.SelectedCells[i];
                    Dictionary<int, int> tiles = null;

                    if (modfrm.ModificationHigh.Checked)
                        tiles = Map.MapTilesHigh;
                    else if (modfrm.ModificationMiddle.Checked)
                        tiles = Map.MapTilesMiddle;
                    else if (modfrm.ModificationLow.Checked)
                        tiles = Map.MapTilesLow;

                    if (tiles != null && tiles.ContainsKey(cell) && tiles[cell] != toWrite)
                    {
                        tiles[cell] = toWrite;
                        draw = true;
                    }
                }
                i++;
            }
            if (draw)
                DrawAll();
        }

        public void DrawAll()
        {
            if (MainPicture.Image != null)
                MainPicture.Image.Dispose();

            Bitmap b = new Bitmap(Constants.TotalWidth + Constants.TileWidth, Constants.TotalHeight + Constants.TileWidth);
            Graphics g = Graphics.FromImage(b);

            if (Couche1ToolStripMenuItem.Checked)
                Map.DrawLow(g);
            if (Couche2ToolStripMenuItem.Checked)
                Map.DrawMiddle(g);
            if (Couche3ToolStripMenuItem.Checked)
                Map.DrawHigh(g);
            if (GrilleToolStripMenuItem.Checked)
                Map.DrawGrid(g);
            if (EditionType == 1)
                Map.DrawAccess(g);
            MainPicture.Image = b;

            g.Dispose();
        }

        private void ExitProgram()
        {
            Application.Exit();
        }

        private void EnregistrerSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Cartes RPG (*.mrm)|*.mrm";
            if (save.ShowDialog() == DialogResult.OK)
            {
                fileName = save.FileName;
                Map.ToFile(fileName);
            }
        }

        private void OuvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Cartes RPG (*.mrm)|*.mrm";
            if (open.ShowDialog() == DialogResult.OK)
                Map.FromFile(open.FileName);
            DrawAll();
        }

        private void EnregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName ==  "")
                EnregistrerSousToolStripMenuItem_Click(sender, e);
            else
            {
                Map.ToFile(fileName);
            }
        }

        private void TerrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditionType = 0;
            DrawAll();
        }

        private void AccessibilitéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditionType = 1;
            DrawAll();
        }

        private void EditionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (modfrm == null || modfrm.IsDisposed)
                modfrm = new Modfrm();
            modfrm.Show();
        }

        private void AccessibilitéToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (accessfrm == null || accessfrm.IsDisposed)
                accessfrm = new Accessfrm();
            accessfrm.Show();
        }

        private void MainfrmKeyDown(object sender, KeyEventArgs e)
        {
            Point aux = new Point();

            if (e.KeyCode == Keys.Left)
                aux = new Point(-1, 0);
            else if (e.KeyCode == Keys.Right)
                aux = new Point(1, 0);
            else if (e.KeyCode == Keys.Up)
                aux = new Point(0, -1);
            else if (e.KeyCode == Keys.Down)
                aux = new Point(0, 1);

            if (aux.X == 0 && aux.Y == 0)
                return;

            Cells.DeltaScrolling = 
                new Point(Cells.DeltaScrolling.X + aux.X, 
                    Cells.DeltaScrolling.Y + aux.Y);

            DrawAll();
        }
    }
}
