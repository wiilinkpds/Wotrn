<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modfrm
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
        Me.ModificationNone = New System.Windows.Forms.RadioButton()
        Me.ModificationLow = New System.Windows.Forms.RadioButton()
        Me.ModificationMiddle = New System.Windows.Forms.RadioButton()
        Me.ModificationHigh = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BrushContinue = New System.Windows.Forms.RadioButton()
        Me.BrushNormal = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PaintBox = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PaintBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ModificationNone
        '
        Me.ModificationNone.AutoSize = True
        Me.ModificationNone.Checked = True
        Me.ModificationNone.Location = New System.Drawing.Point(19, 19)
        Me.ModificationNone.Name = "ModificationNone"
        Me.ModificationNone.Size = New System.Drawing.Size(62, 17)
        Me.ModificationNone.TabIndex = 0
        Me.ModificationNone.TabStop = True
        Me.ModificationNone.Text = "Aucune"
        Me.ModificationNone.UseVisualStyleBackColor = True
        '
        'ModificationLow
        '
        Me.ModificationLow.AutoSize = True
        Me.ModificationLow.Location = New System.Drawing.Point(18, 42)
        Me.ModificationLow.Name = "ModificationLow"
        Me.ModificationLow.Size = New System.Drawing.Size(93, 17)
        Me.ModificationLow.TabIndex = 1
        Me.ModificationLow.Text = "Couche basse"
        Me.ModificationLow.UseVisualStyleBackColor = True
        '
        'ModificationMiddle
        '
        Me.ModificationMiddle.AutoSize = True
        Me.ModificationMiddle.Location = New System.Drawing.Point(18, 65)
        Me.ModificationMiddle.Name = "ModificationMiddle"
        Me.ModificationMiddle.Size = New System.Drawing.Size(108, 17)
        Me.ModificationMiddle.TabIndex = 2
        Me.ModificationMiddle.Text = "Couche moyenne"
        Me.ModificationMiddle.UseVisualStyleBackColor = True
        '
        'ModificationHigh
        '
        Me.ModificationHigh.AutoSize = True
        Me.ModificationHigh.Location = New System.Drawing.Point(18, 88)
        Me.ModificationHigh.Name = "ModificationHigh"
        Me.ModificationHigh.Size = New System.Drawing.Size(92, 17)
        Me.ModificationHigh.TabIndex = 3
        Me.ModificationHigh.Text = "Couche haute"
        Me.ModificationHigh.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ModificationHigh)
        Me.GroupBox1.Controls.Add(Me.ModificationMiddle)
        Me.GroupBox1.Controls.Add(Me.ModificationNone)
        Me.GroupBox1.Controls.Add(Me.ModificationLow)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(137, 119)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Couche"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BrushContinue)
        Me.GroupBox2.Controls.Add(Me.BrushNormal)
        Me.GroupBox2.Location = New System.Drawing.Point(155, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(151, 119)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pinceau"
        '
        'BrushContinue
        '
        Me.BrushContinue.AutoSize = True
        Me.BrushContinue.Location = New System.Drawing.Point(17, 42)
        Me.BrushContinue.Name = "BrushContinue"
        Me.BrushContinue.Size = New System.Drawing.Size(67, 17)
        Me.BrushContinue.TabIndex = 5
        Me.BrushContinue.Text = "Continue"
        Me.BrushContinue.UseVisualStyleBackColor = True
        '
        'BrushNormal
        '
        Me.BrushNormal.AutoSize = True
        Me.BrushNormal.Checked = True
        Me.BrushNormal.Location = New System.Drawing.Point(17, 19)
        Me.BrushNormal.Name = "BrushNormal"
        Me.BrushNormal.Size = New System.Drawing.Size(58, 17)
        Me.BrushNormal.TabIndex = 4
        Me.BrushNormal.TabStop = True
        Me.BrushNormal.Text = "Normal"
        Me.BrushNormal.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.PaintBox)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 137)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(294, 451)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'PaintBox
        '
        Me.PaintBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaintBox.Location = New System.Drawing.Point(3, 16)
        Me.PaintBox.Name = "PaintBox"
        Me.PaintBox.Size = New System.Drawing.Size(288, 432)
        Me.PaintBox.TabIndex = 0
        Me.PaintBox.TabStop = False
        '
        'Modfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 600)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "Modfrm"
        Me.Text = "Edition"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.PaintBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ModificationNone As System.Windows.Forms.RadioButton
    Friend WithEvents ModificationLow As System.Windows.Forms.RadioButton
    Friend WithEvents ModificationMiddle As System.Windows.Forms.RadioButton
    Friend WithEvents ModificationHigh As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BrushNormal As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents PaintBox As System.Windows.Forms.PictureBox
    Friend WithEvents BrushContinue As System.Windows.Forms.RadioButton
End Class
