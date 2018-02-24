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

public partial class ucSubCategories : System.Web.UI.UserControl
{
    int _superCategoryID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int SuperCategoryID
    {
        set
        {
            _superCategoryID = value;
            DataList1.DataSource = CategoriesBF.GetCategoriesBySuperCategoryID(_superCategoryID);
            DataList1.DataBind();
        }
        get { return _superCategoryID; }
    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
