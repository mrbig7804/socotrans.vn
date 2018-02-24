using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class SuperCategory
    {
        protected int _superCategoryID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected string _title = String.Empty;
        protected int _importance;
        protected string _description = String.Empty;
        protected string _imageUrl = String.Empty;

        public SuperCategory()
        {
        }

        public SuperCategory(int superCategoryID, DateTime addedDate, string addedBy, string title, int importance, string description, string imageUrl)
        {
            _superCategoryID = superCategoryID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _title = title;
            _importance = importance;
            _description = description;
            _imageUrl = imageUrl;
        }

        #region Public Properties

        public int SuperCategoryID
        {
            get { return _superCategoryID; }
            set { _superCategoryID = value; }
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

        public int Importance
        {
            get { return _importance; }
            set { _importance = value; }
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
        #endregion
    }


    //[Serializable]
    //public class SuperCategory
    //{
    //    protected int _superCategoryID;
    //    protected DateTime _addedDate;
    //    protected string _addedBy = String.Empty;
    //    protected string _title = String.Empty;
    //    protected int _importance;
    //    protected string _description = String.Empty;
    //    protected string _imageUrl = String.Empty;

    //    public SuperCategory()
    //    {
    //    }

    //    public SuperCategory(DataRow dr)
    //    {
    //        if (!dr.IsNull("SuperCategoryID")) _superCategoryID = Convert.ToInt32(dr["SuperCategoryID"]);
    //        if (!dr.IsNull("AddedDate")) _addedDate = Convert.ToDateTime(dr["AddedDate"]);
    //        if (!dr.IsNull("AddedBy")) _addedBy = Convert.ToString(dr["AddedBy"]);
    //        if (!dr.IsNull("Title")) _title = Convert.ToString(dr["Title"]);
    //        if (!dr.IsNull("Importance")) _importance = Convert.ToInt32(dr["Importance"]);
    //        if (!dr.IsNull("Description")) _description = Convert.ToString(dr["Description"]);
    //        if (!dr.IsNull("ImageUrl")) _imageUrl = Convert.ToString(dr["ImageUrl"]);
    //    }

    //    #region Public Properties

    //    public int SuperCategoryID
    //    {
    //        get { return _superCategoryID; }
    //        set { _superCategoryID = value; }
    //    }

    //    public DateTime AddedDate
    //    {
    //        get { return _addedDate; }
    //        set { _addedDate = value; }
    //    }

    //    public string AddedBy
    //    {
    //        get { return _addedBy; }
    //        set { _addedBy = value; }
    //    }

    //    public string Title
    //    {
    //        get { return _title; }
    //        set { _title = value; }
    //    }

    //    public int Importance
    //    {
    //        get { return _importance; }
    //        set { _importance = value; }
    //    }

    //    public string Description
    //    {
    //        get { return _description; }
    //        set { _description = value; }
    //    }

    //    public string ImageUrl
    //    {
    //        get { return _imageUrl; }
    //        set { _imageUrl = value; }
    //    }
    //    #endregion
    //}


}
