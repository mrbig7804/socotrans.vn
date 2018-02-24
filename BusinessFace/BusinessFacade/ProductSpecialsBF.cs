using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;
namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    /// <summary>
    /// 13/12/07: sondt: thêm hàm DeleteByProductID
    /// </summary>
    public class ProductSpecialsBF
    {

        public int ProductID { get; set; }
        public int SpecialID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool Listed { get; set; }

        public ProductSpecialsBF()
        {
        }

        public ProductSpecialsBF(int productID, int specialID, DateTime releaseDate, DateTime expireDate, bool listed)
        {
            this.ProductID = productID;
            this.SpecialID = specialID;
            this.ReleaseDate = releaseDate;
            this.ExpireDate = expireDate;
            this.Listed = listed;
        }


        #region Custom methods
        public static bool DeleteByProductID(int productID)
        {
            return SiteProvider.ProductSpecialsProvider.DeleteByProductID(productID);
        }

        #endregion

        private static List<ProductSpecialsBF> GetProductSpecialsBFListFromProductSpecialsList(List<ProductSpecial> recordset)
        {
            List<ProductSpecialsBF> ret = new List<ProductSpecialsBF>();
            foreach (ProductSpecial record in recordset)
                ret.Add(GetProductSpecialsBFFromProductSpecial(record));
            return ret;
        }

        private static ProductSpecialsBF GetProductSpecialsBFFromProductSpecial(ProductSpecial record)
        {
            if (record == null)
                return null;
            else
            {
                return new ProductSpecialsBF(record.ProductID, record.SpecialID, record.ReleaseDate, record.ExpireDate, record.Listed);
            }
        }

        public static ProductSpecialsBF GetProductSpecial(int productID, int specialID)
        {
            return GetProductSpecialsBFFromProductSpecial(SiteProvider.ProductSpecialsProvider.GetProductSpecial(productID, specialID));
        }

        //Get by ForeignKey
        public static List<ProductSpecialsBF> GetProductSpecialsByProductID(int productID)
        {
            return GetProductSpecialsBFListFromProductSpecialsList(SiteProvider.ProductSpecialsProvider.GetProductSpecialsByProductID(productID));
        }

        public static List<ProductSpecialsBF> GetProductSpecialsBySpecialID(int specialID)
        {
            return GetProductSpecialsBFListFromProductSpecialsList(SiteProvider.ProductSpecialsProvider.GetProductSpecialsBySpecialID(specialID));
        }

        public static List<ProductSpecialsBF> GetProductSpecialsFilter(int specialID, DateTime fromDate, DateTime toDate, int status)
        {
            return GetProductSpecialsBFListFromProductSpecialsList(SiteProvider.ProductSpecialsProvider.GetProductSpecialsFilter(specialID, fromDate, toDate, status));
        }

        //Get All
        public static List<ProductSpecialsBF> GetProductSpecialsAll()
        {
            return GetProductSpecialsBFListFromProductSpecialsList(SiteProvider.ProductSpecialsProvider.GetProductSpecialsAll());
        }

        //Insert
        public int Insert()
        {
            return ProductSpecialsBF.Insert(this.ProductID, this.SpecialID, this.ReleaseDate, this.ExpireDate, this.Listed);
        }

        //Update
        public bool Update()
        {
            return ProductSpecialsBF.Update(this.ProductID, this.SpecialID, this.ReleaseDate, this.ExpireDate, this.Listed);
        }

        //Delete
        public bool Delete()
        {
            return ProductSpecialsBF.Delete(
            this.ProductID, this.SpecialID);
        }

        //Insert
        public static int Insert(int productID, int specialID, DateTime releaseDate, DateTime expireDate, bool listed)
        {
            return SiteProvider.ProductSpecialsProvider.Insert(new ProductSpecial(productID, specialID, releaseDate, expireDate, listed));
        }

        //Update
        public static bool Update(int productID, int specialID, DateTime releaseDate, DateTime expireDate, bool listed)
        {
            return SiteProvider.ProductSpecialsProvider.Update(new ProductSpecial(productID, specialID, releaseDate, expireDate, listed));
        }

        //Delete
        public static bool Delete(int productID, int specialID)
        {
            return SiteProvider.ProductSpecialsProvider.Delete(productID, specialID);
        }

    }
}
