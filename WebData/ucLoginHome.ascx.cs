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
using Zensoft.Website.Configuration;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucLoginHome : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginView1.DataBind();
    }

    protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
    {
        //Response.Redirect(Request.Url.AbsolutePath);
        Response.Redirect("/");
    }

}
