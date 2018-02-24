using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class Department
    {
        protected int _departmentID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;
        protected int _importance;
        protected int _superDepartmentID;
        protected int _parentID;
        protected string _imageUrl = String.Empty;

        public Department()
        {
        }

        public Department(int departmentID, string title, string description, int importance, int superDepartmentID, int parentID, string imageUrl)
        {
            _departmentID = departmentID;
            _title = title;
            _description = description;
            _importance = importance;
            _superDepartmentID = superDepartmentID;
            _parentID = parentID;
            _imageUrl = imageUrl;
        }

        #region Public Properties

        public int DepartmentID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
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

        public int SuperDepartmentID
        {
            get { return _superDepartmentID; }
            set { _superDepartmentID = value; }
        }

        public int ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }
        #endregion
    }


}
