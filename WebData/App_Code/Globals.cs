using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Globals
/// </summary>
namespace Zensoft.Website.UI
{
    public static class Globals
    {

        public static  string ApplicationPath
        {

            get
            {
                string applicationPath = HttpContext.Current.Request.ApplicationPath;

                if (applicationPath == "/")
                {
                    return string.Empty;
                }
                else
                {
                    return applicationPath;
                }
            }
        }

        public const string ARTICLE_IMAGE_SAVE_PATH = "~/Attachs/Articles/";
        public const string ITEM_IMAGE_SAVE_PATH = "~/Attachs/Items/";
    }
}
