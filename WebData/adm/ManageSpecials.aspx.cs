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
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class adm_ManageSpecials : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gvwProducts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteSpecial")
        {
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))

                ProductSpecialsBF.Delete(Convert.ToInt32(e.CommandArgument), 1);
            else

                ProductSpecialsBF.Delete(Convert.ToInt32(e.CommandArgument),Convert.ToInt32(Request.QueryString["ID"]));

            gvwProducts.DataBind();

        }
    }

}
