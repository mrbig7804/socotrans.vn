using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class person_ucUploadProductPicture : System.Web.UI.UserControl
{
    protected int _productID;
    public int ProductID
    {
        get
        {
            return _productID;
        }
        set
        {
            _productID = value;
            this.DataBind();
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

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}