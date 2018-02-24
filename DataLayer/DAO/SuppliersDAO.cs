using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;
using System.Data.Common;
using System.Web.Configuration;
using System.Configuration;

namespace Zensoft.Website.DataLayer.DAO
{
    public class SuppliersDAO : SuppliersBaseDAO
    {
    }

    public class SuppliersBaseDAO : BaseDAO
    {

        public Supplier GetSupplierFromReader(IDataReader dr)
        {
            Supplier temp = new Supplier();

            if (dr["SupplierID"] != DBNull.Value) temp.SupplierID = Convert.ToInt32(dr["SupplierID"]);
            if (dr["SupplierName"] != DBNull.Value) temp.SupplierName = Convert.ToString(dr["SupplierName"]);
            if (dr["Address"] != DBNull.Value) temp.Address = Convert.ToString(dr["Address"]);
            if (dr["Tel"] != DBNull.Value) temp.Tel = Convert.ToString(dr["Tel"]);
            if (dr["Note"] != DBNull.Value) temp.Note = Convert.ToString(dr["Note"]);

            return temp;
        }

        public SuppliersBaseDAO()
        {
        }

        public Supplier GetSupplier(int supplierID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectSupplier", cn);

                cmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value = supplierID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetSupplierFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetSuppliersAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectSuppliersAll");
        //}


        //Get by ForeignKey

        //Get All
        public List<Supplier> GetSuppliersAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectSuppliersAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Supplier> list = new List<Supplier>();
                while (dr.Read())
                {
                    list.Add(GetSupplierFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(Supplier supplier)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertSupplier", cn);

                cmd.Parameters.Add("@SupplierName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(supplier.SupplierName);
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = ConvertNullToDBNull(supplier.Address);
                cmd.Parameters.Add("@Tel", SqlDbType.VarChar).Value = ConvertNullToDBNull(supplier.Tel);
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = ConvertNullToDBNull(supplier.Note);

                cmd.Parameters.Add("@SupplierID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@SupplierID"].Value;
            }
        }
        //Update
        public bool Update(Supplier supplier)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateSupplier", cn);

                cmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value = ConvertNullToDBNull(supplier.SupplierID);
                cmd.Parameters.Add("@SupplierName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(supplier.SupplierName);
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = ConvertNullToDBNull(supplier.Address);
                cmd.Parameters.Add("@Tel", SqlDbType.VarChar).Value = ConvertNullToDBNull(supplier.Tel);
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = ConvertNullToDBNull(supplier.Note);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int supplierID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteSupplier", cn);

                cmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value = supplierID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

}
