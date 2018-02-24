using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class PCategory
    {
        protected int _pCategoryID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;

        public PCategory()
        {
        }

        public PCategory(int pCategoryID, string title, string description)
        {
            _pCategoryID = pCategoryID;
            _title = title;
            _description = description;
        }

        #region Public Properties

        public int PCategoryID
        {
            get { return _pCategoryID; }
            set { _pCategoryID = value; }
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
