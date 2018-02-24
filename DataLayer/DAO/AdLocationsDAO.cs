using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
 
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public partial class AdLocationsDAO : BaseDAO
    {

        public AdLocation GetAdLocationFromReader(IDataReader dr)
        {
            AdLocation temp = new AdLocation();

            if (dr["AdLocationID"] != DBNull.Value) temp.AdLocationID = Convert.ToInt32(dr["AdLocationID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);

            return temp;
        }

        public AdLocationsDAO()
        {
        }

        public AdLocation GetAdLocation(int adLocationID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectAdLocation", cn);

                cmd.Parameters.Add("@AdLocationID", SqlDbType.Int).Value = adLocationID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetAdLocationFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetAdLocationsAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectAdLocationsAll");
        //}


        //Get by ForeignKey

        //Get All
        public List<AdLocation> GetAdLocationsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectAdLocationsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<AdLocation> list = new List<AdLocation>();
                while (dr.Read())
                {
                    list.Add(GetAdLocationFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(AdLocation adLocation)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertAdLocation", cn);

                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(adLocation.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(adLocation.Description);

                cmd.Parameters.Add("@AdLocationID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@AdLocationID"].Value;
            }
        }
        //Update
        public bool Update(AdLocation adLocation)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateAdLocation", cn);

                cmd.Parameters.Add("@AdLocationID", SqlDbType.Int).Value = ConvertNullToDBNull(adLocation.AdLocationID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(adLocation.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(adLocation.Description);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int adLocationID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteAdLocation", cn);

                cmd.Parameters.Add("@AdLocationID", SqlDbType.Int).Value = adLocationID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
