using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class adm_DepartmentExtension : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPage();
        }
    }

    void BindPage()
    {
        int depID = int.Parse(Request.QueryString["depID"]);

        var dep = DepartmentsBF.GetDepartmentsBF(depID);

        ltrTitlePage.Text = dep.Title.Trim();

        hplNavPrice.NavigateUrl = "/adm/ManagePriceDistance.aspx?depID=" + depID;
        hplNavBrand.NavigateUrl = "/adm/ManageBrands.aspx?depID=" + depID;
        hplNavProperty.NavigateUrl = "/adm/ManageDepartmentProperties.aspx?depID=" + depID;
    }

    protected bool CheckAvailablePriceDep(int priceID, int depID)
    {
        var pd = PriceDepartmentBF.GetPriceDepartmentBF(priceID, depID);
        return pd != null;
    }

    protected bool CheckAvailableBrandDep(int brandID, int depID)
    {
        var bd = BrandDepartmentsBF.GetBrandDepartmentBF(brandID, depID);
        return bd != null;
    }

    protected void gvwPrice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvwPrice.PageIndex = e.NewPageIndex;
        this.gvwPrice.DataBind();
    }

    protected void gvwBrand_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvwBrand.PageIndex = e.NewPageIndex;
        this.gvwBrand.DataBind();
    }

    protected void lbtnUpdatePriceDepartment_Click(object sender, EventArgs e)
    {
        int depID = int.Parse(Request.QueryString["depID"]);

        for (int i = 0; i < gvwPrice.Rows.Count; i++)
        {
            GridViewRow row = gvwPrice.Rows[i];

            bool isChecked = ((CheckBox)row.FindControl("ckbPrice")).Checked;
            int priceID = int.Parse(gvwPrice.DataKeys[row.RowIndex]["PriceID"].ToString());

            if (isChecked)
            {
                PriceDepartmentBF pd = PriceDepartmentBF.GetPriceDepartmentBF(priceID, depID);
                if (pd == null)
                {
                    pd = new PriceDepartmentBF();
                    pd.PriceID = priceID;
                    pd.DepartmentID = depID;
                    pd.Insert();
                }
            }
            else
            {
                PriceDepartmentBF pd = PriceDepartmentBF.GetPriceDepartmentBF(priceID, depID);

                if (pd != null) pd.Delete();
            }
        }
    }

    protected void lbtnUpdateBrandDepartment_Click(object sender, EventArgs e)
    {
        int depID = int.Parse(Request.QueryString["depID"]);

        for (int i = 0; i < gvwBrand.Rows.Count; i++)
        {
            GridViewRow row = gvwBrand.Rows[i];

            bool isChecked = ((CheckBox)row.FindControl("ckbBrand")).Checked;
            int brandID = int.Parse(gvwBrand.DataKeys[row.RowIndex]["BrandID"].ToString());

            if (isChecked)
            {
                BrandDepartmentsBF bd = BrandDepartmentsBF.GetBrandDepartmentBF(brandID, depID);
                if (bd == null)
                {
                    bd = new BrandDepartmentsBF();
                    bd.BrandID = brandID;
                    bd.DepartmentID = depID;
                    bd.Insert();
                }
            }
            else
            {
                BrandDepartmentsBF bd = BrandDepartmentsBF.GetBrandDepartmentBF(brandID, depID);
                if (bd != null) bd.Delete();
            }
        }
    }
}