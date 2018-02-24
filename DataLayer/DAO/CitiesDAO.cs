using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class CitiesDAO : BaseDAO
    {

        public City GetCityFromReader(IDataReader dr)
        {
            City temp = new City();

            if (dr["CityID"] != DBNull.Value) temp.CityID = Convert.ToInt32(dr["CityID"]);
            if (dr["ParentID"] != DBNull.Value) temp.ParentID = Convert.ToInt32(dr["ParentID"]);
            if (dr["Name"] != DBNull.Value) temp.Name = Convert.ToString(dr["Name"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["Important"] != DBNull.Value) temp.Important = Convert.ToInt32(dr["Important"]);
            if (dr["IsMain"] != DBNull.Value) temp.IsMain = Convert.ToBoolean(dr["IsMain"]);

            return temp;
        }

        public CitiesDAO()
        {
        }

        public City GetCity(int cityID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectCity", cn);

                cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = cityID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetCityFromReader(dr);
                else
                    return null;
            }
        }

        //Get All
        public List<City> GetCitiesAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectCitiesAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<City> list = new List<City>();
                while (dr.Read())
                {
                    list.Add(GetCityFromReader(dr));
                }

                return list;
            }
        }

        public List<City> GetCitiesByParentID(int cityID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectCityByParentID", cn);

                cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = cityID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<City> list = new List<City>();
                while (dr.Read())
                {
                    list.Add(GetCityFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(City city)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertCity", cn);

                cmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ConvertNullToDBNull(city.ParentID);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = ConvertNullToDBNull(city.Name);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(city.Description);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(city.Important);
                cmd.Parameters.Add("@IsMain", SqlDbType.Bit).Value = ConvertNullToDBNull(city.IsMain);

                cmd.Parameters.Add("@CityID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@CityID"].Value;
            }
        }
        //Update
        public bool Update(City city)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateCity", cn);

                cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = ConvertNullToDBNull(city.CityID);
                cmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ConvertNullToDBNull(city.ParentID);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = ConvertNullToDBNull(city.Name);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(city.Description);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(city.Important);
                cmd.Parameters.Add("@IsMain", SqlDbType.Bit).Value = ConvertNullToDBNull(city.IsMain);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int cityID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteCity", cn);

                cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = cityID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
