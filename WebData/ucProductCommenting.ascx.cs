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
using System.Collections.Generic;

public partial class ucProductCommenting : System.Web.UI.UserControl
{

    int _departmentID;
    public int DepartmentID
    {
        get
        {
            return _departmentID;
        }
        set
        {
            _departmentID = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        var pc = ProductsBF.GetProductsByDepartmentCommenting(DepartmentID);
        rptProductRelate.DataSource = pc;
        rptProductRelate.DataBind();
    }
}
