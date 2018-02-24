using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class Special
    {
        protected int _specialID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;

        public Special()
        {
        }

        public Special(int specialID, string title, string description)
        {
            _specialID = specialID;
            _title = title;
            _description = description;
        }

        #region Public Properties

        public int SpecialID
        {
            get { return _specialID; }
            set { _specialID = value; }
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
