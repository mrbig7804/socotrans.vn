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
        public bool LogUserActivity(Guid userId, string activity, string pageUrl)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("ActivityLogs_UserActivity", cn);

                cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = ConvertNullToDBNull(userId);
                cmd.Parameters.Add("@Activity", SqlDbType.NVarChar).Value = ConvertNullToDBNull(activity);
                cmd.Parameters.Add("@PageUrl", SqlDbType.VarChar).Value = ConvertNullToDBNull(pageUrl);


                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public List<ActivityLog> GetCurrentActivityForOnline(int minutes)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("ActivityLogs_GetCurrentActivityForOnlineUsers", cn);
                cmd.Parameters.Add("@MinutesSinceLastInactive", SqlDbType.Int).Value = minutes;
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

    }

}
