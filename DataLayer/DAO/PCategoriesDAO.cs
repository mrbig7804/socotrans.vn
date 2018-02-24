using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Zensoft.Website.DataLayer.DataObject;
using System.Data.SqlClient;

namespace Zensoft.Website.DataLayer.DAO
{
    public class PCategoriesDAO : PCategoriesBaseDAO
    {
    }

    public class PCategoriesBaseDAO : BaseDAO
    {

        public PCategory GetPCategoryFromReader(IDataReader dr)
        {
            PCategory temp = new PCategory();

            if (dr["PCategoryID"] != DBNull.Value) temp.PCategoryID = Convert.ToInt32(dr["PCategoryID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);

            return temp;
        }

        public PCategoriesBaseDAO()
        {
        }

        public PCategory GetPCategory(int pCategoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectPCategory", cn);

                cmd.Parameters.Add("@PCategoryID", SqlDbType.Int).Value = pCategoryID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetPCategoryFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetPCategoriesAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectPCategoriesAll");
        //}


        //Get by ForeignKey

        //Get All
        public List<PCategory> GetPCategoriesAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPCategoriesAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PCategory> list = new List<PCategory>();
                while (dr.Read())
                {
                    list.Add(GetPCategoryFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(PCategory pCategory)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertPCategory", cn);

                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(pCategory.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(pCategory.Description);

                cmd.Parameters.Add("@PCategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@PCategoryID"].Value;
            }
        }
        //Update
        public bool Update(PCategory pCategory)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdatePCategory", cn);

                cmd.Parameters.Add("@PCategoryID", SqlDbType.Int).Value = ConvertNullToDBNull(pCategory.PCategoryID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(pCategory.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(pCategory.Description);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int pCategoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeletePCategory", cn);

                cmd.Parameters.Add("@PCategoryID", SqlDbType.Int).Value = pCategoryID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

}
