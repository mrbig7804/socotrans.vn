using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucProductListByDepartment : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<ProductsBF> product = ProductsBF.GetProductsByFilter("", this.SuperDepartmentID, this.DepartmentID, "", 0 , 0, 0);

            if(product.Count > this.MaxItem & this.DepartmentID != 0)
            {
                DepartmentsBF dep = DepartmentsBF.GetDepartmentsBF(this.DepartmentID);

                hplReadmore.Visible = true;
                hplReadmore.NavigateUrl = "/san-pham/" + dep.DepartmentID.ToString() + "/" + VNString.TextToUrl(dep.Title);
            }

            rptProduct.DataSource = product.Take(this.MaxItem).ToList();
            rptProduct.DataBind();
        }
    }

    public int SuperDepartmentID { set; get; }

    public int DepartmentID { set; get; }

    public int MaxItem{ set; get; }

    protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "AddCard")
        {
            int productID = int.Parse(e.CommandArgument.ToString());
            var product = ProductsBF.GetProductsBF(productID);

            if(product.FinalPrice > 0)
            {
                this.Profile.ShoppingCart.InsertItem(product.ProductID, product.Title, product.FinalPrice, product.SmallPictureUrl, 1);
            }

            this.Response.Redirect("/");
        }
    }
}