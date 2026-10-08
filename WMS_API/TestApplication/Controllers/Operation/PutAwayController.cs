using Entity.Operations;
using Repository.Operations;
using Repository.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Entity;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Net.Http.Headers;
using System.Data;

namespace TestApplication.Controllers
{
    [RoutePrefix("Api/PutAway")]
    public class PutAwayController : ApiController
    {
        PutAwayRepository _Repository = new PutAwayRepository();
        [HttpGet]
        [Route("Fetch")]
        public List<PutAwayDet> Fetch(int WarehouseSno, string FromDate, string ToDate, string SelectedGrnSno, string SelectedBatchNo, string SelectedLotNo,int StoragelocationSno)
        {
            return _Repository.Fetch(WarehouseSno, FromDate, ToDate, SelectedGrnSno, SelectedBatchNo, SelectedLotNo, StoragelocationSno);
        }
        [HttpGet]
        [Route("Edit")]
        public PutAwaySave Edit(int PutAwaySno)
        {
            return _Repository.Edit(PutAwaySno);
        }
        [HttpPost]
        [Route("Insert")]
        public PutAwayResponse Insert(PutAwaySave ObjSave)
        {
            return _Repository.Insert(ObjSave);
        }
        [HttpPost]
        [Route("Search")]
        public Tuple<List<PutAwaySearch>, int> GetItemMasterDetails(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _Repository.Search(pageRequest);
        }
        [HttpGet]
        [Route("DashFetch")]
        public List<PutAwayDash> PADashFetch(int EmployeeSno, string RoleFlag)
        {
            return _Repository.PADashFetch(EmployeeSno, RoleFlag);
        }
        [HttpGet]
        [Route("PACDashFetch")]
        public PACDashFetch PACDashFetch(int EmployeeSno, string RoleFlag)
        {
            return _Repository.PACDashFetch(EmployeeSno, RoleFlag);
        }
        [HttpGet]
        [Route("PAConfirmFetch")]
        public PutAwayConfirm PAConfirmFetch(int PutAwayLocSno)
        {
            return _Repository.PAConfirmFetch(PutAwayLocSno);
        }
        [HttpPost]
        [Route("PACInsert")]
        public string PACInsert(PutAwayConfirm objConfirm)
        {
            return _Repository.PAConfirmInsert(objConfirm);
        }
        [HttpGet]
        [Route("PACFetch")]
        public PAFetch PACFetch(int PutAwayLocSno)
        {
            return _Repository.PACFetch(PutAwayLocSno);
        }
        [HttpPost]
        [Route("PAConInsert")]
        public string PAConInsert(PAFetch objConfirm)
        {
            return _Repository.PACInsert(objConfirm);
        }
        [HttpGet]
        [Route("GetLocation")]
        public LocData PACLocation(int UserSno, string TypeValue, int WarehouseSno, int ItemSno, int GRNDetSno, int PutAwayLocSno)
        {
            return _Repository.PACLocation(UserSno, TypeValue, WarehouseSno, ItemSno, GRNDetSno, PutAwayLocSno);
        }
        [Route("GetFile")]
        [HttpGet]

        public HttpResponseMessage GetFile(int PutAwaySno)
        {
            HttpResponseMessage result = null;

            DataTable dtBulk = null;
            DataTable dt = null;
            ReportViewer rptvInvoice = new ReportViewer();






            dtBulk = new DataTable();
            dt = new DataTable();


            dtBulk = _Repository.PrintSearch(PutAwaySno);


            string FilePath;
            FilePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "//PutAway" + "//" + DateTime.Now.ToString("dd-MM-yyyy") + "//";
            string FileName = "PutAway_" + Guid.NewGuid().ToString();







            if (dtBulk.Rows.Count > 0)
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





                for (int k = 0; k < dtBulk.Rows.Count; k++)
                {


                    dt = _Repository.Print(PutAwaySno, Convert.ToInt32(dtBulk.Rows[k]["PutterSno"]));



                    rptvInvoice.ProcessingMode = ProcessingMode.Local;
                    LocalReport rep = rptvInvoice.LocalReport;


                    rep.ReportPath = "Reports\\Design\\PutAway.rdlc";





                    rep.EnableExternalImages = false;

                    ReportDataSource rdsInvoice = new ReportDataSource();
                    rdsInvoice.Name = "DataSet1";
                    rdsInvoice.Value = dt;


                    rep.DataSources.Clear();
                    rep.DataSources.Add(rdsInvoice);



                    try
                    {
                        Microsoft.Reporting.WebForms.Warning[] warnings = null;
                        string[] streamids = null;
                        String mimeType = null;
                        String encoding = null;
                        String extension = null;
                        Byte[] bytes = null;

                        string FileName1 = "PutAway_" + Guid.NewGuid().ToString();

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
                        FileInfo f = new FileInfo(FilePath + "PutAwayPrintCopy\\" + idd);
                        if (!new DirectoryInfo(f.DirectoryName).Exists)
                        {
                            Directory.CreateDirectory(f.DirectoryName);
                        }
                        if (System.IO.File.Exists(f.FullName)) System.IO.File.Delete(f.FullName);


                        FileStream fs = new FileStream(FilePath + "PutAwayPrintCopy\\" + idd, FileMode.OpenOrCreate);
                        byte[] data = new byte[fs.Length];
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Close();

                        PdfReader readerforcopy = null;
                        PdfImportedPage importedPageForCopy = null;



                        try
                        {


                            // Intialize a new PdfReader instance with the contents of the source Pdf file:
                            readerforcopy = new PdfReader(FilePath + "PutAwayPrintCopy\\" + idd);
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

                        if (System.IO.Directory.Exists(FilePath + "PutAwayPrintCopy\\")) System.IO.Directory.Delete(FilePath + "PutAwayPrintCopy\\", true);

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


                }





                sourceDocument.Close();
                rptvInvoice.Visible = false;

                System.IO.FileInfo file1 = new System.IO.FileInfo(System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "//PutAway" + "//" + DateTime.Now.ToString("dd-MM-yyyy") + "//" + FileName + ".pdf");

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
    }
}