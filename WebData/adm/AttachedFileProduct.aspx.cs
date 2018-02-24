using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using Zensoft.Website.Security;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class adm_AttachedFileProduct : Zensoft.Website.UI.BasePage
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
        {
            BindData();
        }
    }

    private void BindData()
    {
        string dir = "~/Attachs/";

        if (this.Request["ProductID"] != null)
            dir = dir + "Items/" + this.Request["ProductID"] + "/";
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

        if (imgPreview != null)
        {
            string s = imgPreview.ImageUrl;
            int i = s.LastIndexOf(".");
            string fileExtension = "";
            if (i > 0)
                fileExtension = imgPreview.ImageUrl.Remove(0, i).ToLower();

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
        if (e.CommandName == "DeleteAttachedFile")
        {
            //Label l = (Label)e.Item.FindControl("lblFileName");

            if (File.Exists((Server.MapPath(e.CommandArgument.ToString()))))
                try
                {
                    int productID;
                    //xóa bài file đính kèm bài viết
                    if (this.Request["ProductID"] != null)
                    {
                        productID = Convert.ToInt32(Request["ProductID"]);
                        ProductsBF product = ProductsBF.GetProductsBF(productID);
                        //kiểm tra xem có quyền xóa file trong bài viết hay không 
                        if (product.AddedBy == User.Identity.Name || Permissions.ArticlesEditPermission(User.Identity.Name))
                        {
                            File.Delete(Server.MapPath(e.CommandArgument.ToString()));
                            BindData();
                        }
                    }
                    else return;

                }
                catch
                { }
        }
    }
}