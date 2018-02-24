using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public partial class CitiesBF
    {
        #region Public Properties
        public int CityID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Important { get; set; }
        public bool IsMain { get; set; }
        #endregion

        public CitiesBF()
        {
        }

        public CitiesBF(int cityID, int parentID, string name, string description, int important, bool isMain)
        {
            this.CityID = cityID;
            this.ParentID = parentID;
            this.Name = name;
            this.Description = description;
            this.Important = important;
            this.IsMain = isMain;
        }

        private static CitiesBF GetCitiesBFFromCity(City record)
        {
            if (record == null)
                return null;
            else
            {
                return new CitiesBF(record.CityID, record.ParentID, record.Name, record.Description, record.Important, record.IsMain);
            }
        }

        private static List<CitiesBF> GetCitiesBFListFromCitiesList(List<City> recordset)
        {
            List<CitiesBF> ret = new List<CitiesBF>();
            foreach (City record in recordset)
                ret.Add(GetCitiesBFFromCity(record));
            return ret;
        }

        public static CitiesBF GetCitiesBF(int cityID)
        {
            return GetCitiesBFFromCity(SiteProvider.CitiesProvider.GetCity(cityID));
        }

        //Get All
        public static List<CitiesBF> GetCitiesAll()
        {
            return GetCitiesBFListFromCitiesList(SiteProvider.CitiesProvider.GetCitiesAll());
        }

        //Get All
        public static List<CitiesBF> GetCitiesByParentID(int cityID)
        {
            return GetCitiesBFListFromCitiesList(SiteProvider.CitiesProvider.GetCitiesByParentID(cityID));
        }

        //Insert
        public int Insert()
        {
            return CitiesBF.Insert(this.CityID, this.ParentID, this.Name, this.Description, this.Important, this.IsMain);
        }

        //Update
        public bool Update()
        {
            return CitiesBF.Update(this.CityID, this.ParentID, this.Name, this.Description, this.Important, this.IsMain);
        }

        //Delete
        public bool Delete()
        {
            return CitiesBF.Delete(
            this.CityID);
        }

        //Insert
        public static int Insert(int cityID, int parentID, string name, string description, int important, bool isMain)
        {
            return SiteProvider.CitiesProvider.Insert(new City(cityID, parentID, name, description, important, isMain));
        }

        //Update
        public static bool Update(int cityID, int parentID, string name, string description, int important, bool isMain)
        {
            return SiteProvider.CitiesProvider.Update(new City(cityID, parentID, name, description, important, isMain));
        }

        //Delete
        public static bool Delete(int cityID)
        {
            return SiteProvider.CitiesProvider.Delete(cityID);
        }

    }
}
