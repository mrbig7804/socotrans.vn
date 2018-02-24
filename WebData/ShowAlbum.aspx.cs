using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ShowAlbum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        string _id = Page.RouteData.Values["albumID"].ToString();

        if (!string.IsNullOrEmpty(_id))
        {
            int albumId = int.Parse(_id);

            var album = AlbumBF.GetAlbumBF(albumId);

            lblTitle.Text = album.Title;
            //lblDate.Text = album.AddedDate.ToString("0:dd/MM/yyyy | HH:mm");
            //ltrDesc.Text = album.Description;

            List<AlbumImageBF> images = AlbumImageBF.GetAlbumImageByAlbumID(albumId);
            rptImages.DataSource = images;
            rptImages.DataBind();

            //List<AlbumBF> albums = AlbumBF.GetAlbumAll();
            //rptAlbumOther.DataSource = albums;
            //rptAlbumOther.DataBind();
        }
        else throw new ApplicationException("Yêu cầu không thể thực hiện vì không tìm thây mã album.");
    }

    protected void rptImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HyperLink hplPreview = (HyperLink)e.Item.FindControl("hplPreview");
            hplPreview.NavigateUrl = DataBinder.Eval(e.Item.DataItem, "MainUrl").ToString();
        }
    }
}