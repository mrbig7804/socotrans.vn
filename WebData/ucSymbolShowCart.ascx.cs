using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucSymbolShowCart : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    protected void LoadData()
    {
        if (Session["Customer"] == null)
            Session["Customer"] = new Customer();

        if (this.Profile.ShoppingCart.Items.Count > 0)
        {
            int amount = 0;
            pnlShowcart.Visible = true;

            ICollection list = this.Profile.ShoppingCart.Items;

            rptCart.DataSource = list;
            rptCart.DataBind();

            foreach (ShoppingCartItem item in list)
            {
                amount += item.TotalItem;
            }

            lblAmount.Text = Zensoft.Website.Configuration.Helpers.PriceFormat(amount);
        }
        else
            pnlMss.Visible = true;
    }

    protected void rptCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int id = int.Parse(DataBinder.Eval(e.Item.DataItem, "ID").ToString());
            ProductsBF product = ProductsBF.GetProductsBF(id);

            if (product != null)
            {
                HyperLink hplProduct = e.Item.FindControl("hplProduct") as HyperLink;
                hplProduct.NavigateUrl = "/san-pham/" + product.UniqueTitle.Trim();
            }

            DropDownList ddlQuantity = e.Item.FindControl("ddlQuantity") as DropDownList;
            ddlQuantity.SelectedValue = DataBinder.Eval(e.Item.DataItem, "Quantity").ToString();
        }
    }

    protected void rptCart_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int cartID = int.Parse(e.CommandArgument.ToString());
            this.Profile.ShoppingCart.DeleteProduct(cartID);

            LoadData();

            if (Request.Url.AbsolutePath.Equals("/default.aspx"))
                Response.Redirect("/");
            else
                Response.Redirect(Request.Url.AbsolutePath);
        }
    }

    protected void lbtnUpdateCart_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rptCart.Items)                                                                                                    //kiểm tra cập nhật lại số lượng cho mỗi sp trong hóa đơn
        {
            int cartD = Int32.Parse((item.FindControl("hdfCartID") as HiddenField).Value);
            int quantity = Convert.ToInt32((item.FindControl("ddlQuantity") as DropDownList).SelectedValue);

            this.Profile.ShoppingCart.UpdateItemQuantity(cartD, quantity);
        }

        if (Request.Url.AbsolutePath.Equals("/default.aspx"))
            Response.Redirect("/");
        else
            Response.Redirect(Request.Url.AbsolutePath);
    }
}