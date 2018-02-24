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

public partial class adm_ucSupplierPrice : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected int _productID;
    public int ProductID
    {
        get { return _productID; }
        set {

            _productID = value;
            objProductPrice.SelectParameters.Add("ProductID", _productID.ToString());
        }
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

    protected void btnAddPrice_Click(object sender, EventArgs e)
    {

        //int supplierID = Convert.ToInt32(ddlSuppliers.SelectedValue);

        //SupplierPricesBF sp = SupplierPricesBF.GetSupplierPricesBF(supplierID, this.ProductID);

        //if (sp != null) sp.Delete();
        
        //SupplierPricesBF.Insert(supplierID, this.ProductID, int.Parse(txtPrice.Text));

        //gvProductPrice.DataBind();
    }

}
