using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Entity = POMS.Entity;
using Repository = POMS.Repository;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.IO.MemoryMappedFiles;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace TestApplication.Reports
{
    public partial class LRPrint : System.Web.UI.Page
    {
        Entity.Common objCommon;
        Repository.BulkCommonRepository objBulkCommon;
        DataTable dtBulk = null;
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            objCommon = new Entity.Common();
            objBulkCommon = new Repository.BulkCommonRepository();
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
            objCommon.ActionType = "Search";
            objCommon.Condition1 = hdnReqSno.Value;
            objBulkCommon.LRPrintSearch(objCommon);
            string str = objCommon.BulkPrint.Tables[0].Rows[0]["PrintSno"].ToString().Trim();
            string FilePath;
            dtBulk = objCommon.BulkPrint.Tables[0];

            PdfCopy pdfCopyProvider = null;

            // For simplicity, I am assuming all the pages share the same size
            // and rotation as the first page:
            Document sourceDocument = null;
            sourceDocument = new Document();
            FilePath = System.Configuration.ConfigurationManager.ConnectionStrings["Document"].ConnectionString + str + "\\";
            if (!System.IO.Directory.Exists(FilePath))
            {
                System.IO.Directory.CreateDirectory(FilePath);
            }
            // Initialize an instance of the PdfCopyClass with the source 
            // document and an output file stream:
            pdfCopyProvider = new PdfCopy(sourceDocument,
                new System.IO.FileStream(System.Configuration.ConfigurationManager.ConnectionStrings["Document"].ConnectionString + str + "//" + "BulkInvoice".Replace("/", " ") + ".pdf", System.IO.FileMode.Create));
            sourceDocument.Open();
            //if (dtBulk.Rows.Count > 0)
            for (var j = 0; j < dtBulk.Rows.Count; j++)
            {


                objCommon.ActionType = "Report";
                objCommon.Condition1 = dtBulk.Rows[j]["LRSno"].ToString();

                objBulkCommon.LRPrintReport(objCommon);
                rptvInvoice.ProcessingMode = ProcessingMode.Local;
                LocalReport rep = rptvInvoice.LocalReport;
                rep.ReportPath = "Design\\LRPrint.rdlc";
                rep.EnableExternalImages = true;

                ReportDataSource rdsInvoice = new ReportDataSource();
                rdsInvoice.Name = "DataSet1";
                rdsInvoice.Value = objCommon.BulkPrintReport.Tables[0];



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

                    bytes = rptvInvoice.LocalReport.Render("PDF", "", out mimeType, out encoding, out extension, out streamids, out warnings);
                    string value = "A";
                    // Split the string on line breaks.

                    string[] lines = value.Split('-');

                    System.IO.File.Delete(FilePath + "\\" + objCommon.BulkPrintReport.Tables[0].Rows[0]["PrintSno"].ToString().Replace("/", " ") + ".pdf");
                    FileInfo f = new FileInfo(FilePath + "\\" + objCommon.BulkPrintReport.Tables[0].Rows[0]["PrintSno"].ToString().Replace("/", " ") + ".pdf");
                    if (!f.Exists)
                    {

                        Directory.CreateDirectory(FilePath);
                    }
                    FileStream fs = new FileStream(FilePath + "\\" + objCommon.BulkPrintReport.Tables[0].Rows[0]["PrintSno"].ToString().Replace("/", " ") + ".pdf", FileMode.OpenOrCreate);
                    byte[] data = new byte[fs.Length];
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();


                    System.IO.FileInfo file = new System.IO.FileInfo(FilePath + "//" + objCommon.BulkPrintReport.Tables[0].Rows[0]["PrintSno"].ToString().Replace("/", " ") + ".pdf");

                    PdfReader reader = null;

                    PdfImportedPage importedPage = null;

                    try
                    {
                        // Intialize a new PdfReader instance with the contents of the source Pdf file:
                        reader = new PdfReader(FilePath + "//" + objCommon.BulkPrintReport.Tables[0].Rows[0]["PrintSno"].ToString().Replace("/", " ") + ".pdf");
                        PdfReader pdfReader = new PdfReader(FilePath + "//" + objCommon.BulkPrintReport.Tables[0].Rows[0]["PrintSno"].ToString().Replace("/", " ") + ".pdf");
                        int numberOfPages = pdfReader.NumberOfPages;




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
            sourceDocument.Close();
            rptvInvoice.Visible = false;
            System.IO.FileInfo file1 = new System.IO.FileInfo(System.Configuration.ConfigurationManager.ConnectionStrings["Document"].ConnectionString + "//" + str + "//" + "BulkInvoice".Replace("/", " ") + ".pdf");
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
