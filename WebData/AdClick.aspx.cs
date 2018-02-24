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

using Zensoft.Website.BusinessLayer.BusinessFacade;
public partial class AdClick :  Zensoft.Website.UI.BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);

            AdLinksBF ad = AdLinksBF.GetAdLinksBF(id);
            ad.IncreaseClick();

            Response.Redirect(ad.Link);
        }
        else Response.Redirect("~/");
    }
}
