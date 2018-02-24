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
using System.Collections.Generic;

public partial class ucProductRelate : System.Web.UI.UserControl
{
    int _productID;

    public int ProductID
    {
        get
        {
            return _productID;
        }
        set
        {
            rptProducts.DataSource = ProductsBF.GetProductsByFilter("", 0, ProductsBF.GetProductsBF(value).DepartmentID, "", 0, 0, 0);
            rptProducts.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
