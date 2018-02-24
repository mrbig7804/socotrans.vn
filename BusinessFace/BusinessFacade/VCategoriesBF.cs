using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public partial class VCategoriesBF
    {

        protected int _categoryID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected string _title = String.Empty;
        protected string _description = String.Empty;
        protected string _imageUrl = String.Empty;
        protected int _important;
        protected int _parentID;

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

        private static List<VCategoriesBF> GetVCategoriesBFListFromVCategoriesList(List<VCategory> recordset)
        {
            List<VCategoriesBF> ret = new List<VCategoriesBF>();
            foreach (VCategory record in recordset)
                ret.Add(GetVCategoriesBFFromVCategory(record));
            return ret;
        }

        private static VCategoriesBF GetVCategoriesBFFromVCategory(VCategory record)
        {
            if (record == null)
                return null;
            else
            {
                return new VCategoriesBF(record.CategoryID, record.AddedDate, record.AddedBy, record.Title, record.Description, record.ImageUrl, record.Important, record.ParentID);
            }
        }

        public VCategoriesBF()
        {
        }


        public VCategoriesBF(int categoryID, DateTime addedDate, string addedBy, string title, string description, string imageUrl, int important, int parentID)
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

        public static VCategoriesBF GetVCategoriesBF(int categoryID)
        {
            return GetVCategoriesBFFromVCategory(SiteProvider.VCategoriesProvider.GetVCategory(categoryID));
        }

        //Get All
        public static List<VCategoriesBF> GetVCategoriesAll()
        {
            return GetVCategoriesBFListFromVCategoriesList(SiteProvider.VCategoriesProvider.GetVCategoriesAll());
        }

        //Get By ParentID
        public static List<VCategoriesBF> GetVCategoriesByParentID(int parentID)
        {
            return GetVCategoriesBFListFromVCategoriesList(SiteProvider.VCategoriesProvider.GetVCategoriesByParentID(parentID));
        }

        //Insert
        public int Insert()
        {
            return VCategoriesBF.Insert(this.CategoryID, this.AddedDate, this.AddedBy, this.Title, this.Description, this.ImageUrl, this.Important, this.ParentID);
        }

        //Update
        public bool Update()
        {
            return VCategoriesBF.Update(this.CategoryID, this.AddedDate, this.AddedBy, this.Title, this.Description, this.ImageUrl, this.Important, this.ParentID);
        }

        //Delete
        public bool Delete()
        {
            return VCategoriesBF.Delete(this.CategoryID);
        }

        //Insert
        public static int Insert(int categoryID, DateTime addedDate, string addedBy, string title, string description, string imageUrl, int important, int parentID)
        {
            return SiteProvider.VCategoriesProvider.Insert(new VCategory(categoryID, addedDate, addedBy, title, description, imageUrl, important, parentID));
        }

        //Update
        public static bool Update(int categoryID, DateTime addedDate, string addedBy, string title, string description, string imageUrl, int important, int parentID)
        {
            return SiteProvider.VCategoriesProvider.Update(new VCategory(categoryID, addedDate, addedBy, title, description, imageUrl, important, parentID));
        }

        //Delete
        public static bool Delete(int categoryID)
        {
            VCategoriesBF vc = VCategoriesBF.GetVCategoriesBF(categoryID);

            if (File.Exists(HttpContext.Current.Server.MapPath(vc.ImageUrl)))
                File.Delete(HttpContext.Current.Server.MapPath(vc.ImageUrl));

            return SiteProvider.VCategoriesProvider.Delete(categoryID);
        }

    }
}
