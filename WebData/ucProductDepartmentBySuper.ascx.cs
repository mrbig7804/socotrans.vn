using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucProductDepartmentBySuper : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    int _superDepartmentID;

    public int SuperDepartmentID
    {
        set
        {
            ltrMenu.Text = BindData(DepartmentsBF.GetDepartmentsByParentIDAndSuperDepartmentID(0, value));
        }

        get
        {
            return _superDepartmentID;
        }
    }

    private string BindData(List<DepartmentsBF> _deps)
    {
        StringBuilder result = new StringBuilder();

        if (_deps.Count > 0)
        {
            result.Append("<ul>");

            foreach (DepartmentsBF dep in _deps)
            {
                result.Append("<li><h3><a href='/san-pham/" + dep.DepartmentID + "/" + VNString.TextToUrl(dep.Title) + "' title='" + dep.Title + "'>" + dep.Title + "</a></h3>");

                //List<DepartmentsBF> _subDeps = DepartmentsBF.GetDepartmentsByParentID(dep.DepartmentID);

                //if (_subDeps.Count > 0)
                //{
                //    result.Append(BindData(_subDeps));
                //}
            }

            result.Append("</li></ul>");
        }

        return result.ToString();
    }
}