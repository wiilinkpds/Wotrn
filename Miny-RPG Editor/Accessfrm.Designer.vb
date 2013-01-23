<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Accessfrm
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.AccessDoor = New System.Windows.Forms.RadioButton()
        Me.AccessGlobal = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DoorTop = New System.Windows.Forms.CheckBox()
        Me.DoorBottom = New System.Windows.Forms.CheckBox()
        Me.DoorLeft = New System.Windows.Forms.CheckBox()
        Me.DoorRight = New System.Windows.Forms.CheckBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.AccessDoor)
        Me.GroupBox2.Controls.Add(Me.AccessGlobal)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(160, 47)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Type d'accès"
        '
        'AccessDoor
        '
        Me.AccessDoor.AutoSize = True
        Me.AccessDoor.Location = New System.Drawing.Point(78, 19)
        Me.AccessDoor.Name = "AccessDoor"
        Me.AccessDoor.Size = New System.Drawing.Size(67, 17)
        Me.AccessDoor.TabIndex = 5
        Me.AccessDoor.Text = "Direction"
        Me.AccessDoor.UseVisualStyleBackColor = True
        '
        'AccessGlobal
        '
        Me.AccessGlobal.AutoSize = True
        Me.AccessGlobal.Checked = True
        Me.AccessGlobal.Location = New System.Drawing.Point(17, 19)
        Me.AccessGlobal.Name = "AccessGlobal"
        Me.AccessGlobal.Size = New System.Drawing.Size(55, 17)
        Me.AccessGlobal.TabIndex = 4
        Me.AccessGlobal.TabStop = True
        Me.AccessGlobal.Text = "Global"
        Me.AccessGlobal.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DoorRight)
        Me.GroupBox1.Controls.Add(Me.DoorLeft)
        Me.GroupBox1.Controls.Add(Me.DoorBottom)
        Me.GroupBox1.Controls.Add(Me.DoorTop)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(160, 72)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Direction"
        '
        'DoorTop
        '
        Me.DoorTop.AutoSize = True
        Me.DoorTop.Location = New System.Drawing.Point(17, 19)
        Me.DoorTop.Name = "DoorTop"
        Me.DoorTop.Size = New System.Drawing.Size(49, 17)
        Me.DoorTop.TabIndex = 0
        Me.DoorTop.Text = "Haut"
        Me.DoorTop.UseVisualStyleBackColor = True
        '
        'DoorBottom
        '
        Me.DoorBottom.AutoSize = True
        Me.DoorBottom.Location = New System.Drawing.Point(87, 19)
        Me.DoorBottom.Name = "DoorBottom"
        Me.DoorBottom.Size = New System.Drawing.Size(44, 17)
        Me.DoorBottom.TabIndex = 1
        Me.DoorBottom.Text = "Bas"
        Me.DoorBottom.UseVisualStyleBackColor = True
        '
        'DoorLeft
        '
        Me.DoorLeft.AutoSize = True
        Me.DoorLeft.Location = New System.Drawing.Point(17, 42)
        Me.DoorLeft.Name = "DoorLeft"
        Me.DoorLeft.Size = New System.Drawing.Size(64, 17)
        Me.DoorLeft.TabIndex = 2
        Me.DoorLeft.Text = "Gauche"
        Me.DoorLeft.UseVisualStyleBackColor = True
        '
        'DoorRight
        '
        Me.DoorRight.AutoSize = True
        Me.DoorRight.Location = New System.Drawing.Point(87, 42)
        Me.DoorRight.Name = "DoorRight"
        Me.DoorRight.Size = New System.Drawing.Size(54, 17)
        Me.DoorRight.TabIndex = 3
        Me.DoorRight.Text = "Droite"
        Me.DoorRight.UseVisualStyleBackColor = True
        '
        'Accessfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(184, 152)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "Accessfrm"
        Me.Text = "Bloquage d'accès aux cases"
        Me.TopMost = True
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents AccessDoor As System.Windows.Forms.RadioButton
    Friend WithEvents AccessGlobal As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DoorBottom As System.Windows.Forms.CheckBox
    Friend WithEvents DoorTop As System.Windows.Forms.CheckBox
    Friend WithEvents DoorRight As System.Windows.Forms.CheckBox
    Friend WithEvents DoorLeft As System.Windows.Forms.CheckBox
End Class
