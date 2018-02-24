using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class PriceDistanceDAO : BaseDAO
    {

        public PriceDistance GetPriceDistanceFromReader(IDataReader dr)
        {
            PriceDistance temp = new PriceDistance();

            if (dr["PriceID"] != DBNull.Value) temp.PriceID = Convert.ToInt32(dr["PriceID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["PriceFrom"] != DBNull.Value) temp.PriceFrom = Convert.ToInt32(dr["PriceFrom"]);
            if (dr["PriceTo"] != DBNull.Value) temp.PriceTo = Convert.ToInt32(dr["PriceTo"]);
            if (dr["Important"] != DBNull.Value) temp.Important = Convert.ToInt32(dr["Important"]);
            if (dr["AllowSearcch"] != DBNull.Value) temp.AllowSearcch = Convert.ToBoolean(dr["AllowSearcch"]);

            return temp;
        }

        public PriceDistanceDAO()
        {
        }

        public PriceDistance GetPriceDistance(int priceID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectPriceDistance", cn);

                cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = priceID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetPriceDistanceFromReader(dr);
                else
                    return null;
            }
        }

        //Get All
        public List<PriceDistance> GetPriceDistanceAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPriceDistancesAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PriceDistance> list = new List<PriceDistance>();
                while (dr.Read())
                {
                    list.Add(GetPriceDistanceFromReader(dr));
                }

                return list;
            }
        }

        //Get BY Department
        public List<PriceDistance> GetPriceDistanceByDepartment(int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPriceDistanceByDepartment", cn);
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PriceDistance> list = new List<PriceDistance>();
                while (dr.Read())
                {
                    list.Add(GetPriceDistanceFromReader(dr));
                }

                return list;
            }
        }

        //Get Dynamic
        public List<PriceDistance> GetPriceDistanceDynamic(string condition, string orderBy)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPriceDistancesDynamic", cn);
                cmd.Parameters.Add("@WhereCondition", SqlDbType.NVarChar).Value = condition;
                cmd.Parameters.Add("@OrderByExpression", SqlDbType.NVarChar).Value = orderBy;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PriceDistance> list = new List<PriceDistance>();
                while (dr.Read())
                {
                    list.Add(GetPriceDistanceFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(PriceDistance priceDistance)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertPriceDistance", cn);

                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(priceDistance.Title);
                cmd.Parameters.Add("@PriceFrom", SqlDbType.Int).Value = ConvertNullToDBNull(priceDistance.PriceFrom);
                cmd.Parameters.Add("@PriceTo", SqlDbType.Int).Value = ConvertNullToDBNull(priceDistance.PriceTo);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(priceDistance.Important);
                cmd.Parameters.Add("@AllowSearcch", SqlDbType.Bit).Value = ConvertNullToDBNull(priceDistance.AllowSearcch);

                cmd.Parameters.Add("@PriceID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@PriceID"].Value;
            }
        }

        //Update
        public bool Update(PriceDistance priceDistance)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdatePriceDistance", cn);

                cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = ConvertNullToDBNull(priceDistance.PriceID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(priceDistance.Title);
                cmd.Parameters.Add("@PriceFrom", SqlDbType.Int).Value = ConvertNullToDBNull(priceDistance.PriceFrom);
                cmd.Parameters.Add("@PriceTo", SqlDbType.Int).Value = ConvertNullToDBNull(priceDistance.PriceTo);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(priceDistance.Important);
                cmd.Parameters.Add("@AllowSearcch", SqlDbType.Bit).Value = ConvertNullToDBNull(priceDistance.AllowSearcch);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }

        //Delete
        public bool Delete(int priceID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeletePriceDistance", cn);

                cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = priceID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
