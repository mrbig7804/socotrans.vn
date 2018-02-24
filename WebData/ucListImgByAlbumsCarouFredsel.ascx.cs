using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucListImgByAlbumsCarouFredsel : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int AlbumID 
    {
        set
        {
            rptImages.DataSource = AlbumImageBF.GetAlbumImageByAlbumID(value);
            rptImages.DataBind();
        }
    }
}