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
    public partial class Options : Form
    {
        public Dictionary<string, Boolean> ActiveGenre;

        public Options(Dictionary<string,Boolean> genre)
        {
            InitializeComponent();
            ActiveGenre = genre;
        }

        private void Options_Load(object sender, EventArgs e)
        {
            foreach(KeyValuePair<string, Boolean> pair in ActiveGenre)
            {
                CheckBox newCheck = new CheckBox();
                newCheck.Text = pair.Key.ToString();
                newCheck.Checked = pair.Value;
                newCheck.CheckedChanged += new EventHandler(checkedChanged);
                container.Controls.Add(newCheck);
            }
        }

        private void checkedChanged(object obj, EventArgs ea)
        {
            if (((CheckBox)obj).Checked)
            {
                ActiveGenre[((CheckBox)obj).Text] = true;
            }
            else
            {
                ActiveGenre[((CheckBox)obj).Text] = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
