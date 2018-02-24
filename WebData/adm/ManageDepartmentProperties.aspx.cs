using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class adm_ManageDepartmentProperties : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPage();
        }
    }

    private void BindPage()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["depID"]))
        {
            int depID = int.Parse(Request.QueryString["depID"]);

            lblTitlePage.Text = DepartmentsBF.GetDepartmentsBF(depID).Title;

            BindGridGroupProperty(depID);
            BindFormGroupProperty(0);
        }
    }

    //GROUP PROPERTIES===============================================================================================

    private void BindGridGroupProperty(int depID)
    {
        var listPropertyG = PropertiesGroupsBF.GetPropertiesGroupsByDepartment(depID);

        lblCountGroupProperty.Text = listPropertyG.Count.ToString();
        gvwGroupProperty.DataSource = listPropertyG;
        gvwGroupProperty.DataBind();
    }

    private void BindFormGroupProperty(int gPropertyID)
    {
        hdfGroupProperty.Value = gPropertyID.ToString();

        if (gPropertyID != 0)
        {
            var pg = PropertiesGroupsBF.GetPropertiesGroupsBF(gPropertyID);

            if (pg != null)
                txtTitleGroup.Text = pg.Title;

            btnInsertGroupProperty.Text = "Cập nhật";
            pnlProperty.Visible = true;
            BindGridProperty(gPropertyID);
            BindFormProperty(0);
        }
        else
        {
            txtTitleGroup.Text = "";
            btnInsertGroupProperty.Text = "Thêm mới";
            pnlProperty.Visible = false;
        }
    }

    private void DeselectGridGroupProperty()
    {
        gvwGroupProperty.SelectedIndex = -1;
        gvwGroupProperty.DataBind();

        BindFormGroupProperty(0);
    }

    protected void gvwGroupProperty_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvwGroupProperty.PageIndex = e.NewPageIndex;
        this.gvwGroupProperty.DataBind();

        BindGridGroupProperty(int.Parse(Request.QueryString["depID"]));
        BindFormGroupProperty(0);
        DeselectGridGroupProperty();
    }

    protected void gvwGroupProperty_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int gProperty = (int)gvwGroupProperty.DataKeys[e.RowIndex]["PropertyGroupID"];

        if (PropertiesBF.GetPropertiesByPropertyGroup(gProperty).Count > 0)
        {
            Response.Write("<script> alert('ERROR! Không thể xóa vì vẫn tồn tại đặc tính dòng trong nhóm đặc tính này.'); </script>");
        }
        else
            PropertiesGroupsBF.Delete(gProperty);

        BindGridGroupProperty(int.Parse(Request.QueryString["depID"]));
        BindFormGroupProperty(0);
        DeselectGridGroupProperty();
    }

    protected void gvwGroupProperty_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[2].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa nhóm đặc tính này?') == false) return false;";
        }
    }

    protected void gvwGroupProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFormGroupProperty(int.Parse(((GridView)sender).SelectedDataKey.Value.ToString()));
    }

    protected void btnInsertGroupProperty_Click(object sender, EventArgs e)
    {
        int depID = int.Parse(Request.QueryString["depID"]);
        int gPropertyID = int.Parse(hdfGroupProperty.Value);

        if (gPropertyID != 0)
        {
            PropertiesGroupsBF pg = PropertiesGroupsBF.GetPropertiesGroupsBF(gPropertyID);

            pg.Title = txtTitleGroup.Text.Trim();
            pg.Update();
        }
        else
        {
            PropertiesGroupsBF pg = new PropertiesGroupsBF();

            pg.Title = txtTitleGroup.Text.Trim();
            pg.DepartmentID = depID;
            gPropertyID = pg.Insert();
        }

        BindGridGroupProperty(depID);
        BindFormGroupProperty(gPropertyID);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        BindGridGroupProperty(int.Parse(Request.QueryString["depID"]));
        DeselectGridGroupProperty();
    }

    //PROPERTIES===============================================================================================
    private void BindGridProperty(int gPropertyID)
    {
        var listProperty = PropertiesBF.GetPropertiesByPropertyGroup(gPropertyID);

        lblCountProperty.Text = listProperty.Count.ToString();
        gvwProperty.DataSource = listProperty;
        gvwProperty.DataBind();
    }

    private void BindFormProperty(int propertyID)
    {
        hdfProperty.Value = propertyID.ToString();

        if (propertyID != 0)
        {
            var p = PropertiesBF.GetPropertiesBF(propertyID);

            if (p != null)
                txtTitleProperty.Text = p.Title;

            btnInsertProperty.Text = "Cập nhật";
            pnlPropertyValue.Visible = true;
            BindGridPropertyValue(propertyID);
        }
        else
        {
            txtTitleProperty.Text = "";
            btnInsertProperty.Text = "Thêm mới";
            pnlPropertyValue.Visible = false;
        }
    }

    private void DeselectGridProperty()
    {
        gvwProperty.SelectedIndex = -1;
        gvwProperty.DataBind();

        BindFormProperty(0);
    }

    protected void gvwProperty_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvwProperty.PageIndex = e.NewPageIndex;
        this.gvwProperty.DataBind();

        BindGridProperty(int.Parse(hdfGroupProperty.Value));
        BindFormProperty(0);
        DeselectGridProperty();
    }

    protected void gvwProperty_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int property = (int)gvwProperty.DataKeys[e.RowIndex]["PropertyID"];

        if (PropertiesValuesBF.GetPropertiesValuesByProperty(property).Count > 0)
        {
            Response.Write("<script> alert('ERROR! Không thể xóa vì vẫn tồn tại thông số trong đặc tính này.'); </script>");
        }
        else
            PropertiesBF.Delete(property);

        BindGridProperty(int.Parse(hdfGroupProperty.Value));
        BindFormProperty(0);
        DeselectGridProperty();
    }

    protected void gvwProperty_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[3].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa đặc tính này?') == false) return false;";
        }
    }

    protected void gvwProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFormProperty(int.Parse(((GridView)sender).SelectedDataKey.Value.ToString()));
    }

    protected void ckbAllow_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ckbAllow = (CheckBox)sender;
        GridViewRow rowId = (GridViewRow)ckbAllow.NamingContainer;

        PropertiesBF p = PropertiesBF.GetPropertiesBF(int.Parse(gvwProperty.DataKeys[rowId.RowIndex].Value.ToString()));
        p.AllowSearch = ckbAllow.Checked;
        p.Update();

        BindGridProperty(int.Parse(hdfGroupProperty.Value));
        BindFormProperty(0);
        DeselectGridProperty();
    }

    protected void btnInsertProperty_Click(object sender, EventArgs e)
    {
        int propertyID = int.Parse(hdfProperty.Value);
        int gPropertyID = int.Parse(hdfGroupProperty.Value);

        if (propertyID != 0)
        {
            PropertiesBF p = PropertiesBF.GetPropertiesBF(propertyID);

            p.Title = txtTitleProperty.Text.Trim();
            p.Update();
        }
        else
        {
            PropertiesBF p = new PropertiesBF();

            p.Title = txtTitleProperty.Text.Trim();
            p.PropertyGroupID = gPropertyID;
            p.AllowSearch = true;
            propertyID = p.Insert();
        }

        BindGridProperty(gPropertyID);
        BindFormProperty(propertyID);
    }

    protected void btnCancelProperty_Click(object sender, EventArgs e)
    {
        BindGridProperty(int.Parse(hdfGroupProperty.Value));
        DeselectGridProperty();
    }

    //PROPERTIES VALUE===============================================================================================

    private void BindGridPropertyValue(int propertyID)
    {
        lblTitlePropertyValue.Text = PropertiesBF.GetPropertiesBF(propertyID).Title;

        var listPropertyValue = PropertiesValuesBF.GetPropertiesValuesByProperty(propertyID);

        lblCountPropertyValue.Text = listPropertyValue.Count.ToString();

        if (listPropertyValue.Count > 0)
        {
            gvwPropertyValue.DataSource = listPropertyValue;
            gvwPropertyValue.DataBind();
        }
        else
        {
            PropertiesValuesBF pv = new PropertiesValuesBF();
            listPropertyValue.Add(pv);

            gvwPropertyValue.DataSource = listPropertyValue;
            gvwPropertyValue.DataBind();
            gvwPropertyValue.Rows[0].Visible = false;
        }
    }

    protected void gvwPropertyValue_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvwPropertyValue.PageIndex = e.NewPageIndex;
        this.gvwPropertyValue.DataBind();

        BindGridPropertyValue(int.Parse(hdfProperty.Value));
    }

    protected void gvwPropertyValue_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvwPropertyValue.EditIndex = e.NewEditIndex;
        BindGridPropertyValue(int.Parse(hdfProperty.Value));
    }

    protected void gvwPropertyValue_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvwPropertyValue.EditIndex = -1;
        BindGridPropertyValue(int.Parse(hdfProperty.Value));
    }

    protected void gvwPropertyValue_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        PropertiesValuesBF propertyValue = PropertiesValuesBF.GetPropertiesValuesBF(int.Parse(gvwPropertyValue.DataKeys[e.RowIndex].Value.ToString()));

        propertyValue.Value = Regex.Replace(((TextBox)gvwPropertyValue.Rows[e.RowIndex].FindControl("txtPropertyValue")).Text.Trim(), "\\ {2,}", " ");

        propertyValue.Update();

        gvwPropertyValue.EditIndex = -1;
        BindGridPropertyValue(int.Parse(hdfProperty.Value));
    }

    protected void lbtnDelPropertyValue_Click(object sender, EventArgs e)
    {
        LinkButton lbtnDelPropertyValue = (LinkButton)sender;

        PropertiesValuesBF.Delete(int.Parse(lbtnDelPropertyValue.CommandArgument));
        BindGridPropertyValue(int.Parse(hdfProperty.Value));
    }

    protected void lbtnInsertPropertyValue_Click(object sender, EventArgs e)
    {
        string value = Regex.Replace(((TextBox)gvwPropertyValue.FooterRow.FindControl("txtPropertyValue")).Text.Trim(), "\\ {2,}", " ");

        PropertiesValuesBF pv = new PropertiesValuesBF();
        pv.PropertyID = int.Parse(hdfProperty.Value);
        pv.Value = value;
        pv.Insert();
        BindGridPropertyValue(int.Parse(hdfProperty.Value));
    }
}