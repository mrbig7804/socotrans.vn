using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucProductGroupPropertiesByDepartment : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

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

            rptPropertiesGroups.DataSource = PropertiesGroupsBF.GetPropertiesGroupsByDepartment(this._departmentID);
            rptPropertiesGroups.DataBind();
        }
    }
}