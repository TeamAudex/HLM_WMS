using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using POM.Repository;
using System.Data;

namespace POMS.Repository
{
    public class ErrorEventLog
    {
        public static string strErrorLogFile = System.Configuration.ConfigurationManager.ConnectionStrings["ErrorLogFile"].ConnectionString;
        /// <summary>
        /// To Log the Exceptions to the Eventlog
        /// </summary>
        /// <param name="ex">This Exception Details use to write in the Event Log file</param>
        public static void ExceptionToEventLog(Exception ex)
        {
            try
            {
                string Message;

                //Message = ex.TargetSite.ReflectedType.FullName + ":" + ex.TargetSite.Name + ":" + ex.Message;

                Message = "Error Message: " + ex.Message + "\r\n" + ex.StackTrace;

                if (EventLog.Exists("WarehouseErrorLog") == false)
                    EventLog.CreateEventSource("WarehouseErrorLog", "WarehouseErrorLog");

                EventLog.WriteEntry("WarehouseErrorLog", Message, EventLogEntryType.Error);
            }
            catch (Exception exc)
            {
                ErrorLog(exc.ToString());
            }
        }

        /// <summary>
        /// To Write Exception Details to the Log file 
        /// </summary>
        /// <param name="ExceptionDetails">This ExceptionDetails use to write a Errorlog file</param>
        public static void ErrorLog(string ExceptionDetails)
        {
            try
            {
                string FilePath = strErrorLogFile; // ((System.Data.DataRow[])SystemParameters.SystemConfigFetch().Tables[0].Select("code = 'ERRORLOGFILEPATH'"))[0]["UnderlyingValue"].ToString();
                FileInfo f = new FileInfo(FilePath + "\\" + DateTime.Today.GetDateTimeFormats().GetValue(6).ToString().Replace('-', '_') + "_" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".txt");
                FileStream file;

                if (!f.Exists)
                {
                    Directory.CreateDirectory(FilePath);
                    file = f.Open(FileMode.Create, FileAccess.Write);
                }
                else
                    file = f.Open(FileMode.Append, FileAccess.Write);

                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(ExceptionDetails);

                sw.Close();
                file.Close();
            }
            catch (Exception Ex)
            {
            }
        }






        public static void ErrorLog(string ExceptionDetails, string url)
        {
            try
            {
                try
                {
                    SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
                    using (SqlCommand cmd = new SqlCommand("SQLErrLogUpadte", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ScreenName", url);
                        cmd.Parameters.AddWithValue("@ProcedureName", url);
                        cmd.Parameters.AddWithValue("@ActionName", "Error Log From API");
                        cmd.Parameters.AddWithValue("@ErrMessage", ExceptionDetails);
                        cmd.CommandTimeout = 20000;
                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapt.Fill(ds);
                    }
                }
                catch (Exception ex) { }

                string FilePath = strErrorLogFile + "_" + url; // ((System.Data.DataRow[])SystemParameters.SystemConfigFetch().Tables[0].Select("code = 'ERRORLOGFILEPATH'"))[0]["UnderlyingValue"].ToString();
                FileInfo f = new FileInfo(FilePath + "\\" + DateTime.Today.GetDateTimeFormats().GetValue(6).ToString().Replace('-', '_') + "_" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".txt");
                FileStream file;

                if (!f.Exists)
                {
                    Directory.CreateDirectory(FilePath);
                    file = f.Open(FileMode.Create, FileAccess.Write);
                }
                else
                    file = f.Open(FileMode.Append, FileAccess.Write);

                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(ExceptionDetails);

                sw.Close();
                file.Close();
            }
            catch (Exception Ex)
            {
            }
        }

        public static void ErrorLogApi(string ExceptionDetails, string url)
        {
            try
            {  
                string FilePath = strErrorLogFile + "_" + url; // ((System.Data.DataRow[])SystemParameters.SystemConfigFetch().Tables[0].Select("code = 'ERRORLOGFILEPATH'"))[0]["UnderlyingValue"].ToString();
                FileInfo f = new FileInfo(FilePath + "\\" + DateTime.Today.GetDateTimeFormats().GetValue(6).ToString().Replace('-', '_') + "_" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".txt");
                FileStream file;

                if (!f.Exists)
                {
                    Directory.CreateDirectory(FilePath);
                    file = f.Open(FileMode.Create, FileAccess.Write);
                }
                else
                    file = f.Open(FileMode.Append, FileAccess.Write);

                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(ExceptionDetails);

                sw.Close();
                file.Close();
            }
            catch (Exception Ex)
            {
            }
        }

        public static void ReqResErrorLog(int? VendorSno, string APIName, string filename, string LRNo)
        {

            try
            {
                SqlConnection conn = DBConnectionHelper.OpenNewSqlConnection(DBConnection.CONNECTION_STRING);
                using (SqlCommand cmd = new SqlCommand("Insert_APIRequestResponseLog", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VendorSno", VendorSno);
                    cmd.Parameters.AddWithValue("@APIName", APIName);
                    cmd.Parameters.AddWithValue("@LogFileName", filename);
                    cmd.Parameters.AddWithValue("@LRNo", LRNo);
                    cmd.CommandTimeout = 20000;
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                }
            }
            catch (Exception ex) { }




        }
    }
}

