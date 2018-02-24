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

public partial class adm_ManageComments : System.Web.UI.Page
{


    private void DeselectComment()
    {
        GridView1.SelectedIndex = -1;
        GridView1.DataBind();
        DetailsView1.ChangeMode(DetailsViewMode.Edit);
        
    }

    //public string title;
    protected void Page_Load(object sender, EventArgs e)
    {
        //ArticlesBF article = ArticlesBF.GetArticlesBF();
        //title = article.Title.ToString();

    }

    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        DeselectComment();
    }
    protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
            DeselectComment();
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetailsView1.ChangeMode(DetailsViewMode.Edit);
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btn = e.Row.Cells[3].Controls[0] as ImageButton;
            btn.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa nhận xét này?') == false) return false;";
        }
    }

    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        DeselectComment();
    }
    protected void DetailsView1_ItemCreated(object sender, EventArgs e)
    {
       
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Comments")
        {
            int commentID = Convert.ToInt32(
               GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)][0]);
            CommentsBF.SpecifyComment(commentID);
            DeselectComment();
            
        }
    }
}
