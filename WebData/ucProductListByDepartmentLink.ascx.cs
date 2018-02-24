using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucProductListByDepartmentLink : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptProduct.DataSource = ProductsBF.GetProductsByFilter("", this.SuperDepartmentID, this.DepartmentID, "", 0, 0, 0);
            rptProduct.DataBind();
        }
    }

    public int SuperDepartmentID { set; get; }

    public int DepartmentID { set; get; }
}