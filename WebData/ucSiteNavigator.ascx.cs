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

public partial class ucSiteNavigator : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public ArticlesBF ArticleID
    {
        set
        {
            lblTitle.Text = ">>" + value.Title;

            lnkCategory.Text =  value.Category.Title;
            lnkCategory.NavigateUrl = "~/ShowCategory.aspx?ID=" + value.Category.CategoryID.ToString();

            lnkSuperCategory.Text = value.Category.SuperCategory.Title;
            lnkSuperCategory.NavigateUrl = "~/ShowSuperCategory.aspx?ID=" + value.Category.SuperCategory.SuperCategoryID.ToString();
        }
    }

    public CategoriesBF Category
    {
        set
        {
            lblTitle.Text = value.Title;

            lnkCategory.Visible = false;

            lnkSuperCategory.Text = value.SuperCategory.Title;
            lnkSuperCategory.NavigateUrl = "~/ShowSuperCategory.aspx?ID=" + value.SuperCategory.SuperCategoryID.ToString();
        }
    }
}
