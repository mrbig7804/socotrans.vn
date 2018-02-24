using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;
namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public partial class ActivityLogsBF
    {

        protected long _activityLogID;
        protected Guid _userId = Guid.Empty;
        protected string _activity = String.Empty;
        protected string _pageUrl = String.Empty;
        protected DateTime _activityDate;

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

        private static List<ActivityLogsBF> GetActivityLogsBFListFromActivityLogsList(List<ActivityLog> recordset)
        {
            List<ActivityLogsBF> ret = new List<ActivityLogsBF>();
            foreach (ActivityLog record in recordset)
                ret.Add(GetActivityLogsBFFromActivityLog(record));
            return ret;
        }

        private static ActivityLogsBF GetActivityLogsBFFromActivityLog(ActivityLog record)
        {
            if (record == null)
                return null;
            else
            {
                return new ActivityLogsBF(record.ActivityLogID, record.UserId, record.Activity, record.PageUrl, record.ActivityDate);
            }
        }

        public ActivityLogsBF()
        {
        }


        public ActivityLogsBF(long activityLogID, Guid userId, string activity, string pageUrl, DateTime activityDate)
        {
            _activityLogID = activityLogID;
            _userId = userId;
            _activity = activity;
            _pageUrl = pageUrl;
            _activityDate = activityDate;
        }

        public static ActivityLogsBF GetActivityLogsBF(long activityLogID)
        {
            return GetActivityLogsBFFromActivityLog(SiteProvider.ActivityLogsProvider.GetActivityLog(activityLogID));
        }

        //Get by ForeignKey
        public static List<ActivityLogsBF> GetActivityLogsByUserId(Guid userId)
        {
            return GetActivityLogsBFListFromActivityLogsList(SiteProvider.ActivityLogsProvider.GetActivityLogsByUserId(userId));
        }

        //Get All
        public static List<ActivityLogsBF> GetActivityLogsAll()
        {
            return GetActivityLogsBFListFromActivityLogsList(SiteProvider.ActivityLogsProvider.GetActivityLogsAll());
        }

        //Insert
        public long Insert()
        {
            return ActivityLogsBF.Insert(this.ActivityLogID, this.UserId, this.Activity, this.PageUrl, this.ActivityDate);
        }

        //Update
        public bool Update()
        {
            return ActivityLogsBF.Update(this.ActivityLogID, this.UserId, this.Activity, this.PageUrl, this.ActivityDate);
        }

        //Delete
        public bool Delete()
        {
            return ActivityLogsBF.Delete(
            this.ActivityLogID);
        }

        //Insert
        public static long Insert(long activityLogID, Guid userId, string activity, string pageUrl, DateTime activityDate)
        {
            return SiteProvider.ActivityLogsProvider.Insert(new ActivityLog(activityLogID, userId, activity, pageUrl, activityDate));
        }

        //Update
        public static bool Update(long activityLogID, Guid userId, string activity, string pageUrl, DateTime activityDate)
        {
            return SiteProvider.ActivityLogsProvider.Update(new ActivityLog(activityLogID, userId, activity, pageUrl, activityDate));
        }

        //Delete
        public static bool Delete(long activityLogID)
        {
            return SiteProvider.ActivityLogsProvider.Delete(activityLogID);
        }

    }
}
