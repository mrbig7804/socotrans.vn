using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    [Serializable]

    public class SuperCategoriesBF: BaseBF
    {

        protected int _superCategoryID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected string _title = String.Empty;
        protected int _importance;
        protected string _description = String.Empty;
        protected string _imageUrl = String.Empty;

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

        #region Custom Method

        //Insert với các giá trị mặc định
        public static int Insert(string title, int importance, string description, string imageUrl)
        {
            return SiteProvider.SuperCategoriesProvider.Insert(
                new SuperCategory(-1, 
                    DateTime.Now, // AddedDate
                    CurrentUserName, // AddedBy
                    title, importance, description, imageUrl));
        }

        //Update với các giá trị mặc định
        public static bool Update(int superCategoryID, string title, int importance, string description, string imageUrl)
        {
            SuperCategory sc = SiteProvider.SuperCategoriesProvider.GetSuperCategory(superCategoryID);
            sc.Description = description;
            sc.ImageUrl = imageUrl;
            sc.Title = title;
            sc.Importance = importance;

            return SiteProvider.SuperCategoriesProvider.Update(sc);
        }       
        #endregion

        private static List<SuperCategoriesBF> GetSuperCategoriesBFListFromSuperCategoriesList(List<SuperCategory> recordset)
        {
            List<SuperCategoriesBF> ret = new List<SuperCategoriesBF>();
            foreach (SuperCategory record in recordset)
                ret.Add(GetSuperCategoriesBFFromSuperCategory(record));
            return ret;
        }

        private static SuperCategoriesBF GetSuperCategoriesBFFromSuperCategory(SuperCategory record)
        {
            if (record == null)
                return null;
            else
            {
                return new SuperCategoriesBF(record.SuperCategoryID, record.AddedDate, record.AddedBy, record.Title, record.Importance, record.Description, record.ImageUrl);
            }
        }

        public SuperCategoriesBF()
        {
        }


        public SuperCategoriesBF(int superCategoryID, DateTime addedDate, string addedBy, string title, int importance, string description, string imageUrl)
        {
            _superCategoryID = superCategoryID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _title = title;
            _importance = importance;
            _description = description;
            _imageUrl = imageUrl;
        }

        public static SuperCategoriesBF GetSuperCategoriesBF(int superCategoryID)
        {
            return GetSuperCategoriesBFFromSuperCategory(SiteProvider.SuperCategoriesProvider.GetSuperCategory(superCategoryID));
        }

        //Get by ForeignKey

        //Get All
        public static List<SuperCategoriesBF> GetSuperCategoriesAll()
        {
            return GetSuperCategoriesBFListFromSuperCategoriesList(SiteProvider.SuperCategoriesProvider.GetSuperCategoriesAll());
        }

        //Insert
        public int Insert()
        {
            return SuperCategoriesBF.Insert(this.SuperCategoryID, this.AddedDate, this.AddedBy, this.Title, this.Importance, this.Description, this.ImageUrl);
        }

        //Update
        public bool Update()
        {
            return SuperCategoriesBF.Update(this.SuperCategoryID, this.AddedDate, this.AddedBy, this.Title, this.Importance, this.Description, this.ImageUrl);
        }

        //Delete
        public bool Delete()
        {
            return SuperCategoriesBF.Delete(this.SuperCategoryID);
        }

        //Insert
        public static int Insert(int superCategoryID, DateTime addedDate, string addedBy, string title, int importance, string description, string imageUrl)
        {
            return SiteProvider.SuperCategoriesProvider.Insert(new SuperCategory(superCategoryID, addedDate, addedBy, title, importance, description, imageUrl));
        }

        //Update
        public static bool Update(int superCategoryID, DateTime addedDate, string addedBy, string title, int importance, string description, string imageUrl)
        {
            return SiteProvider.SuperCategoriesProvider.Update(new SuperCategory(superCategoryID, addedDate, addedBy, title, importance, description, imageUrl));
        }

        //Delete
        public static bool Delete(int superCategoryID)
        {
            return SiteProvider.SuperCategoriesProvider.Delete(superCategoryID);
        }

    }
}
