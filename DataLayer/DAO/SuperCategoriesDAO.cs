using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;
namespace Zensoft.Website.DataLayer.DAO
{
    public class SuperCategoriesDAO : SuperCategoriesBaseDAO
    {
    }

    public class SuperCategoriesBaseDAO : BaseDAO
    {

        public SuperCategory GetSuperCategoryFromReader(IDataReader dr)
        {
            SuperCategory temp = new SuperCategory();

            if (dr["SuperCategoryID"] != DBNull.Value) temp.SuperCategoryID = Convert.ToInt32(dr["SuperCategoryID"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["AddedBy"] != DBNull.Value) temp.AddedBy = Convert.ToString(dr["AddedBy"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Importance"] != DBNull.Value) temp.Importance = Convert.ToInt32(dr["Importance"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["ImageUrl"] != DBNull.Value) temp.ImageUrl = Convert.ToString(dr["ImageUrl"]);

            return temp;
        }

        public SuperCategoriesBaseDAO()
        {
        }

        public SuperCategory GetSuperCategory(int superCategoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectSuperCategory", cn);

                cmd.Parameters.Add("@SuperCategoryID", SqlDbType.Int).Value = superCategoryID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetSuperCategoryFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetSuperCategoriesAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectSuperCategoriesAll");
        //}


        //Get by ForeignKey

        //Get All
        public List<SuperCategory> GetSuperCategoriesAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectSuperCategoriesAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<SuperCategory> list = new List<SuperCategory>();
                while (dr.Read())
                {
                    list.Add(GetSuperCategoryFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(SuperCategory superCategory)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertSuperCategory", cn);

                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(superCategory.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(superCategory.AddedBy);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(superCategory.Title);
                cmd.Parameters.Add("@Importance", SqlDbType.Int).Value = ConvertNullToDBNull(superCategory.Importance);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(superCategory.Description);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(superCategory.ImageUrl);

                cmd.Parameters.Add("@SuperCategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@SuperCategoryID"].Value;
            }
        }
        //Update
        public bool Update(SuperCategory superCategory)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateSuperCategory", cn);

                cmd.Parameters.Add("@SuperCategoryID", SqlDbType.Int).Value = ConvertNullToDBNull(superCategory.SuperCategoryID);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(superCategory.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(superCategory.AddedBy);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(superCategory.Title);
                cmd.Parameters.Add("@Importance", SqlDbType.Int).Value = ConvertNullToDBNull(superCategory.Importance);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(superCategory.Description);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(superCategory.ImageUrl);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int superCategoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteSuperCategory", cn);

                cmd.Parameters.Add("@SuperCategoryID", SqlDbType.Int).Value = superCategoryID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

}
