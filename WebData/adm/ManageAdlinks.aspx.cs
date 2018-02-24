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

public partial class adm_ManagerAdlinks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["adID"]))
        {
            int id = Convert.ToInt32(Request.QueryString["adID"]);
            var ad = AdLinksBF.GetAdLinksBF(id);

            for (int i = 0; i < gvwAdLocations.Rows.Count; i++)
            {
                if (gvwAdLocations.Rows[i].Cells[0].Text == ad.AdLocationID.ToString())
                {
                    gvwAdLocations.SelectedIndex = i;
                    dvwAdLocation.ChangeMode(DetailsViewMode.Edit);
                }
            }

            for (int i = 0; i < gvAllAdLinks.Rows.Count; i++)
            {
                if (gvAllAdLinks.Rows[i].Cells[0].Text == ad.AdLinkID.ToString())
                {
                    gvAllAdLinks.SelectedIndex = i;

                    dvAdLinkDetails.ChangeMode(DetailsViewMode.Edit);

                }
            }
        }
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
            ImageButton btnDelete = e.Row.Cells[4].Controls[0] as ImageButton;
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
        DeselectAdLink();

        ((TextBox)dvAdLinkDetails.Rows[3].FindControl("txtAdLocation")).Text = gvwAdLocations.SelectedValue.ToString();
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

    public void DeselectAdLink()
    {
        gvAllAdLinks.SelectedIndex = -1;
        gvAllAdLinks.DataBind();
        dvAdLinkDetails.ChangeMode(DetailsViewMode.Insert);
    }


    protected void gvAllAdLinks_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[5].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa mục quảng cáo này không?') == false) return false;";
        }
    }
    protected void gvAllAdLinks_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        DeselectAdLink();
    }
    protected void gvAllAdLinks_SelectedIndexChanged(object sender, EventArgs e)
    {
        dvAdLinkDetails.ChangeMode(DetailsViewMode.Edit);
        //ucAdLink1.AdLinkID = Convert.ToInt32(gvAllAdLinks.SelectedValue);
    }
    protected void dvAdLinkDetails_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
            DeselectAdLink();
    }
    protected void dvAdLinkDetails_ItemCreated(object sender, EventArgs e)
    {
        foreach (Control ctl in dvAdLinkDetails.Rows[dvAdLinkDetails.Rows.Count - 1].Controls[0].Controls)
        {
            if (ctl is LinkButton)
            {
                LinkButton lnk = ctl as LinkButton;
                if (lnk.CommandName == "Insert" || lnk.CommandName == "Update")
                    lnk.ValidationGroup = "Category";
            }
        }

    }
    protected void dvAdLinkDetails_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
    {
        DeselectAdLink();
    }
    protected void dvAdLinkDetails_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        DeselectAdLink();
    }
    protected void dvAdLinkDetails_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        DeselectAdLink();
    }
}
