using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class PropertiesValue
    {
        public int PropertiesValueID { get; set; }
        public int PropertyID { get; set; }
        public string Value { get; set; }

        public PropertiesValue()
        {
        }

        public PropertiesValue(int propertiesValueID, int propertyID, string value)
        {
            this.PropertiesValueID = propertiesValueID;
            this.PropertyID = propertyID;
            this.Value = value;
        }
    }
}
