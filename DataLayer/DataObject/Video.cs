using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class Video
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

        public Video()
        {
        }

        public Video(int videoID, int categoriesID, DateTime addedDate, string addedBy, string title, string description, string imageUrl, string videoUrl, int important, int viewCount, bool published)
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
    }
}
