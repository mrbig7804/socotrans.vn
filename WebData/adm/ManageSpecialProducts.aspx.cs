using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Zensoft.Website.BusinessLayer.BusinessFacade;
using System.Collections.Generic;
using System.IO;
using System.Drawing.Imaging;
using System.Globalization;

public partial class adm_ManageSpecialProducts : System.Web.UI.Page
{
    private int flag = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtToDate.Text = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
        }

        BindData();
    }

    private void BindData()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["SpecID"]) && flag != 2) flag = 1;

        List<ProductSpecialsBF> ps = null;

        if (flag == 0)
            ps = ProductSpecialsBF.GetProductSpecialsAll();
        else if (flag == 1)
            ps = ProductSpecialsBF.GetProductSpecialsBySpecialID(int.Parse(Request.QueryString["SpecID"]));
        else if (flag == 2)
        {
            DateTimeFormatInfo dtf = new DateTimeFormatInfo();
            dtf.ShortDatePattern = "dd/MM/yyyy HH:mm";

            int specID = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["SpecID"]))
                specID = int.Parse(Request.QueryString["SpecID"]);

            ps = ProductSpecialsBF.GetProductSpecialsFilter(specID, Convert.ToDateTime(txtFromDate.Text, dtf), Convert.ToDateTime(txtToDate.Text, dtf), int.Parse(ddlStatus.SelectedValue));
        }

        dpProducts.Visible = (ps.Count > dpProducts.PageSize);

        lblCountProduct.Text = ps.Count.ToString();

        gvwProducts.DataSource = ps;
        gvwProducts.DataBind();
    }

    protected void lbtnSearch_Click(object sender, EventArgs e)
    {
        flag = 2;
        BindData();
    }


    protected void gvwProducts_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            int productID = int.Parse(DataBinder.Eval(e.Item.DataItem, "ProductID").ToString());

            Image imgAvatar = e.Item.FindControl("imgAvatar") as Image;
            HyperLink hplTitle = e.Item.FindControl("hplTitle") as HyperLink;
            Label lblView = e.Item.FindControl("lblView") as Label;

            var product = ProductsBF.GetProductsBF(productID);

            imgAvatar.ImageUrl = product.SmallPictureUrl;
            imgAvatar.AlternateText = product.Title;
            hplTitle.Text = product.Title.Trim();
            hplTitle.NavigateUrl = "/san-pham/" + product.UniqueTitle;
            lblView.Text = product.ViewCount.ToString();
        }
    }

    protected void gvwProducts_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            HiddenField hdfSpecialID = e.Item.FindControl("hdfSpecialID") as HiddenField;
            int specID = int.Parse(hdfSpecialID.Value);

            ProductSpecialsBF.Delete(int.Parse(e.CommandArgument.ToString()), specID);
        }

        BindData();
    }

    protected void gvwProducts_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
    }

    protected void gvwProducts_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        dpProducts.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        BindData();
    }

    protected void ckbListed_CheckedChanged(object sender, EventArgs e)
    {
        //CheckBox ckbListed = (CheckBox)sender;
        //GridViewRow rowId = (GridViewRow)ckbListed.NamingContainer;
        //HiddenField hdfProductID = rowId.Cells[0].FindControl("hdfProductID") as HiddenField;
        //HiddenField hdfSpecialID = rowId.Cells[0].FindControl("hdfSpecialID") as HiddenField;

        //var sp = ProductSpecialsBF.GetProductSpecial(int.Parse(hdfProductID.Value), int.Parse(hdfSpecialID.Value));
        //sp.Listed = ckbListed.Checked;

        //sp.Update();

        //BindData();
    }
}
