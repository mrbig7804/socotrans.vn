using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Controls_ucUserProfile : System.Web.UI.UserControl
{
    private void DisplayProfile(string userName)
    {
        //ProfileCommon profile = this.Profile;
        //profile = this.Profile.GetProfile(userName);


        //txtFullName.Text = profile.FullName;

        //if (!string.IsNullOrEmpty(profile.Gender))
        //    ddlGenders.SelectedValue = profile.Gender;

        //if (profile.BirthDate != DateTime.MinValue)
        //    txtBirthDate.Text = profile.BirthDate.ToString("dd/MM/yyyy");

        //if (!string.IsNullOrEmpty(profile.Occupation))
        //    ddlOccupations.SelectedValue = profile.Occupation;

        //txtWebsite.Text = profile.Website;
        //txtPhone.Text = profile.Phone;
        //txtMobile.Text = profile.Mobile;
        //txtAddress.Text = profile.Address;
        //txtYM.Text = profile.YM;

        //imgAvatar.ImageUrl = profile.AvatarUrl;


        //if (ddlCities.Items.FindByValue(profile.City) != null)
        //    ddlCities.SelectedValue = profile.City;

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            ddlCities.DataSource = Zensoft.Website.Configuration.Helpers.GetCities();
            ddlCities.DataBind();

            DisplayProfile(this.Profile.UserName);
        }
    }

    public void SaveProfile()
    {
        //ProfileCommon profile = this.Profile;


        //profile.FullName = txtFullName.Text;
        //profile.Gender = ddlGenders.SelectedValue;

        //DateTimeFormatInfo dtf = new DateTimeFormatInfo();
        //dtf.ShortDatePattern = "dd/MM/yyyy";
        //if (txtBirthDate.Text.Trim().Length > 0)
        //    profile.BirthDate = Convert.ToDateTime(txtBirthDate.Text, dtf);

        //profile.Occupation = ddlOccupations.SelectedValue;
        //profile.Website = txtWebsite.Text;
        //profile.Address = txtAddress.Text;
        //profile.Phone = txtPhone.Text;
        //profile.Mobile = txtMobile.Text;
        //profile.City = ddlCities.SelectedValue;
        //profile.YM = txtYM.Text;

        //profile.Save();
    }

    protected void btnChangeAvatar_Click(object sender, EventArgs e)
    {
        SaveProfile();
        Response.Redirect("~/person/ChangeAvatar.aspx");
    }
}