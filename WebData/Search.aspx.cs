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
using System.Text;

using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.Utilities;
using System.Globalization;

public partial class Search: Zensoft.Website.UI.BasePage
{
    string _keyword;
    public string Keyword
    {
        set
        {
            _keyword = value;
            ViewState.Add("Keyword", _keyword);
        }
        get
        {
            if (string.IsNullOrEmpty(_keyword) && ViewState["Keyword"] != null)
                _keyword = ViewState["Keyword"].ToString();
            return _keyword;
        }
    }


    private List<ArticlesBF> articles;

    protected override void OnInit(EventArgs e)
    {
        Page.RegisterRequiresControlState(this);
        base.OnInit(e);
    }

    protected override void LoadControlState(object savedState)
    {
        object[] ctlState = (object[])savedState;
        base.LoadControlState(ctlState[0]);
        articles = (List<ArticlesBF>)ctlState[1];
    }

    protected override object SaveControlState()
    {
        object[] ctlState = new object[2];
        ctlState[0] = base.SaveControlState();
        ctlState[1] = articles;
        return ctlState;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string fromDate;
        string toDate;
        string catID;

        int superCategoryID = 0;
        int categoryID = 0;


        if (!IsPostBack)
        {
            Keyword = Request.QueryString["Query"];

            if (_keyword == null)
            {
                return;
            }
            lblQuery.Text = SearchUtility.BuildSQLQuery(_keyword);


            catID = Request.QueryString["CatID"];
            if ((string.IsNullOrEmpty(catID)) || (catID == "0"))
            {
                if (Keyword == "")
                {
                    articles = ArticlesBF.GetArticlesAll();
                    gvArticles.DataSource = articles;
                    gvArticles.DataBind();

                }
                else
                {
                    articles = ArticlesBF.SearchArticle(lblQuery.Text);
                    gvArticles.DataSource = articles;
                    gvArticles.DataBind();
                }
                return;
            }



            DateTimeFormatInfo dtf = new DateTimeFormatInfo();
            dtf.ShortDatePattern = "dd/MM/yyyy hh:mm tt";

            Keyword = Request.QueryString["Query"];

            fromDate = Request.QueryString["FDate"];

            toDate = Request.QueryString["TDate"];

            if (catID.IndexOf('S') == 0)
            {
                superCategoryID = TrueValue(catID);
                categoryID = 0;
                if (Keyword == "")
                {
                    articles = ArticlesBF.GetArticlesBySuperCategoryID(superCategoryID);
                    gvArticles.DataSource = articles;
                    gvArticles.DataBind();
                    return;
                }
            }
            else if (catID.IndexOf('C') == 0)
            {
                categoryID = TrueValue(catID);
                superCategoryID = 0;
                if (Keyword == "")
                {
                    articles = ArticlesBF.GetArticlesByCategoryID(categoryID);
                    gvArticles.DataSource = articles;
                    gvArticles.DataBind();
                    return;
                }
            }


            articles = ArticlesBF.Articles_AdvanceSearch(lblQuery.Text, DateTime.Parse(fromDate, dtf), DateTime.Parse(toDate, dtf), categoryID, superCategoryID);
            gvArticles.DataSource = articles;
            gvArticles.DataBind();
        }
    }

    protected void Image1_DataBinding1(object sender, EventArgs e)
    {
        Image temp = sender as Image;
        if (string.IsNullOrEmpty(temp.ImageUrl))
            temp.Visible = false;
    }


    protected void gvArticles_DataBound(object sender, EventArgs e)
    {
        if (gvArticles.Rows.Count > 0)
        {
            lblNote.Visible = true;
            lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Text = "Không tìm thấy kết quả nào phù hợp với từ khóa <strong>\"" + Keyword + "\"</strong>";
            lblMessage.Visible = true;
            lblNote.Visible = false;
        }
    }

    protected static int TrueValue(string str)
    {
        int temp;
        temp = int.Parse(str.Remove(0, 1));
        return temp;
    }

    protected void gvArticles_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvArticles.PageIndex = e.NewPageIndex;
        gvArticles.DataSource = articles;
        gvArticles.DataBind();

        // Cancel the paging operation if the user attempts to navigate
        // to another page while the GridView control is in edit mode. 
        if (gvArticles.EditIndex != -1)
        {
            // Use the Cancel property to cancel the paging operation.
            e.Cancel = true;

            // Display an error message.
            int newPageNumber = e.NewPageIndex + 1;
            //Message.Text = "Please update the record before moving to page " +
            //  newPageNumber.ToString() + ".";
        }
        else
        {
            // Clear the error message.
            //Message.Text = "";
        }
    }
}
