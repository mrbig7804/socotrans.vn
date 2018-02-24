using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;
using System.IO;
using System.Collections;

public partial class person_UploadProductPictureList : Zensoft.Website.UI.BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }

    public string FileUrl
    {
        get;
        set;
    }

    public string GetFullUrl(string url)
    {
        return url.Replace("~/", this.FullBaseUrl);
    }

    private void BindData()
    {
        string dir;

        if (!string.IsNullOrEmpty(this.User.Identity.Name))
        {
            dir = "~/Temp/" + this.User.Identity.Name + "/ItemImage/";
        }
        else 
        {
            dir = "~/Temp/ItemImage/";
        }

        FileUrl = dir;

        if (!Directory.Exists(Server.MapPath(dir))) return;

        string[] files = Directory.GetFiles(Server.MapPath(dir));

        Hashtable fileList = new Hashtable();

        for (int i = 0; i < files.Length; i++)
        {
            FileInfo fi = new FileInfo(files[i]);
            fileList.Add(fi.Name, fi.Length.ToString());
        }

        rptAttachedFiles.DataSource = fileList;
        rptAttachedFiles.DataBind();

    }

    protected void rptAttachedFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteAttachedFile")
        {
            if (File.Exists((Server.MapPath(e.CommandArgument.ToString()))))
                //try
                //{
                //    //kiểm tra xem có quyền xóa file trong bài viết hay không 
                //    if (e.CommandArgument.ToString().ToLower().IndexOf("/temp/" + User.Identity.Name.ToLower() + "/") > 0)
                //    {
                        File.Delete(Server.MapPath(e.CommandArgument.ToString()));
                        BindData();
                //    }
                //    else return;
                //}
                //catch{ }
        }
    }
}