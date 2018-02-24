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

public partial class Login : Zensoft.Website.UI.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (Login1.RememberMeSet)
            FormsAuthentication.SetAuthCookie(Login1.UserName.ToString(), true);
        else
            FormsAuthentication.SetAuthCookie(Login1.UserName.ToString(), false);

        if (Permissions.IsAdministrator(Login1.UserName))
            Login1.DestinationPageUrl = "/adm";
    }
}
