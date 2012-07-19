using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;

namespace MyMovie
{
    class clOFDBGW
    {
        private WebRequest request;
        private Stream resultStream;
        private String searchMovieURL = "http://ofdbgw.org/search/";
        private String searchOfdbIDUrl = "http://ofdbgw.org/movie/";
        private XmlDocument xmlDoc;
        private Movie movie;

        /// <summary>
        /// Searchs in the OFDBGW for a given movietitel
        /// </summary>
        /// <param name="titel">The Titel of the Movie to search</param>
        /// <returns>A List with ListViewItems - an Item for each Movie</returns>
        public List<ListViewItem> searchMoviesByTitel(string titel)
        {
            request = WebRequest.Create(searchMovieURL + titel);
            resultStream = request.GetResponse().GetResponseStream();

            xmlDoc = new XmlDocument();
            xmlDoc.Load(resultStream);

             return readTitelFromXML(xmlDoc);
        }

        /// <summary>
        /// Die Methode sucht in der OFDB.de Datenbank nach dem Film,
        /// mit der übergebenen ID
        /// </summary>
        /// <param name="id">Die OFDB ID des Filmes</param>
        public Movie searchMovieInfoByID(string id)
        {
            request = WebRequest.Create(searchOfdbIDUrl + id);
            resultStream = request.GetResponse().GetResponseStream();

            xmlDoc = new XmlDocument();
            xmlDoc.Load(resultStream);

             return readInfosFromXML(xmlDoc);
        }

        private List<ListViewItem> readTitelFromXML(XmlDocument xmlDoc)
        {
            List<ListViewItem> list = new List<ListViewItem>();

            if (xmlDoc.DocumentElement["status"].ChildNodes.Item(0).InnerText == "0")
            {
                foreach (XmlElement xele in xmlDoc.DocumentElement["resultat"].ChildNodes)
                {
                    //Neues ListViewItem erzeugen und Werte zuweisen
                    ListViewItem Item = new ListViewItem(xele.ChildNodes.Item(1).InnerText);
                    Item.SubItems.Add(xele.ChildNodes.Item(0).InnerText);
                    Item.SubItems.Add(xele.ChildNodes.Item(2).InnerText);
                    list.Add(Item);
                }
            }
            return list;
        }

        /// <summary>
        /// Die Methode liest die übergeben XML-Datei aus
        /// und bildet mit den darin vorhandenen Informationen,
        /// ein Movie-Objekt und gibt dieses zurück
        /// </summary>
        /// <param name="xmlDoc">Die XML-Datei mit den Informationen zum Film</param>
        private Movie readInfosFromXML(XmlDocument xmlDoc)
        {
            movie = new Movie();
           
            //Titel zuweisen
            movie.Titel = xmlDoc.DocumentElement["resultat"].ChildNodes.Item(0).InnerText;
            //Jahr zuweisen
            movie.Year = xmlDoc.DocumentElement["resultat"].ChildNodes.Item(1).InnerText;
            //Bild downloaden und speichern
            movie.MovieImage = Image.FromStream(new System.IO.MemoryStream(new System.Net.WebClient().DownloadData(xmlDoc.DocumentElement["resultat"].ChildNodes.Item(2).InnerText)));
            if (xmlDoc.DocumentElement["resultat"].ChildNodes.Item(3).InnerText != "")
                movie.ImdbID = long.Parse(xmlDoc.DocumentElement["resultat"].ChildNodes.Item(3).InnerText);
            //Überprüfen ob Director gefunden wurde und zuweisen
            if (!(xmlDoc.DocumentElement["resultat"].ChildNodes.Item(5).ChildNodes.Count == 0))
            {
                movie.Director = xmlDoc.DocumentElement["resultat"].ChildNodes.Item(5).ChildNodes.Item(0).ChildNodes[1].InnerText;
            }
            //Genre zuweisen
            movie.Genre = xmlDoc.DocumentElement["resultat"].ChildNodes.Item(11).ChildNodes.Item(0).ChildNodes[0].InnerText;
            foreach (XmlElement xele in xmlDoc.DocumentElement["resultat"].ChildNodes.Item(11).ChildNodes)
            {
                if (xele.InnerText != movie.Genre)
                    movie.MGenres.Add(xele.InnerText);
            }
            //Plot zuweisen
            movie.Plot = xmlDoc.DocumentElement["resultat"].ChildNodes.Item(13).InnerText;
            //Actor zuweisen
            int i = 0;
            string actor = "";
            foreach (XmlElement xele in xmlDoc.DocumentElement["resultat"].ChildNodes.Item(14).ChildNodes)
            {
               if (i == 0)
               {
                  i += 1;
                  actor = xele.ChildNodes[1].InnerText;
               }
               else
               {
                  actor = actor + ", " + xele.ChildNodes[1].InnerText;
               }
            }
            movie.Actors = actor;
            
            //xmlDoc.Save("D:\\movie.xml");
            return movie;
        }

    }
}
