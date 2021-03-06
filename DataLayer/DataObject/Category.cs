using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class Category
    {
        protected int _categoryID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected string _title = String.Empty;
        protected int _importance;
        protected string _description = String.Empty;
        protected string _imageUrl = String.Empty;
        protected int _superCategoryID;
        protected int _parentCategoryID;

        public Category()
        {
        }

        public Category(int categoryID, DateTime addedDate, string addedBy, string title, int importance, string description, string imageUrl, int superCategoryID, int parentCategoryID)
        {
            _categoryID = categoryID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _title = title;
            _importance = importance;
            _description = description;
            _imageUrl = imageUrl;
            _superCategoryID = superCategoryID;
            _parentCategoryID = parentCategoryID;
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

        public int SuperCategoryID
        {
            get { return _superCategoryID; }
            set { _superCategoryID = value; }
        }

        public int ParentCategoryID
        {
            get { return _parentCategoryID; }
            set { _parentCategoryID = value; }
        }
        #endregion
    }


    //[Serializable]
    //public class Category
    //{
    //    protected int _categoryID;
    //    protected DateTime _addedDate;
    //    protected string _addedBy = String.Empty;
    //    protected string _title = String.Empty;
    //    protected int _importance;
    //    protected string _description = String.Empty;
    //    protected string _imageUrl = String.Empty;
    //    protected int _superCategoryID;
		
    //    public Category()
    //    {
    //    }
		
    //    public Category(int categoryID, DateTime addedDate, string addedBy, string title, int importance, string description, string imageUrl, int superCategoryID)
    //    {
    //        _categoryID = categoryID;
    //        _addedDate = addedDate;
    //        _addedBy = addedBy;
    //        _title = title;
    //        _importance = importance;
    //        _description = description;
    //        _imageUrl = imageUrl;
    //        _superCategoryID = superCategoryID;
    //    }
		
    //    #region Public Properties
		
    //    public int CategoryID
    //    {
    //        get {return _categoryID;}
    //        set {_categoryID = value;}
    //    }

    //    public DateTime AddedDate
    //    {
    //        get {return _addedDate;}
    //        set {_addedDate = value;}
    //    }

    //    public string AddedBy
    //    {
    //        get {return _addedBy;}
    //        set {_addedBy = value;}
    //    }

    //    public string Title
    //    {
    //        get {return _title;}
    //        set {_title = value;}
    //    }

    //    public int Importance
    //    {
    //        get {return _importance;}
    //        set {_importance = value;}
    //    }

    //    public string Description
    //    {
    //        get {return _description;}
    //        set {_description = value;}
    //    }

    //    public string ImageUrl
    //    {
    //        get {return _imageUrl;}
    //        set {_imageUrl = value;}
    //    }

    //    public int SuperCategoryID
    //    {
    //        get {return _superCategoryID;}
    //        set {_superCategoryID = value;}
    //    }
    //    #endregion
    //}
}
