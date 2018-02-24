using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;
namespace Zensoft.Website.BusinessLayer.BusinessFacade
{


    public partial class ProductCommentsBF
    {
        protected string _productTitle = string.Empty;

        public string ProductTitle
        {
            get
            {
                return Product.Title;
            }
        }

        private ProductsBF _product = null;

        public ProductsBF Product
        {
            get
            {
                if (_product == null)
                {
                    ProductsBF product = ProductsBF.GetProductsBF(this.ProductID);
                    _product = product;
                }
                return _product;
            }
        }

        
        public static List<ProductCommentsBF> GetProductCommentsByUserProduct(string username)
        {
            return GetProductCommentsBFListFromProductCommentsList(SiteProvider.ProductCommentsProvider.GetProductCommentsByUserProduct(username));
        }

        public static List<ProductCommentsBF> GetProductCommentsApproved()
        {
            return GetProductCommentsBFListFromProductCommentsList(SiteProvider.ProductCommentsProvider.GetProductCommentsApproved());
        }

        public static List<ProductCommentsBF> GetProductCommentsUnapproved()
        {
            return GetProductCommentsBFListFromProductCommentsList(SiteProvider.ProductCommentsProvider.GetProductCommentsUnapproved());
        }


    }

}
