using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucProductProperties : System.Web.UI.UserControl
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

            rptProperties.DataSource = PropertiesBF.GetPropertiesByPropertyGroup(_propertyGroupID);
            rptProperties.DataBind();
        }
    }

    public int ProductID { get; set; }

    protected void rptProperties_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltrValue = e.Item.FindControl("ltrValue") as Literal;

            int propertyID = int.Parse(DataBinder.Eval(e.Item.DataItem, "PropertyID").ToString());

            var pp = PropertiesValuesBF.GetPropertiesValuesByProduct(propertyID, this.ProductID);

            for (int i = 0; i < pp.Count; i++)
            {
                if(i >= 1)
                    ltrValue.Text += ";&nbsp;" + pp[i].Value;
                else
                    ltrValue.Text = pp[i].Value;
            }
        }
    }
}