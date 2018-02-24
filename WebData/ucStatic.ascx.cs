using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucStatic : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        lblUserOnline.Text = Application["UserOnline"].ToString();
        lblUserVisited.Text = Application["UserVisited"].ToString();
    }
}