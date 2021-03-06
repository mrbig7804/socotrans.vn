using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public partial class OrdersBF : BaseBF
    {

        protected int _orderID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected int _statusID;
        protected string _paymentMethod = String.Empty;
        protected string _accountCode = String.Empty;
        protected int _total;
        protected string _shippingFullName = String.Empty;
        protected string _shippingAddress = String.Empty;
        protected string _shippingCity = String.Empty;
        protected string _customerEmail = String.Empty;
        protected string _customerPhone = String.Empty;
        protected string _customerMoblie = String.Empty;
        protected DateTime _shippedDate;
        protected string _description = String.Empty;
        protected string _note = String.Empty;

        #region Public Properties

        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
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

        public int StatusID
        {
            get { return _statusID; }
            set { _statusID = value; }
        }

        public string PaymentMethod
        {
            get { return _paymentMethod; }
            set { _paymentMethod = value; }
        }

        public string AccountCode
        {
            get { return _accountCode; }
            set { _accountCode = value; }
        }

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public string ShippingFullName
        {
            get { return _shippingFullName; }
            set { _shippingFullName = value; }
        }

        public string ShippingAddress
        {
            get { return _shippingAddress; }
            set { _shippingAddress = value; }
        }

        public string ShippingCity
        {
            get { return _shippingCity; }
            set { _shippingCity = value; }
        }

        public string CustomerEmail
        {
            get { return _customerEmail; }
            set { _customerEmail = value; }
        }

        public string CustomerPhone
        {
            get { return _customerPhone; }
            set { _customerPhone = value; }
        }

        public string CustomerMoblie
        {
            get { return _customerMoblie; }
            set { _customerMoblie = value; }
        }

        public DateTime ShippedDate
        {
            get { return _shippedDate; }
            set
            {
                if (value != null)
                    this.ShippedDate = value;
                else
                    this.ShippedDate = this.AddedDate.AddDays(7);
            }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
        public int GrossOrder
        {
            get
            {
                int shipPrice = 0;
                try
                {
                    if (this.Note != null)
                    {
                        shipPrice = Convert.ToInt32(this.Note);
                    }
                    return this.Total + shipPrice;
                }
                catch
                {
                    return this.Total;
                }
            }

        }
        #endregion

        #region Custom Properties

        OrderStatusBF _orderStatus = null;
        OrderStatusBF OrderStatus
        {
            get
            {
                if (_orderStatus == null)
                    _orderStatus = OrderStatusBF.GetOrderStatusBF(this.StatusID);
                return _orderStatus;
            }
        }

        public string OrderStatusTitle
        {
            get
            {
                return this.OrderStatus.Title;
            }
        }

        List<OrderItemsBF> _orderItems = null;
        public List<OrderItemsBF> OrderItems
        {
            get
            {
                if (_orderItems == null)
                    _orderItems = OrderItemsBF.GetOrderItemsByOrderID(this._orderID);
                return _orderItems;
            }
        }


        #endregion


        private static List<OrdersBF> GetOrdersBFListFromOrdersList(List<Order> recordset)
        {
            List<OrdersBF> ret = new List<OrdersBF>();
            foreach (Order record in recordset)
                ret.Add(GetOrdersBFFromOrder(record));
            return ret;
        }

        private static OrdersBF GetOrdersBFFromOrder(Order record)
        {
            if (record == null)
                return null;
            else
            {
                return new OrdersBF(record.OrderID, record.AddedDate, record.AddedBy, record.StatusID, record.PaymentMethod, record.AccountCode, record.Total, record.ShippingFullName, record.ShippingAddress, record.ShippingCity, record.CustomerEmail, record.CustomerPhone, record.CustomerMoblie, record.ShippedDate, record.Description, record.Note);
            }
        }

        public OrdersBF()
        {
        }


        public OrdersBF(int orderID, DateTime addedDate, string addedBy, int statusID, string paymentMethod, string accountCode, int total, string shippingFullName, string shippingAddress, string shippingCity, string customerEmail, string customerPhone, string customerMoblie, DateTime shippedDate, string description, string note)
        {
            _orderID = orderID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _statusID = statusID;
            _paymentMethod = paymentMethod;
            _accountCode = accountCode;
            _total = total;
            _shippingFullName = shippingFullName;
            _shippingAddress = shippingAddress;
            _shippingCity = shippingCity;
            _customerEmail = customerEmail;
            _customerPhone = customerPhone;
            _customerMoblie = customerMoblie;
            _shippedDate = shippedDate;
            _description = description;
            _note = note;
        }

        public static OrdersBF GetOrdersBF(int orderID)
        {
            return GetOrdersBFFromOrder(SiteProvider.OrdersProvider.GetOrder(orderID));
        }

        //Get by ForeignKey
        public static List<OrdersBF> GetOrdersByStatusID(int statusID)
        {
            return GetOrdersBFListFromOrdersList(SiteProvider.OrdersProvider.GetOrdersByStatusID(statusID));
        }

        //Get All
        public static List<OrdersBF> GetOrdersAll()
        {
            return GetOrdersBFListFromOrdersList(SiteProvider.OrdersProvider.GetOrdersAll());
        }

        //Insert
        public int Insert()
        {
            return OrdersBF.Insert(this.OrderID, this.AddedDate, this.AddedBy, this.StatusID, this.PaymentMethod, this.AccountCode, this.Total, this.ShippingFullName, this.ShippingAddress, this.ShippingCity, this.CustomerEmail, this.CustomerPhone, this.CustomerMoblie, this.ShippedDate, this.Description, this.Note);
        }

        //Update
        public bool Update()
        {
            return OrdersBF.Update(this.OrderID, this.AddedDate, this.AddedBy, this.StatusID, this.PaymentMethod, this.AccountCode, this.Total, this.ShippingFullName, this.ShippingAddress, this.ShippingCity, this.CustomerEmail, this.CustomerPhone, this.CustomerMoblie, this.ShippedDate, this.Description, this.Note);
        }

        //Delete
        public bool Delete()
        {
            return OrdersBF.Delete(this.OrderID);
        }

        //Insert
        public static int Insert(int orderID, DateTime addedDate, string addedBy, int statusID, string paymentMethod, string accountCode, int total, string shippingFullName, string shippingAddress, string shippingCity, string customerEmail, string customerPhone, string customerMoblie, DateTime shippedDate, string description, string note)
        {
            return SiteProvider.OrdersProvider.Insert(new Order(orderID, addedDate, addedBy, statusID, paymentMethod, accountCode, total, shippingFullName, shippingAddress, shippingCity, customerEmail, customerPhone, customerMoblie, shippedDate, description, note));
        }

        //Update
        public static bool Update(int orderID, DateTime addedDate, string addedBy, int statusID, string paymentMethod, string accountCode, int total, string shippingFullName, string shippingAddress, string shippingCity, string customerEmail, string customerPhone, string customerMoblie, DateTime shippedDate, string description, string note)
        {
            return SiteProvider.OrdersProvider.Update(new Order(orderID, addedDate, addedBy, statusID, paymentMethod, accountCode, total, shippingFullName, shippingAddress, shippingCity, customerEmail, customerPhone, customerMoblie, shippedDate, description, note));
        }

        //Delete
        public static bool Delete(int orderID)
        {
            List<OrderItemsBF> items = OrderItemsBF.GetOrderItemsByOrderID(orderID);

            if (items.Count > 0)
            {
                foreach (OrderItemsBF item in items) 
                {
                    item.Delete();
                }
            }

            return SiteProvider.OrdersProvider.Delete(orderID);
        }
        //get orderid lastest

    }
}
