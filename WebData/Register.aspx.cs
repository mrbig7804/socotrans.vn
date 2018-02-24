using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Register : System.Web.UI.Page
{
    protected string Email = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack && !string.IsNullOrEmpty(this.Request.QueryString["Email"]))
        {
            CreateUserWizard1.DataBind();
            Email = this.Request.QueryString["Email"];
        }
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        ViewState["ShoppingCart"] = Profile.ShoppingCart;

        //Thêm thành viên vào mục công tác viên
        Roles.AddUserToRole(CreateUserWizard1.UserName, "Members");

    }

    protected void CreateUserWizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        Profile.ShoppingCart = (Zensoft.Website.BusinessLayer.BusinessFacade.ShoppingCart)ViewState["ShoppingCart"];
    }

    protected void chkAgreement_CheckedChanged(object sender, EventArgs e)
    {
        //var step = CreateUserWizard1.CreateUserStep.ContentTemplateContainer;

        //CheckBox chkAgreement = step.FindControl("chkAgreement") as CheckBox;
        //Literal ltrAgreement = step.FindControl("ltrAgreement") as Literal;

        //if (chkAgreement.Checked == false)
        //{
        //    ltrAgreement.Visible = true;
        //    ltrAgreement.Text = "<span style='color: #f80b00; font-weight: bold; font-size: 11px'>Bạn phải cam kết với các điều khoản và chính sách trước khi đăng ký</span>";
        //}
        //else
        //{
        //    ltrAgreement.Visible = false;
        //}
    }
}