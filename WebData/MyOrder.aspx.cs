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

public partial class MyOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            dlstOrders.DataSource = OrdersBF.GetOrdersByCustomerName(this.User.Identity.Name);
            dlstOrders.DataBind();
        }
    }
}
