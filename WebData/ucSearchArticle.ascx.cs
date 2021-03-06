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

public partial class ucSearchArticle : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string keyword = Request.QueryString["Query"];
            if (!string.IsNullOrEmpty(keyword)) txtSearch.Value = keyword;
        }
    }
    string _keyword;
    public string Keyword
    {
        set
        {
            _keyword = value;
            txtSearch.Value = _keyword;
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string keyword = txtSearch.Value;

        Response.Redirect("~/Search.aspx?Query=" + keyword);
    }
}
