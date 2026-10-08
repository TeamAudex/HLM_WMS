using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Entity;
using POMS.Repository;
using Entity.Operations;
using Repository.Operations;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Net.Http.Headers;
using System.Data;

namespace TestApplication.Controllers.Operation
{
    [RoutePrefix("Api/IST")]
    public class InternalStockTransferController : ApiController
    {
        InternalStockTransferRepository _repository = new InternalStockTransferRepository();

        [HttpPost]
        [Route("Insert")]
        public ISTResponse Insert(ISTList objISTList)
        {
            return _repository.Insert(objISTList);
        }

        [HttpGet]
        [Route("Edit")]
        public ISTList Edit(int ISTSno)
        {
            return _repository.Edit(ISTSno);
        }

        [HttpPost]
        [Route("Search")]
        public Tuple<List<InternalStockTransfer>, int> Search(PageRequest pageRequest)
        {

            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _repository.Search(pageRequest);


        }

        [HttpPost]
        [Route("PostingInsert")]
        public STResponse PostingInsert(STList objISTList)
        {
            return _repository.PostingInsert(objISTList);
        }

        [HttpGet]
        [Route("PostingEdit")]
        public STList PostingEdit(int ISTSno)
        {
            return _repository.PostingEdit(ISTSno);
        }

        [HttpPost]
        [Route("PostingSearch")]
        public Tuple<List<IST>, int> PostingSearch(PageRequest pageRequest)
        {

            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _repository.PostingSearch(pageRequest);


        }

        [HttpPost]
        [Route("SplittingSearch")]
        public Tuple<List<IST>, int> SplittingSearch(PageRequest pageRequest)
        {

            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _repository.SplittingSearch(pageRequest);


        }

        [HttpGet]
        [Route("SplittingEdit")]
        public STList SplittingEdit(int ISTSno)
        {
            return _repository.SplittingEdit(ISTSno);
        }

        [HttpPost]
        [Route("SplittingInsert")]
        public STResponse SplittingInsert(STList objISTList)
        {
            return _repository.SplittingInsert(objISTList);
        }

        [HttpGet]
        [Route("ISTConfirmation")]
        public ISTConfirmRespDetails ISTConfirmation(int ISTSno, string PostingLogFile)
        {
            return _repository.ISTConfirmation(ISTSno, PostingLogFile);
        }


        [Route("GetFile")]
        [HttpGet]

        public HttpResponseMessage GetFile(int StockTransferSno)
        {
            HttpResponseMessage result = null;

            DataTable dtBulk = null;
            DataTable dt = null;
            ReportViewer rptvInvoice = new ReportViewer();






            dtBulk = new DataTable();
            dt = new DataTable();


            dtBulk = _repository.PrintSearch(StockTransferSno);


            string FilePath;
            FilePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "//StockTransfer" + "//" + DateTime.Now.ToString("dd-MM-yyyy") + "//";
            string FileName = "StockTransfer_" + Guid.NewGuid().ToString();







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


                    dt = _repository.Print(StockTransferSno, Convert.ToInt32(dtBulk.Rows[k]["ReceivedBySno"]));



                    rptvInvoice.ProcessingMode = ProcessingMode.Local;
                    LocalReport rep = rptvInvoice.LocalReport;


                    rep.ReportPath = "Reports\\Design\\StockTransfer.rdlc";





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

                        string FileName1 = "StockTransfer_" + Guid.NewGuid().ToString();

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
                        FileInfo f = new FileInfo(FilePath + "StockTransferPrintCopy\\" + idd);
                        if (!new DirectoryInfo(f.DirectoryName).Exists)
                        {
                            Directory.CreateDirectory(f.DirectoryName);
                        }
                        if (System.IO.File.Exists(f.FullName)) System.IO.File.Delete(f.FullName);


                        FileStream fs = new FileStream(FilePath + "StockTransferPrintCopy\\" + idd, FileMode.OpenOrCreate);
                        byte[] data = new byte[fs.Length];
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Close();

                        PdfReader readerforcopy = null;
                        PdfImportedPage importedPageForCopy = null;



                        try
                        {


                            // Intialize a new PdfReader instance with the contents of the source Pdf file:
                            readerforcopy = new PdfReader(FilePath + "StockTransferPrintCopy\\" + idd);
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

                        if (System.IO.Directory.Exists(FilePath + "StockTransferPrintCopy\\")) System.IO.Directory.Delete(FilePath + "StockTransferPrintCopy\\", true);

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

                System.IO.FileInfo file1 = new System.IO.FileInfo(System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "//StockTransfer" + "//" + DateTime.Now.ToString("dd-MM-yyyy") + "//" + FileName + ".pdf");

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
