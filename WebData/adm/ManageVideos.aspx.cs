using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class adm_ManageVideos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["vCatId"]) & !string.IsNullOrEmpty(Request.QueryString["i"]))
            {
                var vCategory = VCategoriesBF.GetVCategoriesBF(int.Parse(Request.QueryString["vCatId"]));

                if (Request.QueryString["i"] == "up")
                    vCategory.IncreaseImportance();

                if (Request.QueryString["i"] == "down")
                    vCategory.ReducedImportance();

                Response.Redirect(Request.Url.AbsolutePath);
            }

            BindFormCatVideo();
        }
    }

    private string BindTreeCategories(List<VCategoriesBF> _items)
    {
        StringBuilder result = new StringBuilder();

        if (_items.Count > 0)
        {
            result.Append("<ul id='browse_tree'>");

            foreach (VCategoriesBF item in _items)
            {
                result.Append("<li style='position: relative'>");
                result.Append("<div class='treeNode'>");
                result.Append("<a href='ManageVideos.aspx?vCatId=" + item.CategoryID + "'>" + item.Title + "</a>");
                result.Append("<span class='important'>");
                result.Append("<a href='/adm/ManageVideos.aspx?vCatId=" + item.CategoryID + "&i=up' title='Up'><span class='up_btn' /></a>");
                result.Append("<a href='/adm/ManageVideos.aspx?vCatId=" + item.CategoryID + "&i=down' title='Down'><span class='down_btn' /></a>");
                result.Append("</span>");
                result.Append("</div>");

                List<VCategoriesBF> _subItems = VCategoriesBF.GetVCategoriesByParentID(item.CategoryID);

                if (_subItems.Count > 0)
                {
                    result.Append(BindTreeCategories(_subItems));
                }
            }

            result.Append("</li></ul>");
        }

        return result.ToString();
    }

    private void BindFormCatVideo()
    {
        int catID = 0;

        if (!String.IsNullOrEmpty(Request.QueryString["vCatId"]))
            catID = int.Parse(Request.QueryString["vCatId"]);

        ltrCat.Text = BindTreeCategories(VCategoriesBF.GetVCategoriesByParentID(0));
        BindDropCatVideo(0, ddlParent);

        if(catID == 0)
        {
            hdfCat.Value = catID.ToString();

            lblTitleCVideo.Text = "Thông tin thư mục";
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtImageUrl.Text = "";
            lbtnUpdate.Text = "Thêm mới";
            lbtnDel.Visible = false;

            pnlGridVideos.Visible = false;
            pnlInfoVideo.Visible = false;
        }
        else if (catID > 0)
        {
            VCategoriesBF cat = VCategoriesBF.GetVCategoriesBF(catID);

            lblTitleCVideo.Text = cat.Title;

            hdfCat.Value = cat.CategoryID.ToString();
            txtTitle.Text = cat.Title;
            txtDescription.Text = cat.Description;
            txtImageUrl.Text = cat.ImageUrl;
            lbtnUpdate.Text = "Cập nhật";
            lbtnDel.Visible = true;

            ddlParent.SelectedValue = cat.ParentID.ToString();

            pnlGridVideos.Visible = true;
            pnlInfoVideo.Visible = true;
            BindGridVideos(catID);
        }
    }

    private void BindDropCatVideo(int parentId, DropDownList ddl)
    {
        ddlParent.Items.Clear();
        ddlParent.Items.Add(new ListItem("Thư mục gốc", "0"));
        BindDropCatVideo(parentId, "-", ddl);
    }

    private void BindDropCatVideo(int parentId, string prefix, DropDownList ddl)
    {
        List<VCategoriesBF> _items = VCategoriesBF.GetVCategoriesByParentID(parentId);

        if (_items.Count > 0)
        {
            foreach (VCategoriesBF _item in _items)
            {
                ListItem item = new ListItem(prefix + " " + _item.Title, _item.CategoryID.ToString());
                ddl.Items.Add(item);

                BindDropCatVideo(_item.CategoryID, prefix + "-", ddl);
            }
        }
    }

    protected void lbtnUpdate_Click(object sender, EventArgs e)
    {
        if (hdfCat.Value != "0")
        {
            VCategoriesBF item = VCategoriesBF.GetVCategoriesBF(int.Parse(hdfCat.Value));

            item.Title = txtTitle.Text;
            item.Description = txtDescription.Text;
            item.ImageUrl = txtImageUrl.Text;
            item.ParentID = int.Parse(ddlParent.SelectedValue);

            item.Update();
        }
        else
        {
            VCategoriesBF item = new VCategoriesBF();

            item.Title = txtTitle.Text;
            item.AddedDate = DateTime.Now;
            item.AddedBy = Page.User.Identity.Name;
            item.Important = 1;
            item.Description = txtDescription.Text;
            item.ImageUrl = txtImageUrl.Text;
            item.ParentID = int.Parse(ddlParent.SelectedValue);

            int result = item.Insert();
        }

        BindFormCatVideo();
    }

    protected void lbtnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsolutePath);
    }

    protected void lbtnDel_Click(object sender, EventArgs e)
    {
        int catID = int.Parse(hdfCat.Value);

        if(VideosBF.GetVideosByCategoryID(catID).Count == 0)
        {
            VCategoriesBF.Delete(int.Parse(hdfCat.Value));
            Response.Redirect(Request.Url.AbsolutePath);
        }
        else
            Response.Write("<script> alert('ERROR! Không thể xóa vì vẫn tồn tại video hoặc thư mục con trong thư mục này.'); </script>");
    }

    private List<VideosBF> BindGridVideos(int catID, List<VideosBF> result)
    {
        List<VCategoriesBF> listC = VCategoriesBF.GetVCategoriesByParentID(catID);

        if (listC != null)
        {
            foreach (VCategoriesBF itemC in listC)
            {
                List<VideosBF> listV = VideosBF.GetVideosByCategoryID(itemC.CategoryID);

                if (listV != null)
                {
                    foreach (VideosBF itemV in listV)
                    {
                        result.Add(itemV);
                    }
                }

                BindGridVideos(itemC.CategoryID, result);
            }
        }

        return result;
    }

    private void BindGridVideos(int catID)
    {
        List<VideosBF> videos = VideosBF.GetVideosByCategoryID(catID);
        videos = BindGridVideos(catID, videos);

        lblTitleGridVideo.Text = "&nbsp;" + VCategoriesBF.GetVCategoriesBF(catID).Title;

        grvVideos.DataSource = videos;
        grvVideos.DataBind();

        lblCountVideo.Text = videos.Count.ToString();

        BindFormVideo(0);
    }

    private void BindFormVideo(int videoId)
    {
        if (videoId != 0)
        {
            VideosBF video = VideosBF.GetVideosBF(videoId);

            hdfVideo.Value = video.VideoID.ToString();
            txtTitleVideo.Text = video.Title;
            txtDescVideo.Text = video.Description;
            txtVideoUrl.Text = video.VideoUrl;
            lbtnUpdateVideo.Text = "Cập nhật";

            ddlCatVideo.Items.Clear();
            BindDropCatVideo(0, "", ddlCatVideo);
            ddlCatVideo.SelectedValue = video.CategoriesID.ToString();
        }
        else
        {
            hdfVideo.Value = videoId.ToString();
            txtTitleVideo.Text = "";
            txtDescVideo.Text = "";
            txtVideoUrl.Text = "";
            lbtnUpdateVideo.Text = "Thêm mới";

            ddlCatVideo.Items.Clear();
            BindDropCatVideo(0, "", ddlCatVideo);
            ddlCatVideo.SelectedValue = hdfCat.Value;
        }
    }

    protected void grvVideos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvVideos.PageIndex = e.NewPageIndex;
        this.grvVideos.DataBind();

        BindFormCatVideo();
    }

    protected void grvVideos_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFormVideo(int.Parse(((GridView)sender).SelectedDataKey.Value.ToString()));
    }

    protected void grvVideos_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[5].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa video này?') == false) return false;";
        }
    }

    protected void grvVideos_RowDeleting(Object sender, GridViewDeleteEventArgs e)
    {
        int videoId = (int)grvVideos.DataKeys[e.RowIndex]["VideoID"];

        VideosBF.Delete(videoId);

        BindFormCatVideo();
        BindGridVideos(int.Parse(hdfCat.Value));
    }

    protected void ckbPublished_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ckbListed = (CheckBox)sender;
        GridViewRow rowId = (GridViewRow)ckbListed.NamingContainer;

        VideosBF video = VideosBF.GetVideosBF(int.Parse(grvVideos.DataKeys[rowId.RowIndex].Value.ToString()));
        video.Published = ckbListed.Checked;
        video.Update();
    }

    protected void lbtnUpdateVideo_Click(object sender, EventArgs e)
    {
        if (hdfVideo.Value != "0")
        {
            VideosBF item = VideosBF.GetVideosBF(int.Parse(hdfVideo.Value));

            item.Title = txtTitleVideo.Text;
            item.AddedDate = DateTime.Now;
            item.AddedBy = Page.User.Identity.Name;
            item.Description = txtDescVideo.Text;
            item.VideoUrl = txtVideoUrl.Text.Trim();

            string[] temp = txtVideoUrl.Text.Trim().Split(new string[] { "v=", "&" }, StringSplitOptions.RemoveEmptyEntries);
            item.ImageUrl = "http://img.youtube.com/vi/" + temp[1] + "/2.jpg";

            item.CategoriesID = int.Parse(ddlCatVideo.SelectedValue);

            item.Update();

            BindGridVideos(int.Parse(hdfCat.Value));
            BindFormVideo(int.Parse(hdfVideo.Value));
        }
        else
        {
            VideosBF item = new VideosBF();

            item.Title = txtTitleVideo.Text;
            item.AddedDate = DateTime.Now;
            item.AddedBy = Page.User.Identity.Name;
            item.Important = 1;
            item.Description = txtDescVideo.Text;
            item.VideoUrl = txtVideoUrl.Text.Trim();

            string[] temp = txtVideoUrl.Text.Trim().Split(new string[] { "v=", "&" }, StringSplitOptions.RemoveEmptyEntries);
            item.ImageUrl = "http://img.youtube.com/vi/" + temp[1] + "/2.jpg";

            item.ViewCount = 1;
            item.Published = true;
            item.CategoriesID = int.Parse(ddlCatVideo.SelectedValue);

            int result = item.Insert();

            BindGridVideos(int.Parse(hdfCat.Value));
            BindFormVideo(result);
        }
    }

    protected void lbtnCancleVideo_Click(object sender, EventArgs e)
    {
        BindFormVideo(0);

        grvVideos.SelectedIndex = -1;
        BindGridVideos(int.Parse(hdfCat.Value));
    }
}