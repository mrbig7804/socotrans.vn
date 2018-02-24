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

using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class adm_UploadProductPictureList : Zensoft.Website.UI.BasePage
{

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "DeleteImage")
        {
            int imageID;
            int.TryParse(e.CommandArgument.ToString(), out imageID);

            if (imageID != 0)
            {
                ProductImagesBF image = ProductImagesBF.GetProductImagesBF(imageID);

                if (File.Exists(Server.MapPath(image.SmallImage)))
                    File.Delete(Server.MapPath(image.SmallImage));

                if (File.Exists(Server.MapPath(image.MedImage)))
                    File.Delete(Server.MapPath(image.MedImage));

                if (File.Exists(Server.MapPath(image.FullImage)))
                    File.Delete(Server.MapPath(image.FullImage));

                image.Delete();

                Response.Redirect(Request.Url.ToString());

            }
        }
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }

    private void BindData()
    {
        string dir = "~/Temp/" + this.User.Identity.Name + "/ItemImage/";

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
                try
                {

                    //kiểm tra xem có quyền xóa file trong bài viết hay không 
                    if (e.CommandArgument.ToString().ToLower().IndexOf("/temp/" + User.Identity.Name.ToLower() + "/") > 0)
                    {
                        File.Delete(Server.MapPath(e.CommandArgument.ToString()));
                        BindData();
                    }
                    else return;

                }
                catch
                { }
        }
    }
}
