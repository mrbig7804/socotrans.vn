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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Zensoft.Website.Toolkit;
using Zensoft.Website.Configuration;
using System.Text;

public partial class adm_ManageProducts : System.Web.UI.Page
{
    private int flag = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtImgWidth.Text = AppConfiguration.ProductDepartmentWidth.ToString();
            txtImgHeight.Text = AppConfiguration.ProductDepartmentHeight.ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["depID"]) & !string.IsNullOrEmpty(Request.QueryString["i"]))
            {
                var dep = DepartmentsBF.GetDepartmentsBF(int.Parse(Request.QueryString["depID"]));

                if (Request.QueryString["i"] == "up")
                    dep.IncreaseImportance();

                if (Request.QueryString["i"] == "down")
                    dep.ReducedImportance();

                Response.Redirect(Request.Url.AbsolutePath);
            }

            BindFormDepartment();
        }
    }

    protected void rptSuperDep_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int superDep = int.Parse(DataBinder.Eval(e.Item.DataItem, "SuperDepartmentID").ToString());

            Literal ltrDep = e.Item.FindControl("ltrDep") as Literal;

            ltrDep.Text = BindTreeDepartment(DepartmentsBF.GetDepartmentsByParentIDAndSuperDepartmentID(0, superDep));
        }
    }

    protected void hplChange_Click(object sender, EventArgs e)
    {
        if (File.Exists(Server.MapPath(txtImageUrl.Text)))
        {
            File.Delete(Server.MapPath(txtImageUrl.Text));
        }

        DepartmentsBF dep = DepartmentsBF.GetDepartmentsBF(int.Parse(hdfDepID.Value));
        dep.ImageUrl = "";

        dep.Update();
        txtImageUrl.Text = "";
        pnChangeImage.Visible = false;
        pnImage.Visible = true;

    }

    protected void lbtnUpdate_Click(object sender, EventArgs e)
    {
        if (hdfDepID.Value == "0")
        {
            DepartmentsBF dep = new DepartmentsBF();

            dep.Title = txtTitle.Text;
            dep.Description = txtDesc.Text;
            dep.SuperDepartmentID = SuperDepartmentsBF.GetSuperDepartmentsAll().First().SuperDepartmentID;
            dep.ParentID = int.Parse(ddlDepartment.SelectedValue);

            if (fuImage.HasFile)
            {
                string dir = "/Attachs/Departments/";
                if (!Directory.Exists(Server.MapPath(dir)))
                    Directory.CreateDirectory(Server.MapPath(dir));

                string name = VNString.TextToUrl(txtTitle.Text.Trim());
                string fullPath = Path.Combine(dir, name) + Path.GetExtension(fuImage.FileName);
                int i = 0;

                while (File.Exists(Server.MapPath(fullPath)))
                {
                    i++;
                    name = VNString.TextToUrl(txtTitle.Text.Trim()) + "-" + i.ToString();
                    fullPath = Path.Combine(dir, name) + Path.GetExtension(fuImage.FileName);
                }

                fuImage.SaveAs(Server.MapPath(fullPath));
                Imaging.ResizeCropImage(Server.MapPath(fullPath), Server.MapPath(fullPath), Convert.ToInt32(txtImgWidth.Text), Convert.ToInt32(txtImgHeight.Text));

                dep.ImageUrl = fullPath;
            }
            else
            {
                dep.ImageUrl = "";
            }

            dep.Insert();
        }
        else
        {
            DepartmentsBF dep = DepartmentsBF.GetDepartmentsBF(int.Parse(hdfDepID.Value));

            dep.Title = txtTitle.Text;
            dep.Description = txtDesc.Text;
            dep.ParentID = int.Parse(ddlDepartment.SelectedValue);
            dep.SuperDepartmentID = SuperDepartmentsBF.GetSuperDepartmentsAll().First().SuperDepartmentID;

            if (txtImageUrl.Text != "")
            {
                dep.ImageUrl = txtImageUrl.Text.Trim();
            }
            else
            {
                if (fuImage.HasFile)
                {
                    string dir = "/Attachs/Departments/";
                    if (!Directory.Exists(Server.MapPath(dir)))
                        Directory.CreateDirectory(Server.MapPath(dir));

                    string name = VNString.TextToUrl(txtTitle.Text.Trim());
                    string fullPath = Path.Combine(dir, name) + Path.GetExtension(fuImage.FileName);
                    int i = 0;

                    while (File.Exists(Server.MapPath(fullPath)))
                    {
                        i++;
                        name = VNString.TextToUrl(txtTitle.Text.Trim()) + "-" + i.ToString();
                        fullPath = Path.Combine(dir, name) + Path.GetExtension(fuImage.FileName);
                    }

                    fuImage.SaveAs(Server.MapPath(fullPath));
                    Imaging.ResizeCropImage(Server.MapPath(fullPath), Server.MapPath(fullPath), Convert.ToInt32(txtImgWidth.Text), Convert.ToInt32(txtImgHeight.Text));

                    dep.ImageUrl = fullPath;
                }
                else
                {
                    dep.ImageUrl = "";
                }
            }

            dep.Update();
        }

        BindFormDepartment();
    }

    protected void lbtnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsolutePath);
    }

    protected void lbtnDel_Click(object sender, EventArgs e)
    {
        if(Request.QueryString["depID"] != null)
        {
            int depID = int.Parse(Request.QueryString["depID"]);

            if (DepartmentsBF.GetDepartmentsByParentID(depID).Count == 0 && ProductsBF.GetProductsByDepartmentID(depID, 0).Count == 0)
            {
                DepartmentsBF.Delete(depID);
                Response.Redirect(Request.Url.AbsolutePath);
            }
            else
                Response.Write("<script> alert('ERROR! Không thể xóa vì vẫn tồn tại sản phẩm hoặc nhóm hàng con trong nhóm hàng này.'); </script>");
        }
    }

    protected void gvwProducts_RowCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            ProductsBF.Delete(int.Parse(e.CommandArgument.ToString()));

            BindFormDepartment();
        }
    }

    protected void gvwProducts_RowDeleting(object sender, ListViewDeleteEventArgs e)
    {
    }

    protected void gvwProducts_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        dpProducts.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        BindFormDepartment();
    }

    protected void ckbListed_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ckbListed = (CheckBox)sender;
        ListViewDataItem rowId = (ListViewDataItem)ckbListed.NamingContainer;
        int productID = int.Parse(gvwProducts.DataKeys[rowId.DisplayIndex].Value.ToString());

        ProductsBF product = ProductsBF.GetProductsBF(productID);
        product.Listed = ckbListed.Checked;
        product.Update();

        BindFormDepartment();
    }

    void BindFormDepartment()
    {
        int depId = 0;
        if (!string.IsNullOrEmpty(Request.QueryString["depID"]))
            depId = int.Parse(Request.QueryString["depID"]);

        BindDropDepartment(SuperDepartmentsBF.GetSuperDepartmentsAll().First().SuperDepartmentID, 0);

        if (depId == 0)
        {
            lblTitleDep.Text = "Thông tin nhóm hàng";

            hdfDepID.Value = depId.ToString();
            txtTitle.Text = "";
            txtDesc.Text = "";
            txtImageUrl.Text = "";

            pnImage.Visible = true;
            pnChangeImage.Visible = false;

            lbtnUpdate.Text = "Thêm mới";
            lbtnCancle.Visible = true;
            lbtnDel.Visible = false;
        }
        else if (depId > 0)
        {
            hdfDepID.Value = depId.ToString();

            DepartmentsBF dep = DepartmentsBF.GetDepartmentsBF(depId);

            lblTitleDep.Text = dep.Title; //+"&nbsp;(<a href='/adm/DepartmentExtension.aspx?depID=" + depId.ToString() + "'>Mở rộng</a>)";

            txtTitle.Text = dep.Title;
            txtDesc.Text = dep.Description;

            if (!String.IsNullOrEmpty(dep.ImageUrl))
            {
                txtImageUrl.Text = dep.ImageUrl;

                pnImage.Visible = false;
                pnChangeImage.Visible = true;
            }
            else
            {
                pnImage.Visible = true;
                pnChangeImage.Visible = false;
            }

            ddlDepartment.SelectedValue = dep.ParentID.ToString();

            lbtnUpdate.Text = "Cập nhật";
            lbtnCancle.Visible = true;
            lbtnDel.Visible = true;
        }

        BindGridProduct();

        rptSuperDep.DataBind();
    }

    string BindTreeDepartment(List<DepartmentsBF> _deps)
    {
        StringBuilder result = new StringBuilder();

        if (_deps.Count > 0)
        {
            result.Append("<ul>");

            foreach (DepartmentsBF dep in _deps)
            {
                result.Append("<li style='position: relative'>");
                result.Append("<div class='treeNode'>");
                result.Append("<a href='/adm/ManageProducts.aspx?depID=" + dep.DepartmentID + "'>" + dep.Title + "</a>");
                result.Append("<span class='important'>");
                result.Append("<a href='/adm/ManageProducts.aspx?depID=" + dep.DepartmentID + "&i=up' title='Up'><span class='up_btn' /></a>");
                result.Append("<a href='/adm/ManageProducts.aspx?depID=" + dep.DepartmentID + "&i=down' title='Down'><span class='down_btn' /></a>");
                result.Append("</span>");
                result.Append("</div>");

                List<DepartmentsBF> _subDeps = DepartmentsBF.GetDepartmentsByParentID(dep.DepartmentID);

                if (_subDeps.Count > 0)
                {
                    result.Append(BindTreeDepartment(_subDeps));
                }
            }

           result.Append("</li></ul>");
        }

        return result.ToString();
    }

    void BindDropDepartment(int _super, int _parent)
    {
        ddlDepartment.Items.Clear();
        ddlDepartment.Items.Add(new ListItem("Nhóm hàng gốc", "0"));
        BindDropDepartment(_super, _parent, "-");
    }

    void BindDropDepartment(int _super, int _parent, string prefix)
    {
        List<DepartmentsBF> deps = DepartmentsBF.GetDepartmentsByParentIDAndSuperDepartmentID(_parent, _super);

        foreach (DepartmentsBF dep in deps)
        {
            ListItem item = new ListItem(prefix + " " + dep.Title, dep.DepartmentID.ToString());
            ddlDepartment.Items.Add(item);

            if (DepartmentsBF.GetDepartmentsByParentIDAndSuperDepartmentID(dep.DepartmentID, _super).Count > 0)
            {
                BindDropDepartment(_super, dep.DepartmentID, prefix + "-");
            }
        }
    }

    void BindGridProduct()
    {
        int depID = 0;
        string listed = "";
        string discontinue = "";
        var products = new List<ProductsBF>();

        if(!String.IsNullOrEmpty(Request.QueryString["depID"]))
        {
            flag = 1;
            depID = int.Parse(Request.QueryString["depID"]);
        }

        if (!String.IsNullOrEmpty(Request.QueryString["listed"]))
        {
            flag = 2;
            listed = Request.QueryString["listed"];
        }

        if (!String.IsNullOrEmpty(Request.QueryString["discontinue"]))
        {
            flag = 3;
            discontinue = Request.QueryString["discontinue"];
        }

        //if (flag > 0)
        //{
            panProduct.Visible = true;

            switch (flag)
            {
                case 0:
                    products = ProductsBF.GetProductsAll();
                    break;
                case 1:
                    products = ProductsBF.GetProductsByDepartmentID(depID, 0);
                    lblTitleGridProduct.Text = "&nbsp;" + DepartmentsBF.GetDepartmentsBF(depID).Title;                    
                    break;
                case 2:
                    products = ProductsBF.GetProductsDynamic("[Listed] = '" + listed + "'", "[AddedDate] DESC");
                    lblTitleGridProduct.Text = "&nbsp;chờ duyệt";
                    break;
                case 3:
                    products = ProductsBF.GetProductsDynamic("[Discontinued] = '" + discontinue + "'", "[AddedDate] DESC");
                    lblTitleGridProduct.Text = "&nbsp;ngừng cung cấp";
                    break;
            }

            lblCountProduct.Text = products.Count.ToString();
            dpProducts.Visible = (products.Count > dpProducts.PageSize);

            gvwProducts.DataSource = products;
            gvwProducts.DataBind();
        //}
        //else panProduct.Visible = false;
    }
}
