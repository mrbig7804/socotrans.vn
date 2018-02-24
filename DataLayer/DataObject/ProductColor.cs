using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class ProductColor
    {
        protected int _colorID;
        protected int _productID;
        protected int _quantity;

        public ProductColor()
        {
        }

        public ProductColor(int colorID, int productID, int quantity)
        {
            _colorID = colorID;
            _productID = productID;
            _quantity = quantity;
        }

        #region Public Properties

        public int ColorID
        {
            get { return _colorID; }
            set { _colorID = value; }
        }

        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        #endregion
    }


}
