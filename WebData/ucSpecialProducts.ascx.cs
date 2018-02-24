using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucSpecialProducts : System.Web.UI.UserControl
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