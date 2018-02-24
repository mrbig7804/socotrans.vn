using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class adm_ManageMemberProducts : System.Web.UI.Page
{
    int flag = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        BindGridProduct();
    }

    void BindGridProduct()
    {
        string memmber = "";

        if(!String.IsNullOrEmpty(Request.QueryString["member"]))
        {
            flag = 1;
            memmber = Request.QueryString["member"];
        }

        var products = new List<ProductsBF>();

        switch (flag)
        { 
            case 0:
                products = ProductsBF.GetProductsAll();
                lblTitleGridProduct.Text = "Tất cả sản phẩm";
                break;
            case 1:
                products = ProductsBF.GetProductsByUserName(memmber, 0);
                lblTitleGridProduct.Text = "Sản phẩm của " + memmber;
                break;
        }

        lblCountProduct.Text = products.Count.ToString();
        gvwProducts.DataSource = products;
        gvwProducts.DataBind();
    }


    protected void gvwProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ProductsBF.Delete((int) gvwProducts.DataKeys[e.RowIndex]["ProductID"]);
    }

    protected void gvwProducts_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        gvwProducts.SelectedIndex = -1;
        this.gvwProducts.DataBind();
    }

    protected void gvwProducts_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[5].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa sp này không?') == false) return false;";
        }
    }

    protected void ckbListed_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ckbListed = (CheckBox)sender;
        GridViewRow rowId = (GridViewRow)ckbListed.NamingContainer;

        //ProductsBF product = ProductsBF.GetProductsBF(int.Parse(rowId.Cells[0].Text));
        ProductsBF product = ProductsBF.GetProductsBF(int.Parse(gvwProducts.DataKeys[rowId.RowIndex].Value.ToString()));
        product.Listed = ckbListed.Checked;
        product.Update();

        this.gvwProducts.DataBind();
    }

    protected void gvwProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvwProducts.PageIndex = e.NewPageIndex;
        this.gvwProducts.DataBind();
    }
}