using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class adm_ucSpecialProduct : System.Web.UI.UserControl
{
    public int ProductID { get; set; }

    int specialID;
    public int SpecialID
    {
        get
        {
            return specialID;
        }
        set
        {
            specialID = value;

            var special = SpecialsBF.GetSpecialsBF(specialID);
            ckbSpecial.Text = special.Title.Trim();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        Page.RegisterRequiresControlState(this);
        base.OnInit(e);
    }

    /// <summary>
    /// lấy ra trạng thái cũ của control
    /// </summary>
    /// <param name="savedState"></param>
    protected override void LoadControlState(object savedState)
    {
        object[] ctlState = (object[])savedState;
        base.LoadControlState(ctlState[0]);
        this.ProductID = (int)ctlState[1];
    }

    /// <summary>
    /// lưu lại trạng thái của control
    /// </summary>
    /// <returns></returns>
    protected override object SaveControlState()
    {
        object[] ctlState = new object[2];
        ctlState[0] = base.SaveControlState();
        ctlState[1] = this.ProductID;
        return ctlState;
    }

    protected bool CheckSpecialProduct(int productID, int specialID)
    {
        return ProductSpecialsBF.GetProductSpecial(productID, specialID) != null;
    }

    public void SetSpecialProduct()
    {
        if (CheckSpecialProduct(this.ProductID, this.SpecialID))
        {
            var ps = ProductSpecialsBF.GetProductSpecial(this.ProductID, this.SpecialID);

            ckbSpecial.Checked = true;
            txtReleaseDate.Text = ps.ReleaseDate.ToString("dd/MM/yyyy HH:mm");
            txtExpireDate.Text = ps.ExpireDate.ToString("dd/MM/yyyy HH:mm");
            ckbListed.Checked = ps.Listed;
        }
        else
        {
            ckbSpecial.Checked = false;
            txtReleaseDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            txtExpireDate.Text = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy HH:mm");
        }
    }

    public void ActiveSpecialProduct()
    {
        DateTimeFormatInfo dtf = new DateTimeFormatInfo();
        dtf.ShortDatePattern = "dd/MM/yyyy HH:mm";

        if (ckbSpecial.Checked == true)
        {
            if (!CheckSpecialProduct(this.ProductID, this.SpecialID))
                ProductSpecialsBF.Insert(this.ProductID, this.SpecialID, Convert.ToDateTime(txtReleaseDate.Text, dtf), Convert.ToDateTime(txtExpireDate.Text, dtf), ckbListed.Checked);
            else
                ProductSpecialsBF.Update(this.ProductID, this.SpecialID, Convert.ToDateTime(txtReleaseDate.Text, dtf), Convert.ToDateTime(txtExpireDate.Text, dtf), ckbListed.Checked);
        }
        else if (ckbSpecial.Checked == false)
        {
            if (CheckSpecialProduct(this.ProductID, this.SpecialID))
                ProductSpecialsBF.Delete(this.ProductID, this.SpecialID);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}