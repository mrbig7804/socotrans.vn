using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class ProductComment
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

        public ProductComment()
        {
           
        }

        public ProductComment(int productCommentID, string fullName, string email, string phone, string body, int productID, string userName, DateTime addedDate, bool approved)
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
    }

}
