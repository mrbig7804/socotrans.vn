using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.Configuration;

public partial class ShoppingCart : System.Web.UI.Page
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
        if (this.Profile.ShoppingCart.Items.Count > 0)                                                             //kiểm tra thông tin giỏ hàng còn lưu trong session k0 (sesion lưu thông tin trong vòng 24h)
        {
            int count = 0;
            pnlMss.Visible = false;

            ICollection list = this.Profile.ShoppingCart.Items;                                                    //load dữ liệu giỏ hàng từ session

            rptCart.DataSource = list;
            rptCart.DataBind();

            foreach (ShoppingCartItem item in list)
                count += item.Quantity;

            lblCountProduct.Text = "(" + count.ToString() + " sản phẩm)";

            if (Session["Customer"] == null)                                                                       //kiểm tra có thông tin khách hàng trong sesion k
            {
                Session["Customer"] = new Customer();                                                              //chưa có thì tạo mới
            }
            else
            {
                ProfileCommon profile = this.Profile;                                                              //nếu có thông tin thì load dữ liệu ra form
                Customer cus = (Customer)Session["Customer"];

                try
                {
                    if (cus != null)
                    {
                        txtCusName.Text = cus.Name.ToString();
                        txtCusMobile.Text = cus.Mobile.ToString();
                        txtCusEmail.Text = cus.Email.ToString();
                        txtCusAddress.Text = cus.Street.ToString(); ;
                    }
                    else
                    {
                        if (!HttpContext.Current.Profile.IsAnonymous)
                        {
                            MembershipUser customer = Membership.GetUser(this.Profile.UserName);

                            txtCusName.Text = profile.FullName;
                            txtCusMobile.Text = profile.Mobile;
                            txtCusAddress.Text = profile.Address;
                            txtCusEmail.Text = customer.Email;
                        }
                    }
                }
                catch
                {
                    if (!HttpContext.Current.Profile.IsAnonymous)
                    {
                        MembershipUser customer = Membership.GetUser(this.Profile.UserName);

                        txtCusName.Text = profile.FullName;
                        txtCusMobile.Text = profile.Mobile;
                        txtCusAddress.Text = profile.Address;
                        txtCusEmail.Text = customer.Email;
                    }
                    else
                        return;
                }

                lblCusName.Text = txtCusName.Text;
                lblCusMobile.Text = txtCusMobile.Text;
                lblCusEmail.Text = txtCusEmail.Text;
                lblCusAddress.Text = txtCusAddress.Text;
            }
        }
        else
            Response.Redirect("/");
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

    protected void lbtnPay_Click(object sender, EventArgs e)
    {
        Customer customer = (Customer)Session["Customer"];                                                                                              //Lưu lại thông tin khách hàng vào session
        customer.AddCustomer(txtCusName.Text.Trim(), txtCusEmail.Text.Trim(), "", txtCusMobile.Text.Trim(), txtCusAddress.Text.Trim(), "", "");


        foreach (RepeaterItem item in rptCart.Items)                                                                                                    //kiểm tra cập nhật lại số lượng cho mỗi sp trong hóa đơn
        {
            int cartID = Int32.Parse((item.FindControl("hdfCartID") as HiddenField).Value);
            int quantity = Convert.ToInt32((item.FindControl("txtQty") as TextBox).Text);

            this.Profile.ShoppingCart.UpdateItemQuantity(cartID, quantity);
        }

        string name = txtCusName.Text.Trim(); //lblCusName.Text.Trim();
        string mobile = txtCusMobile.Text.Trim(); //lblCusMobile.Text.Trim();
        string email = txtCusEmail.Text.Trim(); //lblCusEmail.Text.Trim();
        string address = txtCusAddress.Text.Trim(); //lblCusAddress.Text.Trim();
        string note = txtNote.Text.Trim(); //lblCusAddress.Text.Trim();
        string paymentMethods = "";

        if (rdbCOD_1.Checked)
            paymentMethods = "Nội thành Hải Phòng (COD)";
        else if (rdbCOD_2.Checked)
            paymentMethods = "Ngoại thành Hải Phòng (COD)";
        else if (rdbCOD_3.Checked)
            paymentMethods = "Các tỉnh khác (COD)";
        else if (rdbATM_1.Checked)
            paymentMethods = "Thành phố Hải Phòng (ATM)";
        else if (rdbATM_2.Checked)
            paymentMethods = "Các tỉnh khác (ATM)";

        int orderID = OrdersBF.Insert(this.Profile.ShoppingCart, paymentMethods, "", name, address, "", email, AppConfiguration.PromotionOrder, mobile, note);         //lưu đơn hàng vào CSDL
        this.Profile.ShoppingCart.Clear();                                                                                              //xóa toàn bộ thông tin đơn hàng vừa gia dịch

        Response.Redirect("/gui-don-hang?_stt=succ");
    }

}
