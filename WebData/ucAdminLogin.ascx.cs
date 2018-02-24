using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Zensoft.Website.Security;

public partial class ucAdminLogin : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.Visible = Page.User.Identity.IsAuthenticated;
        this.Visible = Permissions.IsAdministrator(Page.User.Identity.Name);
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        this.Visible = false;

        Response.Redirect("/");
    }
}