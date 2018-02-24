using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.Configuration;

public partial class adm_ConfigWebsite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtTitle.Text = AppConfiguration.FooterName;
            txtAdd.Text = AppConfiguration.FooterAdd;
            txtPhone.Text = AppConfiguration.FooterPhone;
            txtEmail.Text = AppConfiguration.FooterEmail;
            txtWeb.Text = AppConfiguration.FooterWeb;
            txtFace.Text = AppConfiguration.FooterFace;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtTitle.Text.Trim()))
            AppConfiguration.FooterName = txtTitle.Text.Trim();

        if (!string.IsNullOrEmpty(txtAdd.Text.Trim()))
            AppConfiguration.FooterAdd = txtAdd.Text.Trim();

        if (!string.IsNullOrEmpty(txtPhone.Text.Trim()))
            AppConfiguration.FooterPhone = txtPhone.Text.Trim();

        if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            AppConfiguration.FooterEmail = txtEmail.Text.Trim();

        if (!string.IsNullOrEmpty(txtWeb.Text.Trim()))
            AppConfiguration.FooterWeb = txtWeb.Text.Trim();

        if (!string.IsNullOrEmpty(txtFace.Text.Trim()))
            AppConfiguration.FooterFace = txtFace.Text.Trim();
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
}