using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucSymbolCart : System.Web.UI.UserControl
{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int amount = 0;

                foreach (ShoppingCartItem item in this.Profile.ShoppingCart.Items)
                    amount += item.Quantity;

                if (amount > 0)
                {
                    lblTotalCard.Visible = true;
                    lblTotalCard.Text = amount.ToString();
                }
            }
        }
}