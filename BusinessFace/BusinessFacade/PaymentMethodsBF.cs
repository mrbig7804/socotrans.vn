using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;


namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class PaymentMethodsBF
    {

        protected int _paymentMethodID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;

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

        private static List<PaymentMethodsBF> GetPaymentMethodsBFListFromPaymentMethodsList(List<PaymentMethod> recordset)
        {
            List<PaymentMethodsBF> ret = new List<PaymentMethodsBF>();
            foreach (PaymentMethod record in recordset)
                ret.Add(GetPaymentMethodsBFFromPaymentMethod(record));
            return ret;
        }

        private static PaymentMethodsBF GetPaymentMethodsBFFromPaymentMethod(PaymentMethod record)
        {
            if (record == null)
                return null;
            else
            {
                return new PaymentMethodsBF(record.PaymentMethodID, record.Title, record.Description);
            }
        }

        public PaymentMethodsBF()
        {
        }


        public PaymentMethodsBF(int paymentMethodID, string title, string description)
        {
            _paymentMethodID = paymentMethodID;
            _title = title;
            _description = description;
        }

        public static PaymentMethodsBF GetPaymentMethodsBF(int paymentMethodID)
        {
            return GetPaymentMethodsBFFromPaymentMethod(SiteProvider.PaymentMethodsProvider.GetPaymentMethod(paymentMethodID));
        }

        //Get by ForeignKey

        //Get All
        public static List<PaymentMethodsBF> GetPaymentMethodsAll()
        {
            return GetPaymentMethodsBFListFromPaymentMethodsList(SiteProvider.PaymentMethodsProvider.GetPaymentMethodsAll());
        }

        //Insert
        public int Insert()
        {
            return PaymentMethodsBF.Insert(this.PaymentMethodID, this.Title, this.Description);
        }

        //Update
        public bool Update()
        {
            return PaymentMethodsBF.Update(this.PaymentMethodID, this.Title, this.Description);
        }

        //Delete
        public bool Delete()
        {
            return PaymentMethodsBF.Delete(this.PaymentMethodID);
        }

        //Insert
        public static int Insert(int paymentMethodID, string title, string description)
        {
            return SiteProvider.PaymentMethodsProvider.Insert(new PaymentMethod(paymentMethodID, title, description));
        }

        //Update
        public static bool Update(int paymentMethodID, string title, string description)
        {
            return SiteProvider.PaymentMethodsProvider.Update(new PaymentMethod(paymentMethodID, title, description));
        }

        //Delete
        public static bool Delete(int paymentMethodID)
        {
            return SiteProvider.PaymentMethodsProvider.Delete(paymentMethodID);
        }

    }
}
