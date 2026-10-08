using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace POM.Repository
{
    public class DBConnection
    {
        public static readonly string CONNECTION_STRING;

        /// <summary>
        /// staic constructor.
        /// </summary>
        static DBConnection()
        {
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        }
    }
    public class DBConnectionHelper
    {
        public static SqlConnection OpenNewSqlConnection(string strConn)
        {
            try
            {
                SqlConnection objSqlConn = new SqlConnection(strConn);

                if (objSqlConn.State == ConnectionState.Closed)
                {
                    objSqlConn.Open();
                }

                return objSqlConn;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void CloseSqlConnection(SqlConnection objConn)
        {
            try
            {
                if (objConn == null)
                {
                    return;
                }
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
