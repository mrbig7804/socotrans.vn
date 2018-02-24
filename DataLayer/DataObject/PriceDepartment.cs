using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class PriceDepartment
    {
        public int PriceID { get; set; }
        public int DepartmentID { get; set; }

        public PriceDepartment()
        {
        }

        public PriceDepartment(int priceID, int departmentID)
        {
            this.PriceID = priceID;
            this.DepartmentID = departmentID;
        }
    }
}
