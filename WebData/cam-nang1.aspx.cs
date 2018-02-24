using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class cam_nang1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindListView();
        }
    }

    void BindListView()
    {
        if (!string.IsNullOrEmpty(Page.RouteData.Values["catID"].ToString()))
        {
            int catID = int.Parse(Page.RouteData.Values["catID"].ToString());

            lblTitle.Text = CategoriesBF.GetCategoriesBF(catID).Title;

            List<ArticlesBF> list = ArticlesBF.GetArticlesByCategoryID(catID);

            lvArticles.DataSource = list;
            lvArticles.DataBind();

            if (list.Count > DataPager1.PageSize)
            {
                pnlPager.Visible = true;
            }
        }
    }

    protected void Image1_DataBinding(object sender, EventArgs e)
    {
        Image temp = sender as Image;
        if (string.IsNullOrEmpty(temp.ImageUrl))
            temp.Visible = false;
    }

    protected void lvArticles_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        BindListView();
    }

    protected string SliptString(string st, int length)
    {
        if (st.Length > length + 10)
        {
            int lastWord = st.IndexOf(' ', length);
            if (lastWord > 0)
                st = st.Substring(0, st.IndexOf(' ', lastWord - 1)) + "...";
            else
                st = st.Substring(0, st.IndexOf(' ', length)) + "...";
        }
        return st;
    }
}