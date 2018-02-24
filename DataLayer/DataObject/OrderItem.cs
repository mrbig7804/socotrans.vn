using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class OrderItem
    {
        protected int _orderItemID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected int _orderID;
        protected int _productID;
        protected string _title = String.Empty;
        protected int _unitPrice;
        protected int _quantity;
        protected string _size = String.Empty;
        protected string _color = String.Empty;
       

        public OrderItem()
        {
        }

        public OrderItem(int orderItemID, DateTime addedDate, string addedBy, int orderID, int productID, string title, int unitPrice, int quantity, string size, string color)
        {
            _orderItemID = orderItemID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _orderID = orderID;
            _productID = productID;
            _title = title;
            _unitPrice = unitPrice;
            _quantity = quantity;
            _size = size;
            _color = color;
        }

        #region Public Properties

        public int OrderItemID
        {
            get { return _orderItemID; }
            set { _orderItemID = value; }
        }

        public DateTime AddedDate
        {
            get { return _addedDate; }
            set { _addedDate = value; }
        }

        public string AddedBy
        {
            get { return _addedBy; }
            set { _addedBy = value; }
        }

        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public int UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
      
        #endregion
    }

}
