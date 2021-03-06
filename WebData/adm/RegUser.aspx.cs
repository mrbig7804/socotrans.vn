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
using System.Collections.Generic;

public partial class admin_RegUser : System.Web.UI.Page
{
    protected string Email = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BindRoles();

            if (!string.IsNullOrEmpty(this.Request.QueryString["Email"]))
            {
                Email = this.Request.QueryString["Email"];
                CreateUserWizard1.DataBind();
            }
        }
    }

    private void BindRoles()
    {
        chklRoles.DataSource = Roles.GetAllRoles();
        chklRoles.DataBind();
    }

    protected void CreateUserWizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        UserProfile1.SaveProfile();

        // thay đổi quyền
        List<string> newRoles = new List<string>();

        foreach (ListItem item in chklRoles.Items)
        {
            if (item.Selected)
                newRoles.Add(item.Text);
        }

        Roles.AddUserToRoles(CreateUserWizard1.UserName, newRoles.ToArray());
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        //Roles.AddUserToRole(CreateUserWizard1.UserName, "Posters");
        UserProfile1.UserName = CreateUserWizard1.UserName;
    }
}
