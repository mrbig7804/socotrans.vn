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
    public class SuperDepartmentsDAO : SuperDepartmentsBaseDAO
    {
    }

    public class SuperDepartmentsBaseDAO : BaseDAO
    {

        public SuperDepartment GetSuperDepartmentFromReader(IDataReader dr)
        {
            SuperDepartment temp = new SuperDepartment();

            if (dr["SuperDepartmentID"] != DBNull.Value) temp.SuperDepartmentID = Convert.ToInt32(dr["SuperDepartmentID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["Importance"] != DBNull.Value) temp.Importance = Convert.ToInt32(dr["Importance"]);
            if (dr["ImageUrl"] != DBNull.Value) temp.ImageUrl = Convert.ToString(dr["ImageUrl"]);

            return temp;
        }

        public SuperDepartmentsBaseDAO()
        {
        }

        public SuperDepartment GetSuperDepartment(int superDepartmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectSuperDepartment", cn);

                cmd.Parameters.Add("@SuperDepartmentID", SqlDbType.Int).Value = superDepartmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetSuperDepartmentFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetSuperDepartmentsAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectSuperDepartmentsAll");
        //}


        //Get by ForeignKey

        //Get All
        public List<SuperDepartment> GetSuperDepartmentsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectSuperDepartmentsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<SuperDepartment> list = new List<SuperDepartment>();
                while (dr.Read())
                {
                    list.Add(GetSuperDepartmentFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(SuperDepartment superDepartment)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertSuperDepartment", cn);

                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(superDepartment.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(superDepartment.Description);
                cmd.Parameters.Add("@Importance", SqlDbType.Int).Value = ConvertNullToDBNull(superDepartment.Importance);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(superDepartment.ImageUrl);

                cmd.Parameters.Add("@SuperDepartmentID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@SuperDepartmentID"].Value;
            }
        }
        //Update
        public bool Update(SuperDepartment superDepartment)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateSuperDepartment", cn);

                cmd.Parameters.Add("@SuperDepartmentID", SqlDbType.Int).Value = ConvertNullToDBNull(superDepartment.SuperDepartmentID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(superDepartment.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(superDepartment.Description);
                cmd.Parameters.Add("@Importance", SqlDbType.Int).Value = ConvertNullToDBNull(superDepartment.Importance);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(superDepartment.ImageUrl);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int superDepartmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteSuperDepartment", cn);

                cmd.Parameters.Add("@SuperDepartmentID", SqlDbType.Int).Value = superDepartmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

}
