using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Zensoft.Website.BusinessLayer.BusinessFacade;
using System.Collections.Generic;

public partial class tin_tuc : Zensoft.Website.UI.BasePage
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
        List<ArticlesBF> list = ArticlesBF.GetArticlesByCategoryID(int.Parse(hdfCatID.Value));

        lvArticles.DataSource = list;
        lvArticles.DataBind();

        if (list.Count > DataPager1.PageSize)
        {
            pnlPager.Visible = true;
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
