using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class Controls_ucProductListImage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int ProductID 
    {
        get
        {
            return ProductID;
        }
        set
        {
            rptProductImages.DataSource = ProductImagesBF.GetProductImagesByProductID(value);
            rptProductImages.DataBind();
        }
    }

    protected void rptProductImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HyperLink hplImage = (HyperLink)e.Item.FindControl("hplImage");
            hplImage.NavigateUrl = DataBinder.Eval(e.Item.DataItem, "FullImage").ToString();
        }
    }
}