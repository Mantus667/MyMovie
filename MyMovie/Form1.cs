using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vbAccelerator.Components.Controls;
using System.Collections;

namespace MyMovie
{
    public partial class Form1 : Form
    {
        private DataTable titel;
        private clXMLController controller;
        private TextBoxMarginCustomise textBox1Icon;
        private Movie movie;
        private ListViewColumnSorter lvwColumnSorter;
        public Dictionary<string, Boolean> ActiveGenre;

        /// <summary>
        /// Basiskonstruktor. Zusätzlich zur initialisierung der Formelemente, wird der ColumnSorter
        /// für das ListView, das Icon für das Suchfeld und verschiedene EventHandler gesetzt
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            controller = new clXMLController();
            
           // Assign a text box customiser to show an
           // icon in the near margin of textBox1:
           textBox1Icon = new TextBoxMarginCustomise();
           textBox1Icon.ImageList = ilsIcons;
           textBox1Icon.Icon = 0;
           textBox1Icon.Attach(textBox1);
           textBox1.TextChanged += new EventHandler(textBox1_TextChanged);

            //ListView Sorter
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control. Set the first Column to be sorted
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
            listView1.ColumnClick += new ColumnClickEventHandler(lv1_columnclick);
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = SortOrder.Ascending;

            //ListView
            listView1.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(showMovie);

            //Plot RTB
            rtbDesc.AutoSize = true;
            rtbDesc.ContentsResized += new ContentsResizedEventHandler(rtb_ContentsResized);

            //Screenshots Container
            flpScreenshots.ControlAdded += new ControlEventHandler(flpScreenshots_ControlAdded);

            //LinkLabel
            lblTrailer.LinkClicked += new LinkLabelLinkClickedEventHandler(lblTrailer_LinkClicked);
            lblHP.LinkClicked += new LinkLabelLinkClickedEventHandler(lblTrailer_LinkClicked);

            //ActiveGenre
            ActiveGenre = new Dictionary<string, bool>();
            for (int i = 0; i < listView1.Groups.Count;i++ )
            {
                ActiveGenre.Add(listView1.Groups[i].Name, true);
            }
        }

        /// <summary>
        /// Beim starten der Form wird eine temporäre Tabelle für die Filmtitel
        /// erstellt und gefüllt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            titel = new DataTable(); //Sample Data
            titel.Columns.Add("name", typeof(string));
            titel.Columns.Add("genre", typeof(string));

            statusStrip1.Items["status"].Text = "Lade Filme... Bitte warten";
            statusStrip1.Items["image"].Visible = true;
            getMovies();
            statusStrip1.Items["image"].Visible = false;
        }

        /// <summary>
        /// Die Methode füllt die temporäre Tabelle mit allen
        /// Filmtiteln die gespeichert sind und ruft dann die Function zum filtern
        /// der Einträge auf. Die EInträge bekommt die Methode über den "controller"
        /// </summary>
        private void getMovies()
        {
            List<ListViewItem> list = controller.fillTree();
            titel.Rows.Clear();

            foreach (ListViewItem i in list)
            {
                titel.Rows.Add(i.Text, i.SubItems[1].Text);
            }

            addItems();
        }

        /// <summary>
        /// Bei einer Änderung des Textfeldes wird die Funktion aufgerufen,
        /// um die Einträge der Filmtitel zu filtern.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void textBox1_TextChanged(object sender, EventArgs e)
        {
            addItems();
        }

        /// <summary>
        /// Die Methode filtert die Einträge im ListView der Filmtitel nach dem Inhalt des Suchfeldes
        /// </summary>
        private void addItems()
        {
            listView1.Items.Clear(); //Clear all the Data in the ListView

            foreach (DataRow row in titel.Rows)
            {
                if (ActiveGenre[row["genre"].ToString()])
                {
                    if (row["name"].ToString().ToLower().StartsWith(textBox1.Text.ToLower())) //If the cell value starts with the value in the TextBox
                    {
                        ListViewItem item = new ListViewItem(row["name"].ToString());
                        item.Group = listView1.Groups[row["genre"].ToString()];
                        listView1.Items.Add(item); //Add this row to the ListView
                    }
                }
            }
            listView1.Sort(); //Sorting the ListView
            status.Text = listView1.Items.Count.ToString() + " Einträge vorhanden";
        }

        /// <summary>
        /// Öffnet den Dialog um einen neuen Film zu speichern und aktualisiert bei
        /// einem neuem Eintrag die Liste mit Filmtiteln
        /// </summary>
        /// <param name="sender">MenüItem für "Neuer Film"</param>
        private void addMovie_Click(object sender, EventArgs e)
        {
            MyMovie.addMovie newMovie = new MyMovie.addMovie();
            if (newMovie.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                getMovies();
            }
        }

        /// <summary>
        /// Beim drücken auf einen Filmtitel in der linken Anzeige wird der passende Film vom "controller" gesucht
        /// und dann angezeigt.
        /// </summary>
        private void showMovie(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btnEdit.Enabled = true;
            clearALL();
            this.Cursor = Cursors.WaitCursor;
            movie = controller.getMovie(e.Item.Text);
            show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Event Handler der den Container für die PictureBoxen mit den Screenshots
        /// die richtige Höhe zuweist sobald ein Control hinzugefügt wurde
        /// </summary>
        private void flpScreenshots_ControlAdded(object sender, ControlEventArgs e)
        {
            if (((FlowLayoutPanel)sender).Controls.Count > 10)
            {
                int i = ((FlowLayoutPanel)sender).Controls.Count / 10 + 1;
                ((FlowLayoutPanel)sender).Height = i * 100 + 20;
            }
            else
            {
                ((FlowLayoutPanel)sender).Height = 105;
            }
            ((FlowLayoutPanel)sender).Refresh();
        }

        /// <summary>
        /// Die Methode liest den aktuellen Film aus und setzt
        /// alle Werte in der Form.
        /// </summary>
        private void show()
        {
            lblTitel.Text = movie.Titel;
            tbOrgTitel.Text = movie.OrigTitel;
            foreach (string s in movie.MGenres)
                if (tbGenre.Text.Trim() == "")
                {
                    tbGenre.AppendText(s);
                }
                else
                {
                    tbGenre.AppendText(", " + s);
                }
            tbJahr.Text = movie.Year;
            tbRegi.Text = movie.Director;
            pbImage.Image = movie.MovieImage;
            rtbActor.Text = movie.Actors;
            starRating1.Rating = movie.Rank;
            cbSeen.Checked = movie.Seen;
            cbWish.Checked = movie.Wishlist;
            if (!"0".Equals(movie.Preis))
            {
                label7.Visible = true;
                lblPrice.Text = movie.Preis;
            }
            if (movie.MediaType != "")
            {
                label2.Visible = true;
                lblMType.Text = movie.MediaType;
            }
            if (movie.MediaCount != 0)
            {
                label6.Visible = true;
                lblDCount.Text = movie.MediaCount.ToString();
            }
            if (movie.Trailer != "http://")
            {
                lblTrailer.Visible = true;
                lblTrailer.Links.Add(0, lblTrailer.Text.Length, movie.Trailer);
            }
            if (movie.HPLink != "http://")
            {
                lblHP.Visible = true;
                lblHP.Links.Add(0, lblHP.Text.Length, movie.HPLink);
            }

            if (movie.LentTo != String.Empty || movie.LentTo != "")
            {
                label8.Visible = true;
                lblLent.Text = movie.LentTo;
            }
            if (movie.MoviePath != string.Empty)
            {
                btnView.Visible = true;
            }
            foreach (Image img in movie.Screenshots)
            {
                PictureBox pb = new PictureBox();
                pb.Click += new EventHandler(pb_Click);
                pb.Size = new System.Drawing.Size(50, 100);
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.Image = img;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                flpScreenshots.Controls.Add(pb);
            }
            if (flpScreenshots.Controls.Count != 0)
            {
                flpScreenshots.Enabled = true;
                rtbDesc.Location = new Point(rtbDesc.Location.X,flpScreenshots.Location.Y + flpScreenshots.Height + 10);
            }
            //Muss nach Screenshots gesetz werden, damit das COntentResized richtig funktioniert.
            rtbDesc.Text = movie.Plot;

            lblAddDate.Text = "Hinzugefügt am: " + Environment.NewLine + movie.AddDate;
        }

        private void lblTrailer_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        /// <summary>
        /// Wird auf die PictureBox eines Screenshots geklickt wird die "Lightbox" aufgerufen,
        /// die das Bild in Originalgröße anzeigt.
        /// </summary>
        private void pb_Click(object sender, EventArgs e)
        {
            lightbox box = new lightbox(((PictureBox)sender).Image);
            box.ShowDialog();
        }

        /// <summary>
        /// Wenn der Content der RichTextBox für die Beschreibung des Filmes seine Größe
        /// verändert dann setze die passende Größe für die RichTextBox und das ParentControl
        /// </summary>
        /// <param name="sender">Die RichTextBox die den aufruf macht</param>
        /// <param name="e">Eventparameter mit der neuen Größe der RichTextBox</param>
        private void rtb_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            ((RichTextBox)sender).Height = e.NewRectangle.Height + 25;
            pnlContainer.Height = ((RichTextBox)sender).Height  + 30;
        }

        /// <summary>
        /// Bei betätigen des "Bearbeiten"-Buttons wird die Form zum erstellen eines Filmes aufgerufen und ihr der zu bearbeitende
        /// Film übergeben. Wenn die Bearbeitung abgeschlossen ist, wird der Film neu angezeigt und die Liste mit Filmen erneuert, für den Fall,
        /// das der Titel verändert wurde
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            MyMovie.addMovie newMovie = new MyMovie.addMovie(movie);
            if (newMovie.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                movie = controller.getMovie(listView1.SelectedItems[0].Text);
                clearALL();
                show();
                getMovies();
                listView1.Sort();
                //listView1.Items[movie.Titel].Selected = true;
                //foreach(ListViewItem item in listView1.Items)
                //{
                //    if (item.Text == movie.Titel)
                //    {
                //        item.Selected = true;
                //        item.Checked = true;
                //    }
                //}
            }
            
        }

        /// <summary>
        /// Bei betätigen des löschen Buttons wird das gerade angezeigte
        /// Movie aus der Sammlung gelöscht. Dazu wird der "controller" benutzt.
        /// Anschliessend werden alle Textboxen von Inhalt befreit und die neue Liste der Filme geholt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            controller.deleteMovie(lblTitel.Text);
            clearALL();
            getMovies();
        }

        /// <summary>
        /// Die Methode löscht alle texte aus den verschiedenen Textboxen der Form
        /// </summary>
        private void clearALL()
        {
            lblTitel.Text = "";
            lblAddDate.Text = "";
            tbGenre.Clear();
            tbJahr.Clear();
            tbRegi.Clear();
            tbOrgTitel.Clear();
            rtbActor.Clear();
            rtbDesc.Clear();
            starRating1.Rating = 0;
            pbImage.Image = Properties.Resources.na;
            lblPrice.ResetText();
            lblDCount.ResetText();
            lblMType.ResetText();
            lblTrailer.Links.Clear();
            label8.ResetText();
            lblLent.ResetText();
            flpScreenshots.Controls.Clear();
            flpScreenshots.Enabled = false;
            label7.Visible = false;
            label6.Visible = false;
            label2.Visible = false;
            lblTrailer.Visible = false;
            lblTrailer.Links.Clear();
            lblHP.Visible = false;
            lblHP.Links.Clear();
            label8.Visible = false;
            btnView.Visible = false;
       }

        #region "Column Sorting ListView"
        private void lv1_columnclick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if ( e.Column == lvwColumnSorter.SortColumn )
            {
	            // Reverse the current sort direction for this column.
	            if (lvwColumnSorter.Order == SortOrder.Ascending)
	            {
		            lvwColumnSorter.Order = SortOrder.Descending;
	            }
	            else
	            {
		            lvwColumnSorter.Order = SortOrder.Ascending;
	            }
            }
            else
            {
	            // Set the column number that is to be sorted; default to ascending.
	            lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }

        /// <summary>
        /// This class is an implementation of the 'IComparer' interface.
        /// </summary>
        public class ListViewColumnSorter : IComparer
        {
            /// <summary>
            /// Specifies the column to be sorted
            /// </summary>
            private int ColumnToSort;
            /// <summary>
            /// Specifies the order in which to sort (i.e. 'Ascending').
            /// </summary>
            private SortOrder OrderOfSort;
            /// <summary>
            /// Case insensitive comparer object
            /// </summary>
            private CaseInsensitiveComparer ObjectCompare;

            /// <summary>
            /// Class constructor.  Initializes various elements
            /// </summary>
            public ListViewColumnSorter()
            {
                // Initialize the column to '0'
                ColumnToSort = 0;

                // Initialize the sort order to 'none'
                OrderOfSort = SortOrder.None;

                // Initialize the CaseInsensitiveComparer object
                ObjectCompare = new CaseInsensitiveComparer();
            }

            /// <summary>
            /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
            /// </summary>
            /// <param name="x">First object to be compared</param>
            /// <param name="y">Second object to be compared</param>
            /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
            public int Compare(object x, object y)
            {
                int compareResult;
                ListViewItem listviewX, listviewY;

                // Cast the objects to be compared to ListViewItem objects
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;

                // Compare the two items
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

                // Calculate correct return value based on object comparison
                if (OrderOfSort == SortOrder.Ascending)
                {
                    // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                }
                else
                {
                    // Return '0' to indicate they are equal
                    return 0;
                }
            }

            /// <summary>
            /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
            /// </summary>
            public int SortColumn
            {
                set
                {
                    ColumnToSort = value;
                }
                get
                {
                    return ColumnToSort;
                }
            }

            /// <summary>
            /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
            /// </summary>
            public SortOrder Order
            {
                set
                {
                    OrderOfSort = value;
                }
                get
                {
                    return OrderOfSort;
                }
            }

        }
        #endregion

        private void btnView_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(movie.MoviePath);
        }

        private void optionenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options opt = new Options(ActiveGenre);
            if (opt.ShowDialog() == DialogResult.OK)
            {
                this.ActiveGenre = opt.ActiveGenre;
                addItems();
            }
        }
    }

}
