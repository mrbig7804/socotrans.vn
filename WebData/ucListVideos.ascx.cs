using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.Utilities.HTML;

public partial class ucListVideos : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<VideosBF> list = VideosBF.GetVideosByCategoryID(CategoryID);

            string[] temp = list[0].VideoUrl.Split(new string[] { "v=", "&" }, StringSplitOptions.RemoveEmptyEntries);
            ltrVideo.Text = (new ParseHTML()).EmbedVideoYoutube(Width, Height, temp[1], AutoPlay);

            //VideosBF.UpdateViewCount(list[0].VideoID);

            list.RemoveAt(0);
            list = list.Take(_maxItem).ToList();

            rptPreVideo.DataSource = list;
            rptPreVideo.DataBind();
        }
    }

    int _maxItem = 5;
    public int MaxItem
    {
        set
        {
            _maxItem = value;
        }
    }

    public int Width { get; set; }

    public int Height { get; set; }

    public int CategoryID { get; set; }

    public bool AutoPlay { get; set; }
}