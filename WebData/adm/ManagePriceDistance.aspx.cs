using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.Configuration;

public partial class adm_ManagePriceDistance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hplNavPage.NavigateUrl = "/adm/DepartmentExtension.aspx?depID=" + Request.QueryString["depID"];
            BindFormInfo(0);
        }
    }

    private void BindFormInfo(int id)
    {
        if (id > 0)
        {
            PriceDistanceBF price = PriceDistanceBF.GetPriceDistanceBF(id);

            hdfId.Value = id.ToString();
            txtPriceFrom.Text = price.PriceFrom.ToString();
            txtPriceTo.Text = price.PriceTo.ToString();
            btnInsert.Text = "Cập nhật";
        }
        else
        {
            hdfId.Value = "0";
            txtPriceFrom.Text = "";
            txtPriceTo.Text = "";
            btnInsert.Text = "Thêm mới";
        }
    }

    private void DeselectPrice()
    {
        gvwPrice.SelectedIndex = -1;
        gvwPrice.DataBind();

        BindFormInfo(0);
    }

    protected void gvwPrice_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFormInfo(int.Parse(((GridView)sender).SelectedDataKey.Value.ToString()));
    }

    protected void gvwPrice_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        DeselectPrice();
    }

    protected void gvwPrice_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = e.Row.Cells[3].Controls[0] as ImageButton;
            btnDelete.OnClientClick = "if (confirm('Bạn có chắc chắn muốn xóa mức giá này?') == false) return false;";
        }
    }

    protected void ckbAllow_CheckedChanged(object sender, EventArgs e)
    {
        //CheckBox ckbListed = (CheckBox)sender;
        //GridViewRow rowId = (GridViewRow)ckbListed.NamingContainer;

        //ArticleHighlightsBF ah = ArticleHighlightsBF.GetArticleHighlightsBF(int.Parse(gvwArticleHighlights.DataKeys[rowId.RowIndex].Value.ToString()));
        //ah.Listed = ckbListed.Checked;
        //ah.Update();

        //DeselectArticleHighlight();
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        int priceFrom = int.Parse(txtPriceFrom.Text.Trim());
        int priceTo = int.Parse(txtPriceTo.Text.Trim());

        if (priceTo <= priceFrom)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Giá sau phải lớn hơn giá trước');", true);
            return;
        }
        else
        {
            if (hdfId.Value != "0")
            {
                PriceDistanceBF price = PriceDistanceBF.GetPriceDistanceBF(int.Parse(hdfId.Value));

                price.PriceFrom = priceFrom;
                price.PriceTo = priceTo;
                price.Update();

                price.Title = price.PriceFrom.ToString("###,###;(###,###)") + " VNĐ - " + price.PriceTo.ToString("###,###;(###,###)") + " VNĐ";
                price.Update();
            }
            else
            {
                PriceDistanceBF price = new PriceDistanceBF();

                price.PriceFrom = priceFrom;
                price.PriceTo = priceTo;
                price.AllowSearcch = true;

                int priceID = price.Insert();

                price = PriceDistanceBF.GetPriceDistanceBF(priceID);
                price.Title = price.PriceFrom.ToString("###,###;(###,###)") + " VNĐ - " + price.PriceTo.ToString("###,###;(###,###)") + " VNĐ";
                price.Update();
            }

            DeselectPrice();
            BindFormInfo(0);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DeselectPrice();
        BindFormInfo(0);
    }

    protected void gvwPrice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvwPrice.PageIndex = e.NewPageIndex;
        this.gvwPrice.DataBind();

        BindFormInfo(0);
    }
}