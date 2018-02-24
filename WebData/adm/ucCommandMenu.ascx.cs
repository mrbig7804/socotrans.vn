using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Zensoft.Website.Security;

public partial class admin_ucCommandMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            panExtensions.Visible = Permissions.FeedbacksBrowsePermission(Page.User.Identity.Name);
            //panAccounts.Visible = Permissions.UsersBrowsePermission(Page.User.Identity.Name);
            //lnkArticleHighlights.Visible = Permissions.ArticleHighlightsBrowserPermission(Page.User.Identity.Name);
            lnkCategories.Visible = Permissions.CategoriesBrowsePermission(Page.User.Identity.Name);
        }
    }
}
