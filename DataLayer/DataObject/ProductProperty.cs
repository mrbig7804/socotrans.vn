using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class ProductProperty
    {
        public int ProductID { get; set; }
        public int PropertyValueID { get; set; }

        public ProductProperty()
        {
        }

        public ProductProperty(int productID, int propertyValueID)
        {
            this.ProductID = productID;
            this.PropertyValueID = propertyValueID;
        }
    }
}
