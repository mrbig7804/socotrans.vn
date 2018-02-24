using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

using System.Web.Security;
using System.Security;
using System.IO;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public partial class ProductsBF
    {

        #region Custom Properties
        public int FinalPrice
        {
            get
            {
                if ((this.SalePrice > 0) && (this.SalePrice < this.UnitPrice))
                    return SalePrice;
                else
                    return UnitPrice;
            }

        }
        #endregion

        #region Custom Methods
        public static List<string> GetAllShop()
        {
            return SiteProvider.ProductsProvider.GetAllShop();
        }

        public static List<ProductsBF> GetProductsByUserName(string userName, int departmentID)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsByUserName(userName, departmentID));
        }

        public static List<ProductsBF> GetProductsByBrandDepartment(string brandID, int departmentID)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsByBrandDepartment(brandID, departmentID));
        }

        public static List<ProductsBF> GetProductsByPropertyValue(int propertyValueID)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsByPropertyValue(propertyValueID));
        }

        public static List<ProductsBF> GetProductsByRoleUsers(string roleName)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsByRoleUsers(roleName));
        }

        public static List<ProductsBF> GetProductsDynamic(string whereCondition, string orderByExpression)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsDynamic(whereCondition, orderByExpression));
        }

        public static List<ProductsBF> GetProductsByFilter(string userName, int superDepartmentID, int departmentID, string gender, int countryID, int maxPrice, int minPrice)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsByFilter(userName, superDepartmentID, departmentID, gender, countryID, maxPrice, minPrice));
        }

        public static List<ProductsBF> GetProductRealtyByFilter(int superDepartmentID, int departmentID, int directionID, int cityID)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductRealtyByFilter(superDepartmentID, departmentID, directionID, cityID));
        }

        public static List<ProductsBF> GetProductsBySearch(string keywords, int superDepartmentID, int departmentID, int minPrice, int maxPrice)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsBySearch(keywords, superDepartmentID, departmentID, minPrice, maxPrice));
        }

        public static List<ProductsBF> GetProductsBySpecialID(int specialID, DateTime expireDate)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductBySpecialID(specialID, expireDate));
        }

        public static List<ProductsBF> GetRelateProducts(int productID)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetRelateProducts(productID));
        }

        public static ProductsBF GetProductByUniqueTitle(string uniqueTitle)
        {
            return GetProductsBFFromProduct(SiteProvider.ProductsProvider.GetProductByUniqueTitle(uniqueTitle));
        }

        //Delete
        public static bool Delete(int productID)
        {
            ProductsBF product = ProductsBF.GetProductsBF(productID);

            // xoa anh minh hoa cua san pham
            List<ProductImagesBF> images = ProductImagesBF.GetProductImagesByProductID(productID);
            if(images.Count > 0)
            {
                foreach (ProductImagesBF image in images)
                {
                    if(File.Exists(HttpContext.Current.Server.MapPath(image.SmallImage)))
                        File.Delete(HttpContext.Current.Server.MapPath(image.SmallImage));
                    if (File.Exists(HttpContext.Current.Server.MapPath(image.MedImage)))
                        File.Delete(HttpContext.Current.Server.MapPath(image.MedImage));
                    if (File.Exists(HttpContext.Current.Server.MapPath(image.FullImage)))
                        File.Delete(HttpContext.Current.Server.MapPath(image.FullImage));

                    image.Delete();
                }
            }

            // xoa anh tat ca ảnh liên quan của sp
            string pathCheck = "~/Attachs/Items/" + productID.ToString() + "/";

            if (Directory.Exists(HttpContext.Current.Server.MapPath(pathCheck)))
            { 
                string[] files = Directory.GetFiles(HttpContext.Current.Server.MapPath(pathCheck));

                for(int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        File.Delete(files[i]);
                    }
                    catch{}
                }

                try
                {
                    Directory.Delete(HttpContext.Current.Server.MapPath(pathCheck), true);
                }
                catch { }
            }

            //xoa comment o san pham
            var comments = ProductCommentsBF.GetProductCommentsByProductID(productID);
            if (comments != null)
            {
                foreach (var cm in comments)
                {
                    cm.Delete();
                }
            }

            //xoa san pham dac biet
            var special = ProductSpecialsBF.GetProductSpecialsByProductID(productID);
            if (special != null)
            {
                foreach (var sp in special)
                {
                    sp.Delete();
                }
            }

            //Xóa thông số sp
            var pProperties = ProductPropertiesBF.GetProductPropertyByProduct(productID);
            if (pProperties != null)
            {
                foreach (var pp in pProperties)
                {
                    pp.Delete();
                }
            }

            //kiem tra xem mat hang co trong don hang hay khong
            List<OrderItemsBF> items = OrderItemsBF.GetOrderItemsByProductID(productID);
            if (items.Count > 0)
            {
                product.Listed = false;
                product.EditedDate = DateTime.Now;
                return product.Update();
            }

            else return SiteProvider.ProductsProvider.Delete(productID);
        }

        /// <summary>
        /// Tăng số lần xem của sản phẩm
        /// </summary>
        /// <returns></returns>
        public bool IncrementViewCount()
        {
            return ProductsBF.IncrementViewCount(this.ProductID);
        }

        /// <summary>
        /// Tăng số lần xem của bài viết
        /// </summary>
        /// <returns></returns>
        public static bool IncrementViewCount(int productID)
        {
            return SiteProvider.ProductsProvider.IncrementViewCount(productID);
        }

        /// <summary>
        /// Lấy tất cả sản phẩm sắp xếp theo điểm để biết đc sản phẩm nào dc quan tâm hơn
        /// </summary>
        /// <returns></returns>
        public static List<ProductsBF> GetProductByPoint()
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductByPoint());
        }

        public static List<ProductsBF> GetProductByPointAndDepartment(int departmentID)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductByPointAndDepartment(departmentID));
        }

        public static List<ProductsBF> GetProductsByDepartmentCommenting(int departmentID)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsByDepartmentCommenting(departmentID));
        }

        public static List<ProductsBF> SearchProduct(string whereCondition, DateTime fromDate, int departmentID)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.SearchProduct(whereCondition,  fromDate, departmentID));

        }

        public static List<ProductsBF> GetProductsNewPosting(int resultTop)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsNewPosting(resultTop));

        }

        public static List<ProductsBF> GetProductsTopView(int resultTop)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsTopView(resultTop));

        }

        public static List<ProductsBF> GetProductsTopRating(int resultTop)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsTopRating(resultTop));

        }

        public static List<ProductsBF> GetProductsTopComment(int resultTop)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsTopComment(resultTop));

        }

        public static List<ProductsBF> GetProductsTopVotes(int resultTop)
        {
            return GetProductsBFListFromProductsList(SiteProvider.ProductsProvider.GetProductsTopVotes(resultTop));

        }


        #endregion

    }

}
