using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;
using System.Data.Common;
using System.Web.Configuration;
using System.Configuration;

namespace Zensoft.Website.DataLayer.DAO
{
    /// <summary>
    /// 05/12/07:sondt: thêm hàm GetRelateProducts
    /// 13/12/07: sondt: thêm hàm GetProductBySpecialID
    /// 15/12/07: sondt: thêm hàm GetByFilter để lấy các mặt hàng phù hợp với yêu cầu đưa ra
    /// </summary>
    public partial class ProductsDAO : BaseDAO
    {

        /// <summary>
        /// Dùng để lấy tên tất cả cửa hàng đã có sản phẩm
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllShop()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Products_GetByShop", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<string> list = new List<string>();
                while (dr.Read())
                {
                    list.Add(dr["AddedBy"].ToString());
                }

                return list;
            }
        }

        public List<Product> GetProductsByUserName(string userName, int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Products_GetByUserName", cn);

                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }

                return list;
            }
        }

        public List<Product> GetProductsByPropertyValue(int propertyValueID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductsByPropertyValue", cn);

                cmd.Parameters.Add("@PropertyValueID", SqlDbType.Int).Value = propertyValueID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }

                return list;
            }
        }

        public List<Product> GetProductsByBrandDepartment(string brandID, int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductByBrandDepartment", cn);

                cmd.Parameters.Add("@BrandID", SqlDbType.NVarChar).Value = brandID;
                cmd.Parameters.Add("@Department", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }

                return list;
            }
        }

        public List<Product> GetProductsByRoleUsers(string roleName)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductsByRoleUsers", cn);

                cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = roleName;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }

                return list;
            }
        }

        public List<Product> GetProductsDynamic(string whereCondition, string orderByExpression)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductsDynamic", cn);

                cmd.Parameters.Add("@WhereCondition", SqlDbType.NVarChar).Value = whereCondition;
                cmd.Parameters.Add("@OrderByExpression", SqlDbType.NVarChar).Value = orderByExpression;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }

                return list;
            }
        }

        public List<Product> GetProductsByFilter(string userName, int superDepartmentID, int departmentID, string gender, int countryID, int maxPrice, int minPrice)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Products_GetByFilter", cn);

                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;
                cmd.Parameters.Add("@SuperDepartmentID", SqlDbType.Int).Value = superDepartmentID;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
                cmd.Parameters.Add("@Gender", SqlDbType.Char).Value = gender;
                cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = countryID;
                cmd.Parameters.Add("@MaxPrice", SqlDbType.Int).Value = maxPrice;
                cmd.Parameters.Add("@MinPrice", SqlDbType.Int).Value = minPrice;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }

                return list;
            }
        }

        public List<Product> GetProductRealtyByFilter(int superDepartmentID, int departmentID, int directionID, int cityID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("ProductRealty_GetByFilter", cn);
                cmd.Parameters.Add("@SuperDepartmentID", SqlDbType.Int).Value = superDepartmentID;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
                cmd.Parameters.Add("@DirectionID", SqlDbType.Int).Value = directionID;
                cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = cityID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }

                return list;
            }
        }

        public List<Product> GetProductsBySearch(string keywords, int superDepartmentID, int departmentID, int minPrice, int maxPrice)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Products_GetBySearch", cn);

                cmd.Parameters.Add("@Keywords", SqlDbType.NVarChar).Value = keywords;
                cmd.Parameters.Add("@SuperDepartmentID", SqlDbType.Int).Value = superDepartmentID;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
                cmd.Parameters.Add("@MinPrice", SqlDbType.Int).Value = minPrice;
                cmd.Parameters.Add("@MaxPrice", SqlDbType.Int).Value = maxPrice;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }

                return list;
            }
        }

        public List<Product> GetProductBySpecialID(int specialID, DateTime expireDate)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Products_GetBySpecialID", cn);

                cmd.Parameters.Add("@SpecialID", SqlDbType.Int).Value = specialID;
                cmd.Parameters.Add("@ExpireDate", SqlDbType.DateTime).Value = expireDate;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }
                return list;
            }
        }
        
        public List<Product> GetRelateProducts(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Products_GetRelateProducts", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }
                return list;
            }
        }

        public Product GetProductByUniqueTitle(string uniqueTitle)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_Products_GetByUniqueTitle", cn);

                cmd.Parameters.Add("@UniqueTitle", SqlDbType.VarChar).Value = uniqueTitle;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetProductFromReader(dr);
                else
                    return null;
            }
        }



        public bool IncrementViewCount(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("Products_IncrementViewCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public List<Product> GetProductByPoint()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Products_GetByPoint", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }
                return list;
            }
        }
        public List<Product> GetProductByPointAndDepartment(int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Products_GetByPointAndDepartment", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }
                return list;
            }
        }
        /// <summary>
        /// Lấy tất cả các mặt hàng đang được thảo luận
        /// </summary>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public List<Product> GetProductsByDepartmentCommenting(int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("products_GetByDepartmentCommenting", cn);

                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }
                return list;
            }
        }

        public List<Product> SearchProduct(string whereCondition, DateTime fromDate, int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Products_Search", cn);

                cmd.Parameters.Add("@WhereCondition", SqlDbType.NVarChar).Value = whereCondition;
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }

                return list;
            }
        }

        public List<Product> GetProductsNewPosting(int resultTop)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductNewPosting", cn);

                cmd.Parameters.Add("@ResultTop", SqlDbType.Int).Value = resultTop;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }
                return list;
            }
        }

        public List<Product> GetProductsTopView(int resultTop)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductTopView", cn);

                cmd.Parameters.Add("@ResultTop", SqlDbType.Int).Value = resultTop;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }
                return list;
            }
        }

        public List<Product> GetProductsTopRating(int resultTop)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductTopRating", cn);

                cmd.Parameters.Add("@ResultTop", SqlDbType.Int).Value = resultTop;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }
                return list;
            }
        }

        public List<Product> GetProductsTopComment(int resultTop)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductTopComment", cn);

                cmd.Parameters.Add("@ResultTop", SqlDbType.Int).Value = resultTop;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }
                return list;
            }
        }

        public List<Product> GetProductsTopVotes(int resultTop)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductTopVotes", cn);

                cmd.Parameters.Add("@ResultTop", SqlDbType.Int).Value = resultTop;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }
                return list;
            }
        }
    }

}
