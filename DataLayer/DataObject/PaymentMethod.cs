using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class PaymentMethod
    {
        protected int _paymentMethodID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;

        public PaymentMethod()
        {
        }

        public PaymentMethod(int paymentMethodID, string title, string description)
        {
            _paymentMethodID = paymentMethodID;
            _title = title;
            _description = description;
        }

        #region Public Properties

        public int PaymentMethodID
        {
            get { return _paymentMethodID; }
            set { _paymentMethodID = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion
    }

}
