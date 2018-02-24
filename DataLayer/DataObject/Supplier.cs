using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class Supplier
    {
        protected int _supplierID;
        protected string _supplierName = String.Empty;
        protected string _address = String.Empty;
        protected string _tel = String.Empty;
        protected string _note = String.Empty;

        public Supplier()
        {
        }

        public Supplier(int supplierID, string supplierName, string address, string tel, string note)
        {
            _supplierID = supplierID;
            _supplierName = supplierName;
            _address = address;
            _tel = tel;
            _note = note;
        }

        #region Public Properties

        public int SupplierID
        {
            get { return _supplierID; }
            set { _supplierID = value; }
        }

        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
        #endregion
    }


}
