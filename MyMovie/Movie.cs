using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyMovie
{
    public class Movie
    {
        private string mOrgTitel;
        private string mTitel;
        private string mYear;
        private string mDirector;
        private string mPlot;
        private Image mMovieImage;
        private string mAddDate;
        private int mRank;
        private string mGenre;
        private string mActors;
        private long mImdbId;
        private string mOfdbID;
        private bool mSeen;
        private bool mWishlist;
        private string mLentTo;
        private string mTrailer;
        private string mHPLink;
        private string mPreis;
        private int mMediaCount;
        private string mMediaType;
        private string mMoviePath;
        private List<Image> mScreenshots;
        private List<String> mGenres;

        public Movie()
        {
            mGenres = new List<string>();
            mScreenshots = new List<Image>();
        }

        public string MoviePath
        {
            get { return mMoviePath; }
            set { mMoviePath = value; }
        }

        public string HPLink
        {
            get { return mHPLink; }
            set { mHPLink = value; }
        }

        public List<Image> Screenshots
        {
            get { return mScreenshots; }
            set { mScreenshots = value; }
        }

        public string Trailer
        {
            get { return mTrailer; }
            set { mTrailer = value; }
        }

        public string Preis
        {
            get { return mPreis; }
            set { mPreis = value; }
        }

        public int MediaCount
        {
            get { return mMediaCount; }
            set { mMediaCount = value; }
        }

        public string MediaType
        {
            get { return mMediaType; }
            set { mMediaType = value; }
        }

        public string LentTo
        {
            get { return mLentTo; }
            set { mLentTo = value; }
        }

        public bool Seen
        {
            get { return mSeen; }
            set { mSeen = value; }
        }

        public bool Wishlist
        {
            get { return mWishlist; }
            set { mWishlist = value; }
        }

        public List<String> MGenres
        {
            get { return mGenres; }
            set { mGenres = value; }
        }

        public long ImdbID
        {
            get { return mImdbId; }
            set { mImdbId = value; }
        }

        public string OfdbID
        {
            get { return mOfdbID; }
            set { mOfdbID = value; }
        }

        public string OrigTitel
        {
            get { return mOrgTitel; }
            set { mOrgTitel = value; }
        }

        public string Titel
        {
            get { return mTitel; }
            set { mTitel = value; }
        }

        public string Year
        {
            get { return mYear; }
            set { mYear = value; }
        }

        public string Director
        {
            get { return mDirector; }
            set { mDirector = value; }
        }

        public string Plot
        {
            get { return mPlot; }
            set { mPlot = value; }
        }

        public Image MovieImage
        {
            get { return mMovieImage; }
            set { mMovieImage = value; }
        }

        public string AddDate
        {
            get { return mAddDate; }
            set { mAddDate = value; }
        }

        public int Rank
        {
            get { return mRank; }
            set { mRank = value; }
        }

        public string Genre
        {
            get { return mGenre; }
            set { mGenre = value; }
        }

        public string Actors
        {
            get { return mActors; }
            set { mActors = value; }
        }
    }
}
