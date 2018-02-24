using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class Like
    {
        protected int _productId;
        protected string _userName = String.Empty;
        protected bool _isLike;

        public Like()
        {
        }

        public Like(int productId, string userName, bool isLike)
        {
            _productId = productId;
            _userName = userName;
            _isLike = isLike;
        }

        #region Public Properties

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public bool IsLike
        {
            get { return _isLike; }
            set { _isLike = value; }
        }
        #endregion
    }
}
