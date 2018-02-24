using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;
namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class AdLink
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

        public AdLink()
        {
        }

        public AdLink(int adLinkID, string title, string description, string link, string image, string code, bool isCode, DateTime regionDate, DateTime expireDate, int importance, int click, int adLocationID)
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
    }

}
