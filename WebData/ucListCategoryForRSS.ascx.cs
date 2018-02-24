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

using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucListCategoryForRSS : System.Web.UI.UserControl
{

    public string BaseUrl
    {
        get
        {
            string url = this.Request.ApplicationPath;
            if (url.EndsWith("/"))
                return url;
            else
                return url + "/";
        }
    }

    public string FullBaseUrl
    {
        get
        {
            return this.Request.Url.AbsoluteUri.Replace(
               this.Request.Url.PathAndQuery, "") + this.BaseUrl;
        }
    }

    public int SuperCategoryID
    {
        set
        {
            dlCategories.DataSource = CategoriesBF.GetCategoriesBySuperCategoryID(value);
            dlCategories.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void HyperLink1_Load(object sender, EventArgs e)
    {
        //HyperLink lnk = (HyperLink)sender;

        //lnk.Text = this.Request.Url.AbsoluteUri.Replace(
        //       this.Request.Url.PathAndQuery, "");//Request.Url.Scheme+"/" +Request.Url.Host+@"://"+ Request.ApplicationPath ;
    }
}
