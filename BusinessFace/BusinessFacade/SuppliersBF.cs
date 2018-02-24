using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

using System.Web.Security;
using System.Security;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class SuppliersBF
    {

        protected int _supplierID;
        protected string _supplierName = String.Empty;
        protected string _address = String.Empty;
        protected string _tel = String.Empty;
        protected string _note = String.Empty;

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

        private static List<SuppliersBF> GetSuppliersBFListFromSuppliersList(List<Supplier> recordset)
        {
            List<SuppliersBF> ret = new List<SuppliersBF>();
            foreach (Supplier record in recordset)
                ret.Add(GetSuppliersBFFromSupplier(record));
            return ret;
        }

        private static SuppliersBF GetSuppliersBFFromSupplier(Supplier record)
        {
            if (record == null)
                return null;
            else
            {
                return new SuppliersBF(record.SupplierID, record.SupplierName, record.Address, record.Tel, record.Note);
            }
        }

        public SuppliersBF()
        {
        }


        public SuppliersBF(int supplierID, string supplierName, string address, string tel, string note)
        {
            _supplierID = supplierID;
            _supplierName = supplierName;
            _address = address;
            _tel = tel;
            _note = note;
        }

        public static SuppliersBF GetSuppliersBF(int supplierID)
        {
            return GetSuppliersBFFromSupplier(SiteProvider.SuppliersProvider.GetSupplier(supplierID));
        }

        //Get by ForeignKey

        //Get All
        public static List<SuppliersBF> GetSuppliersAll()
        {
            return GetSuppliersBFListFromSuppliersList(SiteProvider.SuppliersProvider.GetSuppliersAll());
        }

        //Insert
        public int Insert()
        {
            return SuppliersBF.Insert(this.SupplierID, this.SupplierName, this.Address, this.Tel, this.Note);
        }

        //Update
        public bool Update()
        {
            return SuppliersBF.Update(this.SupplierID, this.SupplierName, this.Address, this.Tel, this.Note);
        }

        //Delete
        public bool Delete()
        {
            return SuppliersBF.Delete(this.SupplierID);
        }

        //Insert
        public static int Insert(int supplierID, string supplierName, string address, string tel, string note)
        {
            return SiteProvider.SuppliersProvider.Insert(new Supplier(supplierID, supplierName, address, tel, note));
        }

        //Update
        public static bool Update(int supplierID, string supplierName, string address, string tel, string note)
        {
            return SiteProvider.SuppliersProvider.Update(new Supplier(supplierID, supplierName, address, tel, note));
        }

        //Delete
        public static bool Delete(int supplierID)
        {
            return SiteProvider.SuppliersProvider.Delete(supplierID);
        }

    }

}
