using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class ArticleLocation
    {
        protected int _articleID;
        protected int _location;
        protected string _description = String.Empty;

        public ArticleLocation()
        {
        }

        public ArticleLocation(int articleID, int location, string description)
        {
            _articleID = articleID;
            _location = location;
            _description = description;
        }

        #region Public Properties

        public int ArticleID
        {
            get { return _articleID; }
            set { _articleID = value; }
        }

        public int Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion
    }


}
