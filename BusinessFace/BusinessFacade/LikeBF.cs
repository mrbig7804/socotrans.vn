using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public partial class LikeBF
    {
        protected int _productId;
        protected string _userName = String.Empty;
        protected bool _isLike;

        public LikeBF()
        {
        }

        public LikeBF(int productId, string userName, bool isLike)
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

        private static List<LikeBF> GetLikeBFListFromLikeList(List<Like> recordset)
        {
            List<LikeBF> ret = new List<LikeBF>();
            foreach (Like record in recordset)
                ret.Add(GetLikeBFFromLike(record));
            return ret;
        }

        private static LikeBF GetLikeBFFromLike(Like record)
        {
            if (record == null)
                return null;
            else
            {
                return new LikeBF(record.ProductId, record.UserName, record.IsLike);
            }
        }

        public static LikeBF GetLikeBF(int productId, string userName)
        {
            return GetLikeBFFromLike(SiteProvider.LikeProvider.GetLike(productId, userName));
        }

        //Insert
        public int Insert()
        {
            return LikeBF.Insert(this.ProductId, this.UserName, this.IsLike);
        }

        //Update
        public bool Update()
        {
            return LikeBF.Update(this.ProductId, this.UserName, this.IsLike);
        }

        //Delete
        public bool Delete()
        {
            return LikeBF.Delete(this.ProductId, this.UserName);
        }

        //Insert
        public static int Insert(int productId, string userName, bool isLike)
        {
            return SiteProvider.LikeProvider.Insert(new Like(productId, userName, isLike));
        }

        //Update
        public static bool Update(int productId, string userName, bool isLike)
        {
            return SiteProvider.LikeProvider.Update(new Like(productId, userName, isLike));
        }

        //Delete
        public static bool Delete(int productId, string userName)
        {
            return SiteProvider.LikeProvider.Delete(productId, userName);
        }
    }
}
