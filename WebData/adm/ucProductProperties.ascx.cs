using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class adm_ucProductProperties : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.ProductID != 0)
            {
                List<PropertiesBF> _source = new List<PropertiesBF>();
                var pGroups = PropertiesGroupsBF.GetPropertiesGroupsByDepartment(ProductsBF.GetProductsBF(this.ProductID).DepartmentID);

                if (pGroups != null)
                {
                    foreach (PropertiesGroupsBF pg in pGroups)
                    {
                        var properties = PropertiesBF.GetPropertiesByPropertyGroup(pg.PropertyGroupID);

                        if (properties != null)
                        {
                            foreach (PropertiesBF p in properties)
                            {
                                _source.Add(p);
                            }
                        }
                    }

                    rptProperty.DataSource = _source;
                    rptProperty.DataBind();
                }

                SetProductProperty();
            }
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

    public int ProductID { get; set ;}    

    protected bool CheckProductProperty(int productID, int propertyValueID)
    {
        return ProductPropertiesBF.GetProductProperty(productID, propertyValueID) != null;
    }

    public void SetProductProperty()
    {
        foreach (RepeaterItem item in rptProperty.Items)
        {
            GridView gvwPropertyValue = item.FindControl("gvwPropertyValue") as GridView;

            for (int i = 0; i < gvwPropertyValue.Rows.Count; i++)
            {
                GridViewRow rowValue = gvwPropertyValue.Rows[i];

                CheckBox chkSetValue = ((CheckBox)rowValue.FindControl("chkSetValue"));

                int valueID = int.Parse(gvwPropertyValue.DataKeys[rowValue.RowIndex]["PropertiesValueID"].ToString());

                if (CheckProductProperty(this.ProductID, valueID))
                {
                    chkSetValue.Checked = true;
                }
                else
                {
                    chkSetValue.Checked = false;
                }
            }
        }
    }

    public void ActiveProductProperty()
    {
        foreach (RepeaterItem item in rptProperty.Items)
        {
            GridView gvwPropertyValue = item.FindControl("gvwPropertyValue") as GridView;

            for (int j = 0; j < gvwPropertyValue.Rows.Count; j++)
            {
                GridViewRow rowValue = gvwPropertyValue.Rows[j];

                bool isChecked = ((CheckBox)rowValue.FindControl("chkSetValue")).Checked;
                int valueID = int.Parse(gvwPropertyValue.DataKeys[rowValue.RowIndex]["PropertiesValueID"].ToString());

                ProductPropertiesBF pp = ProductPropertiesBF.GetProductProperty(this.ProductID, valueID);

                if (isChecked)
                {
                    if (pp == null)
                    {
                        pp = new ProductPropertiesBF();
                        pp.ProductID = this.ProductID;
                        pp.PropertyValueID = valueID;
                        pp.Insert();
                    }
                }
                else
                {
                    if (pp != null) pp.Delete();
                }
            }
        }
    }

    protected void rptProperty_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int propertyId = int.Parse(DataBinder.Eval(e.Item.DataItem, "PropertyID").ToString());

            GridView gvwPropertyValue = e.Item.FindControl("gvwPropertyValue") as GridView;

            gvwPropertyValue.DataSource = PropertiesValuesBF.GetPropertiesValuesByProperty(propertyId);
            gvwPropertyValue.DataBind();
            SetProductProperty();
        }
    }

    //protected void gvwPropertyValue_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    foreach( RepeaterItem item in rptProperty.Items )
    //    {
    //        GridView gvwPropertyValue = item.FindControl("gvwPropertyValue") as GridView;

    //        gvwPropertyValue.EditIndex = e.NewEditIndex;
    //        gvwPropertyValue.DataBind();
    //        SetProductProperty();
    //    }
    //}
    //protected void gvwPropertyValue_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    foreach (RepeaterItem item in rptProperty.Items)
    //    {
    //        GridView gvwPropertyValue = item.FindControl("gvwPropertyValue") as GridView;
    //        PropertiesValuesBF propertyValue = PropertiesValuesBF.GetPropertiesValuesBF(int.Parse(gvwPropertyValue.DataKeys[e.RowIndex].Value.ToString()));

    //        propertyValue.Value = Regex.Replace(((TextBox)gvwPropertyValue.Rows[e.RowIndex].FindControl("txtPropertyValue")).Text.Trim(), "\\ {2,}", " ");
    //        propertyValue.Update();
    //        gvwPropertyValue.DataBind();
    //        SetProductProperty();
    //    }
    //}
    //protected void gvwPropertyValue_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    foreach (RepeaterItem item in rptProperty.Items)
    //    {
    //        GridView gvwPropertyValue = item.FindControl("gvwPropertyValue") as GridView;
    //        gvwPropertyValue.EditIndex = -1;
    //        gvwPropertyValue.DataBind();
    //        SetProductProperty();
    //    }
    //}
    //protected void lbtnInsertPropertyValue_Click(object sender, EventArgs e)
    //{
    //    foreach (RepeaterItem item in rptProperty.Items)
    //    {
    //        GridView gvwPropertyValue = item.FindControl("gvwPropertyValue") as GridView;
    //        string value = Regex.Replace(((TextBox)gvwPropertyValue.FooterRow.FindControl("txtPropertyValue")).Text.Trim(), "\\ {2,}", " ");

    //        //PropertiesValuesBF pv = new PropertiesValuesBF();
    //        //pv.PropertyID = int.Parse(DataBinder.Eval(item.DataItem, "PropertyID").ToString());
    //        //pv.Value = value;
    //        //pv.Insert();
    //        //SetProductProperty();
    //    }
    //}
}