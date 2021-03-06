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

using System.Web.Util;
using System.Linq;
using Zensoft.Website.DataLayer.DataObject;
using Zensoft.Website.BusinessLayer.BusinessFacade;

using System.Globalization;
using Zensoft.Website.Security;
using AjaxControlToolkit;
using System.IO;
using Zensoft.Website.UI;
using Zensoft.Website.Configuration;

public partial class admin_ucArticleDetail : System.Web.UI.UserControl
{
    private void BindDropCategory(int superCatId, int parentId, string prefix)
    {
        List<CategoriesBF> cats = CategoriesBF.GetCategoriesBySuperCategoryIDAndParent(superCatId, parentId);

        foreach (CategoriesBF cat in cats)
        {
            if (CategoriesBF.GetCategoriesBySuperCategoryIDAndParent(cat.SuperCategoryID, cat.CategoryID).Count > 0)
            {
                BindDropCategory(superCatId, cat.CategoryID, prefix + cat.Title + " - ");
            }
            else
            {
                ListItem item = new ListItem(prefix + cat.Title, cat.CategoryID.ToString());
                ddlCategories.Items.Add(item);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AsyncFileUpload1.UploadedComplete += new EventHandler<AsyncFileUploadEventArgs>(AsyncFileUpload1_UploadedComplete);
        AsyncFileUpload1.UploadedFileError += new EventHandler<AsyncFileUploadEventArgs>(AsyncFileUpload1_UploadedFileError);
        
        //fckBody.Height
        //fckBody.Skin = "v2";

        if (!IsPostBack)
        {
            //bool inRoles = Permissions.ArticlesApprovedPermission(this.Page.User.Identity.Name);

            //if (!inRoles) panelPublish.Visible = false;

            //chkResize.Visible = Permissions.IsAdministrator(this.Page.User.Identity.Name);

            txtWitdh.Text = AppConfiguration.ArticleImagePreviewMaxWidth.ToString();
            txtHeight.Text = AppConfiguration.ArticleImagePreviewMaxHeight.ToString();


            ddlCategories.Items.Clear();
            BindDropCategory(SuperCategoriesBF.GetSuperCategoriesAll().First().SuperCategoryID, 0, "");

            ArticlesBF article = ArticlesBF.GetArticlesBF(this.ArticleID);

            if (article != null)
            {
                SetArticle(article);
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        Page.RegisterRequiresControlState(this);
        base.OnInit(e);
    }

    /// <summary>
    /// lấy ra trạng thái cũ của control
    /// </summary>
    /// <param name="savedState"></param>
    protected override void LoadControlState(object savedState)
    {
        object[] ctlState = (object[])savedState;
        base.LoadControlState(ctlState[0]);
        this.ArticleID = (int)ctlState[1];
    }

    /// <summary>
    /// lưu lại trạng thái của control
    /// </summary>
    /// <returns></returns>
    protected override object SaveControlState()
    {
        object[] ctlState = new object[2];
        ctlState[0] = base.SaveControlState();
        ctlState[1] = this.ArticleID;
        return ctlState;
    }


    /// <summary>
    /// Lấy thông tin hiện tại về bài viết đang được thể hiện trên giao diện người dùng
    /// </summary>
    /// <returns></returns>
    public ArticlesBF GetArticle()
    {
        DateTimeFormatInfo dtf = new DateTimeFormatInfo(); //Dùng để convert định dạng ngày tháng sang định dạng tiếng Việt
        dtf.ShortDatePattern = "dd/MM/yyyy HH:mm";

        ArticlesBF _articleDetail;

        if (this.ArticleID != 0)
            _articleDetail = ArticlesBF.GetArticlesBF(this.ArticleID);
        else
        {
            _articleDetail = new ArticlesBF();
            _articleDetail.AddedDate = DateTime.Parse(txtAddedDate.Text, dtf);
            _articleDetail.AddedBy = txtAddedBy.Text;
        }

        _articleDetail.ArticleID = this.ArticleID;

        if (String.IsNullOrEmpty(fckBody.Text))
            _articleDetail.Body = " ";
        else
            _articleDetail.Body = fckBody.Text;

        _articleDetail.Title = txtTitle.Text.Trim();
        _articleDetail.Abstract = txtAbstract.Text.Trim();

        _articleDetail.ReleaseDate = DateTime.Parse(txtReleaseDate.Text, dtf);
        _articleDetail.ExpireDate = Convert.ToDateTime(txtExpireDate.Text, dtf);

        //phần xuất bản
        _articleDetail.Listed = chkListed.Checked;
        _articleDetail.Approved = chkApproved.Checked;
        _articleDetail.CommentsEnabled = chkCommentEnable.Checked;
        _articleDetail.OnlyForMembers = chkMemberOnly.Checked;

        _articleDetail.PictureUrl = hiddenPictureUrl.Value;

        _articleDetail.CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);

        return _articleDetail;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="article"></param>
    public void SetArticle(ArticlesBF article)
    {
        txtAddedBy.Text = article.AddedBy;
        txtAddedDate.Text = article.AddedDate.ToString("dd/MM/yyyy HH:mm");

        fckBody.Text = article.Body;

        //if (value.ReleaseDate != null)
        txtReleaseDate.Text = article.ReleaseDate.ToString("dd/MM/yyyy HH:mm");

        //if (value.ExpireDate != null)
        txtExpireDate.Text = article.ExpireDate.ToString("dd/MM/yyyy HH:mm");
        //else txtExpireDate.Text = DateTime.MaxValue.ToString("dd/MM/yyyy HH:mm");

        txtTitle.Text = article.Title;
        txtAbstract.Text = article.Abstract;

        //phần xuất bản
        chkApproved.Checked = article.Approved;
        chkListed.Checked = article.Listed;
        chkMemberOnly.Checked = article.OnlyForMembers;
        chkCommentEnable.Checked = article.CommentsEnabled;

        hiddenPictureUrl.Value = article.PictureUrl;
        imgPreview.ImageUrl = article.PictureUrl;

        if (article.CategoryID != 0) ddlCategories.SelectedValue = article.CategoryID.ToString();
    }

    public string Body
    {
        set
        {
            fckBody.Text = value;
        }
    }

    private int _ArticleID;
    /// <summary>
    /// gán chi tiết về bài viết bằng id của bài viết đó
    /// </summary>
    public int ArticleID
    {
        get { return _ArticleID; }
        set { _ArticleID = value; }
    }

    protected string GetSavePath()
    {
        string path;

        if (ArticleID == 0)

            path = "~/Attachs/picturepreview/";
        else

            path = Globals.ARTICLE_IMAGE_SAVE_PATH + ArticleID.ToString() + "/";

        return path;
    }

    void AsyncFileUpload1_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
    {
        string path;
        string savePath;
        string fileName;


        path = GetSavePath();
        fileName = Path.GetFileName(e.FileName);

        savePath = Server.MapPath(path) + "preview_" + fileName;

        if (!Directory.Exists(Server.MapPath(path)))
            Directory.CreateDirectory(Server.MapPath(path));

        AsyncFileUpload1.SaveAs(savePath);

        int width = Convert.ToInt32(txtWitdh.Text);
        int height = Convert.ToInt32(txtHeight.Text);

        if (chkResize.Checked) Zensoft.Website.Toolkit.Imaging.ResizeCropImage(savePath, savePath, width, height);

        imgPreview.ImageUrl = path + "preview_" + fileName;
        hiddenPictureUrl.Value = path + fileName;

    }

    void AsyncFileUpload1_UploadedFileError(object sender, AsyncFileUploadEventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "error", "top.$get(\"" + uploadResult.ClientID + "\").innerHTML = 'Error: " + e.StatusMessage + "';", true);
    }
}
