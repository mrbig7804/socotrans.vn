using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class DirectionDAO : BaseDAO
    {

        public Direction GetDirectionFromReader(IDataReader dr)
        {
            Direction temp = new Direction();

            if (dr["DirectionID"] != DBNull.Value) temp.DirectionID = Convert.ToInt32(dr["DirectionID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["Important"] != DBNull.Value) temp.Important = Convert.ToInt32(dr["Important"]);

            return temp;
        }

        public DirectionDAO()
        {
        }

        public Direction GetDirection(int directionID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectDirection", cn);

                cmd.Parameters.Add("@DirectionID", SqlDbType.Int).Value = directionID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetDirectionFromReader(dr);
                else
                    return null;
            }
        }

        //Get All
        public List<Direction> GetDirectionAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectDirectionsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Direction> list = new List<Direction>();
                while (dr.Read())
                {
                    list.Add(GetDirectionFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(Direction direction)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertDirection", cn);

                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(direction.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(direction.Description);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(direction.Important);

                cmd.Parameters.Add("@DirectionID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@DirectionID"].Value;
            }
        }
        //Update
        public bool Update(Direction direction)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateDirection", cn);

                cmd.Parameters.Add("@DirectionID", SqlDbType.Int).Value = ConvertNullToDBNull(direction.DirectionID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(direction.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(direction.Description);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(direction.Important);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int directionID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteDirection", cn);

                cmd.Parameters.Add("@DirectionID", SqlDbType.Int).Value = directionID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
