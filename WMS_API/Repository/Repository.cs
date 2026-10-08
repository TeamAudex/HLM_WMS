using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Librarys.Logging;

namespace POM.Repository
{
    public abstract class RepositoryBaseNew 
    {

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RepositoryBaseNew()
            : this(DBConnection.CONNECTION_STRING)
        {

        }

        /// <summary>
        /// Constructor for when you want to provide connection string from factory.
        /// </summary>
        /// <param name="connectionString"></param>
        public RepositoryBaseNew(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string can't be null or empty.");
            }
        }

        public DataSet ExecuteCommand(string sprocName, List<SqlParameter> parameters, ref int recordCount)
        {
            try
            {
                SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
                using (SqlCommand cmd = CreateCommand(sprocName, CommandType.StoredProcedure, parameters, conn))
                {
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                    DBConnectionHelper.CloseSqlConnection(conn);
                    return ds;
                }
            }
            catch (SqlException ex)
            {
                ////TODO
                Logger.For(this).Error(ex);
                throw;
            }
            catch (Exception ex)
            {
                //TODO
                Logger.For(this).Error(ex);
                throw;
            }
        }

        public DataSet MasterExecuteCommand(string sprocName, List<SqlParameter> parameters, ref int recordCount)
        {
            try
            {
                SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
                using (SqlCommand cmd = CreateCommand(sprocName, CommandType.StoredProcedure, parameters, conn))
                {
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                    DBConnectionHelper.CloseSqlConnection(conn);
                    return ds;
                }
            }
            catch (SqlException ex)
            {
                ////TODO
                Logger.For(this).Error(ex);
                throw;
            }
            catch (Exception ex)
            {
                //TODO
                Logger.For(this).Error(ex);
                throw;
            }
        }

        public DataSet ExecuteCommand(string sprocName, List<SqlParameter> parameters)
        {
            try
            {
               SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
                using (SqlCommand cmd = CreateCommand(sprocName, CommandType.StoredProcedure, parameters, conn))
                {
                    cmd.CommandTimeout = 20000;
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    DBConnectionHelper.CloseSqlConnection(conn);
                    return ds;
                }
            }
            catch (SqlException ex)
            {
                //TODO
                Logger.For(this).Error(ex);
              throw;
            }
            catch (Exception ex)
            {
                //TODO
                Logger.For(this).Error(ex);
                throw;
            }
        }

        public DataSet OneMinExecuteCommand(string sprocName, List<SqlParameter> parameters)
        {
            try
            {
                SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
                using (SqlCommand cmd = CreateCommand(sprocName, CommandType.StoredProcedure, parameters, conn))
                {
                    cmd.CommandTimeout = 60;
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    DBConnectionHelper.CloseSqlConnection(conn);
                    return ds;
                }
            }
            catch (SqlException ex)
            {
                //TODO
                Logger.For(this).Error(ex);
                throw;
            }
            catch (Exception ex)
            {
                //TODO
                Logger.For(this).Error(ex);
                throw;
            }
        }





        public DataSet PushExecuteCommand(string sprocName, List<SqlParameter> parameters)
        {
            try
            {
                SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
                using (SqlCommand cmd = CreateCommand(sprocName, CommandType.StoredProcedure, parameters, conn))
                {
                    cmd.CommandTimeout = 2000;
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    DBConnectionHelper.CloseSqlConnection(conn);
                    return ds;
                }
            }
            catch (SqlException ex)
            {
                //TODO
                Logger.For(this).Error(ex);
                throw;
            }
            catch (Exception ex)
            {
                //TODO
                Logger.For(this).Error(ex);
                throw;
            }
        }





        public DataSet MasterExecuteCommand(string sprocName, List<SqlParameter> parameters)
        {
            try
            {
                SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
                using (SqlCommand cmd = CreateCommand(sprocName, CommandType.StoredProcedure, parameters, conn))
                {
                    cmd.CommandTimeout = 20000;
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    DBConnectionHelper.CloseSqlConnection(conn);
                    return ds;
                }
            }
            catch (SqlException ex)
            {
                //TODO
                Logger.For(this).Error(ex);
                throw;
            }
            catch (Exception ex)
            {
                //TODO
                Logger.For(this).Error(ex);
                throw;
            }
        }









        public DataSet ExecuteCommand(string sprocName, List<SqlParameter> parameters, ref int recordCount, ref int minFilterText)
        {
            try
            {
                SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
                using (SqlCommand cmd = CreateCommand(sprocName, CommandType.StoredProcedure, parameters, conn))
                {
                    cmd.CommandTimeout = 10000;
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                    //minFilterText = Convert.ToInt32(cmd.Parameters["@MinTextLength"].Value);
                    DBConnectionHelper.CloseSqlConnection(conn);
                    return ds;
                }
            }
            catch (SqlException ex)
            {
                //TODO
                Logger.For(this).Error(ex);
                throw;

            }
            catch (Exception ex)
            {
                //TODO
                Logger.For(this).Error(ex);
                throw;
            }
        }

        private SqlCommand CreateCommand(string sprocName, CommandType type, List<SqlParameter> parameters, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(sprocName, conn);
            cmd.CommandType = type;
            // Construct SQL parameters
            for (int i = 0; i < parameters.Count; i++)
            {
                if (parameters[i] is SqlParameter)
                {
                    cmd.Parameters.Add((SqlParameter)parameters[i]);
                }
                else throw new ArgumentException("Invalid type of arguments supplied");
            }
            return cmd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecNonQueryProc(string proc, List<SqlParameter> parameters)
        {
            int rowsAffected;
            try
            {
                SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
                using (SqlCommand cmd = CreateCommand(proc, CommandType.StoredProcedure, parameters, conn))
                {
                    rowsAffected = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                DBConnectionHelper.CloseSqlConnection(conn);
                return rowsAffected;
            }
            catch (SqlException ex)
            {
                //TODO
                Logger.For(this).Error(ex);
                throw;
            }
            catch (Exception ex)
            {
                //TODO
                Logger.For(this).Error(ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public dynamic ExecNonQueryProc(string proc, List<SqlParameter> parameters, string outputParamter)
        {
            dynamic outPut = null;
            try
            {
                SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
                using (SqlCommand cmd = CreateCommand(proc, CommandType.StoredProcedure, parameters, conn))
                {
                    cmd.ExecuteNonQuery();
                    outPut = cmd.Parameters[outputParamter].Value;
                    cmd.Parameters.Clear();
                }

            }
            catch (Exception ex)
            {
                Logger.For(this).Error(ex);
                throw;
            }

            return outPut;
        }
    }
}
