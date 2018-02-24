using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class AdLocationsBF
    {

        protected int _adLocationID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;

        #region Public Properties

        public int AdLocationID
        {
            get { return _adLocationID; }
            set { _adLocationID = value; }
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

        private static List<AdLocationsBF> GetAdLocationsBFListFromAdLocationsList(List<AdLocation> recordset)
        {
            List<AdLocationsBF> ret = new List<AdLocationsBF>();
            foreach (AdLocation record in recordset)
                ret.Add(GetAdLocationsBFFromAdLocation(record));
            return ret;
        }

        private static AdLocationsBF GetAdLocationsBFFromAdLocation(AdLocation record)
        {
            if (record == null)
                return null;
            else
            {
                return new AdLocationsBF(record.AdLocationID, record.Title, record.Description);
            }
        }

        public AdLocationsBF()
        {
        }


        public AdLocationsBF(int adLocationID, string title, string description)
        {
            _adLocationID = adLocationID;
            _title = title;
            _description = description;
        }

        public static AdLocationsBF GetAdLocationsBF(int adLocationID)
        {
            return GetAdLocationsBFFromAdLocation(SiteProvider.AdLocationsProvider.GetAdLocation(adLocationID));
        }

        //Get by ForeignKey

        //Get All
        public static List<AdLocationsBF> GetAdLocationsAll()
        {
            return GetAdLocationsBFListFromAdLocationsList(SiteProvider.AdLocationsProvider.GetAdLocationsAll());
        }

        //Insert
        public int Insert()
        {
            return AdLocationsBF.Insert(this.AdLocationID, this.Title, this.Description);
        }

        //Update
        public bool Update()
        {
            return AdLocationsBF.Update(this.AdLocationID, this.Title, this.Description);
        }

        //Delete
        public bool Delete()
        {
            return AdLocationsBF.Delete(
            this.AdLocationID);
        }

        //Insert
        public static int Insert(int adLocationID, string title, string description)
        {
            return SiteProvider.AdLocationsProvider.Insert(new AdLocation(adLocationID, title, description));
        }

        //Update
        public static bool Update(int adLocationID, string title, string description)
        {
            return SiteProvider.AdLocationsProvider.Update(new AdLocation(adLocationID, title, description));
        }

        //Delete
        public static bool Delete(int adLocationID)
        {
            return SiteProvider.AdLocationsProvider.Delete(adLocationID);
        }

    }
}
