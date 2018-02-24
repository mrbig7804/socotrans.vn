using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.Security;

public partial class ucViewArticle : System.Web.UI.UserControl
{
    bool _showTitle = false;
    public bool ShowTitle
    {
        get
        {
            return _showTitle;
        }
        set { _showTitle = value; }
    }

    bool _showAbstract = false;
    public bool ShowAbstract
    {
        get
        {
            return _showAbstract;
        }
        set { _showAbstract = value; }
    }

    bool _showImage = false;
    public bool ShowImage
    {
        get
        {
            return _showImage;
        }
        set { _showImage = value; }
    }

    bool _showBody = false;
    public bool ShowBody
    {
        get
        {
            return _showBody;
        }
        set { _showBody = value; }
    }
    bool _showReadMore = false;
    public bool ShowReadMore
    {
        get
        {
            return _showReadMore;
        }
        set { _showReadMore = value; }
    }

    int _articleID = 0;
    public int ArticleID
    {
        get
        {
            return _articleID;
        }
        set { _articleID = value; }
    }
    bool _showDeleteButton = false;
    public bool ShowDeleteButton
    {
        get
        {
            return _showDeleteButton;
        }
        set { _showDeleteButton = value; }
    }

    int _bodyLength = 0;
    public int AbstractLength
    {
        set
        {
            _bodyLength = value;
        }
        get
        {
            return _bodyLength;
        }
    }

    bool _editable = true;
    public bool Editable
    {
        set
        {
            _editable = value;
        }
        get
        {
            return _editable;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        panTitle.Visible = ShowTitle;
        panImage.Visible = ShowImage;
        panAbstract.Visible = ShowAbstract;
        panBody.Visible = ShowBody;
        panReadmore.Visible = ShowReadMore;

        ArticlesBF article = ArticlesBF.GetArticlesBF(ArticleID);

        if (article == null)
        {
            this.Visible = false;
            return;
        }

        lblBody.Text = article.Body;
        lblAbstract.Text = article.Abstract;
        lblTitle.Text = article.Title;
        imgImage.ImageUrl = article.PictureUrl;

        lnkReadMore.Text = "Xem Thêm";
        lnkReadMore.NavigateUrl = "/bai-viet/" + article.ArticleID.ToString() + "/" + VNString.TextToUrl(article.Title);
        lblTitle.NavigateUrl = "/bai-viet/" + article.ArticleID.ToString() + "/" + VNString.TextToUrl(article.Title);

        //chỉ có những người được phép sửa bài viết và những người tạo ra bài viêt này mới được sửa bài viết
        bool inRole = Permissions.ArticlesEditPermission(this.Page.User.Identity.Name) || article.AddedBy == this.Page.User.Identity.Name;
        bool editable = (this.Page.User.Identity.IsAuthenticated && inRole);


        //EditBar
        ucEditArticleBar1.Visible = editable && this.Editable;
        ucEditArticleBar1.ArticleID = article.ArticleID;

    }
}