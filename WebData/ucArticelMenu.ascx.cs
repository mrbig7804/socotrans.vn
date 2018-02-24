using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucArticelMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptCategory.DataSource = CategoriesBF.GetCategoriesByParentCategoryID(this.ParentID);
            rptCategory.DataBind();
        }
    }

    public int ParentID { get; set; }

    public string Url { get; set; }

    protected string GetUrl()
    {
        return Url;
    }
}