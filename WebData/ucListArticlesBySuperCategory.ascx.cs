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

using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucListArticlesBySuperCategory : System.Web.UI.UserControl
{
    int _superCategoryID;
    public int SuperCategoryID
    {
        set
        {
            _superCategoryID = value;
        }
    }

    bool _sliptAbstract = true;
    public bool SliptAbstract
    {
        set
        {
            _sliptAbstract = value;
        }
        get
        {
            return _sliptAbstract;
        }
    }

    int _abstractLength = 250;
    public int AbstractLength
    {
        set
        {
            _abstractLength = value;
        }
        get
        {
            return _abstractLength;
        }
    }

     //Cắt bớt độ dài trong mục tóm tăt bài viết
   public string SliptString(string st)
    {
        if (_sliptAbstract & st.Length > _abstractLength + 10)
        {
            int lastWord = st.IndexOf(' ', _abstractLength);
            if (lastWord > 0)
                st = st.Substring(0, st.IndexOf(' ', lastWord - 1)) + "...";
            else
                st = st.Substring(0, st.IndexOf(' ', _abstractLength)) + "...";
        }
        return st;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<ArticlesBF> articles = new List<ArticlesBF>();

            List<CategoriesBF> categories = CategoriesBF.GetCategoriesBySuperCategoryID(_superCategoryID);

            foreach (CategoriesBF c in categories)
            {
                articles.AddRange(ArticlesBF.GetArticlesPublishedPagedByCategoryID(c.CategoryID,0,1));
            }

            dlArticles.DataSource = articles;
            dlArticles.DataBind();
        }
    }

    protected void Image1_DataBinding1(object sender, EventArgs e)
    {
        Image temp = sender as Image;
        if (string.IsNullOrEmpty(temp.ImageUrl))
            temp.Visible = false;
    }
}
