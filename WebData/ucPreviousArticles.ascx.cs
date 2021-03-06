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

public partial class ucPreviousArticles : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptPreviousArticle.DataSource = ArticlesBF.GetArticlesPublishedPrevious(PreviousArticleID, MaxRow);
            rptPreviousArticle.DataBind();
        }
    }

    public int PreviousArticleID { get; set; }
    public int MaxRow { get; set; }    
}
