using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class adm_ManageAdLocations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void Deselect()
    {
        gvwAdLocations.SelectedIndex = -1;
        gvwAdLocations.DataBind();
        dvwAdLocation.ChangeMode(DetailsViewMode.Insert);
    }

    protected void dvwAdLocation_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        Deselect();
    }
    protected void dvwAdLocation_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        Deselect();
    }
    protected void gvwAdLocations_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[3].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn mục này?') == false) return false;";
        }

    }
    protected void gvwAdLocations_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        Deselect();
    }
    protected void gvwAdLocations_SelectedIndexChanged(object sender, EventArgs e)
    {
        dvwAdLocation.ChangeMode(DetailsViewMode.Edit);
    }
    protected void dvwAdLocation_ItemCreated(object sender, EventArgs e)
    {
        foreach (Control ctl in dvwAdLocation.Rows[dvwAdLocation.Rows.Count - 1].Controls[0].Controls)
        {
            if (ctl is LinkButton)
            {
                LinkButton lnk = ctl as LinkButton;
                if (lnk.CommandName == "Insert" || lnk.CommandName == "Update")
                    lnk.ValidationGroup = "AdLocation";
            }
        }

    }
}
