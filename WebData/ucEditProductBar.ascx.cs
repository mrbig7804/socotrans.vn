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
using Zensoft.Website.Security;
using System.Collections.Generic;

public partial class ucEditProductBar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int ProductID
    {
        set
        {
            if (Permissions.ProductEditPermission(Page.User.Identity.Name) || ProductsBF.GetProductsBF(value).AddedBy == Page.User.Identity.Name)
            {
                lnkEdit.NavigateUrl = "/adm/Product.aspx?action=edit&productID=" + value.ToString();
            }

            this.ViewState.Add("ProductsID", value);
        }
        get
        {
            return (int)this.ViewState["ProductsID"];
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        if (Permissions.ProductEditPermission(Page.User.Identity.Name) || ProductsBF.GetProductsBF(this.ProductID).AddedBy == Page.User.Identity.Name)
        {
            ProductsBF product = ProductsBF.GetProductsBF(ProductID);

            if (product != null)
            {
                ProductsBF.Delete(ProductID);
                Response.Redirect("/san-pham/" + product.DepartmentID + "/" + VNString.TextToUrl(DepartmentsBF.GetDepartmentsBF(product.DepartmentID).Title));
            }
        }
    }
}
