using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.Configuration;
using Zensoft.Website.Toolkit;

public partial class adm_ManageBrands : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtImageWidth.Text = AppConfiguration.BrandWidth.ToString();
            txtImageHeight.Text = AppConfiguration.BrandHeight.ToString();

            hplNavPage.NavigateUrl = "/adm/DepartmentExtension.aspx?depID=" + Request.QueryString["depID"];
            BindFormInfo(0);
        }
    }

    private void BindFormInfo(int id)
    {
        if (id > 0)
        {
            BrandsBF brand = BrandsBF.GetBrandsBF(id);

            hdfId.Value = id.ToString();
            txtTitle.Text = brand.Title;
            txtDesc.Text = brand.Description;
            lblLink.Text = brand.ImageUrl;
            btnInsert.Text = "Cập nhật";

            pnChangeImage.Visible = true;
            pnImage.Visible = false;
        }
        else
        {
            hdfId.Value = "0";
            txtTitle.Text = "";
            txtDesc.Text = "";
            lblLink.Text = "";
            btnInsert.Text = "Thêm mới";

            pnChangeImage.Visible = false;
            pnImage.Visible = true;
        }
    }

    private void DeselectBrand()
    {
        gvwBrand.SelectedIndex = -1;
        gvwBrand.DataBind();

        BindFormInfo(0);
    }

    protected void gvwBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFormInfo(int.Parse(((GridView)sender).SelectedDataKey.Value.ToString()));
    }

    protected void gvwBrand_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        DeselectBrand();
    }

    protected void gvwBrand_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[3].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa hãng sản xuất này?') == false) return false;";
        }
    }

    protected void hplChange_Click(object sender, EventArgs e)
    {
        if (File.Exists(Server.MapPath(lblLink.Text)))
        {
            File.Delete(Server.MapPath(lblLink.Text));
        }

        BrandsBF brand = BrandsBF.GetBrandsBF(int.Parse(hdfId.Value));
        brand.ImageUrl = null;

        brand.Update();
        lblLink.Text = "";
        pnChangeImage.Visible = false;
        pnImage.Visible = true;

        DeselectBrand();
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        string dir = "~/Attachs/Brands/";

        if (!Directory.Exists(Server.MapPath(dir)))
            Directory.CreateDirectory(Server.MapPath(dir));

        if (hdfId.Value != "0")
        {
            BrandsBF brand = BrandsBF.GetBrandsBF(int.Parse(hdfId.Value));

            brand.Title = txtTitle.Text.Trim();
            brand.Description = txtDesc.Text.Trim();

            if (!String.IsNullOrEmpty(lblLink.Text))
            {
                brand.ImageUrl = lblLink.Text;
            }
            else
            {
                string filename = Path.Combine(dir, Guid.NewGuid().ToString()) + Path.GetExtension(fuImage.FileName);

                int width = Convert.ToInt32(txtImageWidth.Text);
                int height = Convert.ToInt32(txtImageHeight.Text);

                fuImage.SaveAs(Server.MapPath(filename));
                Imaging.ResizeCropImage(Server.MapPath(filename), Server.MapPath(filename), width, height);

                brand.ImageUrl = filename;

            }

            brand.Update();
        }
        else
        {
            BrandsBF brand = new BrandsBF();

            if (txtTitle.Text != "") brand.Title = txtTitle.Text.Trim();
            brand.Description = txtDesc.Text.Trim();

            string filename = Path.Combine(dir, Guid.NewGuid().ToString()) + Path.GetExtension(fuImage.FileName);

            int width = Convert.ToInt32(txtImageWidth.Text);
            int height = Convert.ToInt32(txtImageHeight.Text);

            fuImage.SaveAs(Server.MapPath(filename));
            Imaging.ResizeCropImage(Server.MapPath(filename), Server.MapPath(filename), width, height);

            brand.ImageUrl = filename;

            brand.Insert();
        }

        DeselectBrand();
        BindFormInfo(0);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DeselectBrand();
        BindFormInfo(0);
    }

    protected void gvwBrand_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvwBrand.PageIndex = e.NewPageIndex;
        this.gvwBrand.DataBind();

        BindFormInfo(0);
    }
}