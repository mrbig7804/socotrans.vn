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

using System.IO;
using System.Security;

using Zensoft.Website.Security;
using Zensoft.Website.BusinessLayer.BusinessFacade;


public partial class adm_AttachedFileArticle : Zensoft.Website.UI.BasePage
{
    string _fileUrl;
    public string FileUrl
    {
        get
        {
            return _fileUrl;
        }
        set
        {
            _fileUrl = value;
        }
    }

    public string GetFullUrl(string url)
    {
        return url.Replace("~/", this.FullBaseUrl); 
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }

    private void BindData()
    {
        string dir = "~/Attachs/";

        if (this.Request["ArticleID"] != null)
            dir = dir +"Articles/" + this.Request["ArticleID"] + "/";
        else if (this.Request["questionID"] != null)
            dir = dir + "Quiz/" + this.Request["questionID"] + "/";
        else return;

        FileUrl = dir;

        if (!Directory.Exists(Server.MapPath(dir))) return;

        string[] files = Directory.GetFiles(Server.MapPath(dir));

        lblTotalFile.Text = files.Length.ToString() + " File";

        Hashtable fileList = new Hashtable();

        for (int i = 0; i < files.Length; i++)
        {
            FileInfo fi = new FileInfo(files[i]);
            fileList.Add(fi.Name, fi.Length.ToString());
        }

        rptAttachedFiles.DataSource = fileList;
        rptAttachedFiles.DataBind();

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void rptAttachedFiles_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
    }
    protected void rptAttachedFiles_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Image imgPreview = (Image)e.Item.FindControl("imgPreview");
        Image imgUnknowFile = (Image)e.Item.FindControl("imgUnknowFile");

        if(imgPreview != null)
        {
            string s = imgPreview.ImageUrl;
            int i = s.LastIndexOf(".");
            string fileExtension = "";
            if (i>0) 
             fileExtension = imgPreview.ImageUrl.Remove(0,i).ToLower();

            if (fileExtension == ".jpg" || fileExtension == ".bmp" || fileExtension == ".gif" || fileExtension == ".png")
            {
                imgPreview.Visible = true;
                imgUnknowFile.Visible = false;
            }
            else imgPreview.Visible = false;
        }

    }
    protected void rptAttachedFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName== "DeleteAttachedFile")
        {
            if ( File.Exists ((Server.MapPath(e.CommandArgument.ToString()))))
                try
                {
                    int articleID;
                    //xóa bài file đính kèm bài viết
                    if (this.Request["ArticleID"] != null) 
                    {
                        articleID = Convert.ToInt32(Request["ArticleID"]);
                        ArticlesBF article = ArticlesBF.GetArticlesBF(articleID);

                        //kiểm tra xem có quyền xóa file trong bài viết hay không 
                        if (article.AddedBy == User.Identity.Name || Permissions.ArticlesEditPermission(User.Identity.Name))
                        {
                            File.Delete(Server.MapPath(e.CommandArgument.ToString()));
                            BindData();
                        }
                    }

                    else return;
                }
                catch{ }
        }
    }
}
