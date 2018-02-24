using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucListArticlesImage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptArticles.DataSource = ArticlesBF.GetArticlesByCategoryID(this.CategoryID).Take(this.MaxItem).ToList();
            rptArticles.DataBind();
        }
    }

    public int MaxItem { get; set; }

    public int CategoryID { get; set; }

    public bool SplitTitle { get; set; }

    public int LengthTitle { get; set; }

    public string SliptString(string st)
    {
        if (this.SplitTitle & st.Length > this.LengthTitle)
        {
            int lastWord = st.IndexOf(' ', this.LengthTitle);

            if (lastWord > 0)
                st = st.Substring(0, st.IndexOf(' ', lastWord - 1)) + "...";
            else
                st = st.Substring(0, st.IndexOf(' ', this.LengthTitle)) + "...";
        }

        return st;
    }
}