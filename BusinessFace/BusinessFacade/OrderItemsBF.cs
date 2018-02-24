using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;


namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public class OrderItemsBF
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
        protected int _total;
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
        public int Total
        {
            get { return _quantity * _unitPrice; }
        }
        #endregion

        private static List<OrderItemsBF> GetOrderItemsBFListFromOrderItemsList(List<OrderItem> recordset)
        {
            List<OrderItemsBF> ret = new List<OrderItemsBF>();
            foreach (OrderItem record in recordset)
                ret.Add(GetOrderItemsBFFromOrderItem(record));
            return ret;
        }

        private static OrderItemsBF GetOrderItemsBFFromOrderItem(OrderItem record)
        {
            if (record == null)
                return null;
            else
            {
                return new OrderItemsBF(record.OrderItemID, record.AddedDate, record.AddedBy, record.OrderID, record.ProductID, record.Title, record.UnitPrice, record.Quantity, record.Size, record.Color);
            }
        }

        public OrderItemsBF()
        {
        }


        public OrderItemsBF(int orderItemID, DateTime addedDate, string addedBy, int orderID, int productID, string title, int unitPrice, int quantity, string size, string color)
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

        public static OrderItemsBF GetOrderItemsBF(int orderItemID)
        {
            return GetOrderItemsBFFromOrderItem(SiteProvider.OrderItemsProvider.GetOrderItem(orderItemID));
        }

        //Get by ForeignKey
        public static List<OrderItemsBF> GetOrderItemsByOrderID(int orderID)
        {
            return GetOrderItemsBFListFromOrderItemsList(SiteProvider.OrderItemsProvider.GetOrderItemsByOrderID(orderID));
        }
        public static List<OrderItemsBF> GetOrderItemsByProductID(int productID)
        {
            return GetOrderItemsBFListFromOrderItemsList(SiteProvider.OrderItemsProvider.GetOrderItemsByProductID(productID));
        }

        public static int GetCountOrderItemsByProductID(int productID)
        {
            return SiteProvider.OrderItemsProvider.GetCountOrderItemsByProductID(productID);
        }

        //Get All
        public static List<OrderItemsBF> GetOrderItemsAll()
        {
            return GetOrderItemsBFListFromOrderItemsList(SiteProvider.OrderItemsProvider.GetOrderItemsAll());
        }

        //Insert
        public int Insert()
        {
            return OrderItemsBF.Insert(this.OrderItemID, this.AddedDate, this.AddedBy, this.OrderID, this.ProductID, this.Title, this.UnitPrice, this.Quantity, this.Size, this.Color);
        }

        //Update
        public bool Update()
        {
            return OrderItemsBF.Update(this.OrderItemID, this.AddedDate, this.AddedBy, this.OrderID, this.ProductID, this.Title, this.UnitPrice, this.Quantity, this.Size, this.Color);
        }

        //Delete
        public bool Delete()
        {
            return OrderItemsBF.Delete(this.OrderItemID);
        }

        //Insert
        public static int Insert(int orderItemID, DateTime addedDate, string addedBy, int orderID, int productID, string title, int unitPrice, int quantity, string size, string color)
        {
            return SiteProvider.OrderItemsProvider.Insert(new OrderItem(orderItemID, addedDate, addedBy, orderID, productID, title, unitPrice, quantity, size, color));
        }

        //Update
        public static bool Update(int orderItemID, DateTime addedDate, string addedBy, int orderID, int productID, string title, int unitPrice, int quantity, string size, string color)
        {
            return SiteProvider.OrderItemsProvider.Update(new OrderItem(orderItemID, addedDate, addedBy, orderID, productID, title, unitPrice, quantity, size, color));
        }

        //Delete
        public static bool Delete(int orderItemID)
        {
            return SiteProvider.OrderItemsProvider.Delete(orderItemID);
        }

    }
}
