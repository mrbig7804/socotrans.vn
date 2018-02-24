using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adm_ucAccountAdm : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbtnSignOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("~/");
    }

    protected string GetAvatarUrl(string userName)
    {
        string ret = "";
        ProfileCommon profile = null;

        if (userName.Length > 0)
            profile = this.Profile.GetProfile(userName);

        if (profile != null)
        {
            ret = profile.Forum.AvatarUrl;
        }

        if (string.IsNullOrEmpty(ret))
            ret = "/adm/images_adm/noAvt.png";

        return ret;
    }
}