using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.IO;
using System.Web.Security;

using Zensoft.Website.BusinessLayer.BusinessFacade;

/// <summary>
/// DropdownList thể hiện nhóm thư mục 
/// </summary>
namespace Zensoft.Website.UI
{
         [ParseChildren(true)]
   public class ProductDepartmentDropdown : DropDownList
    {
        public ProductDepartmentDropdown()
        {
            this.Items.Insert(0, new ListItem("Danh mục sản phẩm", ""));

            List<SuperDepartmentsBF> sd = SuperDepartmentsBF.GetSuperDepartmentsAll();

            foreach (SuperDepartmentsBF s in sd)
            {
                this.CssClass = "dropdownlistParent";
                ListItem l =  new ListItem("" + s.Title.ToUpper(), "");
                l.Attributes.Add("style", "color:Red; font-weight:Bold;");
                this.Items.Add(l);

                List<DepartmentsBF> departments = DepartmentsBF.GetDepartmentsBySuperDepartmentID(s.SuperDepartmentID);

           }

        }
    }
}