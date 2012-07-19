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
    public partial class selectMovie : Form
    {
        private List<ListViewItem> list;
        public int movieid = 0;
        public string orgTitel = "";

        /// <summary>
        /// Überladener Konstruktor.
        /// Bekommt eine Liste mit ListViewItems übergeben die alle gefundenen Titel zu einem Film darstellen
        /// </summary>
        /// <param name="list">Liste mit Filmtiteln</param>
        public selectMovie(List<ListViewItem> list)
        {
            InitializeComponent();
            this.list = list;
            listView1.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(item_click);
        }

        /// <summary>
        /// Beim starten der Form werden alle ListViewItems dem ListViews hinzugefügt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectMovie_Load(object sender, EventArgs e)
        {
            foreach (ListViewItem i in list)
            {
                listView1.Items.Add(i);
            }
        }

        /// <summary>
        /// Beim klicken auf ein Item des ListView wird das angeklickte Item zurück gegeben
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_click(object sender,ListViewItemSelectionChangedEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            movieid = int.Parse(e.Item.SubItems[1].Text);
            orgTitel = e.Item.SubItems[2].Text;
            this.Close();
        }
    }
}
