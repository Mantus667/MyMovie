using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyMovie
{
    public partial class lightbox : Form
    {
        public lightbox()
        {
            InitializeComponent();
        }

        public lightbox(Image img)
        {
            InitializeComponent();
            pictureBox1.Image = img;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
