using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class PaymentMethodsDAO : PaymentMethodsBaseDAO
    {
    }

    public class PaymentMethodsBaseDAO : BaseDAO
    {

        public PaymentMethod GetPaymentMethodFromReader(IDataReader dr)
        {
            PaymentMethod temp = new PaymentMethod();

            if (dr["PaymentMethodID"] != DBNull.Value) temp.PaymentMethodID = Convert.ToInt32(dr["PaymentMethodID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);

            return temp;
        }

        public PaymentMethodsBaseDAO()
        {
        }

        public PaymentMethod GetPaymentMethod(int paymentMethodID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectPaymentMethod", cn);

                cmd.Parameters.Add("@PaymentMethodID", SqlDbType.Int).Value = paymentMethodID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetPaymentMethodFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetPaymentMethodsAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectPaymentMethodsAll");
        //}


        //Get by ForeignKey

        //Get All
        public List<PaymentMethod> GetPaymentMethodsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectPaymentMethodsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<PaymentMethod> list = new List<PaymentMethod>();
                while (dr.Read())
                {
                    list.Add(GetPaymentMethodFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(PaymentMethod paymentMethod)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertPaymentMethod", cn);

                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(paymentMethod.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(paymentMethod.Description);

                cmd.Parameters.Add("@PaymentMethodID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@PaymentMethodID"].Value;
            }
        }
        //Update
        public bool Update(PaymentMethod paymentMethod)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdatePaymentMethod", cn);

                cmd.Parameters.Add("@PaymentMethodID", SqlDbType.Int).Value = ConvertNullToDBNull(paymentMethod.PaymentMethodID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(paymentMethod.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(paymentMethod.Description);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int paymentMethodID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeletePaymentMethod", cn);

                cmd.Parameters.Add("@PaymentMethodID", SqlDbType.Int).Value = paymentMethodID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
