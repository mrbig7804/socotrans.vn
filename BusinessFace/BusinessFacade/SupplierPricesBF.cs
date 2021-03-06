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
    /// <summary>
    /// 05/12/07: sondt: thêm một số thuộc tính liên quan tới sản phẩm
    /// </summary>
    public class SupplierPricesBF
    {

        protected int _supplierID;
        protected int _productID;
        protected int _inputPrice;

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

        #region Custom Properties

        ProductsBF _productBF = null;
        public ProductsBF Product
        {
            get
            {
                if (_productBF == null)
                {
                    _productBF = ProductsBF.GetProductsBF(this.ProductID);
                }
                return _productBF;
            }
        }

        SuppliersBF _suppliersBF = null;
        public SuppliersBF Supplier
        {
            get
            {
                if (_suppliersBF == null)
                    _suppliersBF = SuppliersBF.GetSuppliersBF(this.SupplierID);

                return _suppliersBF;
            }
        }

        public string SupplierName
        {
            get
            {
                return this.Supplier.SupplierName;
            }
        }

        #endregion

        private static List<SupplierPricesBF> GetSupplierPricesBFListFromSupplierPricesList(List<SupplierPrice> recordset)
        {
            List<SupplierPricesBF> ret = new List<SupplierPricesBF>();
            foreach (SupplierPrice record in recordset)
                ret.Add(GetSupplierPricesBFFromSupplierPrice(record));
            return ret;
        }

        private static SupplierPricesBF GetSupplierPricesBFFromSupplierPrice(SupplierPrice record)
        {
            if (record == null)
                return null;
            else
            {
                return new SupplierPricesBF(record.SupplierID, record.ProductID, record.InputPrice);
            }
        }

        public SupplierPricesBF()
        {
        }


        public SupplierPricesBF(int supplierID, int productID, int inputPrice)
        {
            _supplierID = supplierID;
            _productID = productID;
            _inputPrice = inputPrice;
        }

        public static SupplierPricesBF GetSupplierPricesBF(int supplierID, int productID)
        {
            return GetSupplierPricesBFFromSupplierPrice(SiteProvider.SupplierPricesProvider.GetSupplierPrice(supplierID, productID));
        }

        //Get by ForeignKey
        public static List<SupplierPricesBF> GetSupplierPricesBySupplierID(int supplierID)
        {
            return GetSupplierPricesBFListFromSupplierPricesList(SiteProvider.SupplierPricesProvider.GetSupplierPricesBySupplierID(supplierID));
        }
        public static List<SupplierPricesBF> GetSupplierPricesByProductID(int productID)
        {
            return GetSupplierPricesBFListFromSupplierPricesList(SiteProvider.SupplierPricesProvider.GetSupplierPricesByProductID(productID));
        }

        //Get All
        public static List<SupplierPricesBF> GetSupplierPricesAll()
        {
            return GetSupplierPricesBFListFromSupplierPricesList(SiteProvider.SupplierPricesProvider.GetSupplierPricesAll());
        }

        //Insert
        public int Insert()
        {
            return SupplierPricesBF.Insert(this.SupplierID, this.ProductID, this.InputPrice);
        }

        //Update
        public bool Update()
        {
            return SupplierPricesBF.Update(this.SupplierID, this.ProductID, this.InputPrice);
        }

        //Delete
        public bool Delete()
        {
            return SupplierPricesBF.Delete(this.SupplierID, this.ProductID);
        }

        //Insert
        public static int Insert(int supplierID, int productID, int inputPrice)
        {
            return SiteProvider.SupplierPricesProvider.Insert(new SupplierPrice(supplierID, productID, inputPrice));
        }

        //Update
        public static bool Update(int supplierID, int productID, int inputPrice)
        {
            return SiteProvider.SupplierPricesProvider.Update(new SupplierPrice(supplierID, productID, inputPrice));
        }

        //Delete
        public static bool Delete(int supplierID, int productID)
        {
            return SiteProvider.SupplierPricesProvider.Delete(supplierID, productID);
        }

    }

}
