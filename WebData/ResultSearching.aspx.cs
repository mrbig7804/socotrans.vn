using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ResultSearching : System.Web.UI.Page
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
        if (!string.IsNullOrEmpty(Request.QueryString["_key"].ToString()))
        {

            string key = Request.QueryString["_key"].ToString();

            List<ProductsBF> products = ProductsBF.GetProductsBySearch(key, 0, 0, 0, 0);

            lvProducts.DataSource = products;
            lvProducts.DataBind();

            if (products.Count > dpProducts.PageSize)
            {
                pnlPager.Visible = true;
            }
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