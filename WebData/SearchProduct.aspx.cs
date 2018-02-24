using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class SearchProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string key = Request.QueryString["Key"].ToString();

            lvProducts.DataSource = ProductsBF.GetProductsBySearch(key, 0, 0, 0, 0);
            lvProducts.DataBind();
        }
    }

    protected void lvProducts_PreRender(object sender, EventArgs e)
    {
        DataPager1.Visible = (DataPager1.TotalRowCount > DataPager1.PageSize);
        DataPager2.Visible = (DataPager1.TotalRowCount > DataPager1.PageSize);
    }
}