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

public partial class adm_Smiley : System.Web.UI.Page
{


    private void DeselectSuperCategory()
    {
        gvwSuperCategories.SelectedIndex = -1;
        gvwSuperCategories.DataBind();
        dvwSuperCategory.ChangeMode(DetailsViewMode.Insert);
    }

    protected void gvwSuperCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        dvwSuperCategory.ChangeMode(DetailsViewMode.Edit);
    }

    protected void gvwSuperCategories_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        DeselectSuperCategory();
    }
    protected void gvwSuperCategories_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[5].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa Biểu tượng này?') == false) return false;";
        }
    }
    protected void dvwSuperCategory_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        DeselectSuperCategory();
    }
    protected void dvwSuperCategory_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        DeselectSuperCategory();
    }
    protected void dvwSuperCategory_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
            DeselectSuperCategory();
    }

    protected void dvwSuperCategory_ItemCreated(object sender, EventArgs e)
    {
        foreach (Control ctl in dvwSuperCategory.Rows[dvwSuperCategory.Rows.Count - 1].Controls[0].Controls)
        {
            if (ctl is LinkButton)
            {
                LinkButton lnk = ctl as LinkButton;
                if (lnk.CommandName == "Insert" || lnk.CommandName == "Update")
                    lnk.ValidationGroup = "SuperCategory";
            }
        }
    }

    public string FileUrl
    {
        get
        {
            return "~/images/emoticons/";
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }

    private void BindData()
    {


        if (!Directory.Exists(Server.MapPath(FileUrl))) return;

        string[] files = Directory.GetFiles(Server.MapPath(FileUrl));

        for (int i = 0; i < files.Length; i++)
        {
            FileInfo fi = new FileInfo(files[i]);
            files[i] = fi.Name;
        }

        rptAttachedFiles.DataSource = files;
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
            Label l = (Label)e.Item.FindControl("lblFileName");

            if (File.Exists((Server.MapPath(FileUrl + l.Text))))
                try
                {
                    //int articleID = Convert.ToInt32(Request["ArticleID"]);
                    //ArticlesBF article = ArticlesBF.GetArticlesBF(articleID);

                    ////kiểm tra xem có quyền xóa hay không
                    //if (article.AddedBy == User.Identity.Name || Permissions.ArticlesEditPermission(User.Identity.Name))
                    //{

                        File.Delete(Server.MapPath(FileUrl + l.Text));
                        BindData();
                    //}
                }
                catch
                { }
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fuSmiley.PostedFile != null && fuSmiley.PostedFile.ContentLength > 0)
        {
            // lấy tên file
            string fileUrl = FileUrl + "/" + Path.GetFileName(fuSmiley.PostedFile.FileName);

            int i = 0;
            string existFile = fileUrl;
            string filename = fileUrl.Substring(0, fileUrl.LastIndexOf("."));
            string fileExtention = fileUrl.Substring(fileUrl.LastIndexOf("."), fileUrl.Length - fileUrl.LastIndexOf("."));

            //thử xem đã tồn tại file trùng tên ko

            while (File.Exists(Server.MapPath(existFile)))
            {
                i++;
                existFile = filename + "(" + i.ToString() + ")" + fileExtention;
            }

            fuSmiley.PostedFile.SaveAs(Server.MapPath(existFile));

            BindData();
        }
    }
}
