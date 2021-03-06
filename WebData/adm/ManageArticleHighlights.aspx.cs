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

public partial class admin_ManageArticleHighlights : System.Web.UI.Page
{
    private void DeselectArticleHighlight()
    {
        gvwArticleHighlights.SelectedIndex = -1;
        gvwArticleHighlights.DataBind();
        dvwArticleHighlight.ChangeMode(DetailsViewMode.Insert);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void gvwArticleHighlights_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        DeselectArticleHighlight();
    }
    protected void dvwArticleHighlight_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        DeselectArticleHighlight();
    }
    protected void dvwArticleHighlight_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
    {
        DeselectArticleHighlight();
    }

    protected void gvwArticleHighlights_SelectedIndexChanged(object sender, EventArgs e)
    {
        dvwArticleHighlight.ChangeMode(DetailsViewMode.Edit);
    }
    protected void dvwArticleHighlight_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        DeselectArticleHighlight();
    }
    protected void dvwArticleHighlight_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
            DeselectArticleHighlight();
    }
    protected void dvwArticleHighlight_ItemCreated(object sender, EventArgs e)
    {
        foreach (Control ctl in dvwArticleHighlight.Rows[dvwArticleHighlight.Rows.Count - 1].Controls[0].Controls)
        {
            if (ctl is LinkButton)
            {
                LinkButton lnk = ctl as LinkButton;
                if (lnk.CommandName == "Insert" || lnk.CommandName == "Update")
                    lnk.ValidationGroup = "ArticleHighlight";
            }
        }
    }
    protected void gvwArticleHighlights_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[5].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa tin nổi bật này không?') == false) return false;";
        }
    }
}
