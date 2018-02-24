using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;
using System.Web.Security;
namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public partial class ActivityLogsBF
    {
        public string UserName
        {
            get
            {
                MembershipUser currentUser = Membership.GetUser(this.UserId);
                return currentUser.UserName;
            }
        }

        public static bool LogUserActivity(Guid userId, string activity, string pageUrl)
        {
            return SiteProvider.ActivityLogsProvider.LogUserActivity(userId, activity, pageUrl);
        }

        public static List<ActivityLogsBF> GetCurrentActivityForOnline(int minutes)
        {
            return GetActivityLogsBFListFromActivityLogsList(SiteProvider.ActivityLogsProvider.GetCurrentActivityForOnline(minutes));
        }

    }
}
