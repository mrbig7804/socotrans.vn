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
using Zensoft.Website.Security;
using System.Collections.Generic;
using Zensoft.Website.UI;
using System.Text.RegularExpressions;

public partial class ShowItem : System.Web.UI.Page, IShowItemDisplay
{
    public string ProductTitle { get; set; }

    public int ProductID { get; set; }

    protected void ShowDetail(ProductsBF product)
    {
        //tiêu đề trang
        var dep = DepartmentsBF.GetDepartmentsBF(product.DepartmentID);

        //thêm thẻ description cho header
        Page.Header.Description = dep.Title + product.Title + " Giá: " + product.UnitPrice.ToString() + " " + product.Description;
        Page.Header.Title = Page.Header.Title + " - " + product.Title;

        hplDepartment.Text = dep.Title;
        hplDepartment.NavigateUrl = "/san-pham/" + dep.DepartmentID + "/" + VNString.TextToUrl(dep.Title);

        //lblTitlePage.Text = product.Title.Trim();

        //chỉ tài khoản có quyền administrators mới sử dụng được chức năng này
        bool isAdmin = Permissions.IsAdministrator(this.User.Identity.Name);
        bool editable = (this.User.Identity.IsAuthenticated && isAdmin);

        ucEditProductBar1.Visible = editable;
        ucEditProductBar1.ProductID = product.ProductID;

        // kiểm tra sản phẩm còn được bán không.
        if (product.Discontinued)
        {
            //nếu không thì chỉ có người có quyền mới được xem mặt hàng này
            if (!editable)
            {
                Response.Redirect("~/Error.aspx?code=404");
            }
        }

        if (product.FinalPrice > 0)
            pnlCart.Visible = true;
        else
            pnlCart.Visible = false;

        int buyItem = OrderItemsBF.GetCountOrderItemsByProductID(product.ProductID);

        if (buyItem > 0)
        {
            pnlBuy.Visible = true;
            lblBuyItem.Text = buyItem.ToString();
        }
        else
            pnlBuy.Visible = false;


        ucProductRelate1.ProductID = product.ProductID;
    }

    protected void ShowItemDetail(ProductsBF product)
    {
        UcProductImagePreview1.ProductID = product.ProductID;

        lblViews.Text = product.ViewCount.ToString();

        lblTitle.Text = product.Title.ToUpper();
        lblAddedDate.Text = product.AddedDate.ToString("dd/MM/yyyy");

        //if(!string.IsNullOrEmpty(product.Brand))
        //    lblBrand.Text = BrandsBF.GetBrandsBF(int.Parse(product.Brand)).Title;

        lblBrand.Text = product.Brand;
        lblProductCode.Text = product.ProductCode;

        DepartmentsBF dep = DepartmentsBF.GetDepartmentsBF(product.DepartmentID);
        lblDepartment.Text = dep.Title;

        lblPrice.Text = Zensoft.Website.Configuration.Helpers.PriceFormat(Convert.ToInt32(product.UnitPrice), Convert.ToInt32(product.SalePrice));

        if (product.SalePrice > 0)
        {
            lblSale.Visible = true;
            lblSale.Text = "-" + Zensoft.Website.Configuration.Helpers.Approximate(((float)(Convert.ToInt32(product.UnitPrice) - Convert.ToInt32(product.SalePrice)) / Convert.ToInt32(product.UnitPrice)) * 100) + "%";
        }
        else
            lblSale.Visible = false;

        if (!product.Discontinued) lblDis.Text = "Còn hàng";
        else lblDis.Text = "Hết hàng";

        lblDescription.Text = Zensoft.Website.Utils.Text2Html(product.Description);

        lblDetail.Text = product.Details;

        //tăng số lần hiển thị
        product.IncrementViewCount();

        ucEditProductBar1.ProductID = product.ProductID;
        //ucProductGroupProperties1.ProductID = product.ProductID;

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                ProductID = Convert.ToInt32(Request.QueryString["ID"]);
                var product = ProductsBF.GetProductsBF(ProductID);

                if (product == null) Response.Redirect("~/error.aspx?code= 404");

                ShowDetail(product);
                ShowItemDetail(product);
            }
            else if (ProductTitle != "")
            {
                var product = ProductsBF.GetProductByUniqueTitle(ProductTitle);

                if (product == null) Response.Redirect("~/error.aspx?code=404");

                ProductID = product.ProductID;

                ShowDetail(product);
                ShowItemDetail(product);
            }
            else Response.Redirect("~/error.aspx");
        }
    }

    protected void lbntAddCart_Click(object sender, EventArgs e)
    {
        if (ProductTitle != "")
        {
            var product = ProductsBF.GetProductByUniqueTitle(ProductTitle);
            if (product == null) Response.Redirect("~/error.aspx?code=404");

            int qty = int.Parse(ddlQuantity.SelectedItem.Value);

            this.Profile.ShoppingCart.InsertItem(product.ProductID, product.Title, product.FinalPrice, product.SmallPictureUrl, qty);

            this.Response.Redirect(Request.Url.AbsolutePath);
        }
    }

    protected void lbnNowCart_Click(object sender, EventArgs e)
    {
        if (ProductTitle != "")
        {
            var product = ProductsBF.GetProductByUniqueTitle(ProductTitle);
            if (product == null) Response.Redirect("~/error.aspx?code=404");

            int qty = int.Parse(ddlQuantity.SelectedItem.Value);

            this.Profile.ShoppingCart.InsertItem(product.ProductID, product.Title, product.FinalPrice, product.SmallPictureUrl, qty);

            this.Response.Redirect("/thanh-toan-don-hang", false);
        }
    }
}
