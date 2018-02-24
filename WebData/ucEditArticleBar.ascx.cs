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
using Zensoft.Website.Security;

public partial class ucEditArticleBar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int ArticleID
    {
        set
        {
            if (Permissions.ProductEditPermission(Page.User.Identity.Name) || ArticlesBF.GetArticlesBF(value).AddedBy == Page.User.Identity.Name)
            {
                lnkEdit.NavigateUrl = "~/adm/Articles.aspx?Action=edit&ArticleID=" + value.ToString();
            }
            this.ViewState.Add("ArticleID", value);
        }
        get
        {
            return (int)this.ViewState["ArticleID"];
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        if (Permissions.ProductEditPermission(Page.User.Identity.Name) || ArticlesBF.GetArticlesBF(this.ArticleID).AddedBy == Page.User.Identity.Name)
        {
            ArticlesBF article = ArticlesBF.GetArticlesBF(ArticleID);

            if (article != null)
            {
                article.Delete();
                Response.Redirect("~/");
            }
        }
    }
}
