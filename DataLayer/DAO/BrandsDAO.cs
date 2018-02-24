using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class BrandsDAO : BaseDAO
    {

        public Brand GetBrandFromReader(IDataReader dr)
        {
            Brand temp = new Brand();

            if (dr["BrandID"] != DBNull.Value) temp.BrandID = Convert.ToInt32(dr["BrandID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["Important"] != DBNull.Value) temp.Important = Convert.ToInt32(dr["Important"]);
            if (dr["ImageUrl"] != DBNull.Value) temp.ImageUrl = Convert.ToString(dr["ImageUrl"]);

            return temp;
        }

        public BrandsDAO()
        {
        }

        public Brand GetBrand(int brandID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectBrand", cn);

                cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = brandID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetBrandFromReader(dr);
                else
                    return null;
            }
        }

        //Get All
        public List<Brand> GetBrandsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectBrandsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Brand> list = new List<Brand>();
                while (dr.Read())
                {
                    list.Add(GetBrandFromReader(dr));
                }

                return list;
            }
        }

        //Get By department
        public List<Brand> GetBrandsByDepartment(int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectBrandByDepartment", cn);
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Brand> list = new List<Brand>();
                while (dr.Read())
                {
                    list.Add(GetBrandFromReader(dr));
                }

                return list;
            }
        }

        //Get dynamic
        public List<Brand> GetBrandsDynamic(string condition, string orderBy)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectBrandsDynamic", cn);
                cmd.Parameters.Add("@WhereCondition", SqlDbType.NVarChar).Value = condition;
                cmd.Parameters.Add("@OrderByExpression", SqlDbType.NVarChar).Value = orderBy;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Brand> list = new List<Brand>();
                while (dr.Read())
                {
                    list.Add(GetBrandFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(Brand brand)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertBrand", cn);

                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(brand.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(brand.Description);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(brand.Important);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.VarChar).Value = ConvertNullToDBNull(brand.ImageUrl);

                cmd.Parameters.Add("@BrandID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@BrandID"].Value;
            }
        }

        //Update
        public bool Update(Brand brand)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateBrand", cn);

                cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = ConvertNullToDBNull(brand.BrandID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(brand.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(brand.Description);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(brand.Important);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.VarChar).Value = ConvertNullToDBNull(brand.ImageUrl);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }

        //Delete
        public bool Delete(int brandID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteBrand", cn);

                cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = brandID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
