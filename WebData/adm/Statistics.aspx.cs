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

public partial class adm_Statistics : System.Web.UI.Page
{
    private MembershipUserCollection allAcc = Membership.GetAllUsers();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblTotal.Text = allAcc.Count.ToString();
        lblUserOnline.Text = "";
        lblAccOnline.Text = Membership.GetNumberOfUsersOnline().ToString();

        int total = ArticlesBF.GetTotalArticle();
        lblTotalArticles.Text = Convert.ToString(total);

        lblUserOnline.Text =    Application["UserOnline"].ToString() ;
        lblUserVisited.Text =  Application["UserVisited"].ToString() ;

        
    }
}
