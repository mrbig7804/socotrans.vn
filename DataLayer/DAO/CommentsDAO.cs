using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    /// <summary>
    /// sondt:27/09/07 Tạo mới
    /// sondt:05/11/07 Thêm hàm GetCommentsByUser(string name)
    /// </summary>
    public class CommentsDAO : CommentsBaseDAO
    {
        public List<Comment> GetCommentsByUser(string name)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectCommentsByUserName", cn);

                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = name;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Comment> list = new List<Comment>();
                while (dr.Read())
                {
                    list.Add(GetCommentFromReader(dr));
                }
                return list;
            }
        }
    }

    public class CommentsBaseDAO : BaseDAO
    {

        public Comment GetCommentFromReader(IDataReader dr)
        {
            Comment temp = new Comment();

            if (dr["CommentID"] != DBNull.Value) temp.CommentID = Convert.ToInt64(dr["CommentID"]);
            if (dr["FullName"] != DBNull.Value) temp.FullName = Convert.ToString(dr["FullName"]);
            if (dr["Email"] != DBNull.Value) temp.Email = Convert.ToString(dr["Email"]);
            if (dr["Body"] != DBNull.Value) temp.Body = Convert.ToString(dr["Body"]);
            if (dr["ArticleID"] != DBNull.Value) temp.ArticleID = Convert.ToInt32(dr["ArticleID"]);
            if (dr["UserName"] != DBNull.Value) temp.UserName = Convert.ToString(dr["UserName"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["Approved"] != DBNull.Value) temp.Approved = Convert.ToBoolean(dr["Approved"]);

            return temp;
        }

        public CommentsBaseDAO()
        {
        }

        public Comment GetComment(long commentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectComment", cn);

                cmd.Parameters.Add("@CommentID", SqlDbType.BigInt).Value = commentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetCommentFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetCommentsAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectCommentsAll");
        //}


        //Get by ForeignKey
        public List<Comment> GetCommentsByArticleID(int articleID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectCommentsByArticleID", cn);

                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = articleID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Comment> list = new List<Comment>();
                while (dr.Read())
                {
                    list.Add(GetCommentFromReader(dr));
                }
                return list;
            }
        }

        //Get All
        public List<Comment> GetCommentsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectCommentsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Comment> list = new List<Comment>();
                while (dr.Read())
                {
                    list.Add(GetCommentFromReader(dr));
                }

                return list;
            }
        }

        //Get all the comments have not specied yet.
        public List<Comment> GetCommentsNotSpecied()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectCommentsNotSpecified", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Comment> list = new List<Comment>();
                while (dr.Read())
                {
                    list.Add(GetCommentFromReader(dr));
                }

                return list;
            }
        }

        // Get all the comments specified
        public List<Comment> GetCommentsSpecied()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectCommentsSpecified", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Comment> list = new List<Comment>();
                while (dr.Read())
                {
                    list.Add(GetCommentFromReader(dr));
                }

                return list;
            }
        }

        // Xác nhận các Comment cho bài viết.
        public bool SpecifyComment(int commentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Comments_SpecifyComment", cn);

                cmd.Parameters.Add("@CommentID", SqlDbType.BigInt).Value = commentID;
               
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }

        //Insert
        public long Insert(Comment comment)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertComment", cn);

                cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(comment.FullName);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = ConvertNullToDBNull(comment.Email);
                cmd.Parameters.Add("@Body", SqlDbType.NVarChar).Value = ConvertNullToDBNull(comment.Body);
                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ConvertNullToDBNull(comment.ArticleID);
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(comment.UserName);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(comment.AddedDate);
                cmd.Parameters.Add("@Approved", SqlDbType.Bit).Value = ConvertNullToDBNull(comment.Approved);

                cmd.Parameters.Add("@CommentID", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (long)cmd.Parameters["@CommentID"].Value;
            }
        }
        //Update
        public bool Update(Comment comment)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateComment", cn);

                cmd.Parameters.Add("@CommentID", SqlDbType.BigInt).Value = ConvertNullToDBNull(comment.CommentID);
                cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(comment.FullName);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = ConvertNullToDBNull(comment.Email);
                cmd.Parameters.Add("@Body", SqlDbType.NVarChar).Value = ConvertNullToDBNull(comment.Body);
                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ConvertNullToDBNull(comment.ArticleID);
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(comment.UserName);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(comment.AddedDate);
                cmd.Parameters.Add("@Approved", SqlDbType.Bit).Value = ConvertNullToDBNull(comment.Approved);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(long commentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteComment", cn);

                cmd.Parameters.Add("@CommentID", SqlDbType.BigInt).Value = commentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
