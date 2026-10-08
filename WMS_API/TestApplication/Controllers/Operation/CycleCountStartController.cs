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
using System.Web.Mvc;

using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Reporting.WebForms;

using System.Net.Http.Headers;


namespace TestApplication.Controllers.Operation
{
    [System.Web.Http.RoutePrefix("Api/CycleCountStart")]
    public class CycleCountStartController : ApiController
    {
        string strConnention = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        string storagePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "\\ItemPriceDetails";
        CycleCountStartRepository _repository = new CycleCountStartRepository();

        string FileName = "";
        string ErrorMsg = "";
        string Location = "";
        string Serviceable = "";

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CCInsert")]

        public string CCInsert(CycleCountStart Request)
        {
            //CycleCountStart objItemPriceList = new CycleCountStart();
            //objItemPriceList.DocumentFilename = Request.DocumentFilename;
            //objItemPriceList.IPNumber = Request.IPNumber;
            //objItemPriceList.Sts = Request.Sts;
            //objItemPriceList.Creopr = Request.Creopr;
            return _repository.Insert(Request);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Edit")]
        public string Edit(int CycleCountSno)
        {
            return _repository.Edit(CycleCountSno);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Edit1")]
        public string Edit1(int CycleCountSno)
        {
            return _repository.Edit1(CycleCountSno);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ExportPhysicalCycleCounDetails")]
        public bool ExportPhysicalCycleCounDetails(int CycleCountSno)
        {
            var context = System.Web.HttpContext.Current;


            context.Cache["CycleCountSno"] = CycleCountSno;
            if (context != null)
            {
                return true;
            }
            return false;
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Search")]

        public Tuple<List<CycleCountStart>, int> Search(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _repository.Search(pageRequest);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("CCStartDate")]

        public string CCStartDate(int CycleCountSno)
        {
            return _repository.StartDate(CycleCountSno);
        }


        [System.Web.Http.Route("GetFile")]
        [System.Web.Http.HttpGet]

        public HttpResponseMessage GetFile(int CycleCountSno)
        {
            HttpResponseMessage result = null;

            DataTable dtBulk = null;
            DataTable dt = null;
            ReportViewer rptvInvoice = new ReportViewer();
            DataSet ds = new DataSet();





            dtBulk = new DataTable();
            dt = new DataTable();





            string FilePath;
            FilePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "//CycleCountPhysical" + "//" + DateTime.Now.ToString("dd-MM-yyyy") + "//";
            string FileName = "CycleCountPhysical_" + Guid.NewGuid().ToString();







            if (CycleCountSno > 0)
            {
                PdfCopy pdfCopyProvider = null;

                Document sourceDocument = null;
                sourceDocument = new Document();



                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                // Initialize an instance of the PdfCopyClass with the source 
                // document and an output file stream:
                pdfCopyProvider = new PdfCopy(sourceDocument,
                    new System.IO.FileStream(FilePath + FileName + ".pdf", System.IO.FileMode.Create));
                sourceDocument.Open();





                //for (int k = 0; k < dtBulk.Rows.Count; k++)
                //{


                ds = _repository.GetPDF(CycleCountSno);



                rptvInvoice.ProcessingMode = ProcessingMode.Local;
                LocalReport rep = rptvInvoice.LocalReport;


                rep.ReportPath = "Reports\\Design\\CycleCountPhysical.rdlc";





                rep.EnableExternalImages = false;

                ReportDataSource rdsInvoice = new ReportDataSource();
                rdsInvoice.Name = "DataSet1";
                rdsInvoice.Value = ds.Tables[0];

                ReportDataSource rdsInvoice1 = new ReportDataSource();
                rdsInvoice1.Name = "DataSet2";
                rdsInvoice1.Value = ds.Tables[1];


                rep.DataSources.Clear();
                rep.DataSources.Add(rdsInvoice);
                rep.DataSources.Add(rdsInvoice1);


                try
                {
                    Microsoft.Reporting.WebForms.Warning[] warnings = null;
                    string[] streamids = null;
                    String mimeType = null;
                    String encoding = null;
                    String extension = null;
                    Byte[] bytes = null;

                    string FileName1 = "CycleCountPhysical_" + Guid.NewGuid().ToString();

                    string[] arCopyPisitions = { "Original", "Duplicate" };


                    PdfCopy pdfCopyProviderTrplicator = null;
                    Document sourceDocumentTrplicator = null;
                    sourceDocumentTrplicator = new Document();
                    pdfCopyProviderTrplicator = new PdfCopy(sourceDocumentTrplicator,
                    new System.IO.FileStream(FilePath + FileName1 + ".pdf", System.IO.FileMode.Create));


                    //for (int copypos = 0; arCopyPisitions.Length > copypos; copypos++)
                    //{
                    sourceDocumentTrplicator.Open();
                    //  ReportParameter[] p = new ReportParameter[1];

                    //p.SetValue(new ReportParameter("Types", arCopyPisitions[copypos]), 0);

                    //rptvInvoice.LocalReport.SetParameters(p);

                    bytes = rptvInvoice.LocalReport.Render("PDF", "", out mimeType, out encoding, out extension, out streamids, out warnings);
                    string value = "A";
                    // Split the string on line breaks.

                    string[] lines = value.Split('-');
                    string idd = Guid.NewGuid().ToString();
                    FileInfo f = new FileInfo(FilePath + "CycleCountPhysicalCopy\\" + idd);
                    if (!new DirectoryInfo(f.DirectoryName).Exists)
                    {
                        Directory.CreateDirectory(f.DirectoryName);
                    }
                    if (System.IO.File.Exists(f.FullName)) System.IO.File.Delete(f.FullName);


                    FileStream fs = new FileStream(FilePath + "CycleCountPhysicalCopy\\" + idd, FileMode.OpenOrCreate);
                    byte[] data = new byte[fs.Length];
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();

                    PdfReader readerforcopy = null;
                    PdfImportedPage importedPageForCopy = null;



                    try
                    {


                        // Intialize a new PdfReader instance with the contents of the source Pdf file:
                        readerforcopy = new PdfReader(FilePath + "CycleCountPhysicalCopy\\" + idd);
                        int numberOfPages = readerforcopy.NumberOfPages;

                        for (int i = 1; i <= numberOfPages; i++)
                        {
                            importedPageForCopy = pdfCopyProviderTrplicator.GetImportedPage(readerforcopy, i);
                            pdfCopyProviderTrplicator.AddPage(importedPageForCopy);
                        }




                        readerforcopy.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    // }

                    sourceDocumentTrplicator.Close();

                    if (System.IO.Directory.Exists(FilePath + "CycleCountPhysicalCopy\\")) System.IO.Directory.Delete(FilePath + "CycleCountPhysicalCopy\\", true);


                    System.IO.FileInfo file = new System.IO.FileInfo(FilePath + FileName + ".pdf");

                    PdfReader reader = null;


                    PdfImportedPage importedPage = null;
                    PdfImportedPage importedPage1 = null;
                    try
                    {
                        // Intialize a new PdfReader instance with the contents of the source Pdf file:
                        reader = new PdfReader(FilePath + FileName1 + ".pdf");
                        PdfReader pdfReader = new PdfReader(FilePath + FileName1 + ".pdf");

                        int numberOfPages = pdfReader.NumberOfPages;

                        for (int i = 1; i <= numberOfPages; i++)
                        {
                            importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                            pdfCopyProvider.AddPage(importedPage);




                        }






                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                }
                catch (Exception ex)
                {

                    throw;
                }


                // }





                sourceDocument.Close();
                rptvInvoice.Visible = false;

                System.IO.FileInfo file1 = new System.IO.FileInfo(System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "//CycleCountPhysical" + "//" + DateTime.Now.ToString("dd-MM-yyyy") + "//" + FileName + ".pdf");

                if (file1.Exists)
                {
                    var info = System.IO.File.GetAttributes(file1.FullName);
                    result = Request.CreateResponse(HttpStatusCode.OK);
                    result.Content = new StreamContent(new FileStream(file1.FullName, FileMode.Open, FileAccess.Read));
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    result.Content.Headers.Add("x-filename", FileName + ".pdf");
                    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                    result.Content.Headers.ContentDisposition.FileName = FileName + ".pdf";




                }



            }
            return result;

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("CycleCountFetch")]
        public async Task<HttpResponseMessage> CycleCountStartFetch()
        {

            CycleCountStart objPriOE = new CycleCountStart();

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
                objPriOE = model.JsonToObject<CycleCountStart>();
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
                        cmd.CommandText = "CycleCountPhysical_Fetch";
                        cmd.Connection = conn;
                        // cmd.Parameters.AddWithValue("@EntryDate", objPriOE.EntryDate);
                        cmd.Parameters.AddWithValue("@FilePath", Location);
                        cmd.Parameters.AddWithValue("@EXCELTYPE", dtExcel);
                        cmd.Parameters.AddWithValue("@CycleCountSno", objPriOE.CycleCountSno);

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


                        objPriOE.CycleCountUPLOADDisplay = ds.Tables[0].ToCollection<CycleCountUPLOADDisplay>().ToList();

                        objPriOE.LineColumn = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                        objPriOE.DocumentFilename = ds.Tables[1].Rows[0][1].ToString();


                        objPriOE.CycleCountInsert = ds.Tables[2].ToCollection<CycleCountInsert>().ToList();




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

            return Request.CreateResponse<CycleCountStart>(HttpStatusCode.OK, objPriOE);

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