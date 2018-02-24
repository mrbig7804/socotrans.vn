using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class VCategory
    {
        protected int _categoryID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected string _title = String.Empty;
        protected string _description = String.Empty;
        protected string _imageUrl = String.Empty;
        protected int _important;
        protected int _parentID;

        public VCategory()
        {
        }

        public VCategory(int categoryID, DateTime addedDate, string addedBy, string title, string description, string imageUrl, int important, int parentID)
        {
            _categoryID = categoryID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _title = title;
            _description = description;
            _imageUrl = imageUrl;
            _important = important;
            _parentID = parentID;
        }

        #region Public Properties

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
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

        public int Important
        {
            get { return _important; }
            set { _important = value; }
        }

        public int ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }
        #endregion
    }
}
