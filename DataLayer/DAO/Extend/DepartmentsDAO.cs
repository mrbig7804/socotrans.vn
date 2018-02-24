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

        public List<Department> GetDepartmentsListedBySuperDepartmentID(int superDepartmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("Departments_GetListedBySuperDepartmentID", cn);
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

        public List<Department> GetDepartmentsByParentID(int parentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectDepartmentsByParentID", cn);
                cmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = parentID;

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

        public List<Department> GetDepartmentsByParentIDAndSuperDepartmentID(int parentID, int superDepId)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectDepartmentsByParentIDAndSuperDepartmentID", cn);
                cmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = parentID;
                cmd.Parameters.Add("@SuperDepartmentID", SqlDbType.Int).Value = superDepId;

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

        public List<Department> GetDepartmentsByUserName(string userName)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("Departments_GetByUserName", cn);
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;

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
    }
}
