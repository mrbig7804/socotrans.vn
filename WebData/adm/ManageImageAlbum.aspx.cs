using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Zensoft.Website.BusinessLayer.BusinessFacade;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using Zensoft.Website.Toolkit;
using Zensoft.Website.Configuration;

public partial class adm_ManageImageAlbum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtImageWidth.Text = AppConfiguration.AlbumImageMainWidth.ToString();
            txtImageHeight.Text = AppConfiguration.AlbumImageMainHeight.ToString();

            BindFormInfoAlbum(0);
        }
    }

    void BindFormInfoAlbum(int albumID)
    {
        hdfAlbumID.Value = albumID.ToString();

        if (albumID == 0)
        {
            lblTitleAlbum.Text = "Thông tin album";

            txtTitleAlbum.Text = "";
            txtDescAlbum.Text = "";

            lbtnUpdateAlbum.Text = "Thêm mới";

            grvAlbums.SelectedIndex = -1;
            grvAlbums.DataBind();

            pnlGridImage.Visible = false;
            pnlInfoImage.Visible = false;
        }
        else
        {
            AlbumBF alb = AlbumBF.GetAlbumBF(albumID);

            lblTitleAlbum.Text = alb.Title;
            txtTitleAlbum.Text = alb.Title;
            txtDescAlbum.Text = alb.Description;

            lbtnUpdateAlbum.Text = "Cập nhật";

            pnlGridImage.Visible = true;
            pnlInfoImage.Visible = true;

            BindGridImages(albumID);
            BindFormInfoImage(0);

            gvwImages.SelectedIndex = -1;
            gvwImages.DataBind();
        }

        grvAlbums.DataBind();
    }

    protected void grvAlbums_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BindFormInfoAlbum(0);
    }

    protected void grvAlbums_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFormInfoAlbum(int.Parse(((GridView)sender).SelectedDataKey.Value.ToString()));
    }

    protected void grvAlbums_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[5].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa album ảnh này?') == false) return false;";
        }
    }

    protected void grvAlbums_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAlbums.PageIndex = e.NewPageIndex;
        this.grvAlbums.DataBind();

        BindFormInfoAlbum(int.Parse(hdfAlbumID.Value));
    }

    protected void ckbPublished_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ckbListed = (CheckBox)sender;
        GridViewRow rowId = (GridViewRow)ckbListed.NamingContainer;

        AlbumBF alb = AlbumBF.GetAlbumBF(int.Parse(grvAlbums.DataKeys[rowId.RowIndex].Value.ToString()));
        alb.Listed = ckbListed.Checked;
        alb.Update();

        BindFormInfoAlbum(int.Parse(hdfAlbumID.Value));
    }

    protected void lbtnUpdateAlbum_Click(object sender, EventArgs e)
    {
        AlbumBF alb = null;

        if(int.Parse(hdfAlbumID.Value) == 0)
        {
            alb = new AlbumBF();

            alb.Title = txtTitleAlbum.Text.Trim();
            alb.Description = txtDescAlbum.Text;
            alb.AddedDate = DateTime.Now;
            alb.Listed = true;
            alb.PictureUrl = "";

            BindFormInfoAlbum(alb.Insert());
        }
        else
        {
            alb = AlbumBF.GetAlbumBF(int.Parse(hdfAlbumID.Value));

            alb.Title = txtTitleAlbum.Text.Trim();
            alb.Description = txtDescAlbum.Text;

            alb.Update();

            BindFormInfoAlbum(int.Parse(hdfAlbumID.Value));
        }
    }

    protected void lbtnCancleAlbum_Click(object sender, EventArgs e)
    {
        BindFormInfoAlbum(0);
    }

    void BindGridImages(int albumID)
    {
        var albImage = AlbumImageBF.GetAlbumImageByAlbumID(albumID);

        gvwImages.DataSource = albImage;
        gvwImages.DataBind();

        lblTitleGridAlbumImage.Text = "&nbsp;" + AlbumBF.GetAlbumBF(albumID).Title;
        lblCountAlbumImage.Text = albImage.Count.ToString();
    }

    void BindFormInfoImage(int albImageID)
    {
        if (albImageID == 0)
        {
            hdfImageId.Value = albImageID.ToString();
            txtTitleImage.Text = "";
            txtDescImage.Text = "";
            pnlImageUrl.Visible = true;

            lbtnUpdateImage.Text = "Thêm mới";
        }
        else
        { 
            AlbumImageBF ai = AlbumImageBF.GetAlbumImageBF(albImageID);

            hdfImageId.Value = ai.ImageId.ToString();
            txtTitleImage.Text = ai.Title;
            txtDescImage.Text = ai.Description;
            pnlImageUrl.Visible = false;

            lbtnUpdateImage.Text = "Cập nhật";
        }
    }

    protected void gvwImages_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFormInfoImage(int.Parse(((GridView)sender).SelectedDataKey.Value.ToString()));
    }

    protected void gvwImages_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[4].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa ảnh này?') == false) return false;";
        }
    }

    protected void gvwImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int aiID = (int)gvwImages.DataKeys[e.RowIndex]["ImageId"];

        AlbumImageBF.Delete(aiID);

        BindFormInfoAlbum(int.Parse(hdfAlbumID.Value));
    }

    protected void gvwImages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvwImages.PageIndex = e.NewPageIndex;
        this.gvwImages.DataBind();

        BindFormInfoAlbum(int.Parse(hdfAlbumID.Value));
    }

    protected void ckbListed_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ckbListed = (CheckBox)sender;
        GridViewRow rowId = (GridViewRow)ckbListed.NamingContainer;

        AlbumImageBF ai = AlbumImageBF.GetAlbumImageBF(int.Parse(gvwImages.DataKeys[rowId.RowIndex].Value.ToString()));
        ai.IsMain = true;
        ai.Update();

        AlbumBF alb = AlbumBF.GetAlbumBF(int.Parse(hdfAlbumID.Value));
        alb.PictureUrl = ai.PreviewUrl;
        alb.Update();

        var listAi = AlbumImageBF.GetAlbumImageDynamic("[ImageId] != " + ai.ImageId + "AND [AlbumId] = " + alb.AlbumId, "[AddedDate] DESC");

        foreach (AlbumImageBF item in listAi)
        {
            item.IsMain = false;
            item.Update();
        }

        BindFormInfoAlbum(int.Parse(hdfAlbumID.Value));
    }

    protected void lbtnUpdateImage_Click(object sender, EventArgs e)
    {
        string dir = "/Attachs/AlbumImage/";

        if (!Directory.Exists(Server.MapPath(dir)))
            Directory.CreateDirectory(Server.MapPath(dir));

        AlbumImageBF ai = null;

        if (hdfImageId.Value == "0")
        {
            ai = new AlbumImageBF();
            ai.AlbumId = int.Parse(hdfAlbumID.Value);
            ai.Title = txtTitleImage.Text.Trim();
            ai.Description = txtDescImage.Text.Trim();
            ai.AddedDate = DateTime.Now;
            ai.IsMain = false;

            string itemDir = dir + hdfAlbumID.Value + "/";

            if (!Directory.Exists(Server.MapPath(itemDir)))
                Directory.CreateDirectory(Server.MapPath(itemDir));

            string source = Path.Combine(itemDir, Path.GetFileNameWithoutExtension(fuImage.FileName)) + Path.GetExtension(fuImage.FileName);
            fuImage.SaveAs(Server.MapPath(source));

            string url = Path.Combine(itemDir, Guid.NewGuid().ToString());
            string previewUrl = url + "(preview).jpg";
            string mainUrl = url + ".jpg";

            Imaging.ResizeCropImage(Server.MapPath(source), Server.MapPath(previewUrl), AppConfiguration.AlbumImagePreviewWidth, AppConfiguration.AlbumImagePreviewHeight);
            Imaging.ResizeImage(Server.MapPath(source), Server.MapPath(mainUrl), AppConfiguration.AlbumImageMainWidth, AppConfiguration.AlbumImageMainHeight, ImageFormat.Jpeg);

            File.Delete(Server.MapPath(source));

            ai.PreviewUrl = previewUrl;
            ai.MainUrl = mainUrl;

            ai.Insert();

        }
        else
        {
            ai = AlbumImageBF.GetAlbumImageBF(int.Parse(hdfImageId.Value));
            ai.Title = txtTitleImage.Text.Trim();
            ai.Description = txtDescImage.Text.Trim();

            ai.Update();
        }

        BindFormInfoAlbum(int.Parse(hdfAlbumID.Value));
    }

    protected void lbtnCancleImage_Click(object sender, EventArgs e)
    {
        BindFormInfoAlbum(int.Parse(hdfAlbumID.Value));
    }
}