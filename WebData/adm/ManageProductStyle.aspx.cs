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

public partial class adm_ManageProductStyle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void DeselectSuperCategory()
    {
        gvwSuperCategories.SelectedIndex = -1;
        gvwSuperCategories.DataBind();
        dvwSuperCategory.ChangeMode(DetailsViewMode.Insert);
    }

    protected void gvwSuperCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        dvwSuperCategory.ChangeMode(DetailsViewMode.Edit);
    }

    protected void gvwSuperCategories_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        DeselectSuperCategory();
    }
    protected void gvwSuperCategories_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[4].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa nhãn hiệu này?') == false) return false;";
        }
    }
    protected void dvwSuperCategory_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        DeselectSuperCategory();
    }
    protected void dvwSuperCategory_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        DeselectSuperCategory();
    }
    protected void dvwSuperCategory_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
            DeselectSuperCategory();
    }

    protected void dvwSuperCategory_ItemCreated(object sender, EventArgs e)
    {
        foreach (Control ctl in dvwSuperCategory.Rows[dvwSuperCategory.Rows.Count - 1].Controls[0].Controls)
        {
            if (ctl is LinkButton)
            {
                LinkButton lnk = ctl as LinkButton;
                if (lnk.CommandName == "Insert" || lnk.CommandName == "Update")
                    lnk.ValidationGroup = "SuperCategory";
            }
        }
    }

}
