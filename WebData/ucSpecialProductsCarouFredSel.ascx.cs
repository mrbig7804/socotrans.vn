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
using System.Linq;

using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucSpecialProductsCarouFredSel : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptProducts.DataSource = ProductsBF.GetProductsBySpecialID(SpecialID, DateTime.Now).Take(MaxItem);
            rptProducts.DataBind();
        }
    }

    public int MaxItem { get; set; }

    public int SpecialID { get; set; }
}
