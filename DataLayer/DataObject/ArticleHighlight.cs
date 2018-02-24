using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class ArticleHighlight
    {
        protected int _articleHighlightID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected string _title = String.Empty;
        protected string _description = String.Empty;
        protected string _smallPictureUrl = String.Empty;
        protected string _pictureUrl = String.Empty;
        protected string _link = String.Empty;
        protected bool _isCurrent;
        protected bool _listed;

        public ArticleHighlight()
        {
        }

        public ArticleHighlight(int articleHighlightID, DateTime addedDate, string addedBy, string title, string description, string smallPictureUrl, string pictureUrl, string link, bool isCurrent, bool listed)
        {
            _articleHighlightID = articleHighlightID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _title = title;
            _description = description;
            _smallPictureUrl = smallPictureUrl;
            _pictureUrl = pictureUrl;
            _link = link;
            _isCurrent = isCurrent;
            _listed = listed;
        }

        #region Public Properties

        public int ArticleHighlightID
        {
            get { return _articleHighlightID; }
            set { _articleHighlightID = value; }
        }

        public DateTime AddedDate
        {
            get { return _addedDate; }
            set { _addedDate = value; }
        }

        public string AddedBy
        {
            get { return _addedBy; }
            set { _addedBy = value; }
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

        public string SmallPictureUrl
        {
            get { return _smallPictureUrl; }
            set { _smallPictureUrl = value; }
        }

        public string PictureUrl
        {
            get { return _pictureUrl; }
            set { _pictureUrl = value; }
        }

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        public bool IsCurrent
        {
            get { return _isCurrent; }
            set { _isCurrent = value; }
        }

        public bool Listed
        {
            get { return _listed; }
            set { _listed = value; }
        }
        #endregion
    }


}
