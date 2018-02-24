using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;
namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class AdLocation
    {
        protected int _adLocationID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;

        public AdLocation()
        {
        }

        public AdLocation(int adLocationID, string title, string description)
        {
            _adLocationID = adLocationID;
            _title = title;
            _description = description;
        }

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
    }


}
