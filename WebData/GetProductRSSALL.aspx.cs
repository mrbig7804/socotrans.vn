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

public partial class GetProductRSSALL : Zensoft.Website.UI.BasePage
{
    private string _rssTitle = "Sản phẩm mới nhất";

    public string RssTitle
    {
        get { return _rssTitle; }
        set { _rssTitle = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _rssTitle = "Sản phẩm mới nhất";

        rptRss.DataSource = ProductsBF.GetProductsByFilter("", 0, 0, "", 0, 0,0);
        rptRss.DataBind();

    }

}
