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
using System.Globalization;

public partial class admin_ucUserProfile : System.Web.UI.UserControl
{
    private string _userName = "";
    public string UserName
    {
        get { return _userName; }
        set
        {
            _userName = value;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        Page.RegisterRequiresControlState(this);
        base.OnInit(e);
    }


    protected override void LoadControlState(object savedState)
    {
        object[] ctlState = (object[])savedState;
        base.LoadControlState(ctlState[0]);
        this.UserName = (string)ctlState[1];
    }

    protected override object SaveControlState()
    {
        object[] ctlState = new object[2];
        ctlState[0] = base.SaveControlState();
        ctlState[1] = this.UserName;
        return ctlState;
    }


    private void DisplayProfile(string userName)
    {
        ProfileCommon profile = this.Profile;
        profile = this.Profile.GetProfile(userName);

        //ddlSubscriptions.SelectedValue = profile.Preferences.Newsletter.ToString();
        //ddlLanguages.SelectedValue = profile.Preferences.Culture;

        txtFullName.Text = profile.FullName;

        if (!string.IsNullOrEmpty(profile.Gender))
            ddlGenders.SelectedValue = profile.Gender;

        if (profile.BirthDate != DateTime.MinValue)
            txtBirthDate.Text = profile.BirthDate.ToString("dd/MM/yyyy");

        if (!string.IsNullOrEmpty(profile.Occupation))
            ddlOccupations.SelectedValue = profile.Occupation;

        txtWebsite.Text = profile.Website;
        txtPhone.Text = profile.Phone;
        txtAddress.Text = profile.Address;

        imgAvatar.ImageUrl = profile.Forum.AvatarUrl;
        //ddlSubscriptions.SelectedValue = profile.Preferences.Newsletter.ToString();
        //ddlLanguages.SelectedValue = profile.Preferences.Culture;

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (this.UserName.Length > 0)
                DisplayProfile(this.UserName);
        }
    }

    public void SaveProfile()
    {
        // if the UserName property contains an emtpy string, save the current user's profile,
        // othwerwise save the profile for the specified user
        ProfileCommon profile = this.Profile;
        if (this.UserName.Length > 0)
            profile = this.Profile.GetProfile(this.UserName);

        //profile.Preferences.Newsletter = (SubscriptionType)Enum.Parse(typeof(SubscriptionType),
        //   ddlSubscriptions.SelectedValue);

        profile.FullName = txtFullName.Text;
        profile.Gender = ddlGenders.SelectedValue;

        DateTimeFormatInfo dtf = new DateTimeFormatInfo();
        dtf.ShortDatePattern = "dd/MM/yyyy";
        if (txtBirthDate.Text.Trim().Length > 0)
            profile.BirthDate = Convert.ToDateTime(txtBirthDate.Text, dtf);

        profile.Occupation = ddlOccupations.SelectedValue;
        profile.Website = txtWebsite.Text;
        profile.Address = txtAddress.Text;
        profile.Phone = txtPhone.Text;
        profile.Save();
    }
    protected void btnChangeAvatar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/adm/ChangeAvatar.aspx");
    }
}
