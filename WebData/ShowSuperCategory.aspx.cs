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

public partial class ShowSuperCategory: Zensoft.Website.UI.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int superCategoyID = Convert.ToInt32(Request.QueryString["ID"]);

            this.Title =  SuperCategoriesBF.GetSuperCategoriesBF(superCategoyID).Title;
            UcListArticlesBySuperCategory1.SuperCategoryID = superCategoyID;
        }

    }
}
