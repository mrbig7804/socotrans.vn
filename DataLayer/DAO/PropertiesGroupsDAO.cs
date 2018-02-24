using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zensoft.Website.DataLayer.DAO;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class PropertiesGroupsDAO : BaseDAO
    {

        public PropertiesGroup GetPropertiesGroupFromReader(IDataReader dr)
        {
            PropertiesGroup temp = new PropertiesGroup();

            if (dr["PropertyGroupID"] != DBNull.Value) temp.PropertyGroupID = Convert.ToInt32(dr["PropertyGroupID"]);
            if (dr["DepartmentID"] != DBNull.Value) temp.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Important"] != DBNull.Value) temp.Important = Convert.ToInt32(dr["Important"]);

            return temp;
        }

        public PropertiesGroupsDAO()
        {
        }

        public PropertiesGroup GetPropertiesGroup(int propertyGroupID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectPropertiesGroup", cn);

                cmd.Parameters.Add("@PropertyGroupID", SqlDbType.Int).Value = propertyGroupID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetPropertiesGroupFromReader(dr);
                else
                    return null;
            }
        }

        //Get All
        public List<PropertiesGroup> GetPropertiesGroupsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPropertiesGroupsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PropertiesGroup> list = new List<PropertiesGroup>();
                while (dr.Read())
                {
                    list.Add(GetPropertiesGroupFromReader(dr));
                }

                return list;
            }
        }

        //Get By Department
        public List<PropertiesGroup> GetPropertiesGroupsByDepartment(int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPropertiesGroupByDepartment", cn);
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PropertiesGroup> list = new List<PropertiesGroup>();
                while (dr.Read())
                {
                    list.Add(GetPropertiesGroupFromReader(dr));
                }

                return list;
            }
        }

        //Get Dynamic
        public List<PropertiesGroup> GetPropertiesGroupsDynamic(string condition, string orderBy)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPropertiesGroupsDynamic", cn);
                cmd.Parameters.Add("@WhereCondition", SqlDbType.NVarChar).Value = condition;
                cmd.Parameters.Add("@OrderByExpression", SqlDbType.NVarChar).Value = orderBy;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PropertiesGroup> list = new List<PropertiesGroup>();
                while (dr.Read())
                {
                    list.Add(GetPropertiesGroupFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(PropertiesGroup propertiesGroup)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertPropertiesGroup", cn);

                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = ConvertNullToDBNull(propertiesGroup.DepartmentID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(propertiesGroup.Title);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(propertiesGroup.Important);

                cmd.Parameters.Add("@PropertyGroupID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@PropertyGroupID"].Value;
            }
        }
        //Update
        public bool Update(PropertiesGroup propertiesGroup)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdatePropertiesGroup", cn);

                cmd.Parameters.Add("@PropertyGroupID", SqlDbType.Int).Value = ConvertNullToDBNull(propertiesGroup.PropertyGroupID);
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = ConvertNullToDBNull(propertiesGroup.DepartmentID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(propertiesGroup.Title);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(propertiesGroup.Important);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int propertyGroupID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeletePropertiesGroup", cn);

                cmd.Parameters.Add("@PropertyGroupID", SqlDbType.Int).Value = propertyGroupID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
