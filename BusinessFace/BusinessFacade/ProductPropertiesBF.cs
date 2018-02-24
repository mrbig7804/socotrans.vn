using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class ProductPropertiesBF
    {
        #region Public Properties
        public int ProductID { get; set; }
        public int PropertyValueID { get; set; }
        #endregion

        public ProductPropertiesBF()
        {
        }

        public ProductPropertiesBF(int productID, int propertyValueID)
        {
            this.ProductID = productID;
            this.PropertyValueID = propertyValueID;
        }

        private static ProductPropertiesBF GetProductPropertiesBFFromProductProperty(ProductProperty record)
        {
            if (record == null)
                return null;
            else
            {
                return new ProductPropertiesBF(record.ProductID, record.PropertyValueID);
            }
        }

        private static List<ProductPropertiesBF> GetProductPropertiesBFListFromProductPropertiesList(List<ProductProperty> recordset)
        {
            List<ProductPropertiesBF> ret = new List<ProductPropertiesBF>();
            foreach (ProductProperty record in recordset)
                ret.Add(GetProductPropertiesBFFromProductProperty(record));
            return ret;
        }

        public static ProductPropertiesBF GetProductProperty(int productID, int propertyValueID)
        {
            return GetProductPropertiesBFFromProductProperty(SiteProvider.ProductPropertiesProvider.GetProductProperty(productID, propertyValueID));
        }

        public static List<ProductPropertiesBF> GetProductPropertyByProduct(int productID)
        {
            return GetProductPropertiesBFListFromProductPropertiesList(SiteProvider.ProductPropertiesProvider.GetProductPropertyByProduct(productID));
        }

        public static List<ProductPropertiesBF> GetProductPropertyByPropertyValue(int propertyValueID)
        {
            return GetProductPropertiesBFListFromProductPropertiesList(SiteProvider.ProductPropertiesProvider.GetProductPropertyByPropertyValue(propertyValueID));
        }

        //Insert
        public bool Insert()
        {
            return ProductPropertiesBF.Insert(this.ProductID, this.PropertyValueID);
        }

        //Delete
        public bool Delete()
        {
            return ProductPropertiesBF.Delete(this.ProductID, this.PropertyValueID);
        }

        public bool DeleteByProduct()
        {
            return ProductPropertiesBF.DeleteByProduct(this.ProductID);
        }

        public bool DeleteByPropertyValue()
        {
            return ProductPropertiesBF.DeleteByPropertyValue(this.PropertyValueID);
        }

        //Insert
        public static bool Insert(int productID, int propertyValueID)
        {
            return SiteProvider.ProductPropertiesProvider.Insert(new ProductProperty(productID, propertyValueID));
        }

        //Delete
        public static bool Delete(int productID, int propertyValueID)
        {
            return SiteProvider.ProductPropertiesProvider.Delete(productID, propertyValueID);
        }

        public static bool DeleteByProduct(int productID)
        {
            return SiteProvider.ProductPropertiesProvider.DeleteByProduct(productID);
        }

        public static bool DeleteByPropertyValue(int propertyValueID)
        {
            return SiteProvider.ProductPropertiesProvider.DeleteByPropertyValue(propertyValueID);
        }
    }
}
