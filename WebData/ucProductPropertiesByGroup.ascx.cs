using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucProductPropertiesByGroup : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    int _propertyGroupID;
    public int PropertyGroupID
    {
        get 
        {
            return _propertyGroupID;
        }
        set 
        {
            _propertyGroupID = value;

            rptProperties.DataSource = PropertiesBF.GetPropertiesDynamic("[PropertyGroupID] =" + _propertyGroupID.ToString() + " AND [AllowSearch]='true'", "[Important] ASC");
            rptProperties.DataBind();
        }
    }

    protected void rptProperties_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptPropertyValue = e.Item.FindControl("rptPropertyValue") as Repeater;

            rptPropertyValue.DataSource = PropertiesValuesBF.GetPropertiesValuesByProperty(int.Parse(DataBinder.Eval(e.Item.DataItem, "PropertyID").ToString()));
            rptPropertyValue.DataBind();
        }
    }

    protected void rptPropertyValue_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string propertyValueID = DataBinder.Eval(e.Item.DataItem, "PropertiesValueID").ToString();
            int checkCount = ProductPropertiesBF.GetProductPropertyByPropertyValue(int.Parse(propertyValueID)).Count;

            HyperLink hplPropertyValue = e.Item.FindControl("hplPropertyValue") as HyperLink;
            Panel pnlPropertyValue = e.Item.FindControl("pnlPropertyValue") as Panel;

            if(checkCount > 0)
            {
                pnlPropertyValue.Visible = true;
                hplPropertyValue.Text = DataBinder.Eval(e.Item.DataItem, "Value").ToString() + "&nbsp;(" + checkCount.ToString() + ")";
                hplPropertyValue.NavigateUrl = this.Request.Url.AbsolutePath + "?_propertyV=" + propertyValueID;
            }
            else
                pnlPropertyValue.Visible = false;

        }
    }
}