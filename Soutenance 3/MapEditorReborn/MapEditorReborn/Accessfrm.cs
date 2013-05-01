using System;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditorReborn
{
    public partial class Accessfrm : Form
    {
        public Accessfrm()
        {
            InitializeComponent();
        }

        private void accessfrm_Load(Object sender, EventArgs e)
        {
            Location = new Point(100, 100);
        }
    }

}
