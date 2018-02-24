using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public class BrandsBF
    {
        #region Public Properties
        public int BrandID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Important { get; set; }
        public string ImageUrl { get; set; }
        #endregion

        public BrandsBF()
        {
        }

        public BrandsBF(int brandID, string title, string description, int important, string imageUrl)
        {
            this.BrandID = brandID;
            this.Title = title;
            this.Description = description;
            this.Important = important;
            this.ImageUrl = imageUrl;
        }

        private static BrandsBF GetBrandsBFFromBrand(Brand record)
        {
            if (record == null)
                return null;
            else
            {
                return new BrandsBF(record.BrandID, record.Title, record.Description, record.Important, record.ImageUrl);
            }
        }

        private static List<BrandsBF> GetBrandsBFListFromBrandsList(List<Brand> recordset)
        {
            List<BrandsBF> ret = new List<BrandsBF>();
            foreach (Brand record in recordset)
                ret.Add(GetBrandsBFFromBrand(record));
            return ret;
        }

        public static BrandsBF GetBrandsBF(int brandID)
        {
            return GetBrandsBFFromBrand(SiteProvider.BrandsProvider.GetBrand(brandID));
        }

        //Get All
        public static List<BrandsBF> GetBrandsAll()
        {
            return GetBrandsBFListFromBrandsList(SiteProvider.BrandsProvider.GetBrandsAll());
        }

        public static List<BrandsBF> GetBrandsByDepartment(int departmentID)
        {
            return GetBrandsBFListFromBrandsList(SiteProvider.BrandsProvider.GetBrandsByDepartment(departmentID));
        }

        public static List<BrandsBF> GetBrandsDynamic(string condition, string orderBy)
        {
            return GetBrandsBFListFromBrandsList(SiteProvider.BrandsProvider.GetBrandsDynamic(condition, orderBy));
        }

        //Insert
        public int Insert()
        {
            return BrandsBF.Insert(this.BrandID, this.Title, this.Description, this.Important, this.ImageUrl);
        }

        //Update
        public bool Update()
        {
            return BrandsBF.Update(this.BrandID, this.Title, this.Description, this.Important, this.ImageUrl);
        }

        //Delete
        public bool Delete()
        {
            return BrandsBF.Delete(
            this.BrandID);
        }

        //Insert
        public static int Insert(int brandID, string title, string description, int important, string imageUrl)
        {
            return SiteProvider.BrandsProvider.Insert(new Brand(brandID, title, description, important, imageUrl));
        }

        //Update
        public static bool Update(int brandID, string title, string description, int important, string imageUrl)
        {
            return SiteProvider.BrandsProvider.Update(new Brand(brandID, title, description, important, imageUrl));
        }

        //Delete
        public static bool Delete(int brandID)
        {
            BrandsBF temp = BrandsBF.GetBrandsBF(brandID);

            if (File.Exists(HttpContext.Current.Server.MapPath(temp.ImageUrl)))
                File.Delete(HttpContext.Current.Server.MapPath(temp.ImageUrl));

            BrandDepartmentsBF.DeleteByBrand(brandID);

            return SiteProvider.BrandsProvider.Delete(brandID);
        }

    }
}
