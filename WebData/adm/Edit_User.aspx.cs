using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_Edit_User : System.Web.UI.Page
{
    string userName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        userName = this.Request.QueryString["UserName"];

        lblRolesFeedbackOK.Visible = false;
        lblProfileFeedbackOK.Visible = false;

        if (!this.IsPostBack)
        {
            UcUserProfile1.UserName = userName;

            // show the user's details
            MembershipUser user = Membership.GetUser(userName);

            lblUserName.Text = user.UserName;
            txtEmail.Text = user.Email;
            lnkEmail.NavigateUrl = "mailto:" + user.Email;
            lblRegistered.Text = user.CreationDate.ToString("dd/MM/yyyy hh:mm tt");
            lblLastLogin.Text = user.LastLoginDate.ToString("dd/MM/yyyy hh:mm tt");
            lblLastActivity.Text = user.LastActivityDate.ToString("dd/MM/yyyy hh:mm tt");
            chkOnlineNow.Checked = user.IsOnline;
            chkApproved.Checked = user.IsApproved;
            chkLockedOut.Checked = user.IsLockedOut;
            chkLockedOut.Enabled = user.IsLockedOut;

            BindRoles();
        }
    }

    private void BindRoles()
    {
        chklRoles.DataSource = Roles.GetAllRoles();
        chklRoles.DataBind();

        foreach (string role in Roles.GetRolesForUser(userName))
            chklRoles.Items.FindByText(role).Selected = true;
    }

    protected void btnUpdateProfile_Click(object sender, EventArgs e)
    {
        UcUserProfile1.SaveProfile();
        lblProfileFeedbackOK.Visible = true;
    }
    protected void btnUpdatePassword_Click(object sender, EventArgs e)
    {
        userName = this.Request.QueryString["UserName"];
        MembershipUser user = Membership.Providers["SqlProviderResetPassword"].GetUser(userName, false);
        user.ChangePassword(user.ResetPassword(), txtNewPassword.Text);

        lblProfileResetPasswordOK.Visible = true;
    }

    protected void btnCreateRole_Click(object sender, EventArgs e)
    {
        if (!Roles.RoleExists(txtNewRole.Text.Trim()))
        {
            Roles.CreateRole(txtNewRole.Text.Trim());
            BindRoles();
        }
    }

    protected void btnUpdateRoles_Click(object sender, EventArgs e)
    {
        //Xóa tất cả role
        string[] currRoles = Roles.GetRolesForUser(userName);
        if (currRoles.Length > 0)
            Roles.RemoveUserFromRoles(userName, currRoles);
        // cập nhật role
        List<string> newRoles = new List<string>();
        foreach (ListItem item in chklRoles.Items)
        {
            if (item.Selected)
                newRoles.Add(item.Text);
        }
        Roles.AddUserToRoles(userName, newRoles.ToArray());

        lblRolesFeedbackOK.Visible = true;
    }

    protected void chkApproved_CheckedChanged(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser(userName);
        user.IsApproved = chkApproved.Checked;
        Membership.UpdateUser(user);
    }

    protected void chkLockedOut_CheckedChanged(object sender, EventArgs e)
    {
        if (!chkLockedOut.Checked)
        {
            MembershipUser user = Membership.GetUser(userName);
            user.UnlockUser();
            chkLockedOut.Enabled = false;
        }
    }

    protected void btnUpdateEmail_Click(object sender, EventArgs e)
    {
        try
        {
            MembershipUser user = Membership.GetUser(userName);
            user.Email = txtEmail.Text;
            Membership.UpdateUser(user);
            lnkEmail.NavigateUrl = "mailto:" + txtEmail.Text;
            lblEmailFeedbackOK.Visible = true;
            lblEmailErr.Visible = false;
        }
        catch
        {
            lblEmailFeedbackOK.Visible = false;
            lblEmailErr.Visible = true;
        }
    }
}
