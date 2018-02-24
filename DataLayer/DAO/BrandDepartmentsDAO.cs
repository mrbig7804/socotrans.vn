using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class BrandDepartmentsDAO : BaseDAO
    {

        public BrandDepartment GetBrandDepartmentFromReader(IDataReader dr)
        {
            BrandDepartment temp = new BrandDepartment();

            if (dr["BrandID"] != DBNull.Value) temp.BrandID = Convert.ToInt32(dr["BrandID"]);
            if (dr["DepartmentID"] != DBNull.Value) temp.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);

            return temp;
        }

        public BrandDepartmentsDAO()
        {
        }

        public BrandDepartment GetBrandDepartment(int brandID, int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectBrandDepartment", cn);

                cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = brandID;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetBrandDepartmentFromReader(dr);
                else
                    return null;
            }
        }

        //Insert
        public bool Insert(BrandDepartment brandDepartment)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertBrandDepartment", cn);
                cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = ConvertNullToDBNull(brandDepartment.BrandID);
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = ConvertNullToDBNull(brandDepartment.DepartmentID);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }

        //Delete
        public bool Delete(int brandID, int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteBrandDepartment", cn);

                cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = brandID;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }

        //Delete
        public bool DeleteByBrand(int brandID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteBrandDepartmentByBrand", cn);

                cmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = brandID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }

        //Delete
        public bool DeleteByDepartment(int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteBrandDepartmentByDepartment", cn);

                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
