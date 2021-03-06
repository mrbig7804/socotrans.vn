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

//using Zensoft.Website.DataLayer.DataObject;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class GetRSS: Zensoft.Website.UI.BasePage
{
    private string _rssTitle = "Tin mới nhất";

    public string RssTitle
    {
        get { return _rssTitle; }
        set { _rssTitle = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int superCategoryID;
        int categoryID;

        if (int.TryParse(this.Request.QueryString["ID"], out superCategoryID))
        {
            GetSuperCategoryRSS(superCategoryID);
        }
        else if (int.TryParse(this.Request.QueryString["CategoryID"], out categoryID))
        {
            GetCategoryRSS(categoryID);
        }
        else GetNewestArticle();
    }

    private void GetNewestArticle()
    {
        _rssTitle = "Bài viết mới nhất";

        rptRss.DataSource = ArticlesBF.GetArticlesPublishedPaged(0, 15);
        rptRss.DataBind();

    }

    private void GetSuperCategoryRSS(int superCategoryID)
    {
        _rssTitle = SuperCategoriesBF.GetSuperCategoriesBF(superCategoryID).Title;

        rptRss.DataSource = ArticlesBF.GetArticlesPublishedPagedBySuperCategoryID(superCategoryID, 0, 10);
        rptRss.DataBind();
    }

    private void GetCategoryRSS(int categoryID)
    {
        CategoriesBF category = CategoriesBF.GetCategoriesBF(categoryID);
        _rssTitle = category.Title;

        rptRss.DataSource = ArticlesBF.GetArticlesPublishedPagedByCategoryIDAndParentCategoryID(categoryID, 0, 10);
        rptRss.DataBind();
    }

}
