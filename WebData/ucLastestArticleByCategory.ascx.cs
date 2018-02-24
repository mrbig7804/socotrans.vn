using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucLastestArticleByCategory : System.Web.UI.UserControl
{
    public int CategoryID
    {
        set;
        get;
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

            articles.AddRange(ArticlesBF.GetArticlesPublishedPagedByCategoryID(CategoryID, 0, 1));

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