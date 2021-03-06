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

using Zensoft.Website.Configuration;
using Zensoft.Website.BusinessLayer.BusinessFacade;
using System.Collections.Generic;

public partial class sanpham : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDataOnPage();
        }
    }

    void BindDataOnPage()
    {
        List<ProductsBF> products = ProductsBF.GetProductsAll();

        lvProducts.DataSource = products;
        lvProducts.DataBind();

        if (products.Count > dpProducts.PageSize)
        {
            pnlPager.Visible = true;
        }
    }

    protected void lvProducts_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        dpProducts.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        BindDataOnPage();
    }

    protected void lvProducts_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "AddCard")
        {
            int productID = int.Parse(e.CommandArgument.ToString());
            var product = ProductsBF.GetProductsBF(productID);

            this.Profile.ShoppingCart.InsertItem(product.ProductID, product.Title, product.FinalPrice, product.SmallPictureUrl, 1);
            this.Response.Redirect(Request.Url.AbsolutePath);
        }
    }
}
