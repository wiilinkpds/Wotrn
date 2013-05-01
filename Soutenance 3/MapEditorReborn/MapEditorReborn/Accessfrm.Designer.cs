namespace MapEditorReborn
{
    partial class Accessfrm
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
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.AccessDoor = new System.Windows.Forms.RadioButton();
            this.AccessGlobal = new System.Windows.Forms.RadioButton();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.DoorRight = new System.Windows.Forms.CheckBox();
            this.DoorLeft = new System.Windows.Forms.CheckBox();
            this.DoorBottom = new System.Windows.Forms.CheckBox();
            this.DoorTop = new System.Windows.Forms.CheckBox();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.AccessDoor);
            this.GroupBox2.Controls.Add(this.AccessGlobal);
            this.GroupBox2.Location = new System.Drawing.Point(12, 12);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(160, 47);
            this.GroupBox2.TabIndex = 7;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Type d\'accès";
            // 
            // AccessDoor
            // 
            this.AccessDoor.AutoSize = true;
            this.AccessDoor.Location = new System.Drawing.Point(78, 19);
            this.AccessDoor.Name = "AccessDoor";
            this.AccessDoor.Size = new System.Drawing.Size(67, 17);
            this.AccessDoor.TabIndex = 5;
            this.AccessDoor.Text = "Direction";
            this.AccessDoor.UseVisualStyleBackColor = true;
            // 
            // AccessGlobal
            // 
            this.AccessGlobal.AutoSize = true;
            this.AccessGlobal.Checked = true;
            this.AccessGlobal.Location = new System.Drawing.Point(17, 19);
            this.AccessGlobal.Name = "AccessGlobal";
            this.AccessGlobal.Size = new System.Drawing.Size(55, 17);
            this.AccessGlobal.TabIndex = 4;
            this.AccessGlobal.TabStop = true;
            this.AccessGlobal.Text = "Global";
            this.AccessGlobal.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.DoorRight);
            this.GroupBox1.Controls.Add(this.DoorLeft);
            this.GroupBox1.Controls.Add(this.DoorBottom);
            this.GroupBox1.Controls.Add(this.DoorTop);
            this.GroupBox1.Location = new System.Drawing.Point(12, 65);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(160, 72);
            this.GroupBox1.TabIndex = 8;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Direction";
            // 
            // DoorRight
            // 
            this.DoorRight.AutoSize = true;
            this.DoorRight.Location = new System.Drawing.Point(87, 42);
            this.DoorRight.Name = "DoorRight";
            this.DoorRight.Size = new System.Drawing.Size(54, 17);
            this.DoorRight.TabIndex = 3;
            this.DoorRight.Text = "Droite";
            this.DoorRight.UseVisualStyleBackColor = true;
            // 
            // DoorLeft
            // 
            this.DoorLeft.AutoSize = true;
            this.DoorLeft.Location = new System.Drawing.Point(17, 42);
            this.DoorLeft.Name = "DoorLeft";
            this.DoorLeft.Size = new System.Drawing.Size(64, 17);
            this.DoorLeft.TabIndex = 2;
            this.DoorLeft.Text = "Gauche";
            this.DoorLeft.UseVisualStyleBackColor = true;
            // 
            // DoorBottom
            // 
            this.DoorBottom.AutoSize = true;
            this.DoorBottom.Location = new System.Drawing.Point(87, 19);
            this.DoorBottom.Name = "DoorBottom";
            this.DoorBottom.Size = new System.Drawing.Size(44, 17);
            this.DoorBottom.TabIndex = 1;
            this.DoorBottom.Text = "Bas";
            this.DoorBottom.UseVisualStyleBackColor = true;
            // 
            // DoorTop
            // 
            this.DoorTop.AutoSize = true;
            this.DoorTop.Location = new System.Drawing.Point(17, 19);
            this.DoorTop.Name = "DoorTop";
            this.DoorTop.Size = new System.Drawing.Size(49, 17);
            this.DoorTop.TabIndex = 0;
            this.DoorTop.Text = "Haut";
            this.DoorTop.UseVisualStyleBackColor = true;
            // 
            // Accessfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 146);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Name = "Accessfrm";
            this.Text = "Accessfrm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.accessfrm_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.RadioButton AccessDoor;
        internal System.Windows.Forms.RadioButton AccessGlobal;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox DoorRight;
        internal System.Windows.Forms.CheckBox DoorLeft;
        internal System.Windows.Forms.CheckBox DoorBottom;
        internal System.Windows.Forms.CheckBox DoorTop;
    }
}