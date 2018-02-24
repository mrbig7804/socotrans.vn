using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;
using System.Data;
using System.Data.SqlClient;

namespace Zensoft.Website.DataLayer.DAO
{
    public class UserPMessagesDAO : UserPMessagesBaseDAO
    {
        public UserPMessage GetInboxByPMessageID(string userName,int pMessageID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UserPMessages_GetInboxByPMessageID", cn);

                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;
                cmd.Parameters.Add("@PMessageID", SqlDbType.Int).Value = pMessageID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetUserPMessageFromReader(dr);
                else
                    return null;
            }
        }

        public  List<UserPMessage> GetInboxNewMessage(string userName)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UserPMessages_GetInboxNewMessage", cn);

                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<UserPMessage> list = new List<UserPMessage>();
                while (dr.Read())
                {
                    list.Add(GetUserPMessageFromReader(dr));
                }
                return list;
            }
        }

        public bool MarkDeleted(int userPMessageID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UserPMessages_MarkDelete", cn);

                cmd.Parameters.Add("@UserPMessageID", SqlDbType.Int).Value = userPMessageID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }

        }

    }


    public class UserPMessagesBaseDAO : BaseDAO
    {

        public UserPMessage GetUserPMessageFromReader(IDataReader dr)
        {
            UserPMessage temp = new UserPMessage();

            if (dr["UserPMessageID"] != DBNull.Value) temp.UserPMessageID = Convert.ToInt32(dr["UserPMessageID"]);
            if (dr["UserName"] != DBNull.Value) temp.UserName = Convert.ToString(dr["UserName"]);
            if (dr["PMessageID"] != DBNull.Value) temp.PMessageID = Convert.ToInt32(dr["PMessageID"]);
            if (dr["IsRead"] != DBNull.Value) temp.IsRead = Convert.ToBoolean(dr["IsRead"]);
            if (dr["Deleted"] != DBNull.Value) temp.Deleted = Convert.ToBoolean(dr["Deleted"]);

            return temp;
        }

        public UserPMessagesBaseDAO()
        {
        }

        public UserPMessage GetUserPMessage(int userPMessageID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectUserPMessage", cn);

                cmd.Parameters.Add("@UserPMessageID", SqlDbType.Int).Value = userPMessageID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetUserPMessageFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetUserPMessagesAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectUserPMessagesAll");
        //}


        //Get by ForeignKey
        public List<UserPMessage> GetUserPMessagesByPMessageID(int pMessageID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectUserPMessagesByPMessageID", cn);

                cmd.Parameters.Add("@PMessageID", SqlDbType.Int).Value = pMessageID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<UserPMessage> list = new List<UserPMessage>();
                while (dr.Read())
                {
                    list.Add(GetUserPMessageFromReader(dr));
                }
                return list;
            }
        }

        //Get All
        public List<UserPMessage> GetUserPMessagesAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectUserPMessagesAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<UserPMessage> list = new List<UserPMessage>();
                while (dr.Read())
                {
                    list.Add(GetUserPMessageFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(UserPMessage userPMessage)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertUserPMessage", cn);

                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(userPMessage.UserName);
                cmd.Parameters.Add("@PMessageID", SqlDbType.Int).Value = ConvertNullToDBNull(userPMessage.PMessageID);
                cmd.Parameters.Add("@IsRead", SqlDbType.Bit).Value = ConvertNullToDBNull(userPMessage.IsRead);
                cmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = ConvertNullToDBNull(userPMessage.Deleted);

                cmd.Parameters.Add("@UserPMessageID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@UserPMessageID"].Value;
            }
        }
        //Update
        public bool Update(UserPMessage userPMessage)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateUserPMessage", cn);

                cmd.Parameters.Add("@UserPMessageID", SqlDbType.Int).Value = ConvertNullToDBNull(userPMessage.UserPMessageID);
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(userPMessage.UserName);
                cmd.Parameters.Add("@PMessageID", SqlDbType.Int).Value = ConvertNullToDBNull(userPMessage.PMessageID);
                cmd.Parameters.Add("@IsRead", SqlDbType.Bit).Value = ConvertNullToDBNull(userPMessage.IsRead);
                cmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = ConvertNullToDBNull(userPMessage.Deleted);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int userPMessageID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteUserPMessage", cn);

                cmd.Parameters.Add("@UserPMessageID", SqlDbType.Int).Value = userPMessageID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
