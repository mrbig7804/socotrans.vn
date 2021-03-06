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

public partial class admin_ManageArtilceUnapproved : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Approved")
        {
            int articleID = Convert.ToInt32(
               GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)][0]);

            ArticlesBF.UpdatePublish(articleID, 
                DateTime.Now, 
                DateTime.MaxValue, 
                true,  
                true,
                false, //only for member
                true);

            GridView1.SelectedIndex = -1;
            GridView1.DataBind();
        }
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnAppoved = e.Row.Cells[4].Controls[0] as ImageButton;
            btnAppoved.OnClientClick = "if (confirm('Bạn có chắc chắn muốn duyệt bài viết này?') == false) return false;";
            ImageButton btnDelete = e.Row.Cells[5].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa bài viết này?') == false) return false;";
        }

    }
}
