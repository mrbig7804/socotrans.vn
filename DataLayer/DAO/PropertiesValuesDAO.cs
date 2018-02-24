using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class PropertiesValuesDAO : BaseDAO
    {

        public PropertiesValue GetPropertiesValueFromReader(IDataReader dr)
        {
            PropertiesValue temp = new PropertiesValue();

            if (dr["PropertiesValueID"] != DBNull.Value) temp.PropertiesValueID = Convert.ToInt32(dr["PropertiesValueID"]);
            if (dr["PropertyID"] != DBNull.Value) temp.PropertyID = Convert.ToInt32(dr["PropertyID"]);
            if (dr["Value"] != DBNull.Value) temp.Value = Convert.ToString(dr["Value"]);

            return temp;
        }

        public PropertiesValuesDAO()
        {
        }

        public PropertiesValue GetPropertiesValue(int propertiesValueID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectPropertiesValue", cn);

                cmd.Parameters.Add("@PropertiesValueID", SqlDbType.Int).Value = propertiesValueID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetPropertiesValueFromReader(dr);
                else
                    return null;
            }
        }

        //Get All
        public List<PropertiesValue> GetPropertiesValuesAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPropertiesValuesAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PropertiesValue> list = new List<PropertiesValue>();
                while (dr.Read())
                {
                    list.Add(GetPropertiesValueFromReader(dr));
                }

                return list;
            }
        }

        //Get by property
        public List<PropertiesValue> GetPropertiesValuesByProperty(int propertyID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPropertiesValuesByPropertyID", cn);
                cmd.Parameters.Add("@PropertyID", SqlDbType.Int).Value = propertyID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PropertiesValue> list = new List<PropertiesValue>();
                while (dr.Read())
                {
                    list.Add(GetPropertiesValueFromReader(dr));
                }

                return list;
            }
        }

        //Get by product
        public List<PropertiesValue> GetPropertiesValuesByProduct(int propertyID, int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPropertiesValuesByProduct", cn);
                cmd.Parameters.Add("@PropertyID", SqlDbType.Int).Value = propertyID;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PropertiesValue> list = new List<PropertiesValue>();
                while (dr.Read())
                {
                    list.Add(GetPropertiesValueFromReader(dr));
                }

                return list;
            }
        }

        //Get dynamic
        public List<PropertiesValue> GetPropertiesValuesDynamic(string condition, string orderBy)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPropertiesValuesByPropertyID", cn);
                cmd.Parameters.Add("@WhereCondition", SqlDbType.NVarChar).Value = condition;
                cmd.Parameters.Add("@OrderByExpression", SqlDbType.NVarChar).Value = orderBy;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PropertiesValue> list = new List<PropertiesValue>();
                while (dr.Read())
                {
                    list.Add(GetPropertiesValueFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(PropertiesValue propertiesValue)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertPropertiesValue", cn);

                cmd.Parameters.Add("@PropertyID", SqlDbType.Int).Value = ConvertNullToDBNull(propertiesValue.PropertyID);
                cmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = ConvertNullToDBNull(propertiesValue.Value);

                cmd.Parameters.Add("@PropertiesValueID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@PropertiesValueID"].Value;
            }
        }
        //Update
        public bool Update(PropertiesValue propertiesValue)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdatePropertiesValue", cn);

                cmd.Parameters.Add("@PropertiesValueID", SqlDbType.Int).Value = ConvertNullToDBNull(propertiesValue.PropertiesValueID);
                cmd.Parameters.Add("@PropertyID", SqlDbType.Int).Value = ConvertNullToDBNull(propertiesValue.PropertyID);
                cmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = ConvertNullToDBNull(propertiesValue.Value);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int propertiesValueID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeletePropertiesValue", cn);

                cmd.Parameters.Add("@PropertiesValueID", SqlDbType.Int).Value = propertiesValueID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
