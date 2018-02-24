using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Web.Caching;
using System.Data.Common;
using System.Web;
using System.Web.Configuration;

using System.Configuration;

namespace Zensoft.Website.DataLayer.DAO
{
    public class BaseDAO
    {
        private string _connectionString = WebConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString; //"Data Source=SERVER;Initial Catalog=Zensoft_DB;User ID=sa;Password=123456";
        protected string ConnectionString
        {
            get { return _connectionString; }
            //set { _connectionString = value; }
        }


        protected object ConvertNullToDBNull(object input)
        {
            if (input == null)
                return DBNull.Value;
            else
                return input;
        }

        //private bool _enableCaching = true;
        //protected bool EnableCaching
        //{
        //    get { return _enableCaching; }
        //    set { _enableCaching = value; }
        //}

        //private int _cacheDuration = 0;
        //protected int CacheDuration
        //{
        //    get { return _cacheDuration; }
        //    set { _cacheDuration = value; }
        //}

        //protected Cache Cache
        //{
        //    get { return HttpContext.Current.Cache; }
        //}

        protected int ExecuteNonQuery(DbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        protected IDataReader ExecuteReader(DbCommand cmd)
        {
            return ExecuteReader(cmd, CommandBehavior.Default);
        }

        protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            return cmd.ExecuteReader(behavior);
        }

        protected object ExecuteScalar(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }
    }
}
