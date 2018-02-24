using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class PropertiesBF
    {
        #region Public Properties
        public int PropertyID { get; set; }
        public int PropertyGroupID { get; set; }
        public string Title { get; set; }
        public int Important { get; set; }
        public bool AllowSearch { get; set; }
        #endregion

        public PropertiesBF()
        {
        }

        public PropertiesBF(int propertyID, int propertyGroupID, string title, int important, bool allowSearch)
        {
            this.PropertyID = propertyID;
            this.PropertyGroupID = propertyGroupID;
            this.Title = title;
            this.Important = important;
            this.AllowSearch = allowSearch;
        }

        private static PropertiesBF GetPropertiesBFFromProperty(Property record)
        {
            if (record == null)
                return null;
            else
            {
                return new PropertiesBF(record.PropertyID, record.PropertyGroupID, record.Title, record.Important, record.AllowSearch);
            }
        }

        private static List<PropertiesBF> GetPropertiesBFListFromPropertiesList(List<Property> recordset)
        {
            List<PropertiesBF> ret = new List<PropertiesBF>();
            foreach (Property record in recordset)
                ret.Add(GetPropertiesBFFromProperty(record));
            return ret;
        }

        public static PropertiesBF GetPropertiesBF(int propertyID)
        {
            return GetPropertiesBFFromProperty(SiteProvider.PropertiesProvider.GetProperty(propertyID));
        }

        //Get All
        public static List<PropertiesBF> GetPropertiesAll()
        {
            return GetPropertiesBFListFromPropertiesList(SiteProvider.PropertiesProvider.GetPropertiesAll());
        }

        public static List<PropertiesBF> GetPropertiesByPropertyGroup(int groupID)
        {
            return GetPropertiesBFListFromPropertiesList(SiteProvider.PropertiesProvider.GetPropertiesByPropertyGroup(groupID));
        }

        public static List<PropertiesBF> GetPropertiesDynamic(string condition, string orderBy)
        {
            return GetPropertiesBFListFromPropertiesList(SiteProvider.PropertiesProvider.GetPropertiesDynamic(condition, orderBy));
        }

        //Insert
        public int Insert()
        {
            return PropertiesBF.Insert(this.PropertyID, this.PropertyGroupID, this.Title, this.Important, this.AllowSearch);
        }

        //Update
        public bool Update()
        {
            return PropertiesBF.Update(this.PropertyID, this.PropertyGroupID, this.Title, this.Important, this.AllowSearch);
        }

        //Delete
        public bool Delete()
        {
            return PropertiesBF.Delete(
            this.PropertyID);
        }

        //Insert
        public static int Insert(int propertyID, int propertyGroupID, string title, int important, bool allowSearch)
        {
            return SiteProvider.PropertiesProvider.Insert(new Property(propertyID, propertyGroupID, title, important, allowSearch));
        }

        //Update
        public static bool Update(int propertyID, int propertyGroupID, string title, int important, bool allowSearch)
        {
            return SiteProvider.PropertiesProvider.Update(new Property(propertyID, propertyGroupID, title, important, allowSearch));
        }

        //Delete
        public static bool Delete(int propertyID)
        {
            return SiteProvider.PropertiesProvider.Delete(propertyID);
        }

    }
}
