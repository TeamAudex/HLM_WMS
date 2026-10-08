  
using System;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using POMS.Repository;
using POMS.Entity;
namespace TestApplication.Reports
{
    public partial class ExportPrints : System.Web.UI.Page
    {
        CommonReport objCommon;
        BulkCommonRepository objBulkCommon;
        DataTable dtBulk = null;
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            objCommon = new CommonReport();
            objBulkCommon = new BulkCommonRepository();
            dtBulk = new DataTable();
            dt = new DataTable();
            try
            {
                if (!IsPostBack)

                {
                    hdnReqSno.Value = Request.QueryString["id"].ToString();
                     Assign();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Assign()
        {
            objCommon.ActionTypess = "Search";
            objCommon.ReqSno = hdnReqSno.Value;
            objBulkCommon.ExportInvoicePrintSearch(objCommon);
            string str = objCommon.BulkPrint.Tables[0].Rows[0]["InvoicePrintMasSno"].ToString().Trim();
            string Branch = objCommon.BulkPrint.Tables[0].Rows[0]["Branch"].ToString().Trim();
            string BusinessUnit = objCommon.BulkPrint.Tables[0].Rows[0]["BusinessUnit"].ToString().Trim();
            string MOTCode = objCommon.BulkPrint.Tables[0].Rows[0]["MOTCode"].ToString().Trim();
            string InvFileName = string.Empty;
            string DcFileName = string.Empty;
            string Clubbedfilename = string.Empty;
            string FileName = objCommon.BulkPrint.Tables[0].Rows[0]["PrintSno"].ToString().Replace("/", " ");
            string FilePath;
            string TypeofFlag = objCommon.BulkPrint.Tables[0].Rows[0]["TypeofFlag"].ToString().Trim();

            dtBulk = objCommon.BulkPrint.Tables[0];
            dt = objCommon.BulkPrint.Tables[1];

            PdfCopy pdfCopyProvider = null;
            string StrRptTypes = "ORIGINAL Copy";
            // For simplicity, I am assuming all the pages share the same size
            // and rotation as the first page:
            Document sourceDocument = null;
            sourceDocument = new Document();
            FilePath = System.Configuration.ConfigurationManager.ConnectionStrings["ExportDocument"].ConnectionString + str + "//";
            if (!System.IO.Directory.Exists(FilePath))
            {
                System.IO.Directory.CreateDirectory(FilePath);
            }
            // Initialize an instance of the PdfCopyClass with the source 
            // document and an output file stream:
            pdfCopyProvider = new PdfCopy(sourceDocument,
                new System.IO.FileStream(System.Configuration.ConfigurationManager.ConnectionStrings["ExportDocument"].ConnectionString + "//" + str + "//" + BusinessUnit + '_' + Branch + '_' + "ExportInvoicePrintOn".Replace("/", " ") + ".pdf", System.IO.FileMode.Create));
            sourceDocument.Open();
            //if (dtBu
            var L = 0;

            for (var k = 0; k < dt.Rows.Count; k++)
            {

                DataRow[] foundRows = dtBulk.Select("LRSno=" + dt.Rows[k]["LRSno"].ToString());
                for (var j = 0; j < foundRows.Length; j++)
                {
                    InvFileName = foundRows[j]["Invfilename"].ToString();
                    DcFileName = foundRows[j]["DCfilename"].ToString();
                    Clubbedfilename = foundRows[j]["Clubbedfilename"].ToString();
                    objCommon.ActionTypess = "Report";
                    objCommon.ReqSno = foundRows[j]["OrderSno"].ToString();
                    objBulkCommon.ExportInvoicePrintReport(objCommon);

                    rptvInvoice.ProcessingMode = ProcessingMode.Local;
                    LocalReport rep = rptvInvoice.LocalReport;
                    if (TypeofFlag == "G")
                    {
                        rep.ReportPath = "Reports\\Design\\InvoicePrintHealthiumTriple_IRN.rdlc";
                    }
                    else
                    {
                        rep.ReportPath = "Reports\\Design\\InvoicePrintHealthiumTriple_IRN_NG.rdlc";
                    }
                    rep.EnableExternalImages = true;

                    ReportDataSource rdsInvoice = new ReportDataSource();
                    rdsInvoice.Name = "DataSet1";
                    rdsInvoice.Value = objCommon.BulkPrintReport.Tables[0];


                    rep.DataSources.Clear();
                    rep.DataSources.Add(rdsInvoice);
                    PdfCopy pdfCopyProvider1 = null;
                    Document sourceDocument1 = null;
                    sourceDocument1 = new Document();
                    pdfCopyProvider1 = new PdfCopy(sourceDocument1,
                    new System.IO.FileStream(System.Configuration.ConfigurationManager.ConnectionStrings["ExportDocument"].ConnectionString + "//" + str + "//" + Clubbedfilename, System.IO.FileMode.Create));
                    sourceDocument1.Open();
                    try
                    {
                        Microsoft.Reporting.WebForms.Warning[] warnings = null;
                        string[] streamids = null;
                        String mimeType = null;
                        String encoding = null;
                        String extension = null;
                        Byte[] bytes = null;


                        string[] arCopyPisitions = { "ORIGINAL Copy For Buyer", "DUPLICATE Copy", "TRIPLICATE Copy" };

                        PdfCopy pdfCopyProviderTrplicator = null;
                        Document sourceDocumentTrplicator = null;
                        sourceDocumentTrplicator = new Document();
                        pdfCopyProviderTrplicator = new PdfCopy(sourceDocumentTrplicator,
                        new System.IO.FileStream(FilePath + InvFileName, System.IO.FileMode.Create));


                        for (int copypos = 0; arCopyPisitions.Length > copypos; copypos++)
                        {
                            sourceDocumentTrplicator.Open();
                            ReportParameter[] p = new ReportParameter[1];
                            p.SetValue(new ReportParameter("CopyPisition", arCopyPisitions[copypos]), 0);
                            rptvInvoice.LocalReport.SetParameters(p);

                            bytes = rptvInvoice.LocalReport.Render("PDF", "", out mimeType, out encoding, out extension, out streamids, out warnings);
                            string value = "A";
                            // Split the string on line breaks.

                            string[] lines = value.Split('-');
                            string idd = Guid.NewGuid().ToString();
                            FileInfo f = new FileInfo(FilePath + "ExportInvoiceSingleCopy\\" + idd);
                            if (!new DirectoryInfo(f.DirectoryName).Exists)
                            {
                                Directory.CreateDirectory(f.DirectoryName);
                            }
                            if (System.IO.File.Exists(f.FullName)) System.IO.File.Delete(f.FullName);


                            FileStream fs = new FileStream(FilePath + "ExportInvoiceSingleCopy\\" + idd, FileMode.OpenOrCreate);
                            byte[] data = new byte[fs.Length];
                            fs.Write(bytes, 0, bytes.Length);
                            fs.Close();

                            PdfReader readerforcopy = null;
                            PdfImportedPage importedPageForCopy = null;
                            try
                            {
                                // Intialize a new PdfReader instance with the contents of the source Pdf file:
                                readerforcopy = new PdfReader(FilePath + "ExportInvoiceSingleCopy\\" + idd);
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
                        }
                        sourceDocumentTrplicator.Close();

                        if (System.IO.Directory.Exists(FilePath + "ExportInvoiceSingleCopy\\")) System.IO.Directory.Delete(FilePath + "ExportInvoiceSingleCopy\\", true);

                        System.IO.FileInfo file = new System.IO.FileInfo(FilePath + InvFileName);

                        PdfReader reader = null;

                        PdfImportedPage importedPage = null;

                        PdfImportedPage importedPage1 = null;
                        try
                        {
                            // Intialize a new PdfReader instance with the contents of the source Pdf file:
                            reader = new PdfReader(FilePath + InvFileName);
                            PdfReader pdfReader = new PdfReader(FilePath + InvFileName);
                            int numberOfPages = pdfReader.NumberOfPages;

                            for (int i = 1; i <= numberOfPages; i++)
                            {
                                importedPage1 = pdfCopyProvider1.GetImportedPage(reader, i);
                                pdfCopyProvider1.AddPage(importedPage1);
                            }


                            // Walk the specified range and add the page copies to the output file:
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

                    string PART = objCommon.BulkPrintReport.Tables[1].Rows[0]["PART"].ToString();
                    if( (TypeofFlag == "G")&&(PART!="N"))
                    {

                        LocalReport rep1 = rptvInvoice.LocalReport;
                        if (PART == "A")
                        {
                            rep1.ReportPath = "Reports\\Design\\EWB_Part_A_UNQ.rdlc";
                        }
                        else
                        {
                            rep1.ReportPath = "Reports\\Design\\EWB_Part_B_EWB.rdlc";
                        }

                        rep1.EnableExternalImages = true;
                        ReportDataSource rdsInvoice1 = new ReportDataSource();
                        rdsInvoice1.Name = "DataSet1";
                        rdsInvoice1.Value = objCommon.BulkPrintReport.Tables[1];
                        rep1.DataSources.Clear();
                        rep1.DataSources.Add(rdsInvoice1);
                        try
                        {
                            Microsoft.Reporting.WebForms.Warning[] warnings1 = null;
                            string[] streamids1 = null;
                            String mimeType1 = null;
                            String encoding1 = null;
                            String extension1 = null;
                            Byte[] bytes1 = null;

                            bytes1 = rptvInvoice.LocalReport.Render("PDF", "", out mimeType1, out encoding1, out extension1, out streamids1, out warnings1);
                            string value1 = "A";
                            // Split the string on line breaks.

                            string[] lines1 = value1.Split('-');

                            System.IO.File.Delete(FilePath + DcFileName);
                            FileInfo f1 = new FileInfo(FilePath + DcFileName);
                            if (!f1.Exists)
                            {

                                Directory.CreateDirectory(FilePath);
                            }
                            FileStream fs1 = new FileStream(FilePath + DcFileName, FileMode.OpenOrCreate);
                            byte[] data1 = new byte[fs1.Length];
                            fs1.Write(bytes1, 0, bytes1.Length);
                            fs1.Close();
                            System.IO.FileInfo file = new System.IO.FileInfo(FilePath + DcFileName);
                            PdfReader reader1 = null;

                            PdfImportedPage importedPage = null;
                            PdfImportedPage importedPage1 = null;

                            try
                            {
                                reader1 = new PdfReader(FilePath + DcFileName);
                                PdfReader pdfReader1 = new PdfReader(FilePath + DcFileName);
                                int numberOfPages = pdfReader1.NumberOfPages;


                                for (int i = 1; i <= numberOfPages; i++)
                                {
                                    importedPage1 = pdfCopyProvider1.GetImportedPage(reader1, i);


                                    pdfCopyProvider1.AddPage(importedPage1);
                                }

                                sourceDocument1.Close();
                                // Walk the specified range and add the page copies to the output file:
                                for (int i = 1; i <= numberOfPages; i++)
                                {
                                    importedPage = pdfCopyProvider.GetImportedPage(reader1, i);


                                    pdfCopyProvider.AddPage(importedPage);
                                }

                                reader1.Close();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            //file.OpenWrite();
                            //if (file.Exists)
                            //{
                            //    Response.ClearContent();
                            //    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                            //    Response.AddHeader("Content-Length", file.Length.ToString());
                            //    Response.ContentType = file.Extension.ToString();

                            //    Response.WriteFile(file.FullName);
                            //    //  file.Open(FileMode.Open);
                            //    Response.Flush();
                            //    Response.End();
                            //}
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }

                    L = j;

                }




            }

            sourceDocument.Close();
            rptvInvoice.Visible = false;

            System.IO.FileInfo file1 = new System.IO.FileInfo(System.Configuration.ConfigurationManager.ConnectionStrings["ExportDocument"].ConnectionString + "//" + str + "//" + BusinessUnit + '_' + Branch + '_' + "ExportInvoicePrintOn".Replace("/", " ") + ".pdf");

            if (file1.Exists)
            {
                Response.ClearContent();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file1.Name);
                Response.AddHeader("Content-Length", file1.Length.ToString());
                Response.ContentType = file1.Extension.ToString();
                Response.WriteFile(file1.FullName);
                //  file.Open(FileMode.Open);
                Response.Flush();
                Response.End();
            }
        }
    }
}