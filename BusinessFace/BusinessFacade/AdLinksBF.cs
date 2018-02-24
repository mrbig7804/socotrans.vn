using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public partial class AdLinksBF
    {

        protected int _adLinkID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;
        protected string _link = String.Empty;
        protected string _image = String.Empty;
        protected string _code = String.Empty;
        protected bool _isCode;
        protected DateTime _regionDate;
        protected DateTime _expireDate;
        protected int _importance;
        protected int _click;
        protected int _adLocationID;

        #region Public Properties

        public int AdLinkID
        {
            get { return _adLinkID; }
            set { _adLinkID = value; }
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

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public bool IsCode
        {
            get { return _isCode; }
            set { _isCode = value; }
        }

        public DateTime RegionDate
        {
            get { return _regionDate; }
            set { _regionDate = value; }
        }

        public DateTime ExpireDate
        {
            get { return _expireDate; }
            set { _expireDate = value; }
        }

        public int Importance
        {
            get { return _importance; }
            set { _importance = value; }
        }

        public int Click
        {
            get { return _click; }
            set { _click = value; }
        }

        public int AdLocationID
        {
            get { return _adLocationID; }
            set { _adLocationID = value; }
        }
        #endregion

        private static List<AdLinksBF> GetAdLinksBFListFromAdLinksList(List<AdLink> recordset)
        {
            List<AdLinksBF> ret = new List<AdLinksBF>();
            foreach (AdLink record in recordset)
                ret.Add(GetAdLinksBFFromAdLink(record));
            return ret;
        }

        private static AdLinksBF GetAdLinksBFFromAdLink(AdLink record)
        {
            if (record == null)
                return null;
            else
            {
                return new AdLinksBF(record.AdLinkID, record.Title, record.Description, record.Link, record.Image, record.Code, record.IsCode, record.RegionDate, record.ExpireDate, record.Importance, record.Click, record.AdLocationID);
            }
        }

        public AdLinksBF()
        {
        }


        public AdLinksBF(int adLinkID, string title, string description, string link, string image, string code, bool isCode, DateTime regionDate, DateTime expireDate, int importance, int click, int adLocationID)
        {
            _adLinkID = adLinkID;
            _title = title;
            _description = description;
            _link = link;
            _image = image;
            _code = code;
            _isCode = isCode;
            _regionDate = regionDate;
            _expireDate = expireDate;
            _importance = importance;
            _click = click;
            _adLocationID = adLocationID;
        }

        public static AdLinksBF GetAdLinksBF(int adLinkID)
        {
            return GetAdLinksBFFromAdLink(SiteProvider.AdLinksProvider.GetAdLink(adLinkID));
        }

        //Get by ForeignKey
        public static List<AdLinksBF> GetAdLinksByAdLocationID(int adLocationID)
        {
            return GetAdLinksBFListFromAdLinksList(SiteProvider.AdLinksProvider.GetAdLinksByAdLocationID(adLocationID));
        }

        //Get All
        public static List<AdLinksBF> GetAdLinksAll()
        {
            return GetAdLinksBFListFromAdLinksList(SiteProvider.AdLinksProvider.GetAdLinksAll());
        }

        //Insert
        public int Insert()
        {
            return AdLinksBF.Insert(this.AdLinkID, this.Title, this.Description, this.Link, this.Image, this.Code, this.IsCode, this.RegionDate, this.ExpireDate, this.Importance, this.Click, this.AdLocationID);
        }

        //Update
        public bool Update()
        {
            return AdLinksBF.Update(this.AdLinkID, this.Title, this.Description, this.Link, this.Image, this.Code, this.IsCode, this.RegionDate, this.ExpireDate, this.Importance, this.Click, this.AdLocationID);
        }

        //Delete
        public bool Delete()
        {
            return AdLinksBF.Delete(
            this.AdLinkID);
        }

        //Insert
        public static int Insert(int adLinkID, string title, string description, string link, string image, string code, bool isCode, DateTime regionDate, DateTime expireDate, int importance, int click, int adLocationID)
        {
            return SiteProvider.AdLinksProvider.Insert(new AdLink(adLinkID, title, description, link, image, code, isCode, regionDate, expireDate, importance, click, adLocationID));
        }

        //Update
        public static bool Update(int adLinkID, string title, string description, string link, string image, string code, bool isCode, DateTime regionDate, DateTime expireDate, int importance, int click, int adLocationID)
        {
            return SiteProvider.AdLinksProvider.Update(new AdLink(adLinkID, title, description, link, image, code, isCode, regionDate, expireDate, importance, click, adLocationID));
        }

        //Delete
        public static bool Delete(int adLinkID)
        {
            return SiteProvider.AdLinksProvider.Delete(adLinkID);
        }

    }

}
