using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucFilterProductPrice : System.Web.UI.UserControl
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

            rptPrices.DataSource = PriceDistanceBF.GetPriceDistanceByDepartment(_departmentID);
            rptPrices.DataBind();
        }
    }

    protected void rptPrices_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HyperLink hplPrice = e.Item.FindControl("hplPrice") as HyperLink;
            Label lblCount = e.Item.FindControl("lblCount") as Label;

            var dep = DepartmentsBF.GetDepartmentsBF(_departmentID);
            int minPrice = int.Parse(DataBinder.Eval(e.Item.DataItem, "PriceFrom").ToString());
            int maxPrice = int.Parse(DataBinder.Eval(e.Item.DataItem, "PriceTo").ToString());

            hplPrice.NavigateUrl = "/san-pham/" + dep.DepartmentID + "/" + VNString.TextToUrl(dep.Title) + "?_priceDistance=" + DataBinder.Eval(e.Item.DataItem, "PriceID").ToString();
            lblCount.Text = ProductsBF.GetProductsByFilter("", 0, dep.DepartmentID, "", 0, maxPrice, minPrice).Count.ToString();
        }
    }
}