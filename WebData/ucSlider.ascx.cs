using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucSlider : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptSlider.DataSource = ArticleHighlightsBF.GetArticleHighlightsListed();
            rptSlider.DataBind();
        }
    }

    protected void rptSlider_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        HyperLink hplSlider = (HyperLink)e.Item.FindControl("hplSlider");

        if (DataBinder.Eval(e.Item.DataItem, "Link") != null)
        {
            hplSlider.NavigateUrl = DataBinder.Eval(e.Item.DataItem, "Link").ToString();
        }
    }
}