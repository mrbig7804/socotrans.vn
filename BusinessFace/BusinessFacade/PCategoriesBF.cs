using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class PCategoriesBF
    {

        protected int _pCategoryID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;

        #region Public Properties

        public int PCategoryID
        {
            get { return _pCategoryID; }
            set { _pCategoryID = value; }
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
        #endregion

        private static List<PCategoriesBF> GetPCategoriesBFListFromPCategoriesList(List<PCategory> recordset)
        {
            List<PCategoriesBF> ret = new List<PCategoriesBF>();
            foreach (PCategory record in recordset)
                ret.Add(GetPCategoriesBFFromPCategory(record));
            return ret;
        }

        private static PCategoriesBF GetPCategoriesBFFromPCategory(PCategory record)
        {
            if (record == null)
                return null;
            else
            {
                return new PCategoriesBF(record.PCategoryID, record.Title, record.Description);
            }
        }

        public PCategoriesBF()
        {
        }


        public PCategoriesBF(int pCategoryID, string title, string description)
        {
            _pCategoryID = pCategoryID;
            _title = title;
            _description = description;
        }

        public static PCategoriesBF GetPCategoriesBF(int pCategoryID)
        {
            return GetPCategoriesBFFromPCategory(SiteProvider.PCategoriesProvider.GetPCategory(pCategoryID));
        }

        //Get by ForeignKey

        //Get All
        public static List<PCategoriesBF> GetPCategoriesAll()
        {
            return GetPCategoriesBFListFromPCategoriesList(SiteProvider.PCategoriesProvider.GetPCategoriesAll());
        }

        //Insert
        public int Insert()
        {
            return PCategoriesBF.Insert(this.PCategoryID, this.Title, this.Description);
        }

        //Update
        public bool Update()
        {
            return PCategoriesBF.Update(this.PCategoryID, this.Title, this.Description);
        }

        //Delete
        public bool Delete()
        {
            return PCategoriesBF.Delete(
            this.PCategoryID);
        }

        //Insert
        public static int Insert(int pCategoryID, string title, string description)
        {
            return SiteProvider.PCategoriesProvider.Insert(new PCategory(pCategoryID, title, description));
        }

        //Update
        public static bool Update(int pCategoryID, string title, string description)
        {
            return SiteProvider.PCategoriesProvider.Update(new PCategory(pCategoryID, title, description));
        }

        //Delete
        public static bool Delete(int pCategoryID)
        {
            return SiteProvider.PCategoriesProvider.Delete(pCategoryID);
        }

    }

}
