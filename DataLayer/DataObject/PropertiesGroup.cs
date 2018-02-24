using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class PropertiesGroup
    {
        public int PropertyGroupID { get; set; }
        public int DepartmentID { get; set; }
        public string Title { get; set; }
        public int Important { get; set; }

        public PropertiesGroup()
        {
        }

        public PropertiesGroup(int propertyGroupID, int departmentID, string title, int important)
        {
            this.PropertyGroupID = propertyGroupID;
            this.DepartmentID = departmentID;
            this.Title = title;
            this.Important = important;
        }
    }
}
