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

using Zensoft.Website.Configuration;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class Shopping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           if (!string.IsNullOrEmpty(Request.QueryString["SDep"]))
           {
               try
               {
                   var sd = SuperDepartmentsBF.GetSuperDepartmentsBF(Convert.ToInt32(Request.QueryString["SDep"]));
                   Page.Title = sd.Title;

                   if (!string.IsNullOrEmpty(Request.QueryString["Dep"]))
                   {
                       var dep = DepartmentsBF.GetDepartmentsBF(Convert.ToInt32(Request.QueryString["Dep"]));
                       Page.Title = sd.Title + " - " + dep.Title;
                   }
               }
               catch
               {
               	
               }
           }
            
        }
    }

    protected void lnkResetOption_Click(object sender, EventArgs e)
    {
        //UcProductMenu1.ResetOption();
    }

    void UpdateTitles(string title)
    {
        Page.Title =  title;
    }

    protected void imgPicPreview_Load(object sender, EventArgs e)
    {
        _imageClientID = ((Image)sender).ClientID;

    }

    string _imageClientID = "";
    protected string ImageClientID
    {
        get
        {
            return _imageClientID;
        }
    }

    protected void lvProducts_PreRender(object sender, EventArgs e)
    {

        DataPager1.Visible = (DataPager1.TotalRowCount > DataPager1.PageSize);
        DataPager2.Visible = (DataPager1.TotalRowCount > DataPager1.PageSize);
    }

}
