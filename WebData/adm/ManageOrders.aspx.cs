using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Globalization;


using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.Configuration;

public partial class adm_ManageOrders : System.Web.UI.Page
{
    static int flag = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            txtPromotion.Text = AppConfiguration.PromotionOrder.ToString();

            BindData();
        }

    }

    private void BindData()
    {
        DateTimeFormatInfo dtf = new DateTimeFormatInfo();
        dtf.ShortDatePattern = "dd/MM/yyyy";

        txtToDate.Text = DateTime.Now.AddDays(7).ToShortDateString();
        txtFromDate.Text = DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0)).ToShortDateString();

        List<OrdersBF> listOrder = new List<OrdersBF>();

        if (flag == 0)
        {
            listOrder = OrdersBF.GetOrdersAll();

        }
        else if (flag == 1)
        {
            listOrder = OrdersBF.GetOrdersByStatusID(Convert.ToInt32(ddlOrderStatuses.SelectedValue), Convert.ToDateTime(txtFromDate.Text, dtf), Convert.ToDateTime(txtToDate.Text, dtf));
        }

        grvBilling.DataSource = listOrder;
        grvBilling.DataBind();
        lblCountOrder.Text = listOrder.Count.ToString();

        BindFormBill(0);
    }

    private void BindFormBill(int orderID)
    {
        if (orderID > 0)
        {
            pnlBill.Visible = true;
            pnlProducts.Visible = true;

            OrdersBF order = OrdersBF.GetOrdersBF(orderID);

            hdfOrderID.Value = order.OrderID.ToString();

            lblOrderId.Text = VNCurrency.orderFormat(orderID);

            ddlStatus.DataBind();
            if(order.StatusID != 0)
                ddlStatus.SelectedValue = order.StatusID.ToString();

            txtReceiverName.Text = order.ShippingFullName;
            txtAddress.Text = order.ShippingAddress.ToString();
            txtNote.Text = order.Description.ToString();
            txtEmail.Text = order.CustomerEmail;
            txtMobile.Text = order.CustomerMoblie;

            VNCurrency cr = new VNCurrency();
            string gross = "";
            int promotion = Convert.ToInt32((float.Parse(order.CustomerPhone)/100) * order.GrossOrder);

            if (order.PaymentMethod.Equals("Nội thành Hải Phòng (COD)"))
            {
                rdbCOD_1.Checked = true;
                rdbCOD_2.Checked = false;
                rdbCOD_3.Checked = false;
                rdbATM_1.Checked = false;
                rdbATM_2.Checked = false;
                lblShipPrice.Text = "<b style='color:#F95037; line-height: 32px'>10.000 đ</b>";
                gross = "<b style='color:#F95037; line-height: 32px'>" + Zensoft.Website.Configuration.Helpers.PriceFormat((order.GrossOrder + 10000)-promotion);
                gross += " (" + cr.stringCurrency((order.GrossOrder + 10000)-promotion) + ")</b>";
            }
            else if (order.PaymentMethod.Equals("Ngoại thành Hải Phòng (COD)"))
            {
                rdbCOD_1.Checked = false;
                rdbCOD_2.Checked = true;
                rdbCOD_3.Checked = false;
                rdbATM_1.Checked = false;
                rdbATM_2.Checked = false;
                lblShipPrice.Text = "<b style='color:#F95037; line-height: 32px'>20.000 đ</b>";
                gross = "<b style='color:#F95037; line-height: 32px'>" + Zensoft.Website.Configuration.Helpers.PriceFormat((order.GrossOrder + 20000)-promotion);
                gross += " (" + cr.stringCurrency((order.GrossOrder + 20000)-promotion) + ")</b>";
            }
            else if (order.PaymentMethod.Equals("Các tỉnh khác (COD)"))
            {
                rdbCOD_1.Checked = false;
                rdbCOD_2.Checked = false;
                rdbCOD_3.Checked = true;
                rdbATM_1.Checked = false;
                rdbATM_2.Checked = false;
                lblShipPrice.Text = "<b style='color:#F95037; line-height: 32px'>30.000 đ</b>";
                gross = "<b style='color:#F95037; line-height: 32px'>" + Zensoft.Website.Configuration.Helpers.PriceFormat((order.GrossOrder + 30000)-promotion);
                gross += " (" + cr.stringCurrency((order.GrossOrder + 30000)-promotion) + ")</b>";
            }
            else if (order.PaymentMethod.Equals("Thành phố Hải Phòng (ATM)"))
            {
                rdbCOD_1.Checked = false;
                rdbCOD_2.Checked = false;
                rdbCOD_3.Checked = false;
                rdbATM_1.Checked = true;
                rdbATM_2.Checked = false;
                lblShipPrice.Text = "<b style='color:#F95037; line-height: 32px'>Free ship</b>";
                gross = "<b style='color:#F95037; line-height: 32px'>" + Zensoft.Website.Configuration.Helpers.PriceFormat(order.GrossOrder - promotion);
                gross += " (" + cr.stringCurrency(order.GrossOrder - promotion) + ")</b>";
            }
            else if (order.PaymentMethod.Equals("Các tỉnh khác (ATM)"))
            {
                rdbCOD_1.Checked = false;
                rdbCOD_2.Checked = false;
                rdbCOD_3.Checked = false;
                rdbATM_1.Checked = false;
                rdbATM_2.Checked = true;
                lblShipPrice.Text = "<b style='color:#F95037; line-height: 32px'>15.000 đ</b>";
                gross = "<b style='color:#F95037; line-height: 32px'>" + Zensoft.Website.Configuration.Helpers.PriceFormat((order.GrossOrder + 15000)-promotion);
                gross += " (" + cr.stringCurrency((order.GrossOrder + 15000)-promotion) + ")</b>";
            }

            lblGrossOrder.Text = gross;

            int qty = 0;
            List<OrderItemsBF> listOrd = OrderItemsBF.GetOrderItemsByOrderID(order.OrderID);

            foreach (OrderItemsBF item in listOrd)
            {
                qty += item.Quantity;
            }

            txtQuantity.Text = qty.ToString();
            lblSale.Text = order.Description;

            if (promotion > 0)
                lblPromotion.Text = "<b style='color:#F95037; line-height: 32px'>" + "-" + Zensoft.Website.Configuration.Helpers.PriceFormat(promotion).ToString() + "</b>";
            else
                lblPromotion.Text = "<b style='color:#F95037; line-height: 32px'>0 đ</b>";

            txtTotal.Text = Zensoft.Website.Configuration.Helpers.PriceFormat(order.Total);
            txtDateShipping.Text = order.AddedDate.ToString("dd/MM/yyyy");

            List<OrderItemsBF> orderItems = OrderItemsBF.GetOrderItemsByOrderID(orderID);

            lblProductInOrder.Text = orderItems.Count.ToString();
            gvwProducts.DataSource = orderItems;
            gvwProducts.DataBind();
        }
        else
        {
            pnlBill.Visible = false;
            pnlProducts.Visible = false;
        }
    }

    protected void btnFilterOrder_Click(object sender, EventArgs e)
    {
        flag = 0; //1;
        BindData();
    }

    protected void btnAllOrder_Click(object sender, EventArgs e)
    {
        flag = 0;
        BindData();
    }

    protected void grvBilling_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdfStatus = e.Row.FindControl("hdfStatus") as HiddenField;
            Label lblStatus = e.Row.FindControl("lblStatus") as Label;

            var ordStt = OrderStatusBF.GetOrderStatusBF(int.Parse(hdfStatus.Value));

            if(ordStt != null)
                lblStatus.Text = ordStt.Title;
        }
    }

    protected void grvBilling_SelectedIndexChanged(object sender, EventArgs e)
    {
        int orderID = Convert.ToInt32(grvBilling.SelectedDataKey.Value);
        BindFormBill(orderID);
    }

    protected void grvBilling_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvBilling.PageIndex = e.NewPageIndex;
        this.BindData();
    }

    protected void grvBilling_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int orderID = (int)grvBilling.DataKeys[e.RowIndex]["OrderID"];

        OrdersBF.Delete(orderID);
        BindData();
    }

    protected void gvwProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int itemID = int.Parse(gvwProducts.DataKeys[e.Row.RowIndex].Values[0].ToString());

            ProductsBF product = ProductsBF.GetProductsBF(OrderItemsBF.GetOrderItemsBF(itemID).ProductID);

            Image imgProduct = e.Row.FindControl("imgProduct") as Image;
            HyperLink hplTitle = e.Row.FindControl("hplTitle") as HyperLink;

            imgProduct.ImageUrl = product.SmallPictureUrl;
            hplTitle.Text = product.Title;
            hplTitle.NavigateUrl = "/adm/product.aspx?action=edit&productID=" + product.ProductID;
        }
    }

    protected void grvBilling_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[6].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa đơn hàng này không?') == false) return false;";
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            int orderID = Convert.ToInt32(hdfOrderID.Value);

            OrdersBF order = OrdersBF.GetOrdersBF(orderID);
            string method = "";

            if (rdbCOD_1.Checked)
                method = "Nội thành Hải Phòng (COD)";
            else if (rdbCOD_2.Checked)
                method = "Ngoại thành Hải Phòng (COD)";
            else if (rdbCOD_3.Checked)
                method = "Các tỉnh khác (COD)";
            else if (rdbATM_1.Checked)
                method = "Thành phố Hải Phòng (ATM)";
            else if (rdbATM_2.Checked)
                method = "Các tỉnh khác (ATM)";

            order.StatusID = int.Parse(ddlStatus.SelectedItem.Value);
            order.PaymentMethod = method;
            order.ShippingFullName = txtReceiverName.Text;
            order.ShippingAddress = txtAddress.Text;
            order.Description = txtNote.Text;
            order.CustomerEmail = txtEmail.Text;
            order.CustomerMoblie = txtMobile.Text;
            order.Update();

            grvBilling_SelectedIndexChanged(new object(), new EventArgs());
        }
        catch
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('Phát sinh ngoại lệ không thể thay đổi thông tin. Xin hãy kiểm tra lại.');</script>");
            BindData();
            return;
        }
    }

    protected void btnSetupOrder_Click(object sender, EventArgs e)
    {
        AppConfiguration.PromotionOrder = txtPromotion.Text;
    }
}
