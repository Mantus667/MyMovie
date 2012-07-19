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
    public partial class addMovie : Form
    {
        clOFDBGW ofdbgw;
        List<ListViewItem> list;
        Movie movie;
        clXMLController controller;
        bool isEdit = false;

        /// <summary>
        /// Standart Konstruktor der Klasse
        /// Erzeugt einen neuen XMlController und ein neues Objekt des OFDB-Gateways
        /// </summary>
        public addMovie()
        {
            InitializeComponent();
            ofdbgw = new clOFDBGW();
            controller = new clXMLController();
            tabControl1.TabPages.Remove(tabPage2);
        }

        /// <summary>
        /// Überladener Konstruktor. Wird aufgerufen wenn ein Film bearbeitet werden soll
        /// Speichert das übergebene Movie, speichert den alten Titel, falls er verändert wird
        /// </summary>
        /// <param name="movie">Der zu bearbeitende Film</param>
        public addMovie(Movie movie)
        {
            InitializeComponent();
            ofdbgw = new clOFDBGW();
            controller = new clXMLController();
            this.movie = movie;
            Properties.Settings.Default.tmpTitel = movie.Titel;
            isEdit = true;
        }

        /// <summary>
        /// Falls kein Film bearbeitet wird, erstelle einen neuen.
        /// Speichere die Daten in das Movie-Objekt und speichere es in die XML-Datei
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTitel.Text) || string.IsNullOrEmpty(tbTitel.Text) || string.IsNullOrEmpty(cbGenre.SelectedItem.ToString()) || string.IsNullOrWhiteSpace(cbGenre.SelectedItem.ToString()))
            {
                errorProvider1.SetError(btnSave, "Titel oder Genre nicht angegeben");
            }
            else
            {
                if (movie == null)
                {
                    movie = new Movie();
                }
                movie.MGenres.Clear();
                movie.Screenshots.Clear();
                movie.Titel = tbTitel.Text.Trim();
                movie.OrigTitel = tbOrgtitel.Text.Trim();
                movie.Director = tbRegi.Text.Trim();
                movie.Actors = rtbActor.Text.Trim();
                movie.Plot = rtbDesc.Text.Trim();
                movie.Genre = cbGenre.SelectedItem.ToString();
                movie.Year = numYear.Value.ToString();
                movie.Rank = starRating2.Rating;
                movie.Seen = cbSeen.Checked;
                movie.Wishlist = cbWish.Checked;
                movie.LentTo = "";
                movie.Preis = numPreis.Value.ToString();
                movie.MediaCount = int.Parse(numAnzahl.Value.ToString());
                movie.MovieImage = pbImage.Image;
                movie.MoviePath = tbMoviePath.Text.Trim();
                try
                {
                    movie.MediaType = cbMedType.SelectedItem.ToString();
                }
                catch (Exception ex)
                {
                    movie.MediaType = "";
                }

                //Prüfe ob im TrailerLink auch ein Link steht
                try
                {
                    Uri uri = new Uri(tbTrailer.Text.Trim());
                    movie.Trailer = uri.ToString();
                }
                catch (Exception ex)
                {
                    movie.Trailer = "http://";
                }

                //Prüfe ob HP-Link auch ein Link ist
                try
                {
                    Uri uri = new Uri(tbHPLink.Text.Trim());
                    movie.HPLink = uri.ToString();
                }
                catch (Exception ex)
                {
                    movie.HPLink = "http://";
                }

                //Speichere alle Nebengenre
                foreach (string s in clbGenre.CheckedItems)
                {
                    movie.MGenres.Add(s);
                }
               
                //Speichere alle Screenshots
                foreach (PictureBox pb in flowLayoutPanel1.Controls)
                {
                    movie.Screenshots.Add(pb.Image);
                }
                //Wird gerade ein Film bearbeitet?
                if (!isEdit)
                {
                    //Keine Bearbeitung, prüfe auf existens und dann speichere den Film
                    if (!controller.checkApperanceMovie(movie.Titel))
                    {
                        controller.WritetoFileMovie(movie);
                    }
                }
                else
                {
                    controller.saveChanges(Properties.Settings.Default.tmpTitel, movie);
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Ruft die Methode das OFDB-Gateways auf, um nach dem Filmtitel zu suchen, der in der
        /// Textbox steht. Zeigt alle Treffer in der OFDB an, um den User einen auswählen zu lassen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTitel.Text))
            {
                errorProvider1.SetError(tbTitel, "Kein Titel angegeben");
            }
            else
            {
                int id = 0;
                list = ofdbgw.searchMoviesByTitel(tbTitel.Text);
                selectMovie select = new selectMovie(list);
                if (select.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    id = select.movieid;
                    tbOrgtitel.Text = select.orgTitel;
                }
                if (id != 0)
                {
                    movie = ofdbgw.searchMovieInfoByID(id.ToString());
                    movie.OfdbID = id.ToString();
                    movie.OrigTitel = tbOrgtitel.Text;
                    tbTitel.Text = movie.Titel;
                    tbRegi.Text = movie.Director;
                    cbGenre.SelectedItem = movie.Genre;
                    pbImage.Image = movie.MovieImage;
                    rtbActor.Text = movie.Actors;
                    rtbDesc.Text = movie.Plot;
                    numYear.Value = decimal.Parse(movie.Year);
                    foreach (string s in movie.MGenres)
                    {
                        int i = 0;
                        i = clbGenre.Items.IndexOf(s);
                        clbGenre.SetItemChecked(i, true);
                        clbGenre.SetSelected(i, true);
                    }
                }
            }
        }

        /// <summary>
        /// Beim starten der Form, überprüfe ob ein zu bearbeitender Film da ist, wenn ja
        /// dann lese die Informationen in die richtigen Felder aus.
        /// </summary>
        private void addMovie_Load(object sender, EventArgs e)
        {
            if (movie != null)
            {
                tbTitel.Text = movie.Titel;
                tbOrgtitel.Text = movie.OrigTitel;
                tbRegi.Text = movie.Director;
                pbImage.Image = movie.MovieImage;
                rtbActor.Text = movie.Actors;
                rtbDesc.Text = movie.Plot;
                numYear.Value = decimal.Parse(movie.Year);
                starRating2.Rating = movie.Rank;
                cbGenre.SelectedItem = movie.Genre;
                cbWish.Checked = movie.Wishlist;
                cbSeen.Checked = movie.Seen;
                numAnzahl.Value = movie.MediaCount;
                numPreis.Value = decimal.Parse(movie.Preis);
                tbTrailer.Text = movie.Trailer;
                tbHPLink.Text = movie.HPLink;
                tbLentTo.Text = movie.LentTo;
                tbMoviePath.Text = movie.MoviePath;
                if (movie.MediaType != "")
                {
                    cbMedType.SelectedItem = movie.MediaType;
                }
                foreach (string s in movie.MGenres)
                {
                    int i = clbGenre.Items.IndexOf(s);
                    clbGenre.SetItemChecked(i, true);
                }
                foreach (Image img in movie.Screenshots)
                {
                    addScreenShot(img);
                }
            }
        }

        /// <summary>
        /// Öffnet den FileDialog um ein Bild als Screenshot hinzuzufügen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddScreen_Click(object sender, EventArgs e)
        {
            if (FileDia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(FileDia.FileName);
                Bitmap bmp2 = new Bitmap(bmp,new Size(370,530));
                addScreenShot(bmp2);
            }
        }

        /// <summary>
        /// Erzeugt für jedes neue Bild eine PictureBox, setzt den Handler für das Click-Ereignis,
        /// setzt das übergebene Bild und fügt die PictureBox dem Panel hinzu.
        /// </summary>
        /// <param name="img">Das Bild das hinzugefügt werden soll</param>
        private void addScreenShot(Image img)
        {
            PictureBox pb = new PictureBox();
            pb.Click += new EventHandler(pb_Click);
            pb.Size = new System.Drawing.Size(150, 200);
            pb.BorderStyle = BorderStyle.FixedSingle;
            pb.Image = img;
            //pb.Name = FileDia.SafeFileName;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            flowLayoutPanel1.Controls.Add(pb);
        }

        /// <summary>
        /// Methode um ein Screenshot in "Vollbild" anzuzeigen
        /// </summary>
        private void pb_Click(object sender, EventArgs e)
        {
            pbVorschau.Image = ((PictureBox)sender).Image;
        }

        /// <summary>
        /// Setzt den Namen und das Datum wenn der Film an jmd ausgeliehen werden soll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLent_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbLentTo.Text.Trim()) || !string.IsNullOrWhiteSpace(tbLentTo.Text.Trim()))
            {
                errorProvider1.SetError(tbLentTo, "");
                movie.LentTo = tbLentTo.Text + Environment.NewLine + DateTime.Now.ToString();
            }
            else
            {
                errorProvider1.SetError(tbLentTo, "Kein Name Eingetragen");
            }
        }

        /// <summary>
        /// Löscht den Namen und das Datum für den ausgeliehenen Film
        /// </summary>
        private void btnRecieve_Click(object sender, EventArgs e)
        {
            movie.LentTo = "";
        }

        private void btnMoviePath_Click(object sender, EventArgs e)
        {
            if (FileDia2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbMoviePath.Text = FileDia2.FileName;
            }
        }

        private void cbMedType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMedType.SelectedItem.ToString() == "HDD")
            {
                tbMoviePath.Visible = true;
                label13.Visible = true;
                btnMoviePath.Visible = true;
            }
        }
    }
}
