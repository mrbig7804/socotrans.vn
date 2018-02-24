using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucProductGroupProperties : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    int _productID;
    public int ProductID
    {
        get
        {
            return _productID;
        }
        set
        {
            _productID = value;

            rptPropertiesGroups.DataSource = PropertiesGroupsBF.GetPropertiesGroupsByDepartment(ProductsBF.GetProductsBF(this._productID).DepartmentID);
            rptPropertiesGroups.DataBind();
        }
    }
}