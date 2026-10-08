using Entity.Masters;
using Librarys.Extenders;
using Librarys.Logging;
using Newtonsoft.Json;
using POMS.Entity;
using Repository.Masters;
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
using System.Web.Mvc;

namespace TestApplication.Controllers.Masters
{
    [System.Web.Http.RoutePrefix("Api/StorageTypeID")]
    public class StorageTypeIDController : ApiController
    {
        string strConnention = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        string storagePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "\\StorageTypeID";

        StorageTypeIDRepository _Repository = new StorageTypeIDRepository();

        string FileName;
        string ErrorMsg;
        string Location;
        string Serviceable;

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Insert")]
        public async Task<HttpResponseMessage> Insert()
        {
            StorageTypeIDResult ObjResult = new StorageTypeIDResult();

            StorageTypeIDList ObjSave = new StorageTypeIDList();

            string Dateformat = string.Empty;
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (!Request.Content.IsMimeMultipartContent())
                {
                    this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
                }

                var date = DateTime.Now.ToString("dd-MM-yyyy");
                storagePath = storagePath + date;

                if (!Directory.Exists(storagePath))
                {
                    Directory.CreateDirectory(storagePath);
                }

                var provider = new MultipartFormDataStreamProvider(storagePath);
                MultipartFormDataStreamProvider mfdr = null;

                try
                {
                    mfdr = await Request.Content.ReadAsMultipartAsync(provider);
                }
                catch (Exception ex)
                {
                    ObjResult.Result = ex.Message.ToString();
                }

                if (mfdr.FormData["model"] == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                try
                {
                    var model = mfdr.FormData["model"];
                    ObjSave = new StorageTypeIDList();
                    ObjSave = model.JsonToObject<StorageTypeIDList>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (mfdr.FileData.Count > 0)
                {
                    int i = 0;
                    Dictionary<string, string> lstFile = new Dictionary<string, string>();
                    InternalFileUpload1(mfdr, storagePath, ref i, ref lstFile);

                    int filePos = 0, fileIndex = 0;

                    foreach (KeyValuePair<string, string> kvp in lstFile)
                    {
                        filePos = Convert.ToInt16(kvp.Key.Split('_')[1]);
                        if (filePos == 0)
                        {
                            ObjSave.StorageTypeID.FileUpload = storagePath + '\\' + kvp.Value;
                        }
                    }
                }
                else
                {

                }
                ObjResult = _Repository.Insert(ObjSave);
            }
            catch (Exception ex)
            {
                ObjResult.Result = ex.Message.ToString();
            }
            return Request.CreateResponse<StorageTypeIDResult>(HttpStatusCode.OK, ObjResult); ;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Search")]
        public Tuple<List<StorageTypeIDSearch>, int> Search(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _Repository.Search(pageRequest);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Edit")]
        public StorageTypeIDList Edit(int StorageTypeIDSno)
        {
            return _Repository.Edit(StorageTypeIDSno);
        }

        //--------------------------------------------StorageTypeID Upload-----------------------------------------------


        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("StorageTypeIDFetch")]
        public async Task<HttpResponseMessage> AssertToAuditorFetch()
        {

            UploadStorageTypeIDList objPriOE = new UploadStorageTypeIDList();

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


                    using (SqlConnection conn = new SqlConnection(strConnention))
                    {
                        SqlCommand cmd = new SqlCommand();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "StorageTypeIDUpload_Fetch";
                        cmd.Connection = conn;
                        // cmd.Parameters.AddWithValue("@EntryDate", objPriOE.EntryDate);
                        cmd.Parameters.AddWithValue("@FilePath", Location);
                        cmd.Parameters.AddWithValue("@EXCELTYPE", dtExcel);

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();

                        DataSet ds = new DataSet();
                        DataTable dtl = new DataTable();
                        ds.Tables.Add(dtl);
                        DataTable dt2 = new DataTable();
                        ds.Tables.Add(dt2);
                        DataTable dt3 = new DataTable();
                        ds.Tables.Add(dt3);

                        ds.Load(dataReader, LoadOption.OverwriteChanges, dtl, dt2, dt3);

                        objPriOE.StorageTypeIDUploadDisplay = ds.Tables[0].ToCollection<StorageTypeIDDet>().ToList();
                        objPriOE.LineColumn = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                        objPriOE.DocumentFilename = ds.Tables[1].Rows[0][1].ToString();
                        objPriOE.StorageTypeIDUploadInsert = ds.Tables[2].ToCollection<StorageTypeIDDet>().ToList();

                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //objPriOE.Err = true;
                //objPriOE.ErrMsg = ex.Message;
                Librarys.Logging.Logger.For(this).Error(ex);
            }
            return Request.CreateResponse<UploadStorageTypeIDList>(HttpStatusCode.OK, objPriOE);

        }

        public void InternalFileUpload1(MultipartFormDataStreamProvider mfdr, string storagePath, ref int i, ref Dictionary<string, string> strFiles)
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
                fileName = string.Format("{0}{1}{2}", Guid.NewGuid().ToString(), "-", fileName);
                try
                {
                    File.Move(file.LocalFileName, Path.Combine(storagePath, fileName));
                    string fileNo = file.Headers.ContentDisposition.Name.Replace("\"", "").Trim();
                    strFiles.Add(fileNo, new FileInfo(fileName).Name);
                    i += 1;
                }
                catch (Exception ex)
                {
                    Logger.For(this).Error(ex);
                }
            }
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