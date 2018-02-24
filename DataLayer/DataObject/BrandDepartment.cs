using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class BrandDepartment
    {
        public int BrandID { get; set; }
        public int DepartmentID { get; set; }

        public BrandDepartment()
        {
        }

        public BrandDepartment(int brandID, int departmentID)
        {
            this.BrandID = brandID;
            this.DepartmentID = departmentID;
        }
    }
}
