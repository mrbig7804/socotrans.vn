using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class Property
    {
        public int PropertyID { get; set; }
        public int PropertyGroupID { get; set; }
        public string Title { get; set; }
        public int Important { get; set; }
        public bool AllowSearch { get; set; }

        public Property()
        {
        }

        public Property(int propertyID, int propertyGroupID, string title, int important, bool allowSearch)
        {
            this.PropertyID = propertyID;
            this.PropertyGroupID = propertyGroupID;
            this.Title = title;
            this.Important = important;
            this.AllowSearch = allowSearch;
        }
    }
}
