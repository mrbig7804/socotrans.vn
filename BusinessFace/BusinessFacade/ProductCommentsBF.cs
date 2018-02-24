using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;
namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public partial class ProductCommentsBF
    {

        protected int _productCommentID;
        protected string _fullName = String.Empty;
        protected string _email = String.Empty;
        protected string _phone = String.Empty;
        protected string _body = String.Empty;
        protected int _productID;
        protected string _userName = String.Empty;
        protected DateTime _addedDate;
        protected bool _approved;

        #region Public Properties

        public int ProductCommentID
        {
            get { return _productCommentID; }
            set { _productCommentID = value; }
        }

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public DateTime AddedDate
        {
            get { return _addedDate; }
            set { _addedDate = value; }
        }

        public bool Approved
        {
            get { return _approved; }
            set { _approved = value; }
        }
        #endregion

        private static List<ProductCommentsBF> GetProductCommentsBFListFromProductCommentsList(List<ProductComment> recordset)
        {
            List<ProductCommentsBF> ret = new List<ProductCommentsBF>();
            foreach (ProductComment record in recordset)
                ret.Add(GetProductCommentsBFFromProductComment(record));
            return ret;
        }

        private static ProductCommentsBF GetProductCommentsBFFromProductComment(ProductComment record)
        {
            if (record == null)
                return null;
            else
            {
                return new ProductCommentsBF(record.ProductCommentID, record.FullName, record.Email, record.Phone, record.Body, record.ProductID, record.UserName, record.AddedDate, record.Approved);
            }
        }

        public ProductCommentsBF()
        {
        }


        public ProductCommentsBF(int productCommentID, string fullName, string email, string phone, string body, int productID, string userName, DateTime addedDate, bool approved)
        {
            _productCommentID = productCommentID;
            _fullName = fullName;
            _email = email;
            _phone = phone;
            _body = body;
            _productID = productID;
            _userName = userName;
            _addedDate = addedDate;
            _approved = approved;
        }

        public static ProductCommentsBF GetProductCommentsBF(int productCommentID)
        {
            return GetProductCommentsBFFromProductComment(SiteProvider.ProductCommentsProvider.GetProductComment(productCommentID));
        }

        //Get by ForeignKey
        public static List<ProductCommentsBF> GetProductCommentsByProductID(int productID)
        {
            return GetProductCommentsBFListFromProductCommentsList(SiteProvider.ProductCommentsProvider.GetProductCommentsByProductID(productID));
        }

        //Get All
        public static List<ProductCommentsBF> GetProductCommentsAll()
        {
            return GetProductCommentsBFListFromProductCommentsList(SiteProvider.ProductCommentsProvider.GetProductCommentsAll());
        }

        //Insert
        public int Insert()
        {
            return ProductCommentsBF.Insert(this.ProductCommentID, this.FullName, this.Email, this.Phone, this.Body, this.ProductID, this.UserName, this.AddedDate, this.Approved);
        }

        //Update
        public bool Update()
        {
            return ProductCommentsBF.Update(this.ProductCommentID, this.FullName, this.Email, this.Phone, this.Body, this.ProductID, this.UserName, this.AddedDate, this.Approved);
        }

        //Delete
        public bool Delete()
        {
            return ProductCommentsBF.Delete(
            this.ProductCommentID);
        }

        //Insert
        public static int Insert(int productCommentID, string fullName, string email, string phone, string body, int productID, string userName, DateTime addedDate, bool approved)
        {
            return SiteProvider.ProductCommentsProvider.Insert(new ProductComment(productCommentID, fullName, email, phone, body, productID, userName, addedDate, approved));
        }

        //Update
        public static bool Update(int productCommentID, string fullName, string email, string phone, string body, int productID, string userName, DateTime addedDate, bool approved)
        {
            return SiteProvider.ProductCommentsProvider.Update(new ProductComment(productCommentID, fullName, email, phone, body, productID, userName, addedDate, approved));
        }

        //Delete
        public static bool Delete(int productCommentID)
        {
            return SiteProvider.ProductCommentsProvider.Delete(productCommentID);
        }

    }

}
