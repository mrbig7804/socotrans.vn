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
    public partial class ActivityLogsDAO : BaseDAO
    {

        public ActivityLog GetActivityLogFromReader(IDataReader dr)
        {
            ActivityLog temp = new ActivityLog();

            if (dr["ActivityLogID"] != DBNull.Value) temp.ActivityLogID = Convert.ToInt64(dr["ActivityLogID"]);
            if (dr["UserId"] != DBNull.Value) temp.UserId = (Guid)(dr["UserId"]);
            if (dr["Activity"] != DBNull.Value) temp.Activity = Convert.ToString(dr["Activity"]);
            if (dr["PageUrl"] != DBNull.Value) temp.PageUrl = Convert.ToString(dr["PageUrl"]);
            if (dr["ActivityDate"] != DBNull.Value) temp.ActivityDate = Convert.ToDateTime(dr["ActivityDate"]);

            return temp;
        }

        public ActivityLogsDAO()
        {
        }

        public ActivityLog GetActivityLog(long activityLogID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectActivityLog", cn);

                cmd.Parameters.Add("@ActivityLogID", SqlDbType.BigInt).Value = activityLogID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetActivityLogFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetActivityLogsAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectActivityLogsAll");
        //}


        //Get by ForeignKey
        public List<ActivityLog> GetActivityLogsByUserId(Guid userId)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectActivityLogsByUserId", cn);

                cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<ActivityLog> list = new List<ActivityLog>();
                while (dr.Read())
                {
                    list.Add(GetActivityLogFromReader(dr));
                }
                return list;
            }
        }

        //Get All
        public List<ActivityLog> GetActivityLogsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectActivityLogsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<ActivityLog> list = new List<ActivityLog>();
                while (dr.Read())
                {
                    list.Add(GetActivityLogFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public long Insert(ActivityLog activityLog)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertActivityLog", cn);

                cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = ConvertNullToDBNull(activityLog.UserId);
                cmd.Parameters.Add("@Activity", SqlDbType.NVarChar).Value = ConvertNullToDBNull(activityLog.Activity);
                cmd.Parameters.Add("@PageUrl", SqlDbType.VarChar).Value = ConvertNullToDBNull(activityLog.PageUrl);
                cmd.Parameters.Add("@ActivityDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(activityLog.ActivityDate);

                cmd.Parameters.Add("@ActivityLogID", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (long)cmd.Parameters["@ActivityLogID"].Value;
            }
        }
        //Update
        public bool Update(ActivityLog activityLog)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateActivityLog", cn);

                cmd.Parameters.Add("@ActivityLogID", SqlDbType.BigInt).Value = ConvertNullToDBNull(activityLog.ActivityLogID);
                cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = ConvertNullToDBNull(activityLog.UserId);
                cmd.Parameters.Add("@Activity", SqlDbType.NVarChar).Value = ConvertNullToDBNull(activityLog.Activity);
                cmd.Parameters.Add("@PageUrl", SqlDbType.VarChar).Value = ConvertNullToDBNull(activityLog.PageUrl);
                cmd.Parameters.Add("@ActivityDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(activityLog.ActivityDate);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(long activityLogID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteActivityLog", cn);

                cmd.Parameters.Add("@ActivityLogID", SqlDbType.BigInt).Value = activityLogID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

}
