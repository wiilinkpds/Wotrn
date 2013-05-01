namespace MapEditorReborn
{
    partial class Mainfrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OuvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.EnregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnregistrerSousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.QuitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AffichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrilleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Couche1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Couche2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Couche3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TerrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccessibilitéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FenêtresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AccessibilitéToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPicture = new System.Windows.Forms.PictureBox();
            this.MainStatus = new System.Windows.Forms.StatusStrip();
            this.LabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).BeginInit();
            this.MainStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FichierToolStripMenuItem,
            this.AffichageToolStripMenuItem,
            this.EditionToolStripMenuItem,
            this.FenêtresToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1040, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "MenuStrip1";
            // 
            // FichierToolStripMenuItem
            // 
            this.FichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NouveauToolStripMenuItem,
            this.OuvrirToolStripMenuItem,
            this.ToolStripSeparator2,
            this.EnregistrerToolStripMenuItem,
            this.EnregistrerSousToolStripMenuItem,
            this.ToolStripSeparator1,
            this.QuitterToolStripMenuItem});
            this.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem";
            this.FichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.FichierToolStripMenuItem.Text = "Fichier";
            // 
            // NouveauToolStripMenuItem
            // 
            this.NouveauToolStripMenuItem.Name = "NouveauToolStripMenuItem";
            this.NouveauToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.NouveauToolStripMenuItem.Text = "Nouveau";
            this.NouveauToolStripMenuItem.Click += new System.EventHandler(this.NouveauToolStripMenuItem_Click);
            // 
            // OuvrirToolStripMenuItem
            // 
            this.OuvrirToolStripMenuItem.Name = "OuvrirToolStripMenuItem";
            this.OuvrirToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.OuvrirToolStripMenuItem.Text = "Ouvrir...";
            this.OuvrirToolStripMenuItem.Click += new System.EventHandler(this.OuvrirToolStripMenuItem_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(163, 6);
            // 
            // EnregistrerToolStripMenuItem
            // 
            this.EnregistrerToolStripMenuItem.Name = "EnregistrerToolStripMenuItem";
            this.EnregistrerToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.EnregistrerToolStripMenuItem.Text = "Enregistrer";
            this.EnregistrerToolStripMenuItem.Click += new System.EventHandler(this.EnregistrerToolStripMenuItem_Click);
            // 
            // EnregistrerSousToolStripMenuItem
            // 
            this.EnregistrerSousToolStripMenuItem.Name = "EnregistrerSousToolStripMenuItem";
            this.EnregistrerSousToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.EnregistrerSousToolStripMenuItem.Text = "Enregistrer sous...";
            this.EnregistrerSousToolStripMenuItem.Click += new System.EventHandler(this.EnregistrerSousToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // QuitterToolStripMenuItem
            // 
            this.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem";
            this.QuitterToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.QuitterToolStripMenuItem.Text = "Quitter";
            this.QuitterToolStripMenuItem.Click += new System.EventHandler(this.QuitterToolStripMenuItem_Click);
            // 
            // AffichageToolStripMenuItem
            // 
            this.AffichageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GrilleToolStripMenuItem,
            this.Couche1ToolStripMenuItem,
            this.Couche2ToolStripMenuItem,
            this.Couche3ToolStripMenuItem});
            this.AffichageToolStripMenuItem.Name = "AffichageToolStripMenuItem";
            this.AffichageToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.AffichageToolStripMenuItem.Text = "Affichage";
            // 
            // GrilleToolStripMenuItem
            // 
            this.GrilleToolStripMenuItem.Checked = true;
            this.GrilleToolStripMenuItem.CheckOnClick = true;
            this.GrilleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GrilleToolStripMenuItem.Name = "GrilleToolStripMenuItem";
            this.GrilleToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.GrilleToolStripMenuItem.Text = "Grille";
            this.GrilleToolStripMenuItem.Click += new System.EventHandler(this.GrilleToolStripMenuItem_Click);
            // 
            // Couche1ToolStripMenuItem
            // 
            this.Couche1ToolStripMenuItem.Checked = true;
            this.Couche1ToolStripMenuItem.CheckOnClick = true;
            this.Couche1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Couche1ToolStripMenuItem.Name = "Couche1ToolStripMenuItem";
            this.Couche1ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.Couche1ToolStripMenuItem.Text = "Couche basse";
            this.Couche1ToolStripMenuItem.Click += new System.EventHandler(this.Couche1ToolStripMenuItem_Click);
            // 
            // Couche2ToolStripMenuItem
            // 
            this.Couche2ToolStripMenuItem.Checked = true;
            this.Couche2ToolStripMenuItem.CheckOnClick = true;
            this.Couche2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Couche2ToolStripMenuItem.Name = "Couche2ToolStripMenuItem";
            this.Couche2ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.Couche2ToolStripMenuItem.Text = "Couche moyenne";
            this.Couche2ToolStripMenuItem.Click += new System.EventHandler(this.Couche2ToolStripMenuItem_Click);
            // 
            // Couche3ToolStripMenuItem
            // 
            this.Couche3ToolStripMenuItem.Checked = true;
            this.Couche3ToolStripMenuItem.CheckOnClick = true;
            this.Couche3ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Couche3ToolStripMenuItem.Name = "Couche3ToolStripMenuItem";
            this.Couche3ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.Couche3ToolStripMenuItem.Text = "Couche haute";
            this.Couche3ToolStripMenuItem.Click += new System.EventHandler(this.Couche3ToolStripMenuItem_Click);
            // 
            // EditionToolStripMenuItem
            // 
            this.EditionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TerrainToolStripMenuItem,
            this.AccessibilitéToolStripMenuItem});
            this.EditionToolStripMenuItem.Name = "EditionToolStripMenuItem";
            this.EditionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.EditionToolStripMenuItem.Text = "Edition";
            // 
            // TerrainToolStripMenuItem
            // 
            this.TerrainToolStripMenuItem.Name = "TerrainToolStripMenuItem";
            this.TerrainToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.TerrainToolStripMenuItem.Text = "Terrain";
            this.TerrainToolStripMenuItem.Click += new System.EventHandler(this.TerrainToolStripMenuItem_Click);
            // 
            // AccessibilitéToolStripMenuItem
            // 
            this.AccessibilitéToolStripMenuItem.Name = "AccessibilitéToolStripMenuItem";
            this.AccessibilitéToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.AccessibilitéToolStripMenuItem.Text = "Accessibilité";
            this.AccessibilitéToolStripMenuItem.Click += new System.EventHandler(this.AccessibilitéToolStripMenuItem_Click);
            // 
            // FenêtresToolStripMenuItem
            // 
            this.FenêtresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditionToolStripMenuItem1,
            this.AccessibilitéToolStripMenuItem1});
            this.FenêtresToolStripMenuItem.Name = "FenêtresToolStripMenuItem";
            this.FenêtresToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.FenêtresToolStripMenuItem.Text = "Fenêtres";
            // 
            // EditionToolStripMenuItem1
            // 
            this.EditionToolStripMenuItem1.Name = "EditionToolStripMenuItem1";
            this.EditionToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.EditionToolStripMenuItem1.Text = "Edition";
            this.EditionToolStripMenuItem1.Click += new System.EventHandler(this.EditionToolStripMenuItem1_Click);
            // 
            // AccessibilitéToolStripMenuItem1
            // 
            this.AccessibilitéToolStripMenuItem1.Name = "AccessibilitéToolStripMenuItem1";
            this.AccessibilitéToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.AccessibilitéToolStripMenuItem1.Text = "Accessibilité";
            this.AccessibilitéToolStripMenuItem1.Click += new System.EventHandler(this.AccessibilitéToolStripMenuItem1_Click);
            // 
            // MainPicture
            // 
            this.MainPicture.BackColor = System.Drawing.Color.White;
            this.MainPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPicture.Location = new System.Drawing.Point(0, 24);
            this.MainPicture.Name = "MainPicture";
            this.MainPicture.Size = new System.Drawing.Size(1040, 802);
            this.MainPicture.TabIndex = 3;
            this.MainPicture.TabStop = false;
            this.MainPicture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainPicture_MouseClick);
            this.MainPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPicture_MouseDown);
            this.MainPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPicture_MouseMove);
            this.MainPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPicture_MouseUp);
            // 
            // MainStatus
            // 
            this.MainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelStatus});
            this.MainStatus.Location = new System.Drawing.Point(0, 804);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.Size = new System.Drawing.Size(1040, 22);
            this.MainStatus.TabIndex = 4;
            this.MainStatus.Text = "StatusStrip1";
            // 
            // LabelStatus
            // 
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(60, 17);
            this.LabelStatus.Text = "En attente";
            // 
            // Mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 826);
            this.Controls.Add(this.MainStatus);
            this.Controls.Add(this.MainPicture);
            this.Controls.Add(this.MainMenu);
            this.Name = "Mainfrm";
            this.Text = "MainFrm";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainfrmKeyDown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).EndInit();
            this.MainStatus.ResumeLayout(false);
            this.MainStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.MenuStrip MainMenu;
        internal System.Windows.Forms.ToolStripMenuItem FichierToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem NouveauToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem OuvrirToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripMenuItem EnregistrerToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem EnregistrerSousToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripMenuItem QuitterToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem AffichageToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem GrilleToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem Couche1ToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem Couche2ToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem Couche3ToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem EditionToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem TerrainToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem AccessibilitéToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem FenêtresToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem EditionToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem AccessibilitéToolStripMenuItem1;
        internal System.Windows.Forms.StatusStrip MainStatus;
        internal System.Windows.Forms.ToolStripStatusLabel LabelStatus;
        public System.Windows.Forms.PictureBox MainPicture;
    }
}