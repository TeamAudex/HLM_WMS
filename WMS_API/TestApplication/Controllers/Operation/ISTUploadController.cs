using Entity.Operations;
using Librarys.Extenders;
using Librarys.Logging;
using POMS.Entity;
using Repository.Operations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace TestApplication.Controllers.Operation
{
    [RoutePrefix("Api/ISTUpload")]
    public class ISTUploadController : ApiController
    {
        ISTUploadRepository _repository = new ISTUploadRepository();
       
        string strConnention = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        string storagePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "\\ISTUpload\\";
        string FileName = "";
        string ErrorMsg = "";
        string Location = "";
  

        [HttpPost]
        [Route("Insert")]

        public STResponse Insert(ISTUploadList objISTUploadList)
        {     
            return _repository.Insert(objISTUploadList);
        }

        [HttpPost]
        [ActionName("Fetch")]
        public async Task<HttpResponseMessage> Fetch()
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
          //  string time = DateTime.Now.ToString("HH:mm:ss");
         //   time = time.Replace(":","_");
            ISTUploadList objPriOE = new ISTUploadList();
            storagePath = storagePath + date;
            if (!Directory.Exists(storagePath))
            {
                Directory.CreateDirectory(storagePath);
            }
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
                }
                var provider = new MultipartFormDataStreamProvider(storagePath);
                MultipartFormDataStreamProvider mfdr = null;
                try
                {
                    mfdr = await Request.Content.ReadAsMultipartAsync(provider);
                }
                catch (Exception ex)
                {

                }
                if (mfdr.FormData["model"] == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                var model = mfdr.FormData["model"];
                objPriOE.objISTUpload = model.JsonToObject<ISTUpload>();
                if (mfdr.FileData.Count > 0)
                {

                    FileName = mfdr.FileData[0].Headers.ContentDisposition.FileName.ToString();


                    int i = 0;
                    string filePath = "";
                    Dictionary<int, string> lstFile = new Dictionary<int, string>();
                    InternalFileUpload(mfdr, storagePath, ref i, ref lstFile);
                    foreach (KeyValuePair<int, string> kvp in lstFile)
                    {
                        //objPriOE.ItemPrice.DocumentFilename = kvp.Value;
                        Location = storagePath + '\\' + kvp.Value;
                        filePath = kvp.Value;
                    }

                    //Location = storagePath + '\\' + objPriOE.ItemPrice.DocumentFilename;
                    //SFTPMethod(storagePath, objPriOE.DocumentFilename);
                    //string filePath = objPriOE.ItemPrice.DocumentFilename;

                    DataTable dtExcel = ReadExcelData(filePath);
                    DataTable dtIST = new DataTable();
                    dtIST.Columns.Add("ItemName");
                    dtIST.Columns.Add("BatchNo");
                    dtIST.Columns.Add("UOM");
                    dtIST.Columns.Add("ToQty");
                    dtIST.Columns.Add("ToItemName");
                    dtIST.Columns.Add("ToBatchNo");
                    dtIST.Columns.Add("ToExpDate");
                    //Capture the CURRENT size of the DataTable
                    int dtsize = dtExcel.Columns.Count;
                    string TypeFlag = objPriOE.objISTUpload.TypeFlag;
                    bool ErrSts = false;

                    if (TypeFlag=="311")
                    {
                        if (dtsize == 4)
                        {
                            for (int k = 0; k < dtExcel.Rows.Count; k++)
                            {
                                DataRow dr;
                                dr = dtIST.NewRow();
                                dr["ItemName"] = dtExcel.Rows[k]["Item_Code"];
                                dr["BatchNo"] = dtExcel.Rows[k]["Batch_No"];
                                dr["UOM"] = dtExcel.Rows[k]["UOM"];
                                dr["ToQty"] = dtExcel.Rows[k]["Transfer_Qty"];
                                dr["ToItemName"] = "";
                                dr["ToBatchNo"] = "";
                                dr["ToExpDate"] = "";
                                dtIST.Rows.Add(dr);
                            }
                        }
                        else
                        {
                            ErrSts = true;
                        }
                     
                    }

                    if (TypeFlag == "310")
                    {
                        if (dtsize == 6)
                        {
                            for (int k = 0; k < dtExcel.Rows.Count; k++)
                            {
                                DataRow dr;
                                dr = dtIST.NewRow();
                                dr["ItemName"] = dtExcel.Rows[k]["Item_Code"];
                                dr["BatchNo"] = dtExcel.Rows[k]["Batch_No"];
                                dr["UOM"] = dtExcel.Rows[k]["UOM"];
                                dr["ToQty"] = dtExcel.Rows[k]["Transfer_Qty"];
                                dr["ToItemName"] = "";
                                dr["ToBatchNo"] = dtExcel.Rows[k]["To_Batch_No"];
                                dr["ToExpDate"] = dtExcel.Rows[k]["To_Exp_Date"];
                                dtIST.Rows.Add(dr);
                            }
                        }
                        else
                        {
                            ErrSts = true;
                        }
                    }

                    if (TypeFlag == "309")
                    {
                        if (dtsize == 7)
                        {
                            for (int k = 0; k < dtExcel.Rows.Count; k++)
                            {
                                DataRow dr;
                                dr = dtIST.NewRow();
                                dr["ItemName"] = dtExcel.Rows[k]["Item_Code"];
                                dr["BatchNo"] = dtExcel.Rows[k]["Batch_No"];
                                dr["UOM"] = dtExcel.Rows[k]["UOM"];
                                dr["ToQty"] = dtExcel.Rows[k]["Transfer_Qty"];
                                dr["ToItemName"] = dtExcel.Rows[k]["To_Item_Code"];
                                dr["ToBatchNo"] = dtExcel.Rows[k]["To_Batch_No"];
                                dr["ToExpDate"] = dtExcel.Rows[k]["To_Exp_Date"]; 
                                dtIST.Rows.Add(dr);
                            }
                        }
                        else
                        {
                            ErrSts = true;
                        }
                    }

                    if (ErrSts == false)
                    {
                        using (SqlConnection conn = new SqlConnection(strConnention))
                        {

                            SqlCommand cmd = new SqlCommand();


                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "USP_IST_UPLOAD_FETCH";
                            cmd.Connection = conn;
                            cmd.Parameters.AddWithValue("@TransferDate", objPriOE.objISTUpload.TransferDate);
                            cmd.Parameters.AddWithValue("@TypeFlag", objPriOE.objISTUpload.TypeFlag);
                            cmd.Parameters.AddWithValue("@WarehouseSno", objPriOE.objISTUpload.WarehouseSno);
                            cmd.Parameters.AddWithValue("@MovementTypeSno", objPriOE.objISTUpload.MovementTypeSno);
                            cmd.Parameters.AddWithValue("@TypeofStockSno", objPriOE.objISTUpload.TypeofStockSno);
                            cmd.Parameters.AddWithValue("@EmployeeSno", objPriOE.objISTUpload.EmployeeSno);
                            cmd.Parameters.AddWithValue("@Remarks", objPriOE.objISTUpload.Remarks);
                            cmd.Parameters.AddWithValue("@FilePath", Location);
                            cmd.Parameters.AddWithValue("@ISTDetails", dtIST);


                            conn.Open();
                            SqlDataReader dataReader = cmd.ExecuteReader();


                            DataSet ds = new DataSet();
                            DataTable dtl = new DataTable();
                            ds.Tables.Add(dtl);
                            //DataTable dt2 = new DataTable();
                            //ds.Tables.Add(dt2);
                            //DataTable dt3 = new DataTable();
                            //ds.Tables.Add(dt3);


                            ds.Load(dataReader, LoadOption.OverwriteChanges, dtl);


                            objPriOE.objISTUploadDisplay = ds.Tables[0].ToCollection<ISTUploadDisplay>().ToList();
                            objPriOE.objISTUploadDet = ds.Tables[0].ToCollection<ISTUploadDet>().ToList();

                            objPriOE.objISTUpload.UploadFileName = Location;
                            if (objPriOE.objISTUploadDisplay.Count > 0)
                            {
                                objPriOE.objISTUpload.Error = objPriOE.objISTUploadDisplay[0].Error;
                            }
                            else
                            {
                                objPriOE.objISTUpload.Error = false;
                            }





                            conn.Close();



                        }
                    }

                    else
                    {
                        objPriOE.objISTUpload.ErrSts = true;
                        objPriOE.objISTUpload.ErrMsg = "Invalid Excel Format for "+ objPriOE.objISTUpload.MovementType;
                    }
                  

                }
            }


            catch (Exception ex)
            {
                //objPriOE.Err = true;
                //objPriOE.ErrMsg = ex.Message;
                Librarys.Logging.Logger.For(this).Error(ex);
            }

            return Request.CreateResponse<ISTUploadList>(HttpStatusCode.OK, objPriOE);

        }

        public void InternalFileUpload(MultipartFormDataStreamProvider mfdr, string storagePath, ref int i, ref Dictionary<int, string> strFiles)
        {
            i = 0;

            foreach (var file in mfdr.FileData)
            {
                string fileName = file.Headers.ContentDisposition.FileName;

                if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                {
                    fileName = fileName.Trim('"');
                }
                if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                {
                    fileName = Path.GetFileName(fileName);
                }

                string Datetime = DateTime.Now.ToString("hh:mm:ss").Replace(":", "");

                fileName = string.Format("{0}{1}{2}", Datetime, "-", fileName); //"{0}{1}{2}", Guid.NewGuid().ToString(), "-", 
                try
                {
                    File.Move(file.LocalFileName, Path.Combine(storagePath, fileName));
                    strFiles.Add(Convert.ToInt16(file.Headers.ContentDisposition.Name.Replace("file", "").Replace("\"", "").Trim()), new FileInfo(fileName).Name);
                    i += 1;
                }
                catch (Exception ex)
                {
                    Logger.For(this).Error(ex);
                    string Ermsg = ex.Message.ToString();
                    if (ex.Message.ToString() == Ermsg)
                    {
                        ErrorMsg = Ermsg;
                    }
                }
            }
        }


        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        public DataTable ReadExcelData(string filePath)
        {

            DataTable dtExcelRecords = new DataTable();
            string connectionString = string.Empty;

            OleDbConnection con = new OleDbConnection();
            try
            {
                string fileLocation = storagePath + "\\" + filePath;
                string path = fileLocation;

                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + path + "; Extended Properties=Excel 12.0;";

                con.ConnectionString = connectionString;
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
                DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                dAdapter.SelectCommand = cmd;
                dAdapter.Fill(dtExcelRecords);
                con.Close();

                if (dtExcelRecords.Rows.Count > 0)
                {
                    foreach (DataColumn dc in dtExcelRecords.Columns)
                    {
                        dtExcelRecords.Columns[dc.ColumnName].ColumnName = AddOnFeildsinExcelColumn(dc.ColumnName).ToString();
                    }
                }

            }
            catch (OleDbException ex)
            {

            }
            catch (Exception ex)
            {
                Librarys.Logging.Logger.For(this).Error(ex);
            }
            finally
            {
                con.Close();
            }

            return dtExcelRecords;
        }

        private string AddOnFeildsinExcelColumn(string str)
        {
            str = (str.Trim().Contains("(DD-MM-YYYY)") == true ? str.Trim().Replace("(DD-MM-YYYY)", "") : str);
            str = (str.Trim().Contains("(MM-DD-YYYY)") == true ? str.Trim().Replace("(MM-DD-YYYY)", "") : str);
            str = (str.Trim().Contains("(MM/DD/YYYY)") == true ? str.Trim().Replace("(MM/DD/YYYY)", "") : str);
            str = (str.Trim().Contains("(DD/MM/YYYY)") == true ? str.Trim().Replace("(DD/MM/YYYY)", "") : str);
            str = (str.Trim().Contains("(HH:MM:SS)") == true ? str.Trim().Replace("(HH:MM:SS)", "") : str);
            str = (str.Trim().Contains("(KGS)") == true ? str.Trim().Replace("(KGS)", "") : str);
            str = (str.Trim().Contains("(IN KG)") == true ? str.Trim().Replace("(IN KG)", "") : str);
            str = (str.Trim().Contains("(IN WORDS)") == true ? str.Trim().Replace("(IN WORDS)", "") : str);
            str = (str.Trim().Contains("(INR)") == true ? str.Trim().Replace("(INR)", "") : str);
            str = (str.Trim().Contains("(Y/N)") == true ? str.Trim().Replace("(Y/N)", "").Trim() : str);
            str = (str.Trim().Contains("(Kg)") == true ? str.Trim().Replace("(Kg)", "") : str);
            str = (str.Trim().Contains("(cbm)") == true ? str.Trim().Replace("(cbm)", "") : str);

            str = (str.Trim().Contains("(Road/Rail/Air/Ship)") == true ? str.Trim().Replace("(Road/Rail/Air/Ship)", "") : str);
            str = (str.Trim().Contains("(Km)") == true ? str.Trim().Replace("(Km)", "") : str);
            str = (str.Trim().Contains("to/from SEZ unit?") == true ? str.Trim().Replace("to/from SEZ unit?", "") : str);

            str = (str.Contains('.') == true ? (((str.Length - 1) == str.IndexOf('.')) ? str.Replace(".", string.Empty) : str.Replace('.', '_')) : str);

            str = (str.Contains('&') == true ? (((str.Length - 1) == str.IndexOf('&')) ? str.Replace("&", string.Empty) : str.Replace('&', '@')) : str);
            str = (str.Contains('-') == true ? (((str.Length - 1) == str.IndexOf('-')) ? str.Replace("-", string.Empty) : str.Replace('-', '_')) : str);
            str = (str.Contains('/') == true ? (((str.Length - 1) == str.IndexOf('/')) ? str.Replace("/", string.Empty) : str.Replace('/', '_')) : str);
            str = (str.Contains('/') == true ? (((str.Length - 1) == str.IndexOf('/')) ? str.Replace("/", string.Empty) : str.Replace("/", string.Empty)) : str);

            str = (str.Contains(',') == true ? (((str.Length - 1) == str.IndexOf(',')) ? str.Replace(",", string.Empty) : str.Replace(',', '_')) : str);
            str = (str.Contains('*') == true ? (((str.Length - 1) == str.IndexOf('*')) ? str.Replace("*", string.Empty) : str.Replace('*', '_')) : str);
            str = (str.Contains("'") == true ? (((str.Length - 1) == str.IndexOf("'")) ? str.Replace("'", string.Empty) : str.Replace("'", string.Empty)) : str);
            str = (str.Contains('(') == true ? (((str.Length - 1) == str.IndexOf('(')) ? str.Replace("(", string.Empty) : str.Replace('(', '_')) : str);
            str = (str.Contains(')') == true ? (((str.Length - 1) == str.IndexOf(')')) ? str.Replace(")", string.Empty) : str.Replace(')', '_')) : str);

            str = (str.Trim().Contains(" ") == true ? str.Trim().Replace(" ", "_") : str);
            str = (str.Trim().Contains(".") == true ? str.Trim().Replace(".", "#") : str);
            str = (str.Trim().Contains("+") == true ? str.Trim().Replace("+", "#") : str);
            str = (str.Trim().Contains("/") == true ? str.Trim().Replace("/", "_") : str);
            str = (str.Trim().Contains("__") == true ? str.Trim().Replace("__", "_") : str);
            str = (str.Trim().Contains("__") == true ? str.Trim().Replace("__", "_") : str);
            return str;
        }

        public static class loadsetting
        {
            public static double Interval = 90000;
            public static string ServiceName = "";
            public static string connectionString = "";
            public static string DistanceUrl = "";
            public static string SFTPURL = "";
            public static string SFTPServerPath = "";
            public static string InvLogFile = "";
            public static string SFTPUserName = "";
            public static string SFTPPassword = "";
            public static string sourcePath = "";
            public static string TargetPath = "";
            public static string MissingFilePath = "";
            public static string SendInvErrFile = "";
            public static string ErrorPath = "";
            public static string FTPLocalPath = "";
            public static string ServerName = "103.231.125.32";
            public static string SFTPHostName = "";

            public static string FTPUserName = "Aud_ftp";
            public static string FTPPassword = "P@ssw0rd@123";
            public static string FTPURL = "ftp://103.231.125.32/DATA/FTPData/";
            public static string FTPServerPath = "C:/UploadFiles/Healthium/HealthiumOtherChargesUpload/";


        }

        public void SFTPMethod(string storagePath, string DocumentFilename)
        {

            //FTP Process

            using (WebClient client = new WebClient())
            {
                // FileInfo[] files = new DirectoryInfo(storagePath).GetFiles("*.xlsx*");

                //foreach (FileInfo file1 in files)
                //{
                //FileInfo[] files = new DirectoryInfo(storagePath).GetFiles("*.xlsx*");

                string name = DocumentFilename;
                string file = storagePath + '\\' + DocumentFilename;
                string path = "";

                try
                {

                    if (loadsetting.ServerName == "103.231.125.32")
                    {
                        client.Credentials = new NetworkCredential(loadsetting.FTPUserName, loadsetting.FTPPassword);
                        client.UploadFile(loadsetting.FTPURL + name, file);
                        path = loadsetting.FTPServerPath;
                    }
                    // else
                    // {
                    //     FirstMoveFile(file1, loadsetting.FTPLocalPath);
                    //     path = loadsetting.FTPLocalPath;
                    // }
                    //string FilePath1 = path + name;
                    // FileName = name;
                    DataTable dt1 = new DataTable();
                    dt1 = ReadExcelData(path);
                }
                catch (Exception Ex)
                {
                    Ex.Message.ToString();

                }


                ////FileInfo files1 = new FileInfo(file1.FullName);
                //FileInfo files1 = new FileInfo(loadsetting.sourcePath + "\\" + name);

                //    MoveFile(files1, loadsetting.TargetPath);
                //    using (System.IO.StreamWriter Successfile = new System.IO.StreamWriter(loadsetting.InvLogFile, true))
                //    {
                //        Successfile.WriteLine(FileName + " File Generated in " + loadsetting.TargetPath + " at " + DateTime.Now.ToString());
                //    }


            }


        }

        public void MoveFile(FileInfo file, string targetFolderName)
        {
            try
            {
                DirectoryInfo dirinfo = new DirectoryInfo(targetFolderName);


                if (!dirinfo.Exists)
                {
                    dirinfo.Create();
                }
                else
                {
                    file.MoveTo(targetFolderName + "\\" + file.Name.Replace(file.Extension, "") + file.Extension); // +"_" + date //Guid.NewGuid()
                }



            }
            catch (Exception ex)
            {
                ex.Message.ToString();

            }
        }



        public void FirstMoveFile(FileInfo file, string targetFolderName)
        {
            try
            {
                DirectoryInfo dirinfo = new DirectoryInfo(targetFolderName);
                if (!dirinfo.Exists)
                {
                    dirinfo.Create();
                }
                file.CopyTo(targetFolderName + "\\" + file.Name.Replace(file.Extension, "") + file.Extension);

            }
            catch (Exception ex)
            {

            }
        }

    }
}
