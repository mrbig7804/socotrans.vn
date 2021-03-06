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
using Zensoft.Website.Utilities;
using Zensoft.Website.Security;

using System.Security;


public partial class ShowArticle : Zensoft.Website.UI.BasePage
{
    protected int _articleID;
    bool editable = false;

    private bool Published(ArticlesBF a)
    {
        return (a.Approved && a.ReleaseDate <= DateTime.Now &&
           a.ExpireDate > DateTime.Now);
    }

    string _markKeyword = "";
    private string MarkKeyword
    {
        get
        {
            return _markKeyword;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.Request.QueryString["ID"]))
        {
            string id = Page.RouteData.Values["articleID"] as string;

            if (!string.IsNullOrEmpty(id))
            {
                _articleID = int.Parse(id);
            }
            else throw new ApplicationException("Yêu cầu không thể thực hiện vì không tìm thây mã bài viết.");
        }
        else
            _articleID = int.Parse(this.Request.QueryString["ID"]);


        if (!this.IsPostBack)
        {
            ArticlesBF article = ArticlesBF.GetArticlesBF(_articleID);

            //bài viết không tồn tại
            if (article == null)
            {
                Response.Redirect("~/Error.aspx?code=404");
            }

            //chỉ có những người được phép sửa bài viết và những người tạo ra bài viêt này mới được sửa bài viết
            bool isAdmin = Permissions.IsAdministrator(this.User.Identity.Name);
            editable = (this.User.Identity.IsAuthenticated && isAdmin);

            // kiểm tra bài viết đã xuất bản chưa.
            if (!Published(article))
            {
                //nếu chưa xuất bản thì chỉ những người có quyền duyệt bài viết mới được xem
                if (!editable)
                {
                    Response.Redirect("~/Error.aspx?code=404");
                }
            }

            //EditBar
            UcEditArticleBar1.Visible = editable;
            UcEditArticleBar1.ArticleID = article.ArticleID;

            //// bài viết chỉ dành cho thành viên website
            //if (article.OnlyForMembers && !this.User.Identity.IsAuthenticated)
            //    this.Response.Redirect(FormsAuthentication.LoginUrl +
            //       "?ReturnUrl=" + this.Request.Url.PathAndQuery);

            //đánh dấu từ khóa tìm kiếm
            _markKeyword = this.Request.QueryString["Mark"];
            if (!string.IsNullOrEmpty(_markKeyword))
            {
                article.Body = SearchUtility.MarkKeyword(article.Body, _markKeyword);
                article.Abstract = SearchUtility.MarkKeyword(article.Abstract, _markKeyword);
            }

            //tăng số lần hiện thị trang (viewcount)
            ArticlesBF.IncrementViewCount(_articleID);

            //thêm thẻ description cho header
            this.Header.Description = article.Category.Title + " - " + article.Title + " - " + article.Abstract;

            this.Header.Title = article.Category.Title + " - " + article.Title;

            lblTitle.Text = article.Title;

            lblDate.Text = article.ReleaseDate.ToString("dd/MM/yyyy hh:mm tt");
            lblView.Text = article.ViewCount.ToString();

            //lblAddedBy.Text = article.AddedBy;

            lblAbstract.Text = article.Abstract;
            lblBody.Text = article.Body;

            //Các bài viết đã đăng
            ucPreviousArticles1.PreviousArticleID = article.ArticleID;

            ////Comment
            //UcComments1.ArticleID = article.ArticleID;
            //panComment.Visible = article.CommentsEnabled;


        }
    }
}
