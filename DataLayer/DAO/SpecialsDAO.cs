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
    public class SpecialsDAO : SpecialsBaseDAO
    {
    }

    public class SpecialsBaseDAO : BaseDAO
    {

        public Special GetSpecialFromReader(IDataReader dr)
        {
            Special temp = new Special();

            if (dr["SpecialID"] != DBNull.Value) temp.SpecialID = Convert.ToInt32(dr["SpecialID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);

            return temp;
        }

        public SpecialsBaseDAO()
        {
        }

        public Special GetSpecial(int specialID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectSpecial", cn);

                cmd.Parameters.Add("@SpecialID", SqlDbType.Int).Value = specialID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetSpecialFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetSpecialsAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectSpecialsAll");
        //}


        //Get by ForeignKey

        //Get All
        public List<Special> GetSpecialsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectSpecialsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Special> list = new List<Special>();
                while (dr.Read())
                {
                    list.Add(GetSpecialFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(Special special)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertSpecial", cn);

                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(special.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(special.Description);

                cmd.Parameters.Add("@SpecialID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@SpecialID"].Value;
            }
        }
        //Update
        public bool Update(Special special)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateSpecial", cn);

                cmd.Parameters.Add("@SpecialID", SqlDbType.Int).Value = ConvertNullToDBNull(special.SpecialID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(special.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(special.Description);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int specialID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteSpecial", cn);

                cmd.Parameters.Add("@SpecialID", SqlDbType.Int).Value = specialID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

}
