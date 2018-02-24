using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucFilterProductBrands : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int _departmentID;
    public int DepartmentID 
    { 
        get
        {
            return _departmentID;
        }
        set
        {
            _departmentID = value;

            rptBrands.DataSource = BrandsBF.GetBrandsByDepartment(_departmentID);
            rptBrands.DataBind();
        }
    }

    protected void rptBrands_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HyperLink hplBrand = e.Item.FindControl("hplBrand") as HyperLink;

            var dep = DepartmentsBF.GetDepartmentsBF(_departmentID);

            hplBrand.NavigateUrl = "/san-pham/" + dep.DepartmentID + "/" + VNString.TextToUrl(dep.Title) + "?_brand=" + DataBinder.Eval(e.Item.DataItem, "BrandID").ToString();
        }
    }
}