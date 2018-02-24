using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

using Zensoft.Website.Configuration;
using Zensoft.Website.Toolkit;

public partial class adm_ManageSlideshow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            txtSlideHeight.Text = AppConfiguration.SlideshowHeight.ToString();
            txtSlideWidth.Text = AppConfiguration.SlideshowWidth.ToString();

            BindFormInfo(0);
        }
    }

    private void BindFormInfo(int id)
    { 
        if(id > 0)
        {
            ArticleHighlightsBF article = ArticleHighlightsBF.GetArticleHighlightsBF(id);

            hdfId.Value = id.ToString();
            txtTitle.Text = article.Title;
            if(article.Link != null) txtUrl.Text = article.Link;
            lblLink.Text = article.PictureUrl;
            btnInsert.Text = "Cập nhật";

            pnChangeImage.Visible = true;
            pnImage.Visible = false;
        }
        else
        {
            hdfId.Value = "0";
            txtTitle.Text = "";
            txtUrl.Text = "";
            lblLink.Text = "";
            btnInsert.Text = "Thêm mới";

            pnChangeImage.Visible = false;
            pnImage.Visible = true;
        }
    }

    private void DeselectArticleHighlight()
    {
        gvwArticleHighlights.SelectedIndex = -1;
        gvwArticleHighlights.DataBind();

        BindFormInfo(0);
    }

    protected void gvwArticleHighlights_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFormInfo(int.Parse(((GridView)sender).SelectedDataKey.Value.ToString()));
    }

    protected void gvwArticleHighlights_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        DeselectArticleHighlight();
    }

    protected void gvwArticleHighlights_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[4].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa ảnh slide này không?') == false) return false;";
        }
    }

    protected void ckbListed_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ckbListed = (CheckBox)sender;
        GridViewRow rowId = (GridViewRow)ckbListed.NamingContainer;

        ArticleHighlightsBF ah = ArticleHighlightsBF.GetArticleHighlightsBF(int.Parse(gvwArticleHighlights.DataKeys[rowId.RowIndex].Value.ToString()));
        ah.Listed = ckbListed.Checked;
        ah.Update();

        DeselectArticleHighlight();
    }

    protected void hplChange_Click(object sender, EventArgs e)
    {
        if (File.Exists(Server.MapPath(lblLink.Text)))
        {
            File.Delete(Server.MapPath(lblLink.Text));
        }

        ArticleHighlightsBF article = ArticleHighlightsBF.GetArticleHighlightsBF(int.Parse(hdfId.Value));
        article.Link = null;

        article.Update();
        lblLink.Text = "";
        pnChangeImage.Visible = false;
        pnImage.Visible = true;

        DeselectArticleHighlight();
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        string dir = "~/Attachs/slider/";

        if (!Directory.Exists(Server.MapPath(dir)))
            Directory.CreateDirectory(Server.MapPath(dir));

        if (hdfId.Value != "0")
        {
            ArticleHighlightsBF article = ArticleHighlightsBF.GetArticleHighlightsBF(int.Parse(hdfId.Value));

            article.Title = txtTitle.Text.Trim();
            if (!String.IsNullOrEmpty(txtUrl.Text)) article.Link = txtUrl.Text.Trim();
            else article.Link = null;
            article.IsCurrent = false;
            article.Listed = true;

            if (!String.IsNullOrEmpty(lblLink.Text))
            {
                article.PictureUrl = lblLink.Text;
            }
            else
            {
                string filename = Path.Combine(dir, Guid.NewGuid().ToString()) + Path.GetExtension(fuImage.FileName);

                int width = Convert.ToInt32(txtSlideWidth.Text);
                int height = Convert.ToInt32(txtSlideHeight.Text);

                fuImage.SaveAs(Server.MapPath(filename));
                //Imaging.ResizeCropImage(Server.MapPath(filename), Server.MapPath(filename), width, height);
                Imaging.ResizeImage(Server.MapPath(filename), Server.MapPath(filename), width, height, ImageFormat.Jpeg);

                article.PictureUrl = filename;
            }

            article.Update();
            DeselectArticleHighlight();
            BindFormInfo(0);
        }
        else
        {

            ArticleHighlightsBF article = new ArticleHighlightsBF();

            article.AddedDate = DateTime.Now;
            article.AddedBy = Page.User.Identity.Name;
            if (txtTitle.Text != "") article.Title = txtTitle.Text.Trim();
            else article.Title = "";
            if (txtUrl.Text != "") article.Link = txtUrl.Text.Trim();
            else article.Link = null;
            article.Description = "";

            string filename = Path.Combine(dir, Guid.NewGuid().ToString()) + Path.GetExtension(fuImage.FileName);

            int width = Convert.ToInt32(txtSlideWidth.Text);
            int height = Convert.ToInt32(txtSlideHeight.Text);

            fuImage.SaveAs(Server.MapPath(filename));
            //Imaging.ResizeCropImage(Server.MapPath(filename), Server.MapPath(filename), width, height);
            Imaging.ResizeImage(Server.MapPath(filename), Server.MapPath(filename), width, height, ImageFormat.Jpeg);

            article.PictureUrl = filename;

            article.IsCurrent = false;
            article.Listed = true;

            article.Insert();
            DeselectArticleHighlight();
            BindFormInfo(0);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DeselectArticleHighlight();
        BindFormInfo(0);
    }
}