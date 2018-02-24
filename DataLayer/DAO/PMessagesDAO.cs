using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;
using System.Data;
using System.Data.SqlClient;

namespace Zensoft.Website.DataLayer.DAO
{
    public class PMessagesDAO : PMessagesBaseDAO
    {
        public List<PMessage> GetPMessagesOutbox(string userName)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("PMessages_GetOutbox", cn);

                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PMessage> list = new List<PMessage>();
                while (dr.Read())
                {
                    list.Add(GetPMessageFromReader(dr));
                }

                return list;
            }
        }


        public List<PMessage> GetPMessagesInbox(string userName)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("PMessages_GetInbox", cn);

                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PMessage> list = new List<PMessage>();
                while (dr.Read())
                {
                    list.Add(GetPMessageFromReader(dr));
                }

                return list;
            }
        }

    }

    public class PMessagesBaseDAO : BaseDAO
    {

        public PMessage GetPMessageFromReader(IDataReader dr)
        {
            PMessage temp = new PMessage();

            if (dr["PMessageID"] != DBNull.Value) temp.PMessageID = Convert.ToInt32(dr["PMessageID"]);
            if (dr["FromUserName"] != DBNull.Value) temp.FromUserName = Convert.ToString(dr["FromUserName"]);
            if (dr["Created"] != DBNull.Value) temp.Created = Convert.ToDateTime(dr["Created"]);
            if (dr["Subject"] != DBNull.Value) temp.Subject = Convert.ToString(dr["Subject"]);
            if (dr["Body"] != DBNull.Value) temp.Body = Convert.ToString(dr["Body"]);
            if (dr["SenderDeleted"] != DBNull.Value) temp.SenderDeleted = Convert.ToBoolean(dr["SenderDeleted"]);

            return temp;
        }

        public PMessagesBaseDAO()
        {
        }

        public PMessage GetPMessage(int pMessageID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectPMessage", cn);

                cmd.Parameters.Add("@PMessageID", SqlDbType.Int).Value = pMessageID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetPMessageFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetPMessagesAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectPMessagesAll");
        //}


        //Get by ForeignKey

        //Get All
        public List<PMessage> GetPMessagesAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPMessagesAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PMessage> list = new List<PMessage>();
                while (dr.Read())
                {
                    list.Add(GetPMessageFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(PMessage pMessage)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertPMessage", cn);

                cmd.Parameters.Add("@FromUserName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(pMessage.FromUserName);
                cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = ConvertNullToDBNull(pMessage.Created);
                cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = ConvertNullToDBNull(pMessage.Subject);
                cmd.Parameters.Add("@Body", SqlDbType.NText).Value = ConvertNullToDBNull(pMessage.Body);
                cmd.Parameters.Add("@SenderDeleted", SqlDbType.Bit).Value = ConvertNullToDBNull(pMessage.SenderDeleted);

                cmd.Parameters.Add("@PMessageID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@PMessageID"].Value;
            }
        }
        //Update
        public bool Update(PMessage pMessage)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdatePMessage", cn);

                cmd.Parameters.Add("@PMessageID", SqlDbType.Int).Value = ConvertNullToDBNull(pMessage.PMessageID);
                cmd.Parameters.Add("@FromUserName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(pMessage.FromUserName);
                cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = ConvertNullToDBNull(pMessage.Created);
                cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = ConvertNullToDBNull(pMessage.Subject);
                cmd.Parameters.Add("@Body", SqlDbType.NText).Value = ConvertNullToDBNull(pMessage.Body);
                cmd.Parameters.Add("@SenderDeleted", SqlDbType.Bit).Value = ConvertNullToDBNull(pMessage.SenderDeleted);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int pMessageID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeletePMessage", cn);

                cmd.Parameters.Add("@PMessageID", SqlDbType.Int).Value = pMessageID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
