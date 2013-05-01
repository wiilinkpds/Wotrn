namespace MapEditorReborn
{
    partial class Modfrm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.BrushContinue = new System.Windows.Forms.RadioButton();
            this.BrushNormal = new System.Windows.Forms.RadioButton();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ModificationHigh = new System.Windows.Forms.RadioButton();
            this.ModificationMiddle = new System.Windows.Forms.RadioButton();
            this.ModificationNone = new System.Windows.Forms.RadioButton();
            this.ModificationLow = new System.Windows.Forms.RadioButton();
            this.PaintBox = new System.Windows.Forms.PictureBox();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaintBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.BrushContinue);
            this.GroupBox2.Controls.Add(this.BrushNormal);
            this.GroupBox2.Location = new System.Drawing.Point(143, 12);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(151, 119);
            this.GroupBox2.TabIndex = 6;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Pinceau";
            // 
            // BrushContinue
            // 
            this.BrushContinue.AutoSize = true;
            this.BrushContinue.Location = new System.Drawing.Point(17, 42);
            this.BrushContinue.Name = "BrushContinue";
            this.BrushContinue.Size = new System.Drawing.Size(67, 17);
            this.BrushContinue.TabIndex = 5;
            this.BrushContinue.Text = "Continue";
            this.BrushContinue.UseVisualStyleBackColor = true;
            // 
            // BrushNormal
            // 
            this.BrushNormal.AutoSize = true;
            this.BrushNormal.Checked = true;
            this.BrushNormal.Location = new System.Drawing.Point(17, 19);
            this.BrushNormal.Name = "BrushNormal";
            this.BrushNormal.Size = new System.Drawing.Size(58, 17);
            this.BrushNormal.TabIndex = 4;
            this.BrushNormal.TabStop = true;
            this.BrushNormal.Text = "Normal";
            this.BrushNormal.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ModificationHigh);
            this.GroupBox1.Controls.Add(this.ModificationMiddle);
            this.GroupBox1.Controls.Add(this.ModificationNone);
            this.GroupBox1.Controls.Add(this.ModificationLow);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(137, 119);
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Couche";
            // 
            // ModificationHigh
            // 
            this.ModificationHigh.AutoSize = true;
            this.ModificationHigh.Location = new System.Drawing.Point(18, 88);
            this.ModificationHigh.Name = "ModificationHigh";
            this.ModificationHigh.Size = new System.Drawing.Size(92, 17);
            this.ModificationHigh.TabIndex = 3;
            this.ModificationHigh.Text = "Couche haute";
            this.ModificationHigh.UseVisualStyleBackColor = true;
            // 
            // ModificationMiddle
            // 
            this.ModificationMiddle.AutoSize = true;
            this.ModificationMiddle.Location = new System.Drawing.Point(18, 65);
            this.ModificationMiddle.Name = "ModificationMiddle";
            this.ModificationMiddle.Size = new System.Drawing.Size(108, 17);
            this.ModificationMiddle.TabIndex = 2;
            this.ModificationMiddle.Text = "Couche moyenne";
            this.ModificationMiddle.UseVisualStyleBackColor = true;
            // 
            // ModificationNone
            // 
            this.ModificationNone.AutoSize = true;
            this.ModificationNone.Checked = true;
            this.ModificationNone.Location = new System.Drawing.Point(19, 19);
            this.ModificationNone.Name = "ModificationNone";
            this.ModificationNone.Size = new System.Drawing.Size(62, 17);
            this.ModificationNone.TabIndex = 0;
            this.ModificationNone.TabStop = true;
            this.ModificationNone.Text = "Aucune";
            this.ModificationNone.UseVisualStyleBackColor = true;
            // 
            // ModificationLow
            // 
            this.ModificationLow.AutoSize = true;
            this.ModificationLow.Location = new System.Drawing.Point(18, 42);
            this.ModificationLow.Name = "ModificationLow";
            this.ModificationLow.Size = new System.Drawing.Size(93, 17);
            this.ModificationLow.TabIndex = 1;
            this.ModificationLow.Text = "Couche basse";
            this.ModificationLow.UseVisualStyleBackColor = true;
            // 
            // PaintBox
            // 
            this.PaintBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PaintBox.Location = new System.Drawing.Point(12, 137);
            this.PaintBox.Name = "PaintBox";
            this.PaintBox.Size = new System.Drawing.Size(282, 426);
            this.PaintBox.TabIndex = 8;
            this.PaintBox.TabStop = false;
            this.PaintBox.Click += new System.EventHandler(this.PaintBox_Click);
            this.PaintBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PaintBox_MouseDown);
            this.PaintBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PaintBox_MouseMove);
            this.PaintBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PaintBox_MouseUp);
            // 
            // Modfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 575);
            this.Controls.Add(this.PaintBox);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Name = "Modfrm";
            this.Text = "Modfrm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.modfrm_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaintBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.RadioButton BrushContinue;
        internal System.Windows.Forms.RadioButton BrushNormal;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.RadioButton ModificationHigh;
        internal System.Windows.Forms.RadioButton ModificationMiddle;
        internal System.Windows.Forms.RadioButton ModificationNone;
        internal System.Windows.Forms.RadioButton ModificationLow;
        private System.Windows.Forms.PictureBox PaintBox;
    }
}