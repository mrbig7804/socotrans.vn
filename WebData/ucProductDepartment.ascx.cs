using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucProductDepartment : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    int _inputID;

    public int InputID
    {
        set
        {
            ltrMenu.Text = BindData(DepartmentsBF.GetDepartmentsByParentIDAndSuperDepartmentID(0, value));
        }

        get
        {
            return _inputID;
        }
    }

    private string BindData(List<DepartmentsBF> _deps)
    {
        StringBuilder result = new StringBuilder();

        if (_deps.Count > 0)
        {
            int num = 0;
            result.Append("<ul>");

            foreach (DepartmentsBF dep in _deps)
            {
                num += 1;

                result.Append("<li><span class='num'>" + num.ToString() + "</span>");
                result.Append("<h3><a href='/san-pham/" + dep.DepartmentID + "/" + VNString.TextToUrl(dep.Title));
                result.Append("' title='" + dep.Title + "'>" + dep.Title + "</a></h3>");

                List<DepartmentsBF> _subDeps = DepartmentsBF.GetDepartmentsByParentID(dep.DepartmentID);

                if (_subDeps.Count > 0)
                {
                    result.Append(BindData(_subDeps));
                }
            }

            result.Append("</li></ul>");
        }

        return result.ToString();
    }

}