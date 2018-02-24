using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class Order
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

        public Order()
        {
        }

        public Order(int orderID, DateTime addedDate, string addedBy, int statusID, string paymentMethod, string accountCode, int total, string shippingFullName, string shippingAddress, string shippingCity, string customerEmail, string customerPhone, string customerMoblie, DateTime shippedDate, string description, string note)
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
            set { _shippedDate = value; }
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
        #endregion
    }


    //[Serializable]
    //public class Order
    //{
    //    protected int _orderID;
    //    protected DateTime _addedDate;
    //    protected string _addedBy = String.Empty;
    //    protected int _statusID;
    //    protected string _paymentMethod = String.Empty;
    //    protected string _accountCode = String.Empty;
    //    protected string _shippingAddress = String.Empty;
    //    protected string _shippingCity = String.Empty;
    //    protected string _customerEmail = String.Empty;
    //    protected string _customerPhone = String.Empty;
    //    protected string _customerMoblie = String.Empty;
    //    protected DateTime _shippedDate;
    //    protected string _description = String.Empty;
    //    protected string _note = String.Empty;

    //    public Order()
    //    {
    //    }

    //    public Order(int orderID, DateTime addedDate, string addedBy, int statusID, string paymentMethod, string accountCode, string shippingAddress, string shippingCity, string customerEmail, string customerPhone, string customerMoblie, DateTime shippedDate, string description, string note)
    //    {
    //        _orderID = orderID;
    //        _addedDate = addedDate;
    //        _addedBy = addedBy;
    //        _statusID = statusID;
    //        _paymentMethod = paymentMethod;
    //        _accountCode = accountCode;
    //        _shippingAddress = shippingAddress;
    //        _shippingCity = shippingCity;
    //        _customerEmail = customerEmail;
    //        _customerPhone = customerPhone;
    //        _customerMoblie = customerMoblie;
    //        _shippedDate = shippedDate;
    //        _description = description;
    //        _note = note;
    //    }

    //    #region Public Properties

    //    public int OrderID
    //    {
    //        get { return _orderID; }
    //        set { _orderID = value; }
    //    }

    //    public DateTime AddedDate
    //    {
    //        get { return _addedDate; }
    //        set { _addedDate = value; }
    //    }

    //    public string AddedBy
    //    {
    //        get { return _addedBy; }
    //        set { _addedBy = value; }
    //    }

    //    public int StatusID
    //    {
    //        get { return _statusID; }
    //        set { _statusID = value; }
    //    }

    //    public string PaymentMethod
    //    {
    //        get { return _paymentMethod; }
    //        set { _paymentMethod = value; }
    //    }

    //    public string AccountCode
    //    {
    //        get { return _accountCode; }
    //        set { _accountCode = value; }
    //    }

    //    public string ShippingAddress
    //    {
    //        get { return _shippingAddress; }
    //        set { _shippingAddress = value; }
    //    }

    //    public string ShippingCity
    //    {
    //        get { return _shippingCity; }
    //        set { _shippingCity = value; }
    //    }

    //    public string CustomerEmail
    //    {
    //        get { return _customerEmail; }
    //        set { _customerEmail = value; }
    //    }

    //    public string CustomerPhone
    //    {
    //        get { return _customerPhone; }
    //        set { _customerPhone = value; }
    //    }

    //    public string CustomerMoblie
    //    {
    //        get { return _customerMoblie; }
    //        set { _customerMoblie = value; }
    //    }

    //    public DateTime ShippedDate
    //    {
    //        get { return _shippedDate; }
    //        set { _shippedDate = value; }
    //    }

    //    public string Description
    //    {
    //        get { return _description; }
    //        set { _description = value; }
    //    }

    //    public string Note
    //    {
    //        get { return _note; }
    //        set { _note = value; }
    //    }
    //    #endregion
    //}


}
