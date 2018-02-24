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

public partial class Controls_ucDisplayPicture : System.Web.UI.UserControl
{
    public string PictureUrl
    {
        set
        {
            if (string.IsNullOrEmpty(value)) imgDisplay.Visible = false;
            else imgDisplay.ImageUrl = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
