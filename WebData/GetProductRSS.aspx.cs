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

public partial class GetProductRSS : Zensoft.Website.UI.BasePage
{
    private string _rssTitle = "Sản phẩm mới nhất";

    public string RssTitle
    {
        get { return _rssTitle; }
        set { _rssTitle = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int superCategoryID;
        int categoryID;

        if (int.TryParse(this.Request.QueryString["ID"], out superCategoryID))
        {
            GetSuperCategoryRSS(superCategoryID);
        }
        else if (int.TryParse(this.Request.QueryString["CategoryID"], out categoryID))
        {
            GetCategoryRSS(categoryID);
        }
        else GetNewest();
    }

    private void GetNewest()
    {
        _rssTitle = "Sản phẩm mới nhất";

        rptRss.DataSource = ProductsBF.GetProductsByFilter("", 0, 0, "", 0, 0, 0).Take(20); 
        rptRss.DataBind();

    }

    private void GetSuperCategoryRSS(int superCategoryID)
    {
        _rssTitle = SuperDepartmentsBF.GetSuperDepartmentsBF(superCategoryID).Title;

        rptRss.DataSource = ProductsBF.GetProductsByFilter("", superCategoryID, 0, "", 0, 0, 0).Take(20);
        rptRss.DataBind();
    }

    private void GetCategoryRSS(int categoryID)
    {
        _rssTitle = DepartmentsBF.GetDepartmentsBF(categoryID).Title;

        rptRss.DataSource = ProductsBF.GetProductsByFilter("", 0, categoryID, "", 0, 0, 0).Take(20);
        rptRss.DataBind();
    }

}
