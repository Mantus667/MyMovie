using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace MyMovie
{
    class clXMLController
    {
        private string strPath = Application.StartupPath;
        private XDocument xDoc;
        private Movie movie;

        /// <summary>
        /// Durchsucht die XML-Datei und gibt alle gefundenen Einträge zurück
        /// </summary>
        /// <param name="Genre">Das Genre der Filme die angezeigt werden sollen</param>
        /// <remarks></remarks>
        public List<ListViewItem> fillTree()
        {
            //strPath = GetDataDirectory();
            List<ListViewItem> list = new List<ListViewItem>();
            
            //Überprüfen ob die Datei existiert
            if (!System.IO.File.Exists(strPath + "\\Movies.xml")) {
                return null;
            }
            
            xDoc = XDocument.Load(strPath + "\\Movies.xml");
            
            var getMovies = from Movie in xDoc.Descendants("Movie") select Movie;
            try
            {
                foreach (XElement xEle in getMovies)
                {
                    ListViewItem item = new ListViewItem(xEle.Element("Titel").Value);
                    item.SubItems.Add(xEle.Element("Genre").Value);
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        /// <summary>
        /// Die Funktion überprüft ob schon ein Eintrag vorhanden ist
        /// </summary>
        /// <param name="strTitel">Der Titel des Films</param>
        /// <returns>Gibt zurück ob der Eintrag gefunden wurde</returns>
        public bool checkApperanceMovie(string strTitel)
        {
            //strPath = GetDataDirectory();
            
            //Existiert die XML-Datei zum speichern der Filme schon?
            if (!File.Exists(strPath + "\\Movies.xml")) {
                //Sie existiert nicht - Film also auch nicht vorhanden
                return false;
            }
            
            //XML-Datei laden
            xDoc = XDocument.Load(strPath + "\\Movies.xml");
            
            var foundMovie = from Movies in xDoc.Descendants("Movie") where Movies.Element("Titel").Value.ToString() == strTitel select Movies;
            
            //Wurde der Film gefunden?
            if (foundMovie.Count() == 0) {
                //Wurde nicht gefunden
                return false;
            }
            else {
                //Wurde gefunden
                return true;
            }
        }

        /// <summary>
        /// Die Methode sucht in der XML-Datei nach dem gesuchten Film und speichert die gefundenen Daten in
        /// ein Movie-Objekt. Dieses wird dann per Event zurück gegeben
        /// </summary>
        /// <param name="titel">Der Titel des zu suchenden Filmes</param>
        public Movie getMovie(string titel)
        {
            //strPath = GetDataDirectory();
            
            xDoc = XDocument.Load(strPath + "\\Movies.xml");
            
            var FoundMovie = from Movies in xDoc.Descendants("Movie") where Movies.Element("Titel").Value.ToString() == titel select Movies.Elements();
            
            movie = new Movie();
            movie.Titel = titel;
            
            try 
            {
                movie.ImdbID = long.Parse(FoundMovie.ElementAt(0).ElementAt(0).Value);
                movie.OfdbID = FoundMovie.ElementAt(0).ElementAt(1).Value;
                movie.Genre = FoundMovie.ElementAt(0).ElementAt(2).Value;
                movie.OrigTitel = FoundMovie.ElementAt(0).ElementAt(4).Value;
                movie.Plot = FoundMovie.ElementAt(0).ElementAt(6).Value;
                movie.Rank = int.Parse(FoundMovie.ElementAt(0).ElementAt(7).Value);
                movie.AddDate = FoundMovie.ElementAt(0).ElementAt(8).Value;
                movie.Year = FoundMovie.ElementAt(0).ElementAt(9).Value;
                movie.Director = FoundMovie.ElementAt(0).ElementAt(10).Value;
                movie.Actors = FoundMovie.ElementAt(0).ElementAt(11).Value;
                movie.MovieImage = GetImageFromString(FoundMovie.ElementAt(0).ElementAt(12).Value);
                movie.Seen = bool.Parse(FoundMovie.ElementAt(0).ElementAt(13).Value);
                movie.Wishlist = bool.Parse(FoundMovie.ElementAt(0).ElementAt(14).Value);
                movie.LentTo = FoundMovie.ElementAt(0).ElementAt(15).Value;
                movie.MediaType = FoundMovie.ElementAt(0).ElementAt(16).Value;
                movie.MediaCount = int.Parse(FoundMovie.ElementAt(0).ElementAt(17).Value);
                movie.Preis = FoundMovie.ElementAt(0).ElementAt(18).Value;
                movie.Trailer = FoundMovie.ElementAt(0).ElementAt(19).Value;
                movie.HPLink = FoundMovie.ElementAt(0).ElementAt(20).Value;
                movie.MoviePath = FoundMovie.ElementAt(0).ElementAt(22).Value;
                foreach (XElement ele in FoundMovie.ElementAt(0).ElementAt(21).Elements())
                {
                    movie.Screenshots.Add(GetImageFromString(ele.Value));
                }   
                foreach (XElement xele in FoundMovie.ElementAt(0).ElementAt(3).Elements())
                {
                    movie.MGenres.Add(xele.Value.ToString());
                }
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return movie;
        }

        public void saveChanges(string titel, Movie saveMovie)
        {
            try 
            {
                //strPath = GetDataDirectory();
                
                xDoc = XDocument.Load(strPath + "\\Movies.xml");
                
                //Den zu löschenden Film suchen
                var deletedMovie = from Movies in xDoc.Descendants("Movie") where Movies.Element("Titel").Value.ToString() == titel select Movies;
                //Film löschen
                deletedMovie.Remove();
                
                xDoc.Save(strPath + "\\Movies.xml");
                
                    
                WritetoFileMovie(saveMovie);
            }
            catch (Exception ex) {
                MessageBox.Show("Es ist ein Fehler aufgetreten" + Environment.NewLine + ex.Message);
            }
        }

        public void deleteMovie(string titel)
        {
            xDoc = XDocument.Load(strPath + "\\Movies.xml");

            //Den zu löschenden Film suchen
            var deletedMovie = from Movies in xDoc.Descendants("Movie") where Movies.Element("Titel").Value.ToString() == titel select Movies;
            //Film löschen
            deletedMovie.Remove();

            xDoc.Save(strPath + "\\Movies.xml");
        }

        /// <summary>
        /// Die Funktion speichert die Daten in der XML-Datei.
        /// Dafür erstellt es für jeden Parameter ein Element und speichert darin die Daten.
        /// </summary>
        /// <param name="saveMovie">Der zu speichernde Film als Movie-Objekt</param>
        public void WritetoFileMovie(Movie saveMovie)
        {
            //strPath = GetDataDirectory();

            //Existiert die XML-Datei zum speichern der Filme schon?
            if (!File.Exists(strPath + "\\Movies.xml"))
            {
                xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Movies"));
                xDoc.Save(strPath + "\\Movies.xml");
            }

            xDoc = XDocument.Load(strPath + "\\Movies.xml");

            //Create an XElement with all Subgenre
            XElement xele = new XElement("Subgenre");
            foreach(string s in saveMovie.MGenres)
            {
                xele.Add(new XElement("Titel",s));
            }

            //Create Element with all Screenshots
            XElement screens = new XElement("Screenshots");
            foreach (Image img in saveMovie.Screenshots)
            {
                screens.Add(new XElement("img", GetStringFromImage(img)));
            }

            XElement xElement = new XElement("Movie", new XElement("ImdbID", saveMovie.ImdbID), new XElement("OfdbID", saveMovie.OfdbID), new XElement("Genre", saveMovie.Genre),xele, new XElement("OriginalTitel", saveMovie.OrigTitel), new XElement("Titel", saveMovie.Titel), new XElement("Beschreibung", saveMovie.Plot), new XElement("Rank", saveMovie.Rank), new XElement("AddDate", System.DateTime.Today.ToShortDateString()), new XElement("Jahr", saveMovie.Year),
            new XElement("Director", saveMovie.Director), new XElement("Actors", saveMovie.Actors), new XElement("Image", GetStringFromImage(saveMovie.MovieImage)), new XElement("Seen", saveMovie.Seen.ToString()), new XElement("Wishlist", saveMovie.Wishlist.ToString()),new XElement("LentTo",saveMovie.LentTo),new XElement("MediaType",saveMovie.MediaType),
            new XElement("MediaCount",saveMovie.MediaCount),new XElement("Preis",saveMovie.Preis),new XElement("Trailer",saveMovie.Trailer), new XElement("HPLink",saveMovie.HPLink),screens, new XElement("MoviePath",saveMovie.MoviePath));
            
            xDoc.Element("Movies").Add(xElement);

            xDoc.Save(strPath + "\\Movies.xml");
        }

        ///<summary>
        /// Konvertiert ein Bild in einen Base64-String
        ///</summary>
        ///<param name="image">
        ///Zu konvertierendes Bild
        ///</param>
        ///<returns>
        ///Base64 Repräsentation des Bildes
        ///</returns>
        private string GetStringFromImage(Image image)
        {
            if (image != null)
            {
                ImageConverter ic = new ImageConverter();
                byte[] buffer = (byte[])ic.ConvertTo(image, typeof(byte[]));
                return Convert.ToBase64String(buffer, Base64FormattingOptions.InsertLineBreaks);
            }
            else
            {
                return null;
            }
        }

        ///<summary>
        ///Konvertiert einen Base64-String zu einem Bild
        ///</summary>
        ///<param name="base64String">
        ///Zu konvertierender String
        ///</param>
        ///<returns>
        ///Bild das aus dem String erzeugt wird
        ///</returns>
        private Image GetImageFromString(string base64String)
        {
            byte[] buffer = Convert.FromBase64String(base64String);

            if (buffer != null)
            {
                ImageConverter ic = new ImageConverter();
                return ic.ConvertFrom(buffer) as Image;
            }
            else
            {
                return null;
            }
        }
    }
}
