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

    public class SuperDepartmentsBF
    {

        protected int _superDepartmentID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;
        protected int _importance;
        protected string _imageUrl = String.Empty;

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

        private static List<SuperDepartmentsBF> GetSuperDepartmentsBFListFromSuperDepartmentsList(List<SuperDepartment> recordset)
        {
            List<SuperDepartmentsBF> ret = new List<SuperDepartmentsBF>();
            foreach (SuperDepartment record in recordset)
                ret.Add(GetSuperDepartmentsBFFromSuperDepartment(record));
            return ret;
        }

        private static SuperDepartmentsBF GetSuperDepartmentsBFFromSuperDepartment(SuperDepartment record)
        {
            if (record == null)
                return null;
            else
            {
                return new SuperDepartmentsBF(record.SuperDepartmentID, record.Title, record.Description, record.Importance, record.ImageUrl);
            }
        }

        public SuperDepartmentsBF()
        {
        }


        public SuperDepartmentsBF(int superDepartmentID, string title, string description, int importance, string imageUrl)
        {
            _superDepartmentID = superDepartmentID;
            _title = title;
            _description = description;
            _importance = importance;
            _imageUrl = imageUrl;
        }

        public static SuperDepartmentsBF GetSuperDepartmentsBF(int superDepartmentID)
        {
            return GetSuperDepartmentsBFFromSuperDepartment(SiteProvider.SuperDepartmentsProvider.GetSuperDepartment(superDepartmentID));
        }

        //Get by ForeignKey

        //Get All
        public static List<SuperDepartmentsBF> GetSuperDepartmentsAll()
        {
            return GetSuperDepartmentsBFListFromSuperDepartmentsList(SiteProvider.SuperDepartmentsProvider.GetSuperDepartmentsAll());
        }

        //Insert
        public int Insert()
        {
            return SuperDepartmentsBF.Insert(this.SuperDepartmentID, this.Title, this.Description, this.Importance, this.ImageUrl);
        }

        //Update
        public bool Update()
        {
            return SuperDepartmentsBF.Update(this.SuperDepartmentID, this.Title, this.Description, this.Importance, this.ImageUrl);
        }

        //Delete
        public bool Delete()
        {
            return SuperDepartmentsBF.Delete(this.SuperDepartmentID);
        }

        //Insert
        public static int Insert(int superDepartmentID, string title, string description, int importance, string imageUrl)
        {
            return SiteProvider.SuperDepartmentsProvider.Insert(new SuperDepartment(superDepartmentID, title, description, importance, imageUrl));
        }

        //Update
        public static bool Update(int superDepartmentID, string title, string description, int importance, string imageUrl)
        {
            return SiteProvider.SuperDepartmentsProvider.Update(new SuperDepartment(superDepartmentID, title, description, importance, imageUrl));
        }

        //Delete
        public static bool Delete(int superDepartmentID)
        {
            return SiteProvider.SuperDepartmentsProvider.Delete(superDepartmentID);
        }

    }

}
