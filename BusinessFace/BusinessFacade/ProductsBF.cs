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
    [Serializable]

    public partial class ProductsBF
    {

        protected int _productID;
        protected int _departmentID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected DateTime _editedDate;
        protected string _title = String.Empty;
        protected string _description = String.Empty;
        protected string _details = String.Empty;
        protected int _unitPrice;
        protected int _unitInStock;
        protected int _salePrice;
        protected bool _discontinued;
        protected string _smallPictureUrl = String.Empty;
        protected string _fullPictureUrl = String.Empty;
        protected int _viewCount;
        protected int _votes;
        protected int _totalRating;
        protected string _brand = String.Empty;
        protected string _productCode = String.Empty;
        protected bool _listed;
        protected string _profile = String.Empty;
        protected string _uniqueTitle = String.Empty;

        #region Public Properties

        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public int DepartmentID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
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

        public DateTime EditedDate
        {
            get { return _editedDate; }
            set { _editedDate = value; }
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

        public string Details
        {
            get { return _details; }
            set { _details = value; }
        }

        public int UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        public int UnitInStock
        {
            get { return _unitInStock; }
            set { _unitInStock = value; }
        }

        public int SalePrice
        {
            get { return _salePrice; }
            set { _salePrice = value; }
        }

        public bool Discontinued
        {
            get { return _discontinued; }
            set { _discontinued = value; }
        }

        public string SmallPictureUrl
        {
            get { return _smallPictureUrl; }
            set { _smallPictureUrl = value; }
        }

        public string FullPictureUrl
        {
            get { return _fullPictureUrl; }
            set { _fullPictureUrl = value; }
        }

        public int ViewCount
        {
            get { return _viewCount; }
            set { _viewCount = value; }
        }

        public int Votes
        {
            get { return _votes; }
            set { _votes = value; }
        }

        public int TotalRating
        {
            get { return _totalRating; }
            set { _totalRating = value; }
        }

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public string ProductCode
        {
            get { return _productCode; }
            set { _productCode = value; }
        }

        public bool Listed
        {
            get { return _listed; }
            set { _listed = value; }
        }

        public string Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }

        public string UniqueTitle
        {
            get { return _uniqueTitle; }
            set { _uniqueTitle = value; }
        }
        #endregion

        private static List<ProductsBF> GetProductsBFListFromProductsList(List<Product> recordset)
        {
            List<ProductsBF> ret = new List<ProductsBF>();
            foreach (Product record in recordset)
                ret.Add(GetProductsBFFromProduct(record));
            return ret;
        }

        private static ProductsBF GetProductsBFFromProduct(Product record)
        {
            if (record == null)
                return null;
            else
            {
                return new ProductsBF(record.ProductID, record.DepartmentID, record.AddedDate, record.AddedBy, record.EditedDate, record.Title, record.Description, record.Details, record.UnitPrice, record.UnitInStock, record.SalePrice, record.Discontinued, record.SmallPictureUrl, record.FullPictureUrl, record.ViewCount, record.Votes, record.TotalRating, record.Brand, record.ProductCode, record.Listed, record.Profile, record.UniqueTitle);
            }
        }

        public ProductsBF()
        {
        }


        public ProductsBF(int productID, int departmentID, DateTime addedDate, string addedBy, DateTime editedDate, string title, string description, string details, int unitPrice, int unitInStock, int salePrice, bool discontinued, string smallPictureUrl, string fullPictureUrl, int viewCount, int votes, int totalRating, string brand, string productCode, bool listed, string profile, string uniqueTitle)
        {
            _productID = productID;
            _departmentID = departmentID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _editedDate = editedDate;
            _title = title;
            _description = description;
            _details = details;
            _unitPrice = unitPrice;
            _unitInStock = unitInStock;
            _salePrice = salePrice;
            _discontinued = discontinued;
            _smallPictureUrl = smallPictureUrl;
            _fullPictureUrl = fullPictureUrl;
            _viewCount = viewCount;
            _votes = votes;
            _totalRating = totalRating;
            _brand = brand;
            _productCode = productCode;
            _listed = listed;
            _profile = profile;
            _uniqueTitle = uniqueTitle;
        }

        public static ProductsBF GetProductsBF(int productID)
        {
            return GetProductsBFFromProduct(SiteProvider.ProductsProvider.GetProduct(productID));
        }

        //Get by ForeignKey
        public static List<ProductsBF> GetProductsByDepartmentID(int departmentID, int vote)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsByDepartmentID(departmentID, vote));
        }

        //Get All
        public static List<ProductsBF> GetProductsAll()
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsAll());
        }

        //Insert
        public int Insert()
        {
            return ProductsBF.Insert(this.ProductID, this.DepartmentID, this.AddedDate, this.AddedBy, this.EditedDate, this.Title, this.Description, this.Details, this.UnitPrice, this.UnitInStock, this.SalePrice, this.Discontinued, this.SmallPictureUrl, this.FullPictureUrl, this.ViewCount, this.Votes, this.TotalRating, this.Brand, this.ProductCode, this.Listed, this.Profile, this.UniqueTitle);
        }

        //Update
        public bool Update()
        {
            return ProductsBF.Update(this.ProductID, this.DepartmentID, this.AddedDate, this.AddedBy, this.EditedDate, this.Title, this.Description, this.Details, this.UnitPrice, this.UnitInStock, this.SalePrice, this.Discontinued, this.SmallPictureUrl, this.FullPictureUrl, this.ViewCount, this.Votes, this.TotalRating, this.Brand, this.ProductCode, this.Listed, this.Profile, this.UniqueTitle);
        }

        //Delete
        public bool Delete()
        {
            return ProductsBF.Delete(this.ProductID);
        }

        //Insert
        public static int Insert(int productID, int departmentID, DateTime addedDate, string addedBy, DateTime editedDate, string title, string description, string details, int unitPrice, int unitInStock, int salePrice, bool discontinued, string smallPictureUrl, string fullPictureUrl, int viewCount, int votes, int totalRating, string brand, string productCode, bool listed, string profile, string uniqueTitle)
        {
            return SiteProvider.ProductsProvider.Insert(new Product(productID, departmentID, addedDate, addedBy, editedDate, title, description, details, unitPrice, unitInStock, salePrice, discontinued, smallPictureUrl, fullPictureUrl, viewCount, votes, totalRating, brand, productCode, listed, profile, uniqueTitle));
        }

        //Update
        public static bool Update(int productID, int departmentID, DateTime addedDate, string addedBy, DateTime editedDate, string title, string description, string details, int unitPrice, int unitInStock, int salePrice, bool discontinued, string smallPictureUrl, string fullPictureUrl, int viewCount, int votes, int totalRating, string brand, string productCode, bool listed, string profile, string uniqueTitle)
        {
            return SiteProvider.ProductsProvider.Update(new Product(productID, departmentID, addedDate, addedBy, editedDate, title, description, details, unitPrice, unitInStock, salePrice, discontinued, smallPictureUrl, fullPictureUrl, viewCount, votes, totalRating, brand, productCode, listed, profile, uniqueTitle));
        }


    }
}