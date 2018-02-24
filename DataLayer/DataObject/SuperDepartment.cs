using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class SuperDepartment
    {
        protected int _superDepartmentID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;
        protected int _importance;
        protected string _imageUrl = String.Empty;

        public SuperDepartment()
        {
        }

        public SuperDepartment(int superDepartmentID, string title, string description, int importance, string imageUrl)
        {
            _superDepartmentID = superDepartmentID;
            _title = title;
            _description = description;
            _importance = importance;
            _imageUrl = imageUrl;
        }

        #region Public Properties

        public int SuperDepartmentID
        {
            get { return _superDepartmentID; }
            set { _superDepartmentID = value; }
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

        public int Importance
        {
            get { return _importance; }
            set { _importance = value; }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }
        #endregion
    }


}
