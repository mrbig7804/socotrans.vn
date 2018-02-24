using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucProductsBySearch : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadParentDepartments();
            LoadDepartments(0);
        }
    }

    private void LoadParentDepartments()
    {
        List<SuperDepartmentsBF> list = SuperDepartmentsBF.GetSuperDepartmentsAll();

        ddlParentDepartment.Items.Clear();
        ddlParentDepartment.Items.Add(new ListItem("Loại sản phẩm...", "0"));

        foreach (SuperDepartmentsBF item in list)
        {
            ddlParentDepartment.Items.Add(new ListItem(item.Title, item.SuperDepartmentID.ToString()));
        }
    }

    private void LoadDepartments(int parentId)
    {
        List<DepartmentsBF> list = DepartmentsBF.GetDepartmentsBySuperDepartmentID(parentId);

        ddlDepartment.Items.Clear();
        ddlDepartment.Items.Add(new ListItem("Hãng sản xuất...", "0"));

        if (list != null)
        {
            foreach (DepartmentsBF item in list)
            {
                ddlDepartment.Items.Add(new ListItem(item.Title, item.DepartmentID.ToString()));
            }
        }
    }

    protected void ddlParentDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDepartments(int.Parse(ddlParentDepartment.SelectedItem.Value));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string key = "";
        int parentDepartment = 0;
        int department = 0;
        int minPrice = 0;
        int maxPrice = 0;

        if (txtKey.Text != "")
        {
            key = txtKey.Text.Trim();
        }
        if (ddlParentDepartment.SelectedValue != "0")
        {
            parentDepartment = int.Parse(ddlParentDepartment.SelectedValue);
        }
        if (ddlDepartment.SelectedValue != "0")
        {
            department = int.Parse(ddlDepartment.SelectedValue);
        }
        if (ddlMinPrice.SelectedValue != "0")
        {
            minPrice = int.Parse(ddlMinPrice.SelectedValue);
        }
        if (ddlMaxPrice.SelectedValue != "0")
        {
            maxPrice = int.Parse(ddlMaxPrice.SelectedValue);
        }

        pnSearchResult.Visible = true;
        lvProducts.DataSource = ProductsBF.GetProductsBySearch(key, parentDepartment, department, minPrice, maxPrice);
        lvProducts.DataBind();
    }

    protected void lvProducts_PreRender(object sender, EventArgs e)
    {
        DataPager1.Visible = (DataPager1.TotalRowCount > DataPager1.PageSize);
        DataPager2.Visible = (DataPager1.TotalRowCount > DataPager1.PageSize);
    }
}