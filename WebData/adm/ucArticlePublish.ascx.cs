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

public partial class admin_ucArticlePublish : System.Web.UI.UserControl
{

    public int ArticleID
    {
        set
        {
            objArticlePublish.SelectParameters["articleID"].DefaultValue = value.ToString();
            dvwArticle.ChangeMode(DetailsViewMode.Edit);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dvwArticle.Enabled = false;
        }
    }
}
