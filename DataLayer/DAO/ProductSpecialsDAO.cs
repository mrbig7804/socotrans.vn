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
    public class ProductSpecialsBaseDAO : BaseDAO
    {

        public ProductSpecial GetProductSpecialFromReader(IDataReader dr)
        {
            ProductSpecial temp = new ProductSpecial();

            if (dr["ProductID"] != DBNull.Value) temp.ProductID = Convert.ToInt32(dr["ProductID"]);
            if (dr["SpecialID"] != DBNull.Value) temp.SpecialID = Convert.ToInt32(dr["SpecialID"]);
            if (dr["ReleaseDate"] != DBNull.Value) temp.ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]);
            if (dr["ExpireDate"] != DBNull.Value) temp.ExpireDate = Convert.ToDateTime(dr["ExpireDate"]);
            if (dr["Listed"] != DBNull.Value) temp.Listed = Convert.ToBoolean(dr["Listed"]);

            return temp;
        }

        public ProductSpecialsBaseDAO()
        {
        }

        public ProductSpecial GetProductSpecial(int productID, int specialID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductSpecial", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cmd.Parameters.Add("@SpecialID", SqlDbType.Int).Value = specialID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetProductSpecialFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetProductSpecialsAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectProductSpecialsAll");
        //}


        //Get by ForeignKey
        public List<ProductSpecial> GetProductSpecialsByProductID(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductSpecialsByProductID", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<ProductSpecial> list = new List<ProductSpecial>();
                while (dr.Read())
                {
                    list.Add(GetProductSpecialFromReader(dr));
                }
                return list;
            }
        }

        public List<ProductSpecial> GetProductSpecialsBySpecialID(int specialID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductSpecialsBySpecialID", cn);

                cmd.Parameters.Add("@SpecialID", SqlDbType.Int).Value = specialID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<ProductSpecial> list = new List<ProductSpecial>();
                while (dr.Read())
                {
                    list.Add(GetProductSpecialFromReader(dr));
                }
                return list;
            }
        }

        public List<ProductSpecial> GetProductSpecialsFilter(int specialID, DateTime fromDate, DateTime toDate, int status)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductSpecialsFiter", cn);

                cmd.Parameters.Add("@SpecialID", SqlDbType.Int).Value = specialID;
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = toDate;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<ProductSpecial> list = new List<ProductSpecial>();
                while (dr.Read())
                {
                    list.Add(GetProductSpecialFromReader(dr));
                }
                return list;
            }
        }

        //Get All
        public List<ProductSpecial> GetProductSpecialsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectProductSpecialsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<ProductSpecial> list = new List<ProductSpecial>();
                while (dr.Read())
                {
                    list.Add(GetProductSpecialFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(ProductSpecial productSpecial)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertProductSpecial", cn);


                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productSpecial.ProductID;
                cmd.Parameters.Add("@SpecialID", SqlDbType.Int).Value = productSpecial.SpecialID;
                cmd.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = productSpecial.ReleaseDate;
                cmd.Parameters.Add("@ExpireDate", SqlDbType.DateTime).Value = productSpecial.ExpireDate;
                cmd.Parameters.Add("@Listed", SqlDbType.Bit).Value = productSpecial.Listed;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return ret;
            }
        }
        //Update
        public bool Update(ProductSpecial productSpecial)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateProductSpecial", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ConvertNullToDBNull(productSpecial.ProductID);
                cmd.Parameters.Add("@SpecialID", SqlDbType.Int).Value = ConvertNullToDBNull(productSpecial.SpecialID);
                cmd.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = productSpecial.ReleaseDate;
                cmd.Parameters.Add("@ExpireDate", SqlDbType.DateTime).Value = productSpecial.ExpireDate;
                cmd.Parameters.Add("@Listed", SqlDbType.Bit).Value = productSpecial.Listed;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int productID, int specialID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteProductSpecial", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cmd.Parameters.Add("@SpecialID", SqlDbType.Int).Value = specialID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

    /// <summary>
    /// 13/12/07: sondt: thêm hàm DeleteByProductID
    /// </summary>
    public class ProductSpecialsDAO : ProductSpecialsBaseDAO
    {

        //Delete
        public bool DeleteByProductID(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteProductSpecialsByProductID", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
