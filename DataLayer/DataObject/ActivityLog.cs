using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class ActivityLog
    {
        protected long _activityLogID;
        protected Guid _userId = Guid.Empty;
        protected string _activity = String.Empty;
        protected string _pageUrl = String.Empty;
        protected DateTime _activityDate;

        public ActivityLog()
        {
        }

        public ActivityLog(long activityLogID, Guid userId, string activity, string pageUrl, DateTime activityDate)
        {
            _activityLogID = activityLogID;
            _userId = userId;
            _activity = activity;
            _pageUrl = pageUrl;
            _activityDate = activityDate;
        }

        #region Public Properties

        public long ActivityLogID
        {
            get { return _activityLogID; }
            set { _activityLogID = value; }
        }

        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string Activity
        {
            get { return _activity; }
            set { _activity = value; }
        }

        public string PageUrl
        {
            get { return _pageUrl; }
            set { _pageUrl = value; }
        }

        public DateTime ActivityDate
        {
            get { return _activityDate; }
            set { _activityDate = value; }
        }
        #endregion
    }
}
