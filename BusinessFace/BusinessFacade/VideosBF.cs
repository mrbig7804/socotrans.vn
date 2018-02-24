using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public class VideosBF
    {
        protected int _videoID;
        protected int _categoriesID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected string _title = String.Empty;
        protected string _description = String.Empty;
        protected string _imageUrl = String.Empty;
        protected string _videoUrl = String.Empty;
        protected int _important;
        protected int _viewCount;
        protected bool _published;

        #region Public Properties

        public int VideoID
        {
            get { return _videoID; }
            set { _videoID = value; }
        }

        public int CategoriesID
        {
            get { return _categoriesID; }
            set { _categoriesID = value; }
        }

        public DateTime AddedDate
        {
            get { return _addedDate; }
            set { _addedDate = value; }
        }

        public string AddedBy
        {
            get { return _addedBy; }
            set { _addedBy = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        public string VideoUrl
        {
            get { return _videoUrl; }
            set { _videoUrl = value; }
        }

        public int Important
        {
            get { return _important; }
            set { _important = value; }
        }

        public int ViewCount
        {
            get { return _viewCount; }
            set { _viewCount = value; }
        }

        public bool Published
        {
            get { return _published; }
            set { _published = value; }
        }
        #endregion

        private static List<VideosBF> GetVideosBFListFromVideosList(List<Video> recordset)
        {
            List<VideosBF> ret = new List<VideosBF>();
            foreach (Video record in recordset)
                ret.Add(GetVideosBFFromVideo(record));
            return ret;
        }

        private static VideosBF GetVideosBFFromVideo(Video record)
        {
            if (record == null)
                return null;
            else
            {
                return new VideosBF(record.VideoID, record.CategoriesID, record.AddedDate, record.AddedBy, record.Title, record.Description, record.ImageUrl, record.VideoUrl, record.Important, record.ViewCount, record.Published);
            }
        }

        public VideosBF()
        {
        }


        public VideosBF(int videoID, int categoriesID, DateTime addedDate, string addedBy, string title, string description, string imageUrl, string videoUrl, int important, int viewCount, bool published)
        {
            _videoID = videoID;
            _categoriesID = categoriesID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _title = title;
            _description = description;
            _imageUrl = imageUrl;
            _videoUrl = videoUrl;
            _important = important;
            _viewCount = viewCount;
            _published = published;
        }

        public static VideosBF GetVideosBF(int videoID)
        {
            return GetVideosBFFromVideo(SiteProvider.VideosProvider.GetVideo(videoID));
        }

        public static List<VideosBF> GetVideosByCategoryID(int catID)
        {
            return GetVideosBFListFromVideosList(SiteProvider.VideosProvider.GetVideosByCategoryID(catID));
        }

        public static List<VideosBF> GetVideosConnexion(int catID, int videoID)
        {
            return GetVideosBFListFromVideosList(SiteProvider.VideosProvider.GetVideosConnexion(catID, videoID));
        }

        //Get All
        public static List<VideosBF> GetVideosAll()
        {
            return GetVideosBFListFromVideosList(SiteProvider.VideosProvider.GetVideosAll());
        }

        //Insert
        public int Insert()
        {
            return VideosBF.Insert(this.VideoID, this.CategoriesID, this.AddedDate, this.AddedBy, this.Title, this.Description, this.ImageUrl, this.VideoUrl, this.Important, this.ViewCount, this.Published);
        }

        //Update
        public bool Update()
        {
            return VideosBF.Update(this.VideoID, this.CategoriesID, this.AddedDate, this.AddedBy, this.Title, this.Description, this.ImageUrl, this.VideoUrl, this.Important, this.ViewCount, this.Published);
        }

        //Delete
        public bool Delete()
        {
            return VideosBF.Delete(
            this.VideoID);
        }

        //Insert
        public static int Insert(int videoID, int categoriesID, DateTime addedDate, string addedBy, string title, string description, string imageUrl, string videoUrl, int important, int viewCount, bool published)
        {
            return SiteProvider.VideosProvider.Insert(new Video(videoID, categoriesID, addedDate, addedBy, title, description, imageUrl, videoUrl, important, viewCount, published));
        }

        //Update
        public static bool Update(int videoID, int categoriesID, DateTime addedDate, string addedBy, string title, string description, string imageUrl, string videoUrl, int important, int viewCount, bool published)
        {
            return SiteProvider.VideosProvider.Update(new Video(videoID, categoriesID, addedDate, addedBy, title, description, imageUrl, videoUrl, important, viewCount, published));
        }

        public static bool UpdateViewCount(int videoID)
        {
            return SiteProvider.VideosProvider.UpdateViewCount(videoID);
        }

        //Delete
        public static bool Delete(int videoID)
        {
            return SiteProvider.VideosProvider.Delete(videoID);
        }

    }
}
