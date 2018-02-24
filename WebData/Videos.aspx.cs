using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.Utilities.HTML;

public partial class Videos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Page.RouteData.Values["videoID"].ToString()))
            {
                VideosBF video = VideosBF.GetVideosBF(int.Parse(Page.RouteData.Values["videoID"].ToString()));

                string[] temp = video.VideoUrl.Split(new string[] { "v=", "&" }, StringSplitOptions.RemoveEmptyEntries);
                ltrVideo.Text = (new ParseHTML()).EmbedVideoYoutube(672, 380, temp[1], true);

                VideosBF.UpdateViewCount(video.VideoID);

                List<VideosBF> list = VideosBF.GetVideosConnexion(int.Parse(Page.RouteData.Values["catID"].ToString()), video.VideoID);

                rptListVideo.DataSource = list;
                rptListVideo.DataBind();
            }
            //else
            //{
            //    List<VideosBF> list = VideosBF.GetVideosAll();

            //    string[] temp = list[0].VideoUrl.Split(new string[] { "v=", "&" }, StringSplitOptions.RemoveEmptyEntries);

            //    ltrVideo.Text = (new ParseHTML()).EmbedVideoYoutube(510, 380, temp[1]);

            //    list.RemoveAt(0);

            //    rptListVideo.DataSource = list;
            //    rptListVideo.DataBind();
            //}
        }
    }
}