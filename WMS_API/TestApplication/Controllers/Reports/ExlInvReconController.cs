using Librarys.Extenders;
using Librarys.Logging;
using POM.Entity;
using POMS.Entity;
using POMS.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace TestApplication.Controllers
{
    [RoutePrefix("Api/ExlInvRecon")]

    public class ExlInvReconController : ApiController
    {

        string storagePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "\\InvoiceUpload";
        ExlInvReconRepository _repository = new ExlInvReconRepository();

        string FileName;
        string ErrorMsg;

        [HttpPost]
        [Route("Upload_InsertApi")]
        public string Upload_InsertApi(ExlInvReconBoth ApiUpload)
        {
            ExlInvReconciliation objPriOE = new ExlInvReconciliation();
            objPriOE.DocumentFilename = ApiUpload.ParentClass.DocumentFilename;
            ApiUpload.ExlInvReconciliationDet = GetPriOEUploadDet(objPriOE);

            return _repository.Upload_Insert(ApiUpload);
        }


        [HttpPost]
        [ActionName("UploadSearch")]
        public async Task<HttpResponseMessage> UploadSearch()
        {

            ExlInvReconciliation objPriOE = new ExlInvReconciliation();
            objPriOE.Err = false;
            objPriOE.ExlInvReconciliationDet = new List<ExlInvReconciliationDet>();
            objPriOE.DocumentFilename = "";
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
                if (mfdr.FormData["InvStsSno"] == null || mfdr.FormData["InvStsSno"] =="undefined")
                {
                    //throw new HttpResponseException(HttpStatusCode.BadRequest);
                    objPriOE.InvStsSno = 0;
                }
                else
                {
                    //objPriOE.InvStsSno = 0;
                    objPriOE.InvStsSno = Convert.ToInt16(mfdr.FormData["InvStsSno"]);
                }
                //objPriOE.InvStsSno = Convert.ToInt16(mfdr.FormData["InvStsSno"]);
                if (mfdr.FormData["BusinessUnitSno"] == null || mfdr.FormData["BusinessUnitSno"] == "undefined")
                {
                    //throw new HttpResponseException(HttpStatusCode.BadRequest);
                    objPriOE.BusinessUnitSno = 0;
                }
                else
                {
                    //objPriOE.BusinessUnitSno = 0;
                    objPriOE.BusinessUnitSno = Convert.ToInt16(mfdr.FormData["BusinessUnitSno"]);
                }
                //objPriOE.BusinessUnitSno = Convert.ToInt16(mfdr.FormData["BusinessUnitSno"]);
                if (mfdr.FormData["BranchSno"] == null || mfdr.FormData["BranchSno"] == "undefined")
                {
                    //throw new HttpResponseException(HttpStatusCode.BadRequest);
                    objPriOE.BranchSno = 0;
                }
                else
                {
                    //objPriOE.BranchSno = 0;
                    objPriOE.BranchSno = Convert.ToInt16(mfdr.FormData["BranchSno"]);
                }
                //objPriOE.BranchSno = Convert.ToInt16(mfdr.FormData["BranchSno"]);
                if (mfdr.FormData["FromDate"] == mfdr.FormData["FromDate"])
                {
                    //throw new HttpResponseException(HttpStatusCode.BadRequest);
                    objPriOE.FromDate = "";
                }
                else
                {
                    objPriOE.FromDate = mfdr.FormData["FromDate"];
                }
                //objPriOE.FromDate = mfdr.FormData["FromDate"];

                if (mfdr.FormData["ToDate"] == mfdr.FormData["ToDate"])
                {
                    //throw new HttpResponseException(HttpStatusCode.BadRequest);
                    objPriOE.ToDate = "";
                }
                else
                {
                    objPriOE.ToDate = mfdr.FormData["ToDate"];
                }
                //objPriOE.ToDate = mfdr.FormData["ToDate"];

                if (mfdr.FileData.Count > 0)
                {

                    FileName = mfdr.FileData[0].Headers.ContentDisposition.FileName.ToString();
                    int i = 0;
                    Dictionary<int, string> lstFile = new Dictionary<int, string>();
                    InternalFileUpload(mfdr, storagePath, ref i, ref lstFile);
                    foreach (KeyValuePair<int, string> kvp in lstFile)
                    {
                        objPriOE.DocumentFilename = kvp.Value;
                    }

                    objPriOE.ExlInvReconciliationDet = GetPriOEUploadDet(objPriOE);
                }
            }

            catch (Exception ex)
            {
                objPriOE.Err = true;
                objPriOE.ErrMsg = ex.Message;
                Librarys.Logging.Logger.For(this).Error(ex);
            }
            return Request.CreateResponse<ExlInvReconciliation>(HttpStatusCode.OK, objPriOE);
        }

        private string GetProperColumnName(string str)
        {
            str = (str.Trim().Contains("(DD-MM-YYYY)") == true ? str.Trim().Replace("(DD-MM-YYYY)", "") : str);
            str = (str.Trim().Contains("(MM-DD-YYYY)") == true ? str.Trim().Replace("(MM-DD-YYYY)", "") : str);
            str = (str.Trim().Contains("(MM/DD/YYYY)") == true ? str.Trim().Replace("(MM/DD/YYYY)", "") : str);
            str = (str.Trim().Contains("(DD/MM/YYYY)") == true ? str.Trim().Replace("(DD/MM/YYYY)", "") : str);
            str = (str.Trim().Contains("(Invoice/Stock Transfer)") == true ? str.Trim().Replace("(Invoice/Stock Transfer)", "") : str);
            str = (str.Trim().Contains("(Allowed/Not Allowed)") == true ? str.Trim().Replace("(Allowed/Not Allowed)", "") : str);
            str = (str.Trim().Contains("(HH:TT:SS)") == true ? str.Trim().Replace("(HH:TT:SS)", "") : str);
            str = (str.Trim().Contains("(INR)") == true ? str.Trim().Replace("(INR)", "") : str);
            str = (str.Trim().Contains("(Y/N)") == true ? str.Trim().Replace("(Y/N)", "").Trim() : str);
            str = (str.Trim().Contains("(D/C)") == true ? str.Trim().Replace("(D/C)", "") : str);
            str = (str.Trim().Contains("(Kg)") == true ? str.Trim().Replace("(Kg)", "") : str);
            str = (str.Trim().Contains("(gm)") == true ? str.Trim().Replace("(gm)", "") : str);
            str = (str.Trim().Contains("(FMS)") == true ? str.Trim().Replace("(FMS)", "") : str);
            str = (str.Trim().Contains("(cbm)") == true ? str.Trim().Replace("(cbm)", "") : str);
            str = (str.Trim().Contains("(WOR/WR/AE)") == true ? str.Trim().Replace("(WOR/WR/AE)", "") : str);
            str = (str.Contains('.') == true ? (((str.Length - 1) == str.IndexOf('.')) ? str.Replace(".", string.Empty) : str.Replace('.', '_')) : str);//.Contains('&') == true ? str.Replace('&', '_') : str.Contains('-') == true ? str.Replace('-', '_') : str.Trim().Contains(" ") == true ? str.Trim().Replace(" ", "") : str);
            str = (str.Contains('&') == true ? (((str.Length - 1) == str.IndexOf('&')) ? str.Replace("&", string.Empty) : str.Replace('&', '_')) : str);
            str = (str.Contains('-') == true ? (((str.Length - 1) == str.IndexOf('-')) ? str.Replace("-", string.Empty) : str.Replace('-', '_')) : str);
            str = (str.Contains('/') == true ? (((str.Length - 1) == str.IndexOf('/')) ? str.Replace("/", string.Empty) : str.Replace('/', '_')) : str);
            str = (str.Contains('/') == true ? (((str.Length - 1) == str.IndexOf('/')) ? str.Replace("/", string.Empty) : str.Replace("/", string.Empty)) : str);

            str = (str.Contains(',') == true ? (((str.Length - 1) == str.IndexOf(',')) ? str.Replace(",", string.Empty) : str.Replace(',', '_')) : str);
            str = (str.Contains('*') == true ? (((str.Length - 1) == str.IndexOf('*')) ? str.Replace("*", string.Empty) : str.Replace('*', '_')) : str);
            str = (str.Contains("'") == true ? (((str.Length - 1) == str.IndexOf("'")) ? str.Replace("'", string.Empty) : str.Replace("'", string.Empty)) : str);
            str = (str.Contains('(') == true ? (((str.Length - 1) == str.IndexOf('(')) ? str.Replace("(", string.Empty) : str.Replace('(', '_')) : str);
            str = (str.Contains(')') == true ? (((str.Length - 1) == str.IndexOf(')')) ? str.Replace(")", string.Empty) : str.Replace(')', '_')) : str);

            str = (str.Trim().Contains(" ") == true ? str.Trim().Replace(" ", "_") : str);
            str = (str.Trim().Contains("/") == true ? str.Trim().Replace("/", "_") : str);
            str = (str.Trim().Contains("__") == true ? str.Trim().Replace("__", "_") : str);
            str = (str.Trim().Contains("__") == true ? str.Trim().Replace("__", "_") : str);
            return str;
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

        private List<ExlInvReconciliationDet> GetPriOEUploadDet(ExlInvReconciliation objPriOE)
        {


            objPriOE.ErrMsg = ErrorMsg;
            string filePath = objPriOE.DocumentFilename;
            List<ExlInvReconciliationDet> InvoiceUploadDet = new List<ExlInvReconciliationDet>();
            DataTable dtExcel = ReadExcel(filePath);
            if (dtExcel.Rows.Count > 0)
            {
                List<ExlInvReconciliationDet> UploadRR = new List<ExlInvReconciliationDet>();
                if (dtExcel.Rows.Count > 0)
                {
                    string strCustomerName = string.Empty;
                    int i = 0;
                    try
                    {
                        ExlInvReconciliation RRD = new ExlInvReconciliation();


                        RRD.ExlInvReconciliationDet = new List<ExlInvReconciliationDet>();


                        for (int K = 0; K < dtExcel.Rows.Count; K++)
                        {
                            ExlInvReconciliationDet Upld = new ExlInvReconciliationDet();
                            Upld.FilePath = storagePath + "\\" + objPriOE.DocumentFilename;
                            Upld.DocumentFilename = objPriOE.DocumentFilename;
                            try
                            {

                                //Upld.Branch = dtExcel.Rows[K]["Branch"].ToString();
                                //Upld.BusinessUnit = dtExcel.Rows[K]["CompanyCode"].ToString();
                                Upld.InvoiceNo = dtExcel.Rows[K]["Invoice_No"].ToString();
                                Upld.InvoiceDate = dtExcel.Rows[K]["Invoice_Date"].ToString();
                                Upld.InvoiceStatus = dtExcel.Rows[K]["Invoice_Status"].ToString();
                                //Upld.StatusFMS = dtExcel.Rows[K]["Status_in"].ToString();
                                //Upld.LRNo = dtExcel.Rows[K]["LR_No"].ToString();
                                //Upld.LSP = dtExcel.Rows[K]["LSP"].ToString();
                          
                                RRD.ExlInvReconciliationDet.Add(Upld);
                                //RRD.ParentUpload.Add(Upld);
                            }
                            catch (Exception ex) { }
                        }
                        UploadRR = _repository.CheckforExcel(RRD.ExlInvReconciliationDet, objPriOE.InvStsSno, objPriOE.BusinessUnitSno, objPriOE.BranchSno, objPriOE.FromDate, objPriOE.ToDate); //, objPriOE.BranchSno, objPriOE.BusinessUnitSno
                    }
                    catch (Exception ex)
                    {

                    }
                }
                InvoiceUploadDet = UploadRR;
            }
            return InvoiceUploadDet;
        }


        public DataTable ReadExcel(string filePath)
        {

            DataTable dtExcelRecords = new DataTable();
            string connectionString = string.Empty;

            OleDbConnection con = new OleDbConnection();
            try
            {
                string fileLocation = storagePath + "\\" + filePath;
                string path = fileLocation;
                //string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=HTML Import";

                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + path + "; Extended Properties=Excel 12.0;";

                //connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + "; Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";

                //Create OleDB Connection and OleDb Command
                //OleDbConnection DBConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source='" + strfileName + "';" + "Extended Properties=\"Excel 8.0;HDR=Yes\"");

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
                        dtExcelRecords.Columns[dc.ColumnName].ColumnName = GetProperColumnName(dc.ColumnName).ToString();
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





    }
}
