using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POMS.Entity;
using System.Data.SqlClient;
using System.Data;
using Entity = POMS.Entity;
using objLIB = POMS.Repository.ErrorEventLog;

namespace POMS.Repository
{
    public class BulkCommonRepository
    {
        //public void LRPrintSearch(Entity.Common objCommon)
        //{
        //    SqlConnection conn = new SqlConnection(DataAccess.strCon);
        //    DataTable dtResult = new DataTable();
        //    DataSet ds = new DataSet();

        //    ds.Tables.Add(dtResult);
        //    try
        //    {
        //        SqlCommand objCommand = new SqlCommand();
        //        objCommand.CommandType = CommandType.StoredProcedure;
        //        objCommand.CommandTimeout = 2000;
        //        objCommand.CommandText = "LrOrderSearch";
        //        objCommand.Parameters.Add("@ACTIONTYPE", SqlDbType.VarChar, 20).Value = objCommon.ActionType;
        //        objCommand.Parameters.Add("@Condition1", SqlDbType.VarChar, 20).Value = objCommon.Condition1;

        //        objCommand.Connection = conn;
        //        conn.Open();
        //        SqlDataReader objDataReader = objCommand.ExecuteReader();
        //        ds.Load(objDataReader, LoadOption.OverwriteChanges, dtResult);
        //    }

        //    catch (Exception ex)
        //    {
        //        objLIB.ErrorLog(ex.ToString(), "Error Occured Lr Order Search");
                
        //    }
        //    finally
        //    {
        //        objCommon.BulkPrint = ds;
        //        conn.Close();
        //    }
        //    return;
        //}


        //public void LRPrintReport(Entity.Common objCommon)
        //{
        //    SqlConnection conn = new SqlConnection(DataAccess.strCon);
        //    DataTable dtResult = new DataTable();
        //    DataSet ds = new DataSet();

        //    ds.Tables.Add(dtResult);
        //    try
        //    {
        //        SqlCommand objCommand = new SqlCommand();
        //        objCommand.CommandType = CommandType.StoredProcedure;
        //        objCommand.CommandTimeout = 2000;
        //        objCommand.CommandText = "LrOrderReportNew";
        //        objCommand.Parameters.Add("@ACTIONTYPE", SqlDbType.VarChar, 20).Value = objCommon.ActionType;
        //        objCommand.Parameters.Add("@Condition1", SqlDbType.VarChar, 20).Value = objCommon.Condition1;

        //        objCommand.Connection = conn;
        //        conn.Open();
        //        SqlDataReader objDataReader = objCommand.ExecuteReader();
        //        ds.Load(objDataReader, LoadOption.OverwriteChanges, dtResult);
        //    }

        //    catch (Exception ex)
        //    {
        //        objLIB.ErrorLog(ex.ToString(), "Error Occured Lr Order Report");
        //    }
        //    finally
        //    {
        //        objCommon.BulkPrintReport = ds;
        //        conn.Close();
        //    }
        //    return;
        //}


        //public void InvoicePrintSearch(Entity.Common objCommon)
        //{
        //    SqlConnection conn = new SqlConnection(DataAccess.strCon);
        //    DataTable dtResult = new DataTable();
        //    DataSet ds = new DataSet();

        //    ds.Tables.Add(dtResult);
        //    try
        //    {
        //        SqlCommand objCommand = new SqlCommand();
        //        objCommand.CommandType = CommandType.StoredProcedure;
        //        objCommand.CommandTimeout = 2000;
        //        objCommand.CommandText = "InvoiceOrderSearch";
        //        objCommand.Parameters.Add("@ACTIONTYPE", SqlDbType.VarChar, 20).Value = objCommon.ActionType;
        //        objCommand.Parameters.Add("@Condition1", SqlDbType.VarChar, 20).Value = objCommon.Condition1;

        //        objCommand.Connection = conn;
        //        conn.Open();
        //        SqlDataReader objDataReader = objCommand.ExecuteReader();
        //        ds.Load(objDataReader, LoadOption.OverwriteChanges, dtResult);
        //    }

        //    catch (Exception ex)
        //    {
        //        objLIB.ErrorLog(ex.ToString(), "Error Occured Invoice Order Search");
        //    }
        //    finally
        //    {
        //        objCommon.BulkPrint = ds;
        //        conn.Close();
        //    }
        //    return;
        //}


        //public void InvoicePrintReport(Entity.Common objCommon)
        //{
        //    SqlConnection conn = new SqlConnection(DataAccess.strCon);
        //    DataTable dtResult = new DataTable();
        //    DataSet ds = new DataSet();

        //    ds.Tables.Add(dtResult);
        //    try
        //    {
        //        SqlCommand objCommand = new SqlCommand();
        //        objCommand.CommandType = CommandType.StoredProcedure;
        //        objCommand.CommandTimeout = 2000;
        //        objCommand.CommandText = "InvoicePrintReport";
        //        objCommand.Parameters.Add("@ACTIONTYPE", SqlDbType.VarChar, 20).Value = objCommon.ActionType;
        //        objCommand.Parameters.Add("@Condition1", SqlDbType.VarChar, 20).Value = objCommon.Condition1;

        //        objCommand.Connection = conn;
        //        conn.Open();
        //        SqlDataReader objDataReader = objCommand.ExecuteReader();
        //        ds.Load(objDataReader, LoadOption.OverwriteChanges, dtResult);
        //    }

        //    catch (Exception ex)
        //    {
        //        objLIB.ErrorLog(ex.ToString(), "Error Occured Invoice Print Report");
        //    }
        //    finally
        //    {
        //        objCommon.BulkPrintReport = ds;
        //        conn.Close();
        //    }
        //    return;
        //}


        public void LRPrintSearch(Entity.CommonReport objCommon)
        {
            SqlConnection conn = new SqlConnection(DataAccess.strCon);
            DataTable dtResult = new DataTable();
            DataSet ds = new DataSet();

            ds.Tables.Add(dtResult);
            try
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandTimeout = 5000;
                objCommand.CommandText = "LrOrderSearch";
                objCommand.Parameters.Add("@ACTIONTYPE", SqlDbType.VarChar, 20).Value = objCommon.ActionTypess;
                objCommand.Parameters.Add("@Condition1", SqlDbType.VarChar, 20).Value = objCommon.ReqSno;

                objCommand.Connection = conn;
                conn.Open();
                SqlDataReader objDataReader = objCommand.ExecuteReader();
                ds.Load(objDataReader, LoadOption.OverwriteChanges, dtResult);
            }

            catch (Exception ex)
            {
                objLIB.ErrorLog(ex.ToString(), "Error Occured Lr Order Search");

            }
            finally
            {
                objCommon.BulkPrint = ds;
                conn.Close();
            }
            return;
        }


        public void LRPrintReport(Entity.CommonReport objCommon)
        {
            SqlConnection conn = new SqlConnection(DataAccess.strCon);
            DataTable dtResult = new DataTable();
            DataSet ds = new DataSet();

            ds.Tables.Add(dtResult);
            try
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandTimeout = 5000;
                objCommand.CommandText = "LrOrderReportNew";
                objCommand.Parameters.Add("@ACTIONTYPE", SqlDbType.VarChar, 20).Value = objCommon.ActionTypess;
                objCommand.Parameters.Add("@Condition1", SqlDbType.VarChar, 20).Value = objCommon.ReqSno;
                objCommand.Parameters.Add("@Condition2", SqlDbType.VarChar, 20).Value = objCommon.RptTypes;

                objCommand.Connection = conn;
                conn.Open();
                SqlDataReader objDataReader = objCommand.ExecuteReader();
                ds.Load(objDataReader, LoadOption.OverwriteChanges, dtResult);
            }
            catch (Exception ex)
            {
                objLIB.ErrorLog(ex.ToString(), "Error Occured Lr Order Search");

            }
            finally
            {
                objCommon.BulkPrintReport = ds;
                conn.Close();
            }
            return;
        }
        public void InvoicePrintReport(CommonReport objCommon)
        {
            SqlConnection conn = new SqlConnection(DataAccess.strCon);
            DataTable dtResult = new DataTable();
            DataTable dtResult1 = new DataTable();
            DataTable dtResult2 = new DataTable();
            DataSet ds = new DataSet();

            ds.Tables.Add(dtResult);
            ds.Tables.Add(dtResult1);
            ds.Tables.Add(dtResult2);
            try
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandTimeout = 5000;
                objCommand.CommandText = "NewInvoicePrintReport";
                objCommand.Parameters.Add("@ACTIONTYPE", SqlDbType.VarChar, 20).Value = objCommon.ActionTypess;
                objCommand.Parameters.Add("@Condition1", SqlDbType.VarChar, 20).Value = objCommon.ReqSno;
                objCommand.Parameters.Add("@TypeofFlag", SqlDbType.VarChar, 20).Value = objCommon.TypeofFlag;

                objCommand.Connection = conn;
                conn.Open();
                SqlDataReader objDataReader = objCommand.ExecuteReader();
                ds.Load(objDataReader, LoadOption.OverwriteChanges, dtResult, dtResult1, dtResult2); 
            }

            catch (Exception ex)
            {
                objLIB.ErrorLog(ex.ToString(), "Error Occured Lr Order Search");

            }
            finally
            {
                objCommon.BulkPrintReport = ds;
                conn.Close();
            }
            return;
        }

        public void InvoicePrintSearch(CommonReport objCommon)
        {
            SqlConnection conn = new SqlConnection(DataAccess.strCon);
            DataTable dtResult = new DataTable();
            DataTable dtResult1 = new DataTable();
            DataSet ds = new DataSet();

            ds.Tables.Add(dtResult);
            ds.Tables.Add(dtResult1);
            try
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandTimeout = 5000;
                objCommand.CommandText = "InvoiceOrderSearch";
                objCommand.Parameters.Add("@ACTIONTYPE", SqlDbType.VarChar, 20).Value = objCommon.ActionTypess;
                objCommand.Parameters.Add("@Condition1", SqlDbType.VarChar, 20).Value = objCommon.ReqSno;
               // objCommand.Parameters.Add("@TypeofFlag", SqlDbType.VarChar, 20).Value = objCommon.TypeofFlag;

                objCommand.Connection = conn;
                conn.Open();
                SqlDataReader objDataReader = objCommand.ExecuteReader();
                ds.Load(objDataReader, LoadOption.OverwriteChanges, dtResult, dtResult1);
            }
            catch (Exception ex)
            {
                objLIB.ErrorLog(ex.ToString(), "Error Occured Lr Order Search");

            }
            finally
            {
                objCommon.BulkPrint = ds;
                conn.Close();
            }
            return;
        }
        public void ExportInvoicePrintSearch(CommonReport objCommon)
        {
            SqlConnection conn = new SqlConnection(DataAccess.strCon);
            DataTable dtResult = new DataTable();
            DataTable dtResult1 = new DataTable();
            DataSet ds = new DataSet();

            ds.Tables.Add(dtResult);
            ds.Tables.Add(dtResult1);
            try
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandTimeout = 5000;
                objCommand.CommandText = "ExportInvoiceOrderSearch";
                objCommand.Parameters.Add("@ACTIONTYPE", SqlDbType.VarChar, 20).Value = objCommon.ActionTypess;
                objCommand.Parameters.Add("@Condition1", SqlDbType.VarChar, 20).Value = objCommon.ReqSno;
                // objCommand.Parameters.Add("@TypeofFlag", SqlDbType.VarChar, 20).Value = objCommon.TypeofFlag;

                objCommand.Connection = conn;
                conn.Open();
                SqlDataReader objDataReader = objCommand.ExecuteReader();
                ds.Load(objDataReader, LoadOption.OverwriteChanges, dtResult, dtResult1);
            }
            catch (Exception ex)
            {
                objLIB.ErrorLog(ex.ToString(), "Error Occured Lr Order Search");

            }
            finally
            {
                objCommon.BulkPrint = ds;
                conn.Close();
            }
            return;
        }
        public void ExportInvoicePrintReport(CommonReport objCommon)
        {
            SqlConnection conn = new SqlConnection(DataAccess.strCon);
            DataTable dtResult = new DataTable();
            DataTable dtResult1 = new DataTable();
            DataTable dtResult2 = new DataTable();
            DataSet ds = new DataSet();

            ds.Tables.Add(dtResult);
            ds.Tables.Add(dtResult1);
            ds.Tables.Add(dtResult2);
            try
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandTimeout = 5000;
                objCommand.CommandText = "NewExportInvoicePrintReport";
                objCommand.Parameters.Add("@ACTIONTYPE", SqlDbType.VarChar, 20).Value = objCommon.ActionTypess;
                objCommand.Parameters.Add("@Condition1", SqlDbType.VarChar, 20).Value = objCommon.ReqSno;
                //objCommand.Parameters.Add("@TypeofFlag", SqlDbType.VarChar, 20).Value = objCommon.TypeofFlag;

                objCommand.Connection = conn;
                conn.Open();
                SqlDataReader objDataReader = objCommand.ExecuteReader();
                ds.Load(objDataReader, LoadOption.OverwriteChanges, dtResult, dtResult1, dtResult2);
            }

            catch (Exception ex)
            {
                objLIB.ErrorLog(ex.ToString(), "Error Occured Lr Order Search");

            }
            finally
            {
                objCommon.BulkPrintReport = ds;
                conn.Close();
            }
            return;
        }
                public void DBCRInvoicePrintSearch(CommonReport objCommon)
        {
            SqlConnection conn = new SqlConnection(DataAccess.strCon);
            DataTable dtResult = new DataTable();
            DataTable dtResult1 = new DataTable();
            DataSet ds = new DataSet();

            ds.Tables.Add(dtResult);
            ds.Tables.Add(dtResult1);
            try
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandTimeout = 5000;
                objCommand.CommandText = "DBCRInvoiceOrderSearch";
                objCommand.Parameters.Add("@ACTIONTYPE", SqlDbType.VarChar, 20).Value = objCommon.ActionTypess;
                objCommand.Parameters.Add("@Condition1", SqlDbType.VarChar, 20).Value = objCommon.ReqSno;
                // objCommand.Parameters.Add("@TypeofFlag", SqlDbType.VarChar, 20).Value = objCommon.TypeofFlag;

                objCommand.Connection = conn;
                conn.Open();
                SqlDataReader objDataReader = objCommand.ExecuteReader();
                ds.Load(objDataReader, LoadOption.OverwriteChanges, dtResult, dtResult1);
            }
            catch (Exception ex)
            {
                objLIB.ErrorLog(ex.ToString(), "Error Occured Lr Order Search");

            }
            finally
            {
                objCommon.BulkPrint = ds;
                conn.Close();
            }
            return;
        }
        public void DBCRInvoicePrintReport(CommonReport objCommon)
        {
            SqlConnection conn = new SqlConnection(DataAccess.strCon);
            DataTable dtResult = new DataTable();
            DataTable dtResult1 = new DataTable();
            DataTable dtResult2 = new DataTable();
            DataSet ds = new DataSet();

            ds.Tables.Add(dtResult);
            ds.Tables.Add(dtResult1);
            ds.Tables.Add(dtResult2);
            try
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandTimeout = 5000;
                objCommand.CommandText = "NewDBCRInvoicePrintReport";
                objCommand.Parameters.Add("@ACTIONTYPE", SqlDbType.VarChar, 20).Value = objCommon.ActionTypess;
                objCommand.Parameters.Add("@Condition1", SqlDbType.VarChar, 20).Value = objCommon.ReqSno;
                //objCommand.Parameters.Add("@TypeofFlag", SqlDbType.VarChar, 20).Value = objCommon.TypeofFlag;

                objCommand.Connection = conn;
                conn.Open();
                SqlDataReader objDataReader = objCommand.ExecuteReader();
                ds.Load(objDataReader, LoadOption.OverwriteChanges, dtResult, dtResult1, dtResult2);
            }

            catch (Exception ex)
            {
                objLIB.ErrorLog(ex.ToString(), "Error Occured Lr Order Search");

            }
            finally
            {
                objCommon.BulkPrintReport = ds;
                conn.Close();
            }
            return;
        }
    }
}
