using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.Utilities;
using System.Globalization;
using System.Collections.Generic;

public partial class ItemSearch : System.Web.UI.Page
{

    //dùng để lưu danh sách vào viewstate để có thể phân trang bằng gridview
    private List<ProductsBF> products;

    string _keywords;
    public string Keywords
    {
        set
        {
            _keywords = value;
            ViewState.Add("Keyword", _keywords);
        }
        get
        {
            if (string.IsNullOrEmpty(_keywords) && ViewState["Keywords"] != null)
                _keywords = ViewState["Keywords"].ToString();
            return _keywords;
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
        products = (List<ProductsBF>)ctlState[1];
    }

    protected override object SaveControlState()
    {
        object[] ctlState = new object[2];
        ctlState[0] = base.SaveControlState();
        ctlState[1] = products;
        return ctlState;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        string fromDate = "01/01/1901 00:00 00";
        //string keywords;
        int depID = 0;

        if (!IsPostBack)
        {
            Keywords = Request.QueryString["keywords"];

            txtKeywords.Text = Keywords;

            //set tiêu đề của trang
            this.Header.Description = "Tìm kiếm - " + Keywords;

            if (Keywords == null)
            {
                return;
            }

            lblQuery.Text = SearchUtility.BuildSQLQuery(Keywords);

            if (Request.QueryString["dep"] != "")
            {
                 int.TryParse(Request.QueryString["dep"], out depID);
            }

            DateTimeFormatInfo dtf = new DateTimeFormatInfo();
            dtf.ShortDatePattern = "dd/MM/yyyy hh:mm tt";

            if (!string.IsNullOrEmpty( Request.QueryString["date"]))
                fromDate = Request.QueryString["date"];
            else fromDate = "01/01/1901 01:01 AM";

            products  = ProductsBF.SearchProduct(SearchUtility.BuildSQLQuery(Keywords), DateTime.Parse(fromDate, dtf), depID);
            gvProducts.DataSource = products;
            gvProducts.DataBind();


        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/itemsearch.aspx?keywords=" + txtKeywords.Text);
    }

    protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProducts.PageIndex = e.NewPageIndex;
        gvProducts.DataSource = products;
        gvProducts.DataBind();

        // Cancel the paging operation if the user attempts to navigate
        // to another page while the GridView control is in edit mode. 
        if (gvProducts.EditIndex != -1)
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
