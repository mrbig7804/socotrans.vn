using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class PropertiesDAO : BaseDAO
    {

        public Property GetPropertyFromReader(IDataReader dr)
        {
            Property temp = new Property();

            if (dr["PropertyID"] != DBNull.Value) temp.PropertyID = Convert.ToInt32(dr["PropertyID"]);
            if (dr["PropertyGroupID"] != DBNull.Value) temp.PropertyGroupID = Convert.ToInt32(dr["PropertyGroupID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Important"] != DBNull.Value) temp.Important = Convert.ToInt32(dr["Important"]);
            if (dr["AllowSearch"] != DBNull.Value) temp.AllowSearch = Convert.ToBoolean(dr["AllowSearch"]);

            return temp;
        }

        public PropertiesDAO()
        {
        }

        public Property GetProperty(int propertyID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProperty", cn);

                cmd.Parameters.Add("@PropertyID", SqlDbType.Int).Value = propertyID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetPropertyFromReader(dr);
                else
                    return null;
            }
        }

        //Get All
        public List<Property> GetPropertiesAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPropertiesAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Property> list = new List<Property>();
                while (dr.Read())
                {
                    list.Add(GetPropertyFromReader(dr));
                }

                return list;
            }
        }

        //Get by property group
        public List<Property> GetPropertiesByPropertyGroup(int propertyGroupID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPropertiesByPropertyGroupID", cn);
                cmd.Parameters.Add("@PropertyGroupID", SqlDbType.Int).Value = propertyGroupID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Property> list = new List<Property>();
                while (dr.Read())
                {
                    list.Add(GetPropertyFromReader(dr));
                }

                return list;
            }
        }

        //Get Dynamic
        public List<Property> GetPropertiesDynamic(string condition, string orderBy)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPropertiesDynamic", cn);
                cmd.Parameters.Add("@WhereCondition", SqlDbType.NVarChar).Value = condition;
                cmd.Parameters.Add("@OrderByExpression", SqlDbType.NVarChar).Value = orderBy;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Property> list = new List<Property>();
                while (dr.Read())
                {
                    list.Add(GetPropertyFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(Property property)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertProperty", cn);

                cmd.Parameters.Add("@PropertyGroupID", SqlDbType.Int).Value = ConvertNullToDBNull(property.PropertyGroupID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(property.Title);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(property.Important);
                cmd.Parameters.Add("@AllowSearch", SqlDbType.Bit).Value = ConvertNullToDBNull(property.AllowSearch);

                cmd.Parameters.Add("@PropertyID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@PropertyID"].Value;
            }
        }
        //Update
        public bool Update(Property property)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateProperty", cn);

                cmd.Parameters.Add("@PropertyID", SqlDbType.Int).Value = ConvertNullToDBNull(property.PropertyID);
                cmd.Parameters.Add("@PropertyGroupID", SqlDbType.Int).Value = ConvertNullToDBNull(property.PropertyGroupID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(property.Title);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(property.Important);
                cmd.Parameters.Add("@AllowSearch", SqlDbType.Bit).Value = ConvertNullToDBNull(property.AllowSearch);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int propertyID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteProperty", cn);

                cmd.Parameters.Add("@PropertyID", SqlDbType.Int).Value = propertyID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
