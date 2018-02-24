using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class SupplierPrice
    {
        protected int _supplierID;
        protected int _productID;
        protected int _inputPrice;

        public SupplierPrice()
        {
        }

        public SupplierPrice(int supplierID, int productID, int inputPrice)
        {
            _supplierID = supplierID;
            _productID = productID;
            _inputPrice = inputPrice;
        }

        #region Public Properties

        public int SupplierID
        {
            get { return _supplierID; }
            set { _supplierID = value; }
        }

        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public int InputPrice
        {
            get { return _inputPrice; }
            set { _inputPrice = value; }
        }
        #endregion
    }

}
