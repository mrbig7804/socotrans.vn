using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class sanpham1 : System.Web.UI.Page
{
    private int _flag = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            BindDataOnPage();
        }
    }

    void BindDataOnPage()
    {
        if(!string.IsNullOrEmpty(Page.RouteData.Values["departmentID"].ToString()))
        {
            int depID = int.Parse(Page.RouteData.Values["departmentID"].ToString());

            var dep = DepartmentsBF.GetDepartmentsBF(depID);

            lblTitlePage.Text = dep.Title.Trim();

            if (!string.IsNullOrEmpty(dep.Description))
            {
                ltrDescription.Visible = true;
                ltrDescription.Text = "<div class='descPage-product'>" + dep.Description + "</div>";
            }

            //ucFilterProductBrands1.DepartmentID = depID;
            //ucFilterProductPrice1.DepartmentID = depID;
            //ucProductGroupPropertiesByDepartment1.DepartmentID = depID;

            int _brandID = 0;
            int _priceID = 0;
            int _propertyValueID = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["_brand"]))
            {
                _brandID = int.Parse(Request.QueryString["_brand"]);
                _flag = 1;
            }

            if (!string.IsNullOrEmpty(Request.QueryString["_priceDistance"]))
            {
                _priceID = int.Parse(Request.QueryString["_priceDistance"]);
                _flag = 2;
            }

            if (!string.IsNullOrEmpty(Request.QueryString["_propertyV"]))
            {
                _propertyValueID = int.Parse(Request.QueryString["_propertyV"]);
                _flag = 3;
            }

            var products = new List<ProductsBF>();

            switch (_flag)
            { 
                case 0:                                                                                                     //Mặc định lấy SP theo nhóm hàng
                    products = ProductsBF.GetProductsByFilter("", 0, depID, "", 0, 0, 0);
                    break;
                case 1:                                                                                                     //Lọc SP theo nhóm hàng và hãng sản xuất
                    products = ProductsBF.GetProductsByBrandDepartment(_brandID.ToString(), depID);
                    break;
                case 2:                                                                                                     //Lọc SP theo nhóm hàng và mức giá
                    var price = PriceDistanceBF.GetPriceDistanceBF(_priceID);
                    products = ProductsBF.GetProductsByFilter("", 0, depID, "", 0, price.PriceTo, price.PriceFrom);
                    break;
                case 3:                                                                                                     //Lọc SP theo nhóm hàng và thông số chi tiết
                    products = ProductsBF.GetProductsByPropertyValue(_propertyValueID);
                    break;
            }

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