using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.UI;

public partial class Controls_ucProductImagePreview : System.Web.UI.UserControl
{
    protected void dlImageThumbnail_Load(object sender, EventArgs e)
    {
        //if (dlImageThumbnail.Items.Count <= 1) dlImageThumbnail.Visible = false;
    }

    int _productID;
    public int ProductID
    {
        set
        {
            _productID = value;
            DisplayImage();
        }
        get
        {
            return _productID;

        }
    }
    public string BaseUrl
    {
        get
        {
            string url = this.Request.ApplicationPath;
            if (url.EndsWith("/"))
                return url;
            else
                return url + "/";
        }
    }

    public void DisplayImage()
    {
        List<ProductImagesBF> images = ProductImagesBF.GetProductImagesByProductID(ProductID);

        if (images.Count > 0)
        {

            imgImagePreview.ImageUrl = images[0].MedImage;

            dlImageThumbnail.DataSource = images;
            dlImageThumbnail.DataBind();

            if (images.Count <= 1) dlImageThumbnail.Visible = false;
            else dlImageThumbnail.Visible = true;


            string imageindex = "var arrImagePreview = new Array(";

            foreach (var i in images)
            {
                imageindex = imageindex + "\"" + GetPath(i.MedImage) + "\",";
            }
            imageindex = imageindex.Remove(imageindex.Length - 1);

            imageindex = imageindex + "); var arrLargeImagePreview = new Array(";
            foreach (var i in images)
            {
                imageindex = imageindex + "\"" + GetPath(i.FullImage) + "\",";
            }
            imageindex = imageindex.Remove(imageindex.Length - 1);
            imageindex = imageindex + ");";

            imageindex = imageindex + "document.getElementById('lnkLargePic').href=arrLargeImagePreview[0];";


            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), imageindex, true);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string GetPath(string path)
    {
        if (string.IsNullOrEmpty(path)) return path;
        if (path[0] == '~')
            return Globals.ApplicationPath + path.Remove(0, 1);
        else return path;
    }

    int i = 0;
    protected void rptImageThumbnail_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        HyperLink link = (HyperLink)e.Item.FindControl("lnkSmallImage");
        link.NavigateUrl = "javaScript:RollOver('" + i.ToString() + "')";
        i++;
    }
}
