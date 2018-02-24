using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class adm_WhoIsOnline : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string FormatActivity(string activity, string pageUrl)
    {
        if (string.IsNullOrEmpty(pageUrl))
            return activity;
        else
            return string.Format(@"<a href=""{0}"">{1}</a>", pageUrl, activity);
    }


    protected string FormatLastUpdatedDate(DateTime lastUpdateDate, DateTime currentDate)
    {
        TimeSpan delta = currentDate.Subtract(lastUpdateDate);
        if (delta.Days > 7)
            return lastUpdateDate.ToShortDateString();
        else if (delta.Days > 1)
            return string.Format("{0} days ago", delta.Days);
        else if (delta.Days == 1)
            return string.Format("Yesterday", delta.Days);
        else if (delta.Hours > 1)
            return string.Format("{0} hours ago", delta.Hours);
        else if (delta.Hours == 1)
            return string.Format("1 hour ago", delta.Hours);
        else if (delta.Minutes > 1)
            return string.Format("{0} minutes ago", delta.Minutes);
        else if (delta.Minutes == 1)
            return string.Format("1 minute ago", delta.Minutes);
        else
            return "A few seconds ago";
    }


}
