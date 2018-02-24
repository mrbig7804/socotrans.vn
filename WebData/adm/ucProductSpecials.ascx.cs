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

using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class adm_ucProductSpecials : System.Web.UI.UserControl
{
    protected int _productID;
    public int ProductID
    {
        get { return _productID; }
        set { _productID = value; }
    }

    protected override void OnInit(EventArgs e)
    {
        Page.RegisterRequiresControlState(this);
        base.OnInit(e);
    }

    protected override void LoadControlState(object savedState)
    {
        object[] ctlState = (object[])savedState;
        base.LoadControlState(ctlState[0]);
        this.ProductID = (int)ctlState[1];
    }

    protected override object SaveControlState()
    {
        object[] ctlState = new object[2];
        ctlState[0] = base.SaveControlState();
        ctlState[1] = this.ProductID;
        return ctlState;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            chklProductSpecials.DataSource = SpecialsBF.GetSpecialsAll();
            chklProductSpecials.DataTextField = "Title";
            chklProductSpecials.DataValueField = "SpecialID";
            chklProductSpecials.DataBind();

            List<ProductSpecialsBF> productSpecials = ProductSpecialsBF.GetProductSpecialsByProductID(ProductID);

            foreach (ListItem item in chklProductSpecials.Items)
            {
                foreach (ProductSpecialsBF ps in productSpecials)
                {
                    if (ps.SpecialID.ToString() == item.Value)
                        item.Selected = true;
                }
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        ProductSpecialsBF.DeleteByProductID(ProductID);

        foreach (ListItem item in chklProductSpecials.Items)
        {
            if (item.Selected)
            {
                ProductSpecialsBF.Insert(ProductID, int.Parse(item.Value), DateTime.Now, DateTime.MaxValue, true);
            }
        }
        btnUpdate.Enabled = false;
    }
    protected void chklProductSpecials_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnUpdate.Enabled = true;
    }
}
