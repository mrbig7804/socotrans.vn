using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class adm_ManageCities : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["cityID"]) & !string.IsNullOrEmpty(Request.QueryString["i"]))
            {
                var city = CitiesBF.GetCitiesBF(int.Parse(Request.QueryString["cityID"]));

                if (Request.QueryString["i"] == "up")
                    city.IncreaseImportance();

                if (Request.QueryString["i"] == "down")
                    city.ReducedImportance();

                Response.Redirect(Request.Url.AbsolutePath);
            }

            BindFormCity();
        }
    }

    void BindFormCity()
    {
        int cityID = 0;
        if (!string.IsNullOrEmpty(Request.QueryString["cityID"]))
            cityID = int.Parse(Request.QueryString["cityID"]);

        hdfCityID.Value = cityID.ToString();
        BindDropCity(0);

        if (cityID == 0)
        {
            txtName.Text = "";
            txtDesc.Text = "";
            
            lbtnUpdate.Text = "Thêm mới";
            lbtnCancle.Visible = true;
            lbtnDel.Visible = false;
        }
        else if (cityID > 0)
        {
            CitiesBF city = CitiesBF.GetCitiesBF(cityID);

            txtName.Text = city.Name;
            txtDesc.Text = city.Description;
            ddlCities.SelectedValue = city.ParentID.ToString();

            lbtnUpdate.Text = "Cập nhật";
            lbtnCancle.Visible = true;
            lbtnDel.Visible = true;
        }

        ltrCities.Text = BindTreeeCities(CitiesBF.GetCitiesByParentID(0));
    }

    void BindDropCity(int _parent)
    {
        ddlCities.Items.Clear();
        ddlCities.Items.Add(new ListItem("Danh mục gốc", "0"));
        BindDropCity(_parent, "-");
    }

    void BindDropCity(int _parent, string prefix)
    {
        List<CitiesBF> cities = CitiesBF.GetCitiesByParentID(_parent);

        foreach (CitiesBF city in cities)
        {
            ListItem item = new ListItem(prefix + " " + city.Name, city.CityID.ToString());
            ddlCities.Items.Add(item);

            if (CitiesBF.GetCitiesByParentID(city.CityID).Count > 0)
            {
                BindDropCity(city.CityID, prefix + "--");
            }
        }
    }

    string BindTreeeCities(List<CitiesBF> _cities)
    {
        StringBuilder result = new StringBuilder();

        if (_cities.Count > 0)
        {
            result.Append("<ul id='browse_tree'>");

            foreach (CitiesBF city in _cities)
            {
                result.Append("<li style='position: relative'>");
                result.Append("<div class='treeNode'>");
                result.Append("<a href='/adm/ManageCities.aspx?cityID=" + city.CityID + "'>" + city.Name + "</a>");
                result.Append("<span class='important'>");
                result.Append("<a href='/adm/ManageCities.aspx?cityID=" + city.CityID + "&i=up' title='Up'><span class='up_btn' /></a>");
                result.Append("<a href='/adm/ManageCities.aspx?cityID=" + city.CityID + "&i=down' title='Down'><span class='down_btn' /></a>");
                result.Append("</span>");
                result.Append("</div>");

                List<CitiesBF> _subCities = CitiesBF.GetCitiesByParentID(city.CityID);

                if (_subCities.Count > 0)
                {
                    result.Append(BindTreeeCities(_subCities));
                }
            }

            result.Append("</li></ul>");
        }

        return result.ToString();
    }

    protected void lbtnUpdate_Click(object sender, EventArgs e)
    {
        if (hdfCityID.Value == "0")
        {
            CitiesBF city = new CitiesBF();

            city.Name = txtName.Text;
            city.Description = txtDesc.Text;
            city.ParentID = int.Parse(ddlCities.SelectedValue);

            city.Insert();
        }
        else
        {
            CitiesBF city = CitiesBF.GetCitiesBF(int.Parse(hdfCityID.Value));

            city.Name = txtName.Text;
            city.Description = txtDesc.Text;
            city.ParentID = int.Parse(ddlCities.SelectedValue);

            city.Update();
        }

        BindFormCity();
    }

    protected void lbtnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsolutePath);
    }

    protected void lbtnDel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["cityID"] != null)
        {
            int cityID = int.Parse(Request.QueryString["cityID"]);

            if (CitiesBF.GetCitiesByParentID(cityID).Count == 0)
            {
                CitiesBF.Delete(cityID);
                Response.Redirect(Request.Url.AbsolutePath);
            }
            else
                Response.Write("<script> alert('ERROR! Không thể xóa vì vẫn tồn tại nhóm danh mục con trong nhóm danh mục này.'); </script>");
        }
    }
}