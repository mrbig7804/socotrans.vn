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

public partial class admin_ucListCategories : System.Web.UI.UserControl
{
    protected int _superCategoryID;

    public int SuperCategoryID
    {
        get { return _superCategoryID; }
        set { _superCategoryID = value;
        ObjectDataSource1.SelectParameters["superCategoryID"].DefaultValue = value.ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
}
