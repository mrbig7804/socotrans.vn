using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
 
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public partial class AdLinksDAO : BaseDAO
    {

        public AdLink GetAdLinkFromReader(IDataReader dr)
        {
            AdLink temp = new AdLink();

            if (dr["AdLinkID"] != DBNull.Value) temp.AdLinkID = Convert.ToInt32(dr["AdLinkID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["Link"] != DBNull.Value) temp.Link = Convert.ToString(dr["Link"]);
            if (dr["Image"] != DBNull.Value) temp.Image = Convert.ToString(dr["Image"]);
            if (dr["Code"] != DBNull.Value) temp.Code = Convert.ToString(dr["Code"]);
            if (dr["IsCode"] != DBNull.Value) temp.IsCode = Convert.ToBoolean(dr["IsCode"]);
            if (dr["RegionDate"] != DBNull.Value) temp.RegionDate = Convert.ToDateTime(dr["RegionDate"]);
            if (dr["ExpireDate"] != DBNull.Value) temp.ExpireDate = Convert.ToDateTime(dr["ExpireDate"]);
            if (dr["Importance"] != DBNull.Value) temp.Importance = Convert.ToInt32(dr["Importance"]);
            if (dr["Click"] != DBNull.Value) temp.Click = Convert.ToInt32(dr["Click"]);
            if (dr["AdLocationID"] != DBNull.Value) temp.AdLocationID = Convert.ToInt32(dr["AdLocationID"]);

            return temp;
        }

        public AdLinksDAO()
        {
        }

        public AdLink GetAdLink(int adLinkID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectAdLink", cn);

                cmd.Parameters.Add("@AdLinkID", SqlDbType.Int).Value = adLinkID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetAdLinkFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetAdLinksAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectAdLinksAll");
        //}


        //Get by ForeignKey
        public List<AdLink> GetAdLinksByAdLocationID(int adLocationID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectAdLinksByAdLocationID", cn);

                cmd.Parameters.Add("@AdLocationID", SqlDbType.Int).Value = adLocationID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<AdLink> list = new List<AdLink>();
                while (dr.Read())
                {
                    list.Add(GetAdLinkFromReader(dr));
                }
                return list;
            }
        }

        //Get All
        public List<AdLink> GetAdLinksAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectAdLinksAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<AdLink> list = new List<AdLink>();
                while (dr.Read())
                {
                    list.Add(GetAdLinkFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(AdLink adLink)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertAdLink", cn);

                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(adLink.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(adLink.Description);
                cmd.Parameters.Add("@Link", SqlDbType.NVarChar).Value = ConvertNullToDBNull(adLink.Link);
                cmd.Parameters.Add("@Image", SqlDbType.NVarChar).Value = ConvertNullToDBNull(adLink.Image);
                cmd.Parameters.Add("@Code", SqlDbType.NText).Value = ConvertNullToDBNull(adLink.Code);
                cmd.Parameters.Add("@IsCode", SqlDbType.Bit).Value = ConvertNullToDBNull(adLink.IsCode);
                cmd.Parameters.Add("@RegionDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(adLink.RegionDate);
                cmd.Parameters.Add("@ExpireDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(adLink.ExpireDate);
                cmd.Parameters.Add("@Importance", SqlDbType.Int).Value = ConvertNullToDBNull(adLink.Importance);
                cmd.Parameters.Add("@Click", SqlDbType.Int).Value = ConvertNullToDBNull(adLink.Click);
                cmd.Parameters.Add("@AdLocationID", SqlDbType.Int).Value = ConvertNullToDBNull(adLink.AdLocationID);

                cmd.Parameters.Add("@AdLinkID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@AdLinkID"].Value;
            }
        }
        //Update
        public bool Update(AdLink adLink)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateAdLink", cn);

                cmd.Parameters.Add("@AdLinkID", SqlDbType.Int).Value = ConvertNullToDBNull(adLink.AdLinkID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(adLink.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(adLink.Description);
                cmd.Parameters.Add("@Link", SqlDbType.NVarChar).Value = ConvertNullToDBNull(adLink.Link);
                cmd.Parameters.Add("@Image", SqlDbType.NVarChar).Value = ConvertNullToDBNull(adLink.Image);
                cmd.Parameters.Add("@Code", SqlDbType.NText).Value = ConvertNullToDBNull(adLink.Code);
                cmd.Parameters.Add("@IsCode", SqlDbType.Bit).Value = ConvertNullToDBNull(adLink.IsCode);
                cmd.Parameters.Add("@RegionDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(adLink.RegionDate);
                cmd.Parameters.Add("@ExpireDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(adLink.ExpireDate);
                cmd.Parameters.Add("@Importance", SqlDbType.Int).Value = ConvertNullToDBNull(adLink.Importance);
                cmd.Parameters.Add("@Click", SqlDbType.Int).Value = ConvertNullToDBNull(adLink.Click);
                cmd.Parameters.Add("@AdLocationID", SqlDbType.Int).Value = ConvertNullToDBNull(adLink.AdLocationID);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int adLinkID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteAdLink", cn);

                cmd.Parameters.Add("@AdLinkID", SqlDbType.Int).Value = adLinkID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
