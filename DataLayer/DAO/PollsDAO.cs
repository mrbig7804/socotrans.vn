using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;
namespace Zensoft.Website.DataLayer.DAO
{
    public class PollsDAO : PollsBaseDAO
    {
        public int GetCurrentPollID()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Polls_GetCurrentPollID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PollID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@PollID"].Value;
            }
        }

        public bool ArchivePoll(int pollID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Polls_ArchivePoll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PollID", SqlDbType.Int).Value = pollID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public List<Poll> GetPollsArchived()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPollsArchived", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Poll> list = new List<Poll>();
                while (dr.Read())
                {
                    list.Add(GetPollFromReader(dr));
                }

                return list;
            }
        }

        public List<Poll> GetPollsNonArchived()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPollsNonArchived", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Poll> list = new List<Poll>();
                while (dr.Read())
                {
                    list.Add(GetPollFromReader(dr));
                }

                return list;
            }
        }
    }

    public class PollsBaseDAO : BaseDAO
    {

        public Poll GetPollFromReader(IDataReader dr)
        {
            Poll temp = new Poll();

            if (dr["PollID"] != DBNull.Value) temp.PollID = Convert.ToInt32(dr["PollID"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["AddedBy"] != DBNull.Value) temp.AddedBy = Convert.ToString(dr["AddedBy"]);
            if (dr["QuestionText"] != DBNull.Value) temp.QuestionText = Convert.ToString(dr["QuestionText"]);
            if (dr["IsCurrent"] != DBNull.Value) temp.IsCurrent = Convert.ToBoolean(dr["IsCurrent"]);
            if (dr["IsArchived"] != DBNull.Value) temp.IsArchived = Convert.ToBoolean(dr["IsArchived"]);
            if (dr["ArchivedDate"] != DBNull.Value) temp.ArchivedDate = Convert.ToDateTime(dr["ArchivedDate"]);
            if (dr["Votes"] != DBNull.Value) temp.Votes = Convert.ToInt32(dr["Votes"]);

            return temp;
        }

        public PollsBaseDAO()
        {
        }

        public Poll GetPoll(int pollID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectPoll", cn);

                cmd.Parameters.Add("@PollID", SqlDbType.Int).Value = pollID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetPollFromReader(dr);
                else
                    return null;
            }
        }

        //Get All
        public List<Poll> GetPollsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPollsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Poll> list = new List<Poll>();
                while (dr.Read())
                {
                    list.Add(GetPollFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(Poll poll)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertPoll", cn);

                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = poll.AddedDate;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = poll.AddedBy;
                cmd.Parameters.Add("@QuestionText", SqlDbType.NVarChar).Value = poll.QuestionText;
                cmd.Parameters.Add("@IsCurrent", SqlDbType.Bit).Value = poll.IsCurrent;
                cmd.Parameters.Add("@IsArchived", SqlDbType.Bit).Value = poll.IsArchived;
                //cmd.Parameters.Add("@ArchivedDate", SqlDbType.DateTime).Value = poll.ArchivedDate;

                cmd.Parameters.Add("@PollID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@PollID"].Value;
            }
        }
        //Update
        public bool Update(Poll poll)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdatePoll", cn);

                cmd.Parameters.Add("@PollID", SqlDbType.Int).Value = poll.PollID;
                //cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = poll.AddedDate;
                //cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = poll.AddedBy;
                cmd.Parameters.Add("@QuestionText", SqlDbType.NVarChar).Value = poll.QuestionText;
                cmd.Parameters.Add("@IsCurrent", SqlDbType.Bit).Value = poll.IsCurrent;
                //cmd.Parameters.Add("@IsArchived", SqlDbType.Bit).Value = poll.IsArchived;
                //cmd.Parameters.Add("@ArchivedDate", SqlDbType.DateTime).Value = poll.ArchivedDate;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int pollID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeletePoll", cn);

                cmd.Parameters.Add("@PollID", SqlDbType.Int).Value = pollID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

}
