using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    /// <summary>
    /// sondt:29/11/07: them 2 hàm GetCategoriesBySuperCategoryIDNoParent và GetCategoriesByParentCategoryID
    /// sondt:08/12/07: thêm hàm GetArticlesPublishedPagedByCategoryIDAndParentCategoryID
    /// </summary>
    public class CategoriesDAO : CategoriesBaseDAO
    {
        public List<Category> GetCategoriesBySuperCategoryIDAndParent(int superCategoryID, int parentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectCategoriesBySuperCategoryIDAndParent", cn);

                cmd.Parameters.Add("@SuperCategoryID", SqlDbType.Int).Value = superCategoryID;
                cmd.Parameters.Add("@Parent", SqlDbType.Int).Value = parentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Category> list = new List<Category>();
                while (dr.Read())
                {
                    list.Add(GetCategoryFromReader(dr));
                }
                return list;
            }
        }

        public List<Category> GetCategoriesByParentCategoryID(int categoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectCategoriesByParentCategoryID", cn);

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Category> list = new List<Category>();
                while (dr.Read())
                {
                    list.Add(GetCategoryFromReader(dr));
                }
                return list;
            }
        }

    }

    public class CategoriesBaseDAO : BaseDAO
    {

        public Category GetCategoryFromReader(IDataReader dr)
        {
            Category temp = new Category();

            if (dr["CategoryID"] != DBNull.Value) temp.CategoryID = Convert.ToInt32(dr["CategoryID"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["AddedBy"] != DBNull.Value) temp.AddedBy = Convert.ToString(dr["AddedBy"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Importance"] != DBNull.Value) temp.Importance = Convert.ToInt32(dr["Importance"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["ImageUrl"] != DBNull.Value) temp.ImageUrl = Convert.ToString(dr["ImageUrl"]);
            if (dr["SuperCategoryID"] != DBNull.Value) temp.SuperCategoryID = Convert.ToInt32(dr["SuperCategoryID"]);
            if (dr["ParentCategoryID"] != DBNull.Value) temp.ParentCategoryID = Convert.ToInt32(dr["ParentCategoryID"]);

            return temp;
        }

        public CategoriesBaseDAO()
        {
        }

        public Category GetCategory(int categoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectCategory", cn);

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetCategoryFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetCategoriesAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectCategoriesAll");
        //}


        //Get by ForeignKey
        public List<Category> GetCategoriesBySuperCategoryID(int superCategoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectCategoriesBySuperCategoryID", cn);

                cmd.Parameters.Add("@SuperCategoryID", SqlDbType.Int).Value = superCategoryID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Category> list = new List<Category>();
                while (dr.Read())
                {
                    list.Add(GetCategoryFromReader(dr));
                }
                return list;
            }
        }


        //Get All
        public List<Category> GetCategoriesAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectCategoriesAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Category> list = new List<Category>();
                while (dr.Read())
                {
                    list.Add(GetCategoryFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(Category category)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertCategory", cn);

                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(category.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.AddedBy);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.Title);
                cmd.Parameters.Add("@Importance", SqlDbType.Int).Value = ConvertNullToDBNull(category.Importance);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.Description);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.ImageUrl);
                cmd.Parameters.Add("@SuperCategoryID", SqlDbType.Int).Value = ConvertNullToDBNull(category.SuperCategoryID);
                cmd.Parameters.Add("@ParentCategoryID", SqlDbType.Int).Value = ConvertNullToDBNull(category.ParentCategoryID);

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@CategoryID"].Value;
            }
        }
        //Update
        public bool Update(Category category)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateCategory", cn);

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = ConvertNullToDBNull(category.CategoryID);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(category.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.AddedBy);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.Title);
                cmd.Parameters.Add("@Importance", SqlDbType.Int).Value = ConvertNullToDBNull(category.Importance);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.Description);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.ImageUrl);
                cmd.Parameters.Add("@SuperCategoryID", SqlDbType.Int).Value = ConvertNullToDBNull(category.SuperCategoryID);
                cmd.Parameters.Add("@ParentCategoryID", SqlDbType.Int).Value = ConvertNullToDBNull(category.ParentCategoryID);

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
                SqlCommand cmd = new SqlCommand("usp_DeleteCategory", cn);

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }


    //public class CategoriesDAO : CategoriesBaseDAO
    //{
    //}

    //public class CategoriesBaseDAO : BaseDAO
    //{

    //    public Category GetCategoryFromReader(IDataReader dr)
    //    {
    //        Category temp = new Category();

    //        if (dr["CategoryID"] != DBNull.Value) temp.CategoryID = Convert.ToInt32(dr["CategoryID"]);
    //        if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
    //        if (dr["AddedBy"] != DBNull.Value) temp.AddedBy = Convert.ToString(dr["AddedBy"]);
    //        if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
    //        if (dr["Importance"] != DBNull.Value) temp.Importance = Convert.ToInt32(dr["Importance"]);
    //        if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
    //        if (dr["ImageUrl"] != DBNull.Value) temp.ImageUrl = Convert.ToString(dr["ImageUrl"]);
    //        if (dr["SuperCategoryID"] != DBNull.Value) temp.SuperCategoryID = Convert.ToInt32(dr["SuperCategoryID"]);

    //        return temp;
    //    }

    //    public CategoriesBaseDAO()
    //    {
    //    }

    //    public Category GetCategory(int categoryID)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_SelectCategory", cn);

    //            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            IDataReader dr = ExecuteReader(cmd);
    //            if (dr.Read())
    //                return GetCategoryFromReader(dr);
    //            else
    //                return null;
    //        }
    //    }

    //    //public DataSet GetCategoriesAll()
    //    //{
    //    //	SqlService service = new SqlService();
    //    //	return service.ExecuteSPDataSet("usp_SelectCategoriesAll");
    //    //}


    //    //Get by ForeignKey
    //    public List<Category> GetCategoriesBySuperCategoryID(int superCategoryID)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_SelectCategoriesBySuperCategoryID", cn);

    //            cmd.Parameters.Add("@SuperCategoryID", SqlDbType.Int).Value = superCategoryID;

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            IDataReader dr = ExecuteReader(cmd);

    //            List<Category> list = new List<Category>();
    //            while (dr.Read())
    //            {
    //                list.Add(GetCategoryFromReader(dr));
    //            }
    //            return list;
    //        }
    //    }

    //    //Get All
    //    public List<Category> GetCategoriesAll()
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {

    //            SqlCommand cmd = new SqlCommand("usp_SelectCategoriesAll", cn);

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            IDataReader dr = ExecuteReader(cmd);

    //            List<Category> list = new List<Category>();
    //            while (dr.Read())
    //            {
    //                list.Add(GetCategoryFromReader(dr));
    //            }

    //            return list;
    //        }
    //    }
    //    //Insert
    //    public int Insert(Category category)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_InsertCategory", cn);

    //            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(category.AddedDate);
    //            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.AddedBy);
    //            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.Title);
    //            cmd.Parameters.Add("@Importance", SqlDbType.Int).Value = ConvertNullToDBNull(category.Importance);
    //            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.Description);
    //            cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.ImageUrl);
    //            cmd.Parameters.Add("@SuperCategoryID", SqlDbType.Int).Value = ConvertNullToDBNull(category.SuperCategoryID);

    //            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            int ret = ExecuteNonQuery(cmd);

    //            return (int)cmd.Parameters["@CategoryID"].Value;
    //        }
    //    }
    //    //Update
    //    public bool Update(Category category)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_UpdateCategory", cn);

    //            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = ConvertNullToDBNull(category.CategoryID);
    //            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(category.AddedDate);
    //            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.AddedBy);
    //            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.Title);
    //            cmd.Parameters.Add("@Importance", SqlDbType.Int).Value = ConvertNullToDBNull(category.Importance);
    //            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.Description);
    //            cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(category.ImageUrl);
    //            cmd.Parameters.Add("@SuperCategoryID", SqlDbType.Int).Value = ConvertNullToDBNull(category.SuperCategoryID);

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            int ret = ExecuteNonQuery(cmd);

    //            return (ret == 1);
    //        }
    //    }

    //    //Delete
    //    public bool Delete(int categoryID)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_DeleteCategory", cn);

    //            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            int ret = ExecuteNonQuery(cmd);

    //            return (ret == 1);
    //        }
    //    }
    //}

}
