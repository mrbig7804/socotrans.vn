using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucDepartmentForShowItem : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptDepartment.DataSource = DepartmentsBF.GetDepartmentsByParentID(DepartmentsBF.GetDepartmentsBF(this.DepartmentID).ParentID);
            rptDepartment.DataBind();
        }
    }

    public int DepartmentID { get; set; }

    protected void rptDepartment_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int depID = int.Parse(DataBinder.Eval(e.Item.DataItem, "DepartmentID").ToString());

            if (depID == this.DepartmentID)
            {
                HyperLink hplDep = e.Item.FindControl("hplDep") as HyperLink;
                hplDep.CssClass = "starlink_Dep";
            }
        }
    }
}