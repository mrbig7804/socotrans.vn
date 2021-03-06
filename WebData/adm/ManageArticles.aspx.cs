using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.Configuration;
using Zensoft.Website.Toolkit;

public partial class admin_ManageArticles : System.Web.UI.Page
{
    private int flag = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCateHeight.Text = AppConfiguration.ArticleCategoryHeight.ToString();
            txtCatWidth.Text = AppConfiguration.ArticleCategoryWidth.ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["catID"]) & !string.IsNullOrEmpty(Request.QueryString["i"]))
            {
                var cat = CategoriesBF.GetCategoriesBF(int.Parse(Request.QueryString["catID"]));

                if (Request.QueryString["i"] == "up")
                    cat.IncreaseImportance();

                if (Request.QueryString["i"] == "down")
                    cat.ReducedImportance();

                Response.Redirect(Request.Url.AbsolutePath);
            }
            
            BindFormCategory();
        }
    }

    void BindGridArticle(int supCatID, int catID)
    {
        List<ArticlesBF> listArt = null;

        switch (flag)
        { 
            case 0:
                listArt = ArticlesBF.GetArticlesAll();
                break;
            case 1:
                listArt = ArticlesBF.GetArticlesBySuperCategoryID(supCatID);
                break;
            case 2:
                listArt = ArticlesBF.GetArticlesByCategoryID(catID);
                break;
        }

        lblCountArticle.Text = listArt.Count.ToString();

        grvArticles.DataSource = listArt;
        grvArticles.DataBind();
    }

    private void BindFormCategory()
    {
        int catID = 0;

        if (!string.IsNullOrEmpty(Request.QueryString["catID"]))
            catID = int.Parse(Request.QueryString["catID"]);

        hdfCat.Value = catID.ToString();

        if (catID != 0)
        {
            CategoriesBF cat = CategoriesBF.GetCategoriesBF(catID);

            lblTitleCat.Text = cat.Title;
            txtTitle.Text = cat.Title;
            txtDescription.Text = cat.Description;
            txtImageUrl.Text = cat.ImageUrl;
            lbtnUpdate.Text = "Cập nhật";
            lbtnDel.Visible = true;

            BindDropChildren(cat.SuperCategoryID, 0);
            ddlChildren.SelectedValue = cat.ParentCategoryID.ToString();

            if (cat.ImageUrl != "")
            {
                txtImageUrl.Text = cat.ImageUrl;

                pnImage.Visible = false;
                pnChangeImage.Visible = true;
            }
            else
            {
                pnImage.Visible = true;
                pnChangeImage.Visible = false;
            }

            flag = 2;
            BindGridArticle(0, catID);

            pnlArticles.Visible = true;
        }
        else
        {
            lblTitleCat.Text = "Thông tin thư mục";
            txtTitle.Text = "";
            txtDescription.Text = "";

            BindDropChildren(SuperCategoriesBF.GetSuperCategoriesAll().First().SuperCategoryID, 0);

            txtImageUrl.Text = "";
            lbtnUpdate.Text = "Thêm mới";
            lbtnDel.Visible = false;

            pnImage.Visible = true;
            pnChangeImage.Visible = false;

            pnlArticles.Visible = false;
        }

        rptSuperCat.DataBind();
    }

    string BindTreeCategory(List<CategoriesBF> _cats)
    {
        StringBuilder result = new StringBuilder();

        if (_cats.Count > 0)
        {
            result.Append("<ul>");

            foreach (CategoriesBF cat in _cats)
            {
                result.Append("<li style='position: relative'>");
                result.Append("<div class='treeNode'>");
                result.Append("<a href='/adm/ManageArticles.aspx?catID=" + cat.CategoryID + "'>" + cat.Title + "</a>");
                result.Append("<span class='important'>");
                result.Append("<a href='/adm/ManageArticles.aspx?catID=" + cat.CategoryID + "&i=up' title='Up'><span class='up_btn' /></a>");
                result.Append("<a href='/adm/ManageArticles.aspx?catID=" + cat.CategoryID + "&i=down' title='Down'><span class='down_btn' /></a>");
                result.Append("</span>");
                result.Append("</div>");

                List<CategoriesBF> _subCats = CategoriesBF.GetCategoriesByParentCategoryID(cat.CategoryID);

                if (_subCats.Count > 0)
                {
                    result.Append(BindTreeCategory(_subCats));
                }
            }

            result.Append("</li></ul>");
        }

        return result.ToString();
    }

    private void BindDropChildren(int superID, int parent)
    {
        ddlChildren.Items.Clear();
        ddlChildren.Items.Add(new ListItem("Nhóm bài viết gốc", "0"));
        BindDropChildren(superID, parent, "-");
    }

    private void BindDropChildren(int superCatID, int parentID, string prefix)
    {
        List<CategoriesBF> _cats = CategoriesBF.GetCategoriesBySuperCategoryIDAndParent(superCatID, parentID);

        if (_cats.Count > 0)
        {
            foreach (CategoriesBF cat in _cats)
            {
                ListItem subitem = new ListItem(prefix + " " + cat.Title, cat.CategoryID.ToString());
                ddlChildren.Items.Add(subitem);

                BindDropChildren(superCatID, cat.CategoryID, prefix + "-");
            }
        }
    }

    protected void rptSuperCat_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int superCat = int.Parse(DataBinder.Eval(e.Item.DataItem, "SuperCategoryID").ToString());

            Literal ltrCat = e.Item.FindControl("ltrCat") as Literal;

            ltrCat.Text = BindTreeCategory(CategoriesBF.GetCategoriesBySuperCategoryIDAndParent(superCat, 0));
        }
    }

    protected void hplChange_Click(object sender, EventArgs e)
    {
        if (File.Exists(Server.MapPath(txtImageUrl.Text)))
        {
            File.Delete(Server.MapPath(txtImageUrl.Text));
        }

        if (hdfCat.Value != "0")
        {
            CategoriesBF cat = CategoriesBF.GetCategoriesBF(int.Parse(hdfCat.Value));
            cat.ImageUrl = "";

            cat.Update();
            txtImageUrl.Text = "";
            pnChangeImage.Visible = false;
            pnImage.Visible = true;
        }
    }

    protected void lbtnUpdate_Click(object sender, EventArgs e)
    {
        if (hdfCat.Value != "0")
        {
            CategoriesBF cat = CategoriesBF.GetCategoriesBF(int.Parse(hdfCat.Value));

            cat.Title = txtTitle.Text;
            cat.Description = txtDescription.Text;
            cat.ParentCategoryID = int.Parse(ddlChildren.SelectedValue);

            if (txtImageUrl.Text != "")
            {
                cat.ImageUrl = txtImageUrl.Text.Trim();
            }
            else
            {
                if (fuImage.HasFile)
                {
                    string dir = "/Attachs/Categories/";
                    if (!Directory.Exists(Server.MapPath(dir)))
                        Directory.CreateDirectory(Server.MapPath(dir));

                    string name = VNString.TextToUrl(txtTitle.Text.Trim());
                    string fullPath = Path.Combine(dir, name) + Path.GetExtension(fuImage.FileName);
                    int i = 0;

                    while (File.Exists(Server.MapPath(fullPath)))
                    {
                        i++;
                        name = VNString.TextToUrl(txtTitle.Text.Trim()) + "-" + i.ToString();
                        fullPath = Path.Combine(dir, name) + Path.GetExtension(fuImage.FileName);
                    }

                    fuImage.SaveAs(Server.MapPath(fullPath));
                    Imaging.ResizeCropImage(Server.MapPath(fullPath), Server.MapPath(fullPath), AppConfiguration.ArticleCategoryWidth, AppConfiguration.ArticleCategoryHeight);

                    cat.ImageUrl = fullPath;
                }
                else
                {
                    cat.ImageUrl = "";
                }
            }

            cat.Update();
            UpdateForChildren(cat);
        }
        else
        {
            CategoriesBF cat = new CategoriesBF();

            cat.AddedDate = DateTime.Now;
            cat.AddedBy = Page.User.Identity.Name;
            cat.Title = txtTitle.Text;
            cat.SuperCategoryID = SuperCategoriesBF.GetSuperCategoriesAll().First().SuperCategoryID;
            cat.ParentCategoryID = int.Parse(ddlChildren.SelectedValue);

            if (fuImage.HasFile)
            {
                string dir = "/Attachs/Categories/";
                if (!Directory.Exists(Server.MapPath(dir)))
                    Directory.CreateDirectory(Server.MapPath(dir));

                string name = VNString.TextToUrl(txtTitle.Text.Trim());
                string fullPath = Path.Combine(dir, name) + Path.GetExtension(fuImage.FileName);
                int i = 0;

                while (File.Exists(Server.MapPath(fullPath)))
                {
                    i++;
                    name = VNString.TextToUrl(txtTitle.Text.Trim()) + "-" + i.ToString();
                    fullPath = Path.Combine(dir, name) + Path.GetExtension(fuImage.FileName);
                }

                fuImage.SaveAs(Server.MapPath(fullPath));
                Imaging.ResizeCropImage(Server.MapPath(fullPath), Server.MapPath(fullPath), AppConfiguration.ArticleCategoryWidth, AppConfiguration.ArticleCategoryHeight);

                cat.ImageUrl = fullPath;
            }
            else
            {
                cat.ImageUrl = "";
            }

            cat.Insert();
        }

        BindFormCategory();
    }

    private void UpdateForChildren(CategoriesBF parentCat)
    {
        List<CategoriesBF> cats = CategoriesBF.GetCategoriesByParentCategoryID(parentCat.CategoryID);

        if (cats != null)
        {
            foreach (CategoriesBF cat in cats)
            {
                cat.SuperCategoryID = parentCat.SuperCategoryID;

                UpdateForChildren(cat);
            }
        }
    }

    protected void lbtnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsolutePath);
    }

    protected void lbtnDel_Click(object sender, EventArgs e)
    {
        if (hdfCat.Value != "0")
        {
            int cat = int.Parse(hdfCat.Value);

            if (CategoriesBF.GetCategoriesByParentCategoryID(cat).Count == 0 && ArticlesBF.GetArticlesByCategoryID(cat).Count == 0)
                CategoriesBF.Delete(cat);
            else
                Response.Write("<script>alert('ERROR! Không thể xóa vì vẫn tồn tại bài viết hoặc nhóm thư mục con trong thư mục này.');</script>");
        }

        Response.Redirect(Request.Url.AbsolutePath);
    }

    protected void grvArticles_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvArticles.PageIndex = e.NewPageIndex;
        this.grvArticles.DataBind();

        BindFormCategory();
    }

    protected void grvArticles_RowDeleting(Object sender, GridViewDeleteEventArgs e)
    {
        int articleId = (int)grvArticles.DataKeys[e.RowIndex]["ArticleID"];

        ArticlesBF.Delete(articleId);

        BindFormCategory();
    }
}
