<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mainfrm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MainMenu = New System.Windows.Forms.MenuStrip()
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NouveauToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OuvrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EnregistrerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnregistrerSousToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AffichageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrilleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Couche1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Couche2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Couche3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerrainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccessibilitéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FenêtresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditionToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainStatus = New System.Windows.Forms.StatusStrip()
        Me.LabelStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MainPicture = New System.Windows.Forms.PictureBox()
        Me.AccessibilitéToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenu.SuspendLayout()
        Me.MainStatus.SuspendLayout()
        CType(Me.MainPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainMenu
        '
        Me.MainMenu.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem, Me.AffichageToolStripMenuItem, Me.EditionToolStripMenuItem, Me.FenêtresToolStripMenuItem})
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(1035, 24)
        Me.MainMenu.TabIndex = 0
        Me.MainMenu.Text = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NouveauToolStripMenuItem, Me.OuvrirToolStripMenuItem, Me.ToolStripSeparator2, Me.EnregistrerToolStripMenuItem, Me.EnregistrerSousToolStripMenuItem, Me.ToolStripSeparator1, Me.QuitterToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.FichierToolStripMenuItem.Text = "Fichier"
        '
        'NouveauToolStripMenuItem
        '
        Me.NouveauToolStripMenuItem.Name = "NouveauToolStripMenuItem"
        Me.NouveauToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.NouveauToolStripMenuItem.Text = "Nouveau"
        '
        'OuvrirToolStripMenuItem
        '
        Me.OuvrirToolStripMenuItem.Name = "OuvrirToolStripMenuItem"
        Me.OuvrirToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.OuvrirToolStripMenuItem.Text = "Ouvrir..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(172, 6)
        '
        'EnregistrerToolStripMenuItem
        '
        Me.EnregistrerToolStripMenuItem.Name = "EnregistrerToolStripMenuItem"
        Me.EnregistrerToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.EnregistrerToolStripMenuItem.Text = "Enregistrer"
        '
        'EnregistrerSousToolStripMenuItem
        '
        Me.EnregistrerSousToolStripMenuItem.Name = "EnregistrerSousToolStripMenuItem"
        Me.EnregistrerSousToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.EnregistrerSousToolStripMenuItem.Text = "Enregistrer sous..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(172, 6)
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'AffichageToolStripMenuItem
        '
        Me.AffichageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GrilleToolStripMenuItem, Me.Couche1ToolStripMenuItem, Me.Couche2ToolStripMenuItem, Me.Couche3ToolStripMenuItem})
        Me.AffichageToolStripMenuItem.Name = "AffichageToolStripMenuItem"
        Me.AffichageToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.AffichageToolStripMenuItem.Text = "Affichage"
        '
        'GrilleToolStripMenuItem
        '
        Me.GrilleToolStripMenuItem.Checked = True
        Me.GrilleToolStripMenuItem.CheckOnClick = True
        Me.GrilleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.GrilleToolStripMenuItem.Name = "GrilleToolStripMenuItem"
        Me.GrilleToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.GrilleToolStripMenuItem.Text = "Grille"
        '
        'Couche1ToolStripMenuItem
        '
        Me.Couche1ToolStripMenuItem.Checked = True
        Me.Couche1ToolStripMenuItem.CheckOnClick = True
        Me.Couche1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Couche1ToolStripMenuItem.Name = "Couche1ToolStripMenuItem"
        Me.Couche1ToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.Couche1ToolStripMenuItem.Text = "Couche basse"
        '
        'Couche2ToolStripMenuItem
        '
        Me.Couche2ToolStripMenuItem.Checked = True
        Me.Couche2ToolStripMenuItem.CheckOnClick = True
        Me.Couche2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Couche2ToolStripMenuItem.Name = "Couche2ToolStripMenuItem"
        Me.Couche2ToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.Couche2ToolStripMenuItem.Text = "Couche moyenne"
        '
        'Couche3ToolStripMenuItem
        '
        Me.Couche3ToolStripMenuItem.Checked = True
        Me.Couche3ToolStripMenuItem.CheckOnClick = True
        Me.Couche3ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Couche3ToolStripMenuItem.Name = "Couche3ToolStripMenuItem"
        Me.Couche3ToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.Couche3ToolStripMenuItem.Text = "Couche haute"
        '
        'EditionToolStripMenuItem
        '
        Me.EditionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TerrainToolStripMenuItem, Me.AccessibilitéToolStripMenuItem})
        Me.EditionToolStripMenuItem.Name = "EditionToolStripMenuItem"
        Me.EditionToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.EditionToolStripMenuItem.Text = "Edition"
        '
        'TerrainToolStripMenuItem
        '
        Me.TerrainToolStripMenuItem.Name = "TerrainToolStripMenuItem"
        Me.TerrainToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TerrainToolStripMenuItem.Text = "Terrain"
        '
        'AccessibilitéToolStripMenuItem
        '
        Me.AccessibilitéToolStripMenuItem.Name = "AccessibilitéToolStripMenuItem"
        Me.AccessibilitéToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AccessibilitéToolStripMenuItem.Text = "Accessibilité"
        '
        'FenêtresToolStripMenuItem
        '
        Me.FenêtresToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditionToolStripMenuItem1, Me.AccessibilitéToolStripMenuItem1})
        Me.FenêtresToolStripMenuItem.Name = "FenêtresToolStripMenuItem"
        Me.FenêtresToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.FenêtresToolStripMenuItem.Text = "Fenêtres"
        '
        'EditionToolStripMenuItem1
        '
        Me.EditionToolStripMenuItem1.Name = "EditionToolStripMenuItem1"
        Me.EditionToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.EditionToolStripMenuItem1.Text = "Edition"
        '
        'MainStatus
        '
        Me.MainStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelStatus})
        Me.MainStatus.Location = New System.Drawing.Point(0, 800)
        Me.MainStatus.Name = "MainStatus"
        Me.MainStatus.Size = New System.Drawing.Size(1035, 22)
        Me.MainStatus.TabIndex = 1
        Me.MainStatus.Text = "StatusStrip1"
        '
        'LabelStatus
        '
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(58, 17)
        Me.LabelStatus.Text = "En attente"
        '
        'MainPicture
        '
        Me.MainPicture.BackColor = System.Drawing.Color.White
        Me.MainPicture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPicture.Location = New System.Drawing.Point(0, 24)
        Me.MainPicture.Name = "MainPicture"
        Me.MainPicture.Size = New System.Drawing.Size(1035, 776)
        Me.MainPicture.TabIndex = 2
        Me.MainPicture.TabStop = False
        '
        'AccessibilitéToolStripMenuItem1
        '
        Me.AccessibilitéToolStripMenuItem1.Name = "AccessibilitéToolStripMenuItem1"
        Me.AccessibilitéToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.AccessibilitéToolStripMenuItem1.Text = "Accessibilité"
        '
        'Mainfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 822)
        Me.Controls.Add(Me.MainPicture)
        Me.Controls.Add(Me.MainStatus)
        Me.Controls.Add(Me.MainMenu)
        Me.MainMenuStrip = Me.MainMenu
        Me.Name = "Mainfrm"
        Me.Text = "Miny-Rpg Editor"
        Me.MainMenu.ResumeLayout(False)
        Me.MainMenu.PerformLayout()
        Me.MainStatus.ResumeLayout(False)
        Me.MainStatus.PerformLayout()
        CType(Me.MainPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FichierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouveauToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OuvrirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnregistrerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnregistrerSousToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents QuitterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents LabelStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MainPicture As System.Windows.Forms.PictureBox
    Friend WithEvents AffichageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrilleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Couche1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Couche2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Couche3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TerrainToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccessibilitéToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FenêtresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditionToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccessibilitéToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

End Class
