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
        //Get list categories by parent id
        public List<VCategory> GetVCategoriesByParentID(int parentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectVCategoryByParentID", cn);
                cmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = parentID;

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
    }
}
