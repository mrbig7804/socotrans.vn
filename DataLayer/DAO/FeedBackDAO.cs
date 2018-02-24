using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;


namespace Zensoft.Website.DataLayer.DAO
{
    public class FeedbacksDAO : FeedbacksBaseDAO
    {
    }

    public class FeedbacksBaseDAO : BaseDAO
    {

        public Feedback GetFeedbackFromReader(IDataReader dr)
        {
            Feedback temp = new Feedback();

            if (dr["ContactID"] != DBNull.Value) temp.ContactID = Convert.ToInt32(dr["ContactID"]);
            if (dr["FeedbackDate"] != DBNull.Value) temp.FeedbackDate = Convert.ToDateTime(dr["FeedbackDate"]);
            if (dr["FullName"] != DBNull.Value) temp.FullName = Convert.ToString(dr["FullName"]);
            if (dr["Tel"] != DBNull.Value) temp.Tel = Convert.ToString(dr["Tel"]);
            if (dr["Email"] != DBNull.Value) temp.Email = Convert.ToString(dr["Email"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Detail"] != DBNull.Value) temp.Detail = Convert.ToString(dr["Detail"]);

            return temp;
        }

        public FeedbacksBaseDAO()
        {
        }

        public Feedback GetFeedback(int contactID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectFeedback", cn);

                cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = contactID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetFeedbackFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetFeedbacksAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectFeedbacksAll");
        //}


        //Get by ForeignKey

        //Get All
        public List<Feedback> GetFeedbacksAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectFeedbacksAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Feedback> list = new List<Feedback>();
                while (dr.Read())
                {
                    list.Add(GetFeedbackFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(Feedback feedback)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertFeedback", cn);

                cmd.Parameters.Add("@FeedbackDate", SqlDbType.DateTime).Value = feedback.FeedbackDate;
                cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = feedback.FullName;
                cmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = feedback.Tel;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = feedback.Email;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = feedback.Title;
                cmd.Parameters.Add("@Detail", SqlDbType.NVarChar).Value = feedback.Detail;

                cmd.Parameters.Add("@ContactID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@ContactID"].Value;
            }
        }
        //Update
        public bool Update(Feedback feedback)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateFeedback", cn);

                cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = feedback.ContactID;
                cmd.Parameters.Add("@FeedbackDate", SqlDbType.DateTime).Value = feedback.FeedbackDate;
                cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = feedback.FullName;
                cmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = feedback.Tel;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = feedback.Email;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = feedback.Title;
                cmd.Parameters.Add("@Detail", SqlDbType.NVarChar).Value = feedback.Detail;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int contactID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteFeedback", cn);

                cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = contactID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

}
