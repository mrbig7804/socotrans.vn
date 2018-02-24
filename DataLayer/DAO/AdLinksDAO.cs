using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
 
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    /// <summary>
    /// NgocDV - 26-10-2007 - Thêm hàm GetAdLinksbyLocation
    /// </summary>
    public partial class AdLinksDAO : BaseDAO
    {
        /// <summary>
        /// tăng số lượt click vào mỗi mẫu quảng cáo .
        /// </summary>
        /// <param name="adlinkID"></param>
        /// <returns></returns>
        public bool IncreaseClick(int adlinkID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("AdLinks_IncreaseClick", cn);

                cmd.Parameters.Add("@AdLinkID", SqlDbType.Int).Value = adlinkID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }

        // Get Adlinks By Location and locate the Adlink according to the Location.
        public List<AdLink> GetByLocationIDAndEffectiveTime(int location)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("AdLinks_GetByLocationIDAndEffectiveTime", cn);

                cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<AdLink> list = new List<AdLink>();
                while (dr.Read())
                {
                    list.Add(GetAdLinkFromReader(dr));
                }

                return list;
            }
        }

    }
}
