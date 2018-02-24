using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public partial class VCategoriesDAO : BaseDAO
    {

        public VCategory GetVCategoryFromReader(IDataReader dr)
        {
            VCategory temp = new VCategory();

            if (dr["CategoryID"] != DBNull.Value) temp.CategoryID = Convert.ToInt32(dr["CategoryID"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["AddedBy"] != DBNull.Value) temp.AddedBy = Convert.ToString(dr["AddedBy"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["ImageUrl"] != DBNull.Value) temp.ImageUrl = Convert.ToString(dr["ImageUrl"]);
            if (dr["Important"] != DBNull.Value) temp.Important = Convert.ToInt32(dr["Important"]);
            if (dr["ParentID"] != DBNull.Value) temp.ParentID = Convert.ToInt32(dr["ParentID"]);

            return temp;
        }

        public VCategoriesDAO()
        {
        }

        public VCategory GetVCategory(int categoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectVCategory", cn);

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetVCategoryFromReader(dr);
                else
                    return null;
            }
        }

        //Get All
        public List<VCategory> GetVCategoriesAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectVCategoriesAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<VCategory> list = new List<VCategory>();
                while (dr.Read())
                {
                    list.Add(GetVCategoryFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(VCategory vCategory)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertVCategory", cn);

                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(vCategory.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(vCategory.AddedBy);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(vCategory.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(vCategory.Description);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(vCategory.ImageUrl);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(vCategory.Important);
                cmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ConvertNullToDBNull(vCategory.ParentID);

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@CategoryID"].Value;
            }
        }
        //Update
        public bool Update(VCategory vCategory)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateVCategory", cn);

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = ConvertNullToDBNull(vCategory.CategoryID);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(vCategory.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(vCategory.AddedBy);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(vCategory.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(vCategory.Description);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(vCategory.ImageUrl);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(vCategory.Important);
                cmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ConvertNullToDBNull(vCategory.ParentID);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int categoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteVCategory", cn);

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
