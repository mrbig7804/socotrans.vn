using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class PropertiesValuesBF
    {
        #region Public Properties
        public int PropertiesValueID { get; set; }
        public int PropertyID { get; set; }
        public string Value { get; set; }
        #endregion

        public PropertiesValuesBF()
        {
        }

        public PropertiesValuesBF(int propertiesValueID, int propertyID, string value)
        {
            this.PropertiesValueID = propertiesValueID;
            this.PropertyID = propertyID;
            this.Value = value;
        }

        private static PropertiesValuesBF GetPropertiesValuesBFFromPropertiesValue(PropertiesValue record)
        {
            if (record == null)
                return null;
            else
            {
                return new PropertiesValuesBF(record.PropertiesValueID, record.PropertyID, record.Value);
            }
        }

        private static List<PropertiesValuesBF> GetPropertiesValuesBFListFromPropertiesValuesList(List<PropertiesValue> recordset)
        {
            List<PropertiesValuesBF> ret = new List<PropertiesValuesBF>();
            foreach (PropertiesValue record in recordset)
                ret.Add(GetPropertiesValuesBFFromPropertiesValue(record));
            return ret;
        }

        public static PropertiesValuesBF GetPropertiesValuesBF(int propertiesValueID)
        {
            return GetPropertiesValuesBFFromPropertiesValue(SiteProvider.PropertiesValuesProvider.GetPropertiesValue(propertiesValueID));
        }

        //Get All
        public static List<PropertiesValuesBF> GetPropertiesValuesAll()
        {
            return GetPropertiesValuesBFListFromPropertiesValuesList(SiteProvider.PropertiesValuesProvider.GetPropertiesValuesAll());
        }

        public static List<PropertiesValuesBF> GetPropertiesValuesByProperty(int propertyID)
        {
            return GetPropertiesValuesBFListFromPropertiesValuesList(SiteProvider.PropertiesValuesProvider.GetPropertiesValuesByProperty(propertyID));
        }

        public static List<PropertiesValuesBF> GetPropertiesValuesByProduct(int propertyID, int productID)
        {
            return GetPropertiesValuesBFListFromPropertiesValuesList(SiteProvider.PropertiesValuesProvider.GetPropertiesValuesByProduct(propertyID, productID));
        }

        public static List<PropertiesValuesBF> GetPropertiesValuesDynamic(string condition, string orderBy)
        {
            return GetPropertiesValuesBFListFromPropertiesValuesList(SiteProvider.PropertiesValuesProvider.GetPropertiesValuesDynamic(condition, orderBy));
        }

        //Insert
        public int Insert()
        {
            return PropertiesValuesBF.Insert(this.PropertiesValueID, this.PropertyID, this.Value);
        }

        //Update
        public bool Update()
        {
            return PropertiesValuesBF.Update(this.PropertiesValueID, this.PropertyID, this.Value);
        }

        //Delete
        public bool Delete()
        {
            return PropertiesValuesBF.Delete(
            this.PropertiesValueID);
        }

        //Insert
        public static int Insert(int propertiesValueID, int propertyID, string value)
        {
            return SiteProvider.PropertiesValuesProvider.Insert(new PropertiesValue(propertiesValueID, propertyID, value));
        }

        //Update
        public static bool Update(int propertiesValueID, int propertyID, string value)
        {
            return SiteProvider.PropertiesValuesProvider.Update(new PropertiesValue(propertiesValueID, propertyID, value));
        }

        //Delete
        public static bool Delete(int propertiesValueID)
        {
            //Xóa thông số sp
            var pProperties = ProductPropertiesBF.GetProductPropertyByPropertyValue(propertiesValueID);
            if (pProperties != null)
            {
                foreach (var pp in pProperties)
                {
                    pp.Delete();
                }
            }

            return SiteProvider.PropertiesValuesProvider.Delete(propertiesValueID);
        }

    }
}
