using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;
namespace Zensoft.Website.DataLayer.DAO
{
    public class PollOptionsDAO : PollOptionsBaseDAO
    {
        public bool Vote(int pollOptionID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PollOptions_Vote", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PollOptionID", SqlDbType.Int).Value = pollOptionID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }
    }

    public class PollOptionsBaseDAO : BaseDAO
    {

        public PollOption GetPollOptionFromReader(IDataReader dr)
        {
            PollOption temp = new PollOption();

            if (dr["PollOptionID"] != DBNull.Value) temp.PollOptionID = Convert.ToInt32(dr["PollOptionID"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["AddedBy"] != DBNull.Value) temp.AddedBy = Convert.ToString(dr["AddedBy"]);
            if (dr["PollId"] != DBNull.Value) temp.PollId = Convert.ToInt32(dr["PollId"]);
            if (dr["OptionText"] != DBNull.Value) temp.OptionText = Convert.ToString(dr["OptionText"]);
            if (dr["Votes"] != DBNull.Value) temp.Votes = Convert.ToInt32(dr["Votes"]);
            if (dr["Percentage"] != DBNull.Value) temp.Percentage = Convert.ToDouble(dr["Percentage"]);

            return temp;
        }

        public PollOptionsBaseDAO()
        {
        }

        public PollOption GetPollOption(int pollOptionID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectPollOption", cn);

                cmd.Parameters.Add("@PollOptionID", SqlDbType.Int).Value = pollOptionID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetPollOptionFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetPollOptionsAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectPollOptionsAll");
        //}


        //Get by ForeignKey
        public List<PollOption> GetPollOptionsByPollId(int pollId)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectPollOptionsByPollId", cn);

                cmd.Parameters.Add("@PollId", SqlDbType.Int).Value = pollId;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PollOption> list = new List<PollOption>();
                while (dr.Read())
                {
                    list.Add(GetPollOptionFromReader(dr));
                }
                return list;
            }
        }

        //Get All
        public List<PollOption> GetPollOptionsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPollOptionsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PollOption> list = new List<PollOption>();
                while (dr.Read())
                {
                    list.Add(GetPollOptionFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(PollOption pollOption)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertPollOption", cn);

                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = pollOption.AddedDate;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = pollOption.AddedBy;
                cmd.Parameters.Add("@PollId", SqlDbType.Int).Value = pollOption.PollId;
                cmd.Parameters.Add("@OptionText", SqlDbType.NChar).Value = pollOption.OptionText;
                cmd.Parameters.Add("@Votes", SqlDbType.Int).Value = pollOption.Votes;

                cmd.Parameters.Add("@PollOptionID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@PollOptionID"].Value;
            }
        }
        //Update
        public bool Update(PollOption pollOption)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdatePollOption", cn);

                cmd.Parameters.Add("@PollOptionID", SqlDbType.Int).Value = pollOption.PollOptionID;
                cmd.Parameters.Add("@OptionText", SqlDbType.NChar).Value = pollOption.OptionText;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int pollOptionID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeletePollOption", cn);

                cmd.Parameters.Add("@PollOptionID", SqlDbType.Int).Value = pollOptionID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

}
