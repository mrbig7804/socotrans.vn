using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucSearchProducts : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string keyword = txtKey.Value.Trim();

        if (keyword != "Nhập từ khóa")
        {
            keyword = VNString.TextToUrl(txtKey.Value.Trim());

            Response.Redirect("/ket-qua-tim-kiem?_key=" + VNString.TextToUrl(keyword));
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Bạn cần nhập từ khóa để tìm kiếm');", true);
            return;
        }
    }
}