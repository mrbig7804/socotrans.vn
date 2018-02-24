using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class adm_ManageDirection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["dirID"]) & !string.IsNullOrEmpty(Request.QueryString["i"]))
            {
                var dir = DirectionBF.GetDirectionBF(int.Parse(Request.QueryString["dirID"]));

                if (Request.QueryString["i"] == "up")
                    dir.IncreaseImportance();

                if (Request.QueryString["i"] == "down")
                    dir.ReducedImportance();

                Response.Redirect(Request.Url.AbsolutePath);
            }

            BindFormDirection();
        }
    }

    void BindFormDirection()
    {
        int dirID = 0;
        if (!string.IsNullOrEmpty(Request.QueryString["dirID"]))
            dirID = int.Parse(Request.QueryString["dirID"]);

        if (dirID == 0)
        {
            hdfDirID.Value = dirID.ToString();
            txtTitle.Text = "";
            txtDesc.Text = "";
            
            lbtnUpdate.Text = "Thêm mới";
            lbtnCancle.Visible = true;
            lbtnDel.Visible = false;
        }
        else if (dirID > 0)
        {
            hdfDirID.Value = dirID.ToString();

            DirectionBF dir = DirectionBF.GetDirectionBF(dirID);

            txtTitle.Text = dir.Title;
            txtDesc.Text = dir.Description;
            
            lbtnUpdate.Text = "Cập nhật";
            lbtnCancle.Visible = true;
            lbtnDel.Visible = true;
        }

        rptDirection.DataBind();
    }
    protected void lbtnUpdate_Click(object sender, EventArgs e)
    {
        if (hdfDirID.Value == "0")
        {
            DirectionBF dir = new DirectionBF();

            dir.Title = txtTitle.Text;
            dir.Description = txtDesc.Text;

            dir.Insert();
        }
        else
        {
            DirectionBF dir = DirectionBF.GetDirectionBF(int.Parse(hdfDirID.Value));

            dir.Title = txtTitle.Text;
            dir.Description = txtDesc.Text;

            dir.Update();
        }

        BindFormDirection();
    }
    protected void lbtnDel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["dirID"] != null)
        {
            int dirID = int.Parse(Request.QueryString["dirID"]);

            //if (DepartmentsBF.GetDepartmentsByParentID(dirID).Count == 0 && ProductsBF.GetProductsByDepartmentID(dirID).Count == 0)
            //{
                DirectionBF.Delete(dirID);
                Response.Redirect(Request.Url.AbsolutePath);
            //}
            //else
            //    Response.Write("<script> alert('ERROR! Không thể xóa vì vẫn tồn tại sản phẩm hoặc nhóm hàng con trong nhóm hàng này.'); </script>");
        }
    }
    protected void lbtnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsolutePath);
    }
}