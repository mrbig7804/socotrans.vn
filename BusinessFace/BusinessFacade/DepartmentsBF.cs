using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

using System.Web.Security;
using System.Security;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{


    public partial class DepartmentsBF
    {

        protected int _departmentID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;
        protected int _importance;
        protected int _superDepartmentID;
        protected int _parentID;
        protected string _imageUrl = String.Empty;

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

        private static List<DepartmentsBF> GetDepartmentsBFListFromDepartmentsList(List<Department> recordset)
        {
            List<DepartmentsBF> ret = new List<DepartmentsBF>();
            foreach (Department record in recordset)
                ret.Add(GetDepartmentsBFFromDepartment(record));
            return ret;
        }

        private static DepartmentsBF GetDepartmentsBFFromDepartment(Department record)
        {
            if (record == null)
                return null;
            else
            {
                return new DepartmentsBF(record.DepartmentID, record.Title, record.Description, record.Importance, record.SuperDepartmentID, record.ParentID, record.ImageUrl);
            }
        }

        public DepartmentsBF()
        {
        }


        public DepartmentsBF(int departmentID, string title, string description, int importance, int superDepartmentID, int parentID, string imageUrl)
        {
            _departmentID = departmentID;
            _title = title;
            _description = description;
            _importance = importance;
            _superDepartmentID = superDepartmentID;
            _parentID = parentID;
            _imageUrl = imageUrl;
        }

        public static DepartmentsBF GetDepartmentsBF(int departmentID)
        {
            return GetDepartmentsBFFromDepartment(SiteProvider.DepartmentsProvider.GetDepartment(departmentID));
        }

        //Get by ForeignKey
        public static List<DepartmentsBF> GetDepartmentsBySuperDepartmentID(int superDepartmentID)
        {
            return GetDepartmentsBFListFromDepartmentsList(SiteProvider.DepartmentsProvider.GetDepartmentsBySuperDepartmentID(superDepartmentID));
        }

        //Get All
        public static List<DepartmentsBF> GetDepartmentsAll()
        {
            return GetDepartmentsBFListFromDepartmentsList(SiteProvider.DepartmentsProvider.GetDepartmentsAll());
        }

        //Insert
        public int Insert()
        {
            return DepartmentsBF.Insert(this.DepartmentID, this.Title, this.Description, this.Importance, this.SuperDepartmentID, this.ParentID, this.ImageUrl);
        }

        //Update
        public bool Update()
        {
            return DepartmentsBF.Update(this.DepartmentID, this.Title, this.Description, this.Importance, this.SuperDepartmentID, this.ParentID, this.ImageUrl);
        }

        //Delete
        public bool Delete()
        {
            return DepartmentsBF.Delete(
            this.DepartmentID);
        }

        //Insert
        public static int Insert(int departmentID, string title, string description, int importance, int superDepartmentID, int parentID, string imageUrl)
        {
            return SiteProvider.DepartmentsProvider.Insert(new Department(departmentID, title, description, importance, superDepartmentID, parentID, imageUrl));
        }

        //Update
        public static bool Update(int departmentID, string title, string description, int importance, int superDepartmentID, int parentID, string imageUrl)
        {
            return SiteProvider.DepartmentsProvider.Update(new Department(departmentID, title, description, importance, superDepartmentID, parentID, imageUrl));
        }

        //Delete
        public static bool Delete(int departmentID)
        {
            return SiteProvider.DepartmentsProvider.Delete(departmentID);
        }

    }

}
