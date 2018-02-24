using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class PropertiesGroupsBF
    {
        #region Public Properties
        public int PropertyGroupID { get; set; }
        public int DepartmentID { get; set; }
        public string Title { get; set; }
        public int Important { get; set; }
        #endregion

        public PropertiesGroupsBF()
        {
        }

        public PropertiesGroupsBF(int propertyGroupID, int departmentID, string title, int important)
        {
            this.PropertyGroupID = propertyGroupID;
            this.DepartmentID = departmentID;
            this.Title = title;
            this.Important = important;
        }

        private static PropertiesGroupsBF GetPropertiesGroupsBFFromPropertiesGroup(PropertiesGroup record)
        {
            if (record == null)
                return null;
            else
            {
                return new PropertiesGroupsBF(record.PropertyGroupID, record.DepartmentID, record.Title, record.Important);
            }
        }

        private static List<PropertiesGroupsBF> GetPropertiesGroupsBFListFromPropertiesGroupsList(List<PropertiesGroup> recordset)
        {
            List<PropertiesGroupsBF> ret = new List<PropertiesGroupsBF>();
            foreach (PropertiesGroup record in recordset)
                ret.Add(GetPropertiesGroupsBFFromPropertiesGroup(record));
            return ret;
        }

        public static PropertiesGroupsBF GetPropertiesGroupsBF(int propertyGroupID)
        {
            return GetPropertiesGroupsBFFromPropertiesGroup(SiteProvider.PropertiesGroupsProvider.GetPropertiesGroup(propertyGroupID));
        }

        //Get All
        public static List<PropertiesGroupsBF> GetPropertiesGroupsAll()
        {
            return GetPropertiesGroupsBFListFromPropertiesGroupsList(SiteProvider.PropertiesGroupsProvider.GetPropertiesGroupsAll());
        }

        public static List<PropertiesGroupsBF> GetPropertiesGroupsByDepartment(int departmentID)
        {
            return GetPropertiesGroupsBFListFromPropertiesGroupsList(SiteProvider.PropertiesGroupsProvider.GetPropertiesGroupsByDepartment(departmentID));
        }

        public static List<PropertiesGroupsBF> GetPropertiesGroupsDynamic(string condition, string orderBy)
        {
            return GetPropertiesGroupsBFListFromPropertiesGroupsList(SiteProvider.PropertiesGroupsProvider.GetPropertiesGroupsDynamic(condition, orderBy));
        }

        //Insert
        public int Insert()
        {
            return PropertiesGroupsBF.Insert(this.PropertyGroupID, this.DepartmentID, this.Title, this.Important);
        }

        //Update
        public bool Update()
        {
            return PropertiesGroupsBF.Update(this.PropertyGroupID, this.DepartmentID, this.Title, this.Important);
        }

        //Delete
        public bool Delete()
        {
            return PropertiesGroupsBF.Delete(
            this.PropertyGroupID);
        }

        //Insert
        public static int Insert(int propertyGroupID, int departmentID, string title, int important)
        {
            return SiteProvider.PropertiesGroupsProvider.Insert(new PropertiesGroup(propertyGroupID, departmentID, title, important));
        }

        //Update
        public static bool Update(int propertyGroupID, int departmentID, string title, int important)
        {
            return SiteProvider.PropertiesGroupsProvider.Update(new PropertiesGroup(propertyGroupID, departmentID, title, important));
        }

        //Delete
        public static bool Delete(int propertyGroupID)
        {
            return SiteProvider.PropertiesGroupsProvider.Delete(propertyGroupID);
        }

    }
}
