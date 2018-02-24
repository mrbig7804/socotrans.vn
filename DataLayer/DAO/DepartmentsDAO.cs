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
    /// 31/12/07: sondt: thêm hàng GetDepartmentsListedBySuperDepartmentID
    /// </summary>
    public partial class DepartmentsDAO : BaseDAO
    {

        public Department GetDepartmentFromReader(IDataReader dr)
        {
            Department temp = new Department();

            if (dr["DepartmentID"] != DBNull.Value) temp.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["Importance"] != DBNull.Value) temp.Importance = Convert.ToInt32(dr["Importance"]);
            if (dr["SuperDepartmentID"] != DBNull.Value) temp.SuperDepartmentID = Convert.ToInt32(dr["SuperDepartmentID"]);
            if (dr["ParentID"] != DBNull.Value) temp.ParentID = Convert.ToInt32(dr["ParentID"]);
            if (dr["ImageUrl"] != DBNull.Value) temp.ImageUrl = Convert.ToString(dr["ImageUrl"]);

            return temp;
        }

        public DepartmentsDAO()
        {
        }

        public Department GetDepartment(int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectDepartment", cn);

                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetDepartmentFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetDepartmentsAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectDepartmentsAll");
        //}


        //Get by ForeignKey
        public List<Department> GetDepartmentsBySuperDepartmentID(int superDepartmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectDepartmentsBySuperDepartmentID", cn);

                cmd.Parameters.Add("@SuperDepartmentID", SqlDbType.Int).Value = superDepartmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Department> list = new List<Department>();
                while (dr.Read())
                {
                    list.Add(GetDepartmentFromReader(dr));
                }
                return list;
            }
        }

        //Get All
        public List<Department> GetDepartmentsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectDepartmentsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Department> list = new List<Department>();
                while (dr.Read())
                {
                    list.Add(GetDepartmentFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(Department department)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertDepartment", cn);

                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(department.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(department.Description);
                cmd.Parameters.Add("@Importance", SqlDbType.Int).Value = ConvertNullToDBNull(department.Importance);
                cmd.Parameters.Add("@SuperDepartmentID", SqlDbType.Int).Value = ConvertNullToDBNull(department.SuperDepartmentID);
                cmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ConvertNullToDBNull(department.ParentID);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(department.ImageUrl);

                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@DepartmentID"].Value;
            }
        }
        //Update
        public bool Update(Department department)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateDepartment", cn);

                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = ConvertNullToDBNull(department.DepartmentID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(department.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(department.Description);
                cmd.Parameters.Add("@Importance", SqlDbType.Int).Value = ConvertNullToDBNull(department.Importance);
                cmd.Parameters.Add("@SuperDepartmentID", SqlDbType.Int).Value = ConvertNullToDBNull(department.SuperDepartmentID);
                cmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ConvertNullToDBNull(department.ParentID);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(department.ImageUrl);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteDepartment", cn);

                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

}
