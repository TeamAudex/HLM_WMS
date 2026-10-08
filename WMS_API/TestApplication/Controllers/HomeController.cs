using OfficeOpenXml;
using OfficeOpenXml.Style;
using POMS.Entity;
using POMS.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Entity.Operations;
using POMS.Entity;
using Repository.Operations;

namespace TestApplication.Controllers
{


    [RoutePrefix("Api/Home")]
    public class HomeController : Controller
    {

        [System.Web.Http.HttpGet]
        [ActionName("GetCycleCount")]
        public void GetCycleCountDetails()
        {
            CycleCountAdjustRepository _Repository = new CycleCountAdjustRepository();
            var context = System.Web.HttpContext.Current;
            var CycleCountSno = context.Cache["CycleCountSno"];
            List<CycleCountAdjustDet> data = _Repository.GetCycleExcel(Convert.ToInt32(CycleCountSno)).ArrCycleCountDet;

            if (data == null || data.Count <= 0)
            {
                data = new List<CycleCountAdjustDet>();
            }

            DataTable dt = new DataTable("tblData");
            dt.Columns.Add("S.No.");
            dt.Columns.Add("SubZone");
            dt.Columns.Add("Location");
            dt.Columns.Add("Pallet");
            dt.Columns.Add("StockType");
            dt.Columns.Add("ItemName");
            dt.Columns.Add("BatchNo");
            dt.Columns.Add("ExpDate");
            dt.Columns.Add("PhysicalCount");
            dt.Columns.Add("SystemCount");
            dt.Columns.Add("Difference");
            dt.Columns.Add("Reason");

            int i = 1;
            foreach (CycleCountAdjustDet NC in data)
            {
                dt.Rows.Add(
                               i
                              , NC.SubZone
                              , NC.WHRowColumn
                              , NC.Pallet
                              , NC.StockType
                              , NC.ItemName
                              , NC.BatchNo
                              , NC.ExpDate
                              , NC.PhysicalCount
                              , NC.SystemCount
                              , NC.DifferenceCount
                              , NC.Reason

                            );
                i++;
            }
            try
            {
                ExcelPackage excel = new ExcelPackage();
                var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells[1, 1].LoadFromDataTable(dt, true);
                workSheet.Cells["A1"].Value = "S.No.";
                workSheet.Cells["B1"].Value = "SubZone";
                workSheet.Cells["C1"].Value = "Location";
                workSheet.Cells["D1"].Value = "Pallet";
                workSheet.Cells["E1"].Value = "StockType";
                workSheet.Cells["F1"].Value = "ItemName";
                workSheet.Cells["G1"].Value = "BatchNo";
                workSheet.Cells["H1"].Value = "ExpDate";
                workSheet.Cells["I1"].Value = "PhysicalCount";
                workSheet.Cells["J1"].Value = "SystemCount"; 
                workSheet.Cells["K1"].Value = "DifferenceCount";
                workSheet.Cells["L1"].Value = "Reason";
                var HeaderCells = workSheet.Cells["A1,B1,C1,D1,E1,F1,G1,H1,I1,J1,K1,L1"];
                HeaderCells.Style.Font.Bold = true;
                HeaderCells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                // var HeaderMandatoryCells = workSheet.Cells[];
                // HeaderMandatoryCells.Style.Font.Color.SetColor(Color.Red);

                var start = workSheet.Dimension.Start;
                var end = workSheet.Dimension.End;

                for (int row = start.Row; row <= end.Row; row++)
                { // Row by row...
                    for (int col = start.Column; col <= end.Column; col++)
                    { // ... Cell by cell...   
                        workSheet.Cells[row, col].Style.WrapText = true;
                        workSheet.Cells[row, col].AutoFitColumns();
                        workSheet.Column(col).Width = 30;
                        workSheet.Cells[row, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[row, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[row, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[row, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    }
                }
                string fileName = "CycleCountDetails_";
                string fileNameWithtime = fileName + DateTime.Now.ToString("dd-MMM-yyyy_hh_mm_ss");
                using (var memoryStream = new MemoryStream())
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;  filename=" + fileNameWithtime + ".xlsx");
                    excel.SaveAs(memoryStream);
                    memoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {

            }
        }



        [System.Web.Http.HttpGet]
        [ActionName("GetPhysicalCycleCount")]
        public void GetPhysicalCycleCountDetails()
        {
            CycleCountStartRepository _Repository = new CycleCountStartRepository();
            var context = System.Web.HttpContext.Current;
            var CycleCountSno = context.Cache["CycleCountSno"];
            List<CycleCountExcel> data = _Repository.GetCycleExcel(Convert.ToInt32(CycleCountSno));

            if (data == null || data.Count <= 0)
            {
                data = new List<CycleCountExcel>();
            }

            DataTable dt = new DataTable("tblData");
            dt.Columns.Add("SubZone");
            dt.Columns.Add("RackLocation");
            dt.Columns.Add("Pallet");
            dt.Columns.Add("Item");
            dt.Columns.Add("PackageUOM");
            dt.Columns.Add("BatchNo");
            dt.Columns.Add("Qty");
            dt.Columns.Add("StorageLocation");
          

            int i = 1;
            foreach (CycleCountExcel NC in data)
            {
                dt.Rows.Add(
                              
                               NC.SubZone
                              , NC.RackLocation
                              , NC.Pallet
                              , NC.ItemName
                              , NC.Package
                              , NC.BatchNo
                              , null
                              , NC.StorageLocation
                              

                            );
                i++;
            }
            try
            {
                ExcelPackage excel = new ExcelPackage();
                var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells[1, 1].LoadFromDataTable(dt, true);
                workSheet.Cells["A1"].Value = "SubZone";
                workSheet.Cells["B1"].Value = "RackLocation";
                workSheet.Cells["C1"].Value = "Pallet";
                workSheet.Cells["D1"].Value = "Item";
                workSheet.Cells["E1"].Value = "PackageUOM";
                workSheet.Cells["F1"].Value = "BatchNo";
                workSheet.Cells["G1"].Value = "Qty";
                workSheet.Cells["H1"].Value = "StorageLocation";
           
                var HeaderCells = workSheet.Cells["A1,B1,C1,D1,E1,F1,G1,H1"];
                HeaderCells.Style.Font.Bold = true;
                HeaderCells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                // var HeaderMandatoryCells = workSheet.Cells[];
                // HeaderMandatoryCells.Style.Font.Color.SetColor(Color.Red);

                var start = workSheet.Dimension.Start;
                var end = workSheet.Dimension.End;

                for (int row = start.Row; row <= end.Row; row++)
                { // Row by row...
                    for (int col = start.Column; col <= end.Column; col++)
                    { // ... Cell by cell...   
                        workSheet.Cells[row, col].Style.WrapText = true;
                        workSheet.Cells[row, col].AutoFitColumns();
                        workSheet.Column(col).Width = 30;
                        workSheet.Cells[row, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[row, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[row, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[row, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    }
                }
                string fileName = "PhysicalCycleCount_";
                string fileNameWithtime = fileName + DateTime.Now.ToString("dd-MMM-yyyy_hh_mm_ss");
                using (var memoryStream = new MemoryStream())
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;  filename=" + fileNameWithtime + ".xlsx");
                    excel.SaveAs(memoryStream);
                    memoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {

            }
        }

        //ApprovalEmailRepository _ApprovalEmailRepository = new ApprovalEmailRepository();
        //PODForwardRepository _PODForwardRepository = new PODForwardRepository();
        //TripCompletionUploadRepository _TripClosureRepository = new TripCompletionUploadRepository();
        //TATRespostiory TATResp = new TATRespostiory();\
        ReportsRepository _ReportsRepository = new ReportsRepository();

        [System.Web.Http.HttpGet]
        [ActionName("PGIResend")]
        public string PGIResend(int IssueOrderErrorConfSno, int UserSno, string IPNumber)
        {
            string result = "";

            StringBuilder stringBuilder = new StringBuilder();
            result = _ReportsRepository.GetPGIResend(IssueOrderErrorConfSno, UserSno, IPNumber);
            result = (result != "" && result != null) ? result : "Error Occurred!!";
            stringBuilder.Append("<style>div {background-color: #DDE0E3; padding: 20px; } </style>");
            stringBuilder.Append("<div><h1 align='center'>");
            stringBuilder.Append(result);
            stringBuilder.Append("</h1></div>");
            result = stringBuilder.ToString();
            return result;
        }

        [System.Web.Http.HttpGet]
        [ActionName("CycleCountConfirmResend")]
        public string CycleCountConfirmResend(int CycleCountErrorConfSno, int UserSno, string IPNumber)
        {
            string result = "";

            StringBuilder stringBuilder = new StringBuilder();
            result = _ReportsRepository.CycleCountConfirmResend(CycleCountErrorConfSno, UserSno, IPNumber);
            result = (result != "" && result != null) ? result : "Error Occurred!!";
            stringBuilder.Append("<style>div {background-color: #DDE0E3; padding: 20px; } </style>");
            stringBuilder.Append("<div><h1 align='center'>");
            stringBuilder.Append(result);
            stringBuilder.Append("</h1></div>");
            result = stringBuilder.ToString();
            return result;
        }
        [System.Web.Http.HttpGet]
        [ActionName("StockDisposeResend")]
        public string StockDisposeResend(int StockDisposeErrorConfSno, int UserSno, string IPNumber)
        {
            string result = "";

            StringBuilder stringBuilder = new StringBuilder();
            result = _ReportsRepository.StockDisposeResend(StockDisposeErrorConfSno, UserSno, IPNumber);
            result = (result != "" && result != null) ? result : "Error Occurred!!";
            stringBuilder.Append("<style>div {background-color: #DDE0E3; padding: 20px; } </style>");
            stringBuilder.Append("<div><h1 align='center'>");
            stringBuilder.Append(result);
            stringBuilder.Append("</h1></div>");
            result = stringBuilder.ToString();
            return result;
        }


        //[System.Web.Http.HttpGet]
        //[ActionName("ApprovalByMail")]
        //public string ApprovalByMail(int NumberSeries, string Appflag)
        //{
        //    string result = "";
        //    StringBuilder stringBuilder = new StringBuilder();
        //    result =_ApprovalEmailRepository.ApprovalByMail(NumberSeries, Appflag);
        //    result = (result != "" && result != null) ? result : "Error Occurred!!";
        //    stringBuilder.Append("<style>div {background-color: #DDE0E3; padding: 20px; } </style>");
        //    stringBuilder.Append("<div><h1 align='center'>");
        //    stringBuilder.Append(result);
        //    stringBuilder.Append("</h1></div>");
        //    result = stringBuilder.ToString();
        //    return result;
        //}

        //[System.Web.Http.HttpGet]
        //[ActionName("SMSResend")]
        //public string SMSResend(int AUDIT_SMS_SNO, int UserSno, string IPNumber)
        //{
        //    string result = "";

        //    StringBuilder stringBuilder = new StringBuilder();
        //    result = _ApprovalEmailRepository.GetSMSResend(AUDIT_SMS_SNO, UserSno, IPNumber);
        //    result = (result != "" && result != null) ? result : "Error Occurred!!";
        //    stringBuilder.Append("<style>div {background-color: #DDE0E3; padding: 20px; } </style>");
        //    stringBuilder.Append("<div><h1 align='center'>");
        //    stringBuilder.Append(result);
        //    stringBuilder.Append("</h1></div>");
        //    result = stringBuilder.ToString();
        //    return result;
        //}


        //[System.Web.Http.HttpGet]
        //[ActionName("MailResend")]
        //public string MailResend(int AUTO_MAIL_ATTACH_SNO, int UserSno, string IPNumber)
        //{
        //    string result = "";

        //    StringBuilder stringBuilder = new StringBuilder();
        //    result = _ApprovalEmailRepository.GetMailResend(AUTO_MAIL_ATTACH_SNO, UserSno, IPNumber);
        //    result = (result != "" && result != null) ? result : "Error Occurred!!";
        //    stringBuilder.Append("<style>div {background-color: #DDE0E3; padding: 20px; } </style>");
        //    stringBuilder.Append("<div><h1 align='center'>");
        //    stringBuilder.Append(result);
        //    stringBuilder.Append("</h1></div>");
        //    result = stringBuilder.ToString();
        //    return result;
        //}
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        Color BgColorYellow = ColorTranslator.FromHtml("#FEFDBD");
        Color BgColorWhite = ColorTranslator.FromHtml("#f7f7f2");
         Color BgColor = ColorTranslator.FromHtml("#FEFDBD");



        //public List<Color> Itemcolors = new List<Color>();
        //[System.Web.Http.HttpGet]
        //[ActionName("GetPODfile")]
        //public void GetPODfile()
        //{
        //    var context = System.Web.HttpContext.Current;
        //    var PODUploadRequest = (PODForwardFilter)context.Cache["ObjFilterPOD"];
        //    PODUploadRequest.LRFromDate = PODUploadRequest.LRFromDate != null ? PODUploadRequest.LRFromDate : "";
        //    PODUploadRequest.LRToDate = PODUploadRequest.LRToDate != null ? PODUploadRequest.LRToDate : "";
        //    List<PODForwardDetSearchFetch> data = _PODForwardRepository.GetPODDetails(PODUploadRequest);
        //    if (data == null || data.Count <= 0)
        //    {
        //        data = new List<PODForwardDetSearchFetch>();
        //    }
        //    DataTable dt = new DataTable("tblData");
        //    dt.Columns.Add("LSPName");
        //    dt.Columns.Add("LSPCode");
        //    dt.Columns.Add("TrnType");
        //    dt.Columns.Add("LRNo");
        //    dt.Columns.Add("LRDate");
        //    dt.Columns.Add("OrderNo");
        //    dt.Columns.Add("Origin");
        //    dt.Columns.Add("Destination");
        //    dt.Columns.Add("VehicleNo");
        //    dt.Columns.Add("Distibutor");
        //    dt.Columns.Add("CustomerCode");
        //    dt.Columns.Add("Customer");
        //    dt.Columns.Add("DispatchNOP");
        //    dt.Columns.Add("DispatchWeight");
        //    dt.Columns.Add("ActualWeight");
        //    dt.Columns.Add("NOP");
        //    dt.Columns.Add("RecWeight");
        //    dt.Columns.Add("DeliveryDate");
        //    dt.Columns.Add("DeliveryTime");
        //    dt.Columns.Add("ReachedDate");
        //    dt.Columns.Add("ReachedTime");
        //    dt.Columns.Add("UnloadedDate");
        //    dt.Columns.Add("UnloadedTime");
        //    dt.Columns.Add("PODStatus");
          
        //    dt.Columns.Add("NCAmount");
        //    dt.Columns.Add("NCReason");
        //    dt.Columns.Add("Remarks");
        //    dt.Columns.Add("ToLocation");
        //    dt.Columns.Add("ReceviedBy");
        //    dt.Columns.Add("UploadFile1");
        //    dt.Columns.Add("UploadFile2");
        //    dt.Columns.Add("UploadFile3");
        //    dt.Columns.Add("UploadFile4");

        //    foreach (PODForwardDetSearchFetch POD in data)
        //    {
        //        dt.Rows.Add(
        //                      POD.LSPName
        //                    , POD.LSPCode
        //                    , (POD.TrnType == "F") ? "Forward" : "Return"
        //                    , POD.LRNo
        //                    , POD.LRDate
        //                    , POD.OrderNo
        //                    , POD.Origin
        //                    , POD.Destination
        //                    , POD.VehicleNo
        //                    , POD.Distibutor
        //                    , POD.CustomerCode
        //                    , POD.Customer
        //                    , POD.DispatchNOP
        //                    , POD.DispatchWeight
        //                    , POD.ActualWeight
        //                    , POD.NOP
        //                    , POD.RecWeight
        //                    , POD.DeliveryDate
        //                    , POD.DeliveryTime
        //                    , POD.ReachedDate
        //                    , POD.ReachedTime
        //                    , POD.UnloadedDate
        //                    , POD.UnloadedTime
        //                    , POD.PODStatus

        //                    , POD.NCAmount
        //                    , POD.NCReason
        //                    , POD.Remarks
        //                    , POD.ToLocation
        //                    , POD.ReceviedBy
        //                    , POD.UploadFile1
        //                    , POD.UploadFile2
        //                    , POD.UploadFile3
        //                    , POD.UploadFile4
        //                    );
        //    }
        //    try
        //    {
        //        ExcelPackage excel = new ExcelPackage();
        //        var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
        //        workSheet.Cells[1, 1].LoadFromDataTable(dt, true);
        //        workSheet.Cells["A1"].Value = "LSP Name";
        //        workSheet.Cells["B1"].Value = "LSP Code";
        //        workSheet.Cells["C1"].Value = "Transaction Type";
        //        workSheet.Cells["D1"].Value = "LR No.";
        //        workSheet.Cells["E1"].Value = "LR Date";
        //        workSheet.Cells["F1"].Value = "Invoice No.";
        //        workSheet.Cells["G1"].Value = "Origin";
        //        workSheet.Cells["H1"].Value = "Destination";
        //        workSheet.Cells["I1"].Value = "Vehicle No";
        //        workSheet.Cells["J1"].Value = "Distributor Channel";
        //        workSheet.Cells["K1"].Value = "Customer Code";
        //        workSheet.Cells["L1"].Value = "Customer";
        //        workSheet.Cells["M1"].Value = "As Per LR Pkg/Box/Bales.";
        //        workSheet.Cells["N1"].Value = "Actual Wt.";
        //        workSheet.Cells["O1"].Value = "Chargeable Wt.(kg)/ltr./Volumetric Wt.";
        //        workSheet.Cells["P1"].Value = "As Per POD Pkg/Box/Bales.*";
        //        workSheet.Cells["Q1"].Value = "As Per POD Tot.Wt.(kg)/ltr./Volumetric Wt.*";
        //        workSheet.Cells["R1"].Value = "Delivery Date*(DD-MM-YYYY)";
        //        workSheet.Cells["S1"].Value = "Delivery Time*(HH:MM)";
        //        workSheet.Cells["T1"].Value = "Reached Date(DD-MM-YYYY)";
        //        workSheet.Cells["U1"].Value = "Reached Time(HH:MM)";
        //        workSheet.Cells["V1"].Value = "Unloaded Date(DD-MM-YYYY)";
        //        workSheet.Cells["W1"].Value = "Unloaded Time(HH:MM)";
        //        workSheet.Cells["X1"].Value = "POD Status*(REFUSED/HOLD/LSP ISSUE/CONSIGNEE ADDRESS CLOSED/COMPLETE)";
        //        workSheet.Cells["Y1"].Value = "Refused Date(DD-MM-YYYY)";
        //        workSheet.Cells["Z1"].Value = "NC Amount";
        //        workSheet.Cells["AA1"].Value = "NC Reason";
        //        workSheet.Cells["AB1"].Value = "Location Code*";
        //        workSheet.Cells["AC1"].Value = "Remarks";
        //        workSheet.Cells["AD1"].Value = "Recevied By";
        //        workSheet.Cells["AE1"].Value = "Upload File 1";
        //        workSheet.Cells["AF1"].Value = "Upload File 2";
        //        workSheet.Cells["AG1"].Value = "Upload File 3";
        //        workSheet.Cells["AH1"].Value = "Upload File 4";


        //        var HeaderCells = workSheet.Cells["A1,B1,C1,D1,E1,F1,G1,H1,I1,J1,K1,L1,M1,N1,O1,P1,Q1,R1,S1,T1,U1,V1,W1,X1,Y1,Z1,AA1,AB1,AC1,AD1,AE1,AF1,AG1,AH1"];
        //        HeaderCells.Style.Font.Bold = true;
        //        HeaderCells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //        var HeaderMandatoryCells = workSheet.Cells["P1,Q1,R1,S1,X1,AB1"];
        //        HeaderMandatoryCells.Style.Font.Color.SetColor(Color.Red);


        //        var start = workSheet.Dimension.Start;
        //        var end = workSheet.Dimension.End;

        //        for (int row = start.Row; row <= end.Row; row++)
        //        { // Row by row...
        //            for (int col = start.Column; col <= end.Column; col++)
        //            { // ... Cell by cell...   
        //                workSheet.Cells[row, col].Style.WrapText = true;
        //                workSheet.Cells[row, col].AutoFitColumns();
        //                workSheet.Column(col).Width = 30;
        //                workSheet.Cells[row, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //                workSheet.Cells[row, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //                workSheet.Cells[row, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //                workSheet.Cells[row, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //                //Set BgColor for Input fields 
        //                if (col >= 16)
        //                {
        //                    workSheet.Cells[row, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                    workSheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(BgColor);
        //                }
        //            }
        //        }
        //        string fileName = "POD";
        //        string fileNameWithtime = fileName + DateTime.Now.ToString("dd-MMM-yyyy_hh_mm_ss");
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //            Response.AddHeader("content-disposition", "attachment;  filename=" + fileNameWithtime + ".xlsx");
        //            excel.SaveAs(memoryStream);
        //            memoryStream.WriteTo(Response.OutputStream);
        //            Response.Flush();
        //            Response.End();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}

        //[System.Web.Http.HttpGet]
        //[ActionName("SequenceReport")]
        //public void SequenceReport()
        //{
        //    //   List<Color> Itemcolors = new List<Color>();
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Brown"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Orange"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Violet"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("PaleGreen"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("LightPink"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Red"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Lavender"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Turquoise"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Pink"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Khaki"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Wheat"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Blue"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Tan"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("DimGray"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Green"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Purple"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("MediumBlue"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("BlanchedAlmond"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Bisque"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("White"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("White"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("RosyBrown"));
        //    //Itemcolors.Add(ColorTranslator.FromHtml("Turquoise"));

        //    List<Color> Itemcolors = new List<Color>();
        //    Itemcolors.Add(ColorTranslator.FromHtml("Tomato"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("Orange"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("Violet"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("SlateBlue"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("LightPink"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("Bisque"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("Lavender"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("LightBlue"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("Turquoise"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("PaleTurquoise"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("Wheat"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("Turquoise"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("PaleGreen"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("RosyBrown"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("Green"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("Khaki"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("HotPink"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("BlanchedAlmond"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("LightSteelBlue"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("Plum"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("White"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("Olive"));
        //    Itemcolors.Add(ColorTranslator.FromHtml("Teal"));


        //    // Itemcolors.Add("#FFF0F8FF");

        //    string fileName = "SequenceReport";

        //    var context = System.Web.HttpContext.Current;
        //    var SeqRequest = (SysExecelDetails)context.Cache["ObjSeqDet"];
        //    List<Vehicletypedetails> data1 = SeqRequest.Vehicletype;
        //    List<VehicletypeLoading> data2 = SeqRequest.VehLoad;

        //    List<CompareLspFTLRowXL> data = SeqRequest.CompareLspFTL; 
        //    if (data == null || data.Count <= 0)
        //    {
        //        data = new List<CompareLspFTLRowXL>();
        //    }

        //    //DataTable dt = new DataTable("tblData");
        //    //dt.Columns.Add("RowId");
        //    //dt.Columns.Add("WayofPutting");
        //    //dt.Columns.Add("Height");
        //    //dt.Columns.Add("Width");
        //    //dt.Columns.Add("Length");
        //    //dt.Columns.Add("Qty");

        //    //foreach (CompareLspFTLRowXL POD in data)
        //    //{
        //    //    dt.Rows.Add(POD.RowId
        //    //                  , POD.WayofPutting,
        //    //                  POD.Height
        //    //                , POD.Width
        //    //                , POD.Length
        //    //                , POD.Qty
        //    //                );
        //    //}

        //    //try
        //    //{
        //    //    ExcelPackage excel = new ExcelPackage();
        //    //    var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
        //    //    workSheet.Cells[1, 1].LoadFromDataTable(dt, true);
        //    //    workSheet.Cells["A1"].Value = " Row No";
        //    //    workSheet.Cells["B1"].Value = "Way of Putting";
        //    //    workSheet.Cells["C1"].Value = "Height";
        //    //    workSheet.Cells["D1"].Value = "Width";
        //    //    workSheet.Cells["E1"].Value = "Length";
        //    //    workSheet.Cells["F1"].Value = "Quantity.";


        //    //    var HeaderCells = workSheet.Cells["A1,B1,C1,D1,E1,F1,G1,H1,I1,J1,K1,L1,M1,N1,O1,P1,Q1,R1,S1,T1,U1,V1,W1,X1,Y1,Z1,AA1,AB1,AC1,AD1,AE1,AF1,AG1,AH1"];



        //    DataTable dt = new DataTable("tblData");
        //    dt.Columns.Add("NewPosition");
        //    dt.Columns.Add("RowId");
        //    dt.Columns.Add("levcol");
        //    dt.Columns.Add("WayofPutting");
        //    dt.Columns.Add("Length");
        //    dt.Columns.Add("Width");
        //    dt.Columns.Add("Height");
        //    dt.Columns.Add("InvoiceNo");
        //    dt.Columns.Add("ItemName");
        //    dt.Columns.Add("ItemCode");
        //    dt.Columns.Add("Qty");
        //    dt.Columns.Add("Level");
        //    dt.Columns.Add("Column");
        //     dt.Columns.Add("color"); 





        //    foreach (CompareLspFTLRowXL POD in data)
        //    {
        //        dt.Rows.Add(
        //                    POD.NewPosition,
        //                      POD.RowId
        //                     , POD.levcol
        //                     , POD.WayofPutting
        //                     , POD.Length
        //                     , POD.Width
        //                     , POD.Height
        //                     , POD.InvoiceNo
        //                     , POD.ItemName
        //                     , POD.ItemCode
        //                     , POD.Qty
        //                     , POD.Level
        //                     , POD.Column
        //                     ,POD.color
        //                    );
        //    }
        //    //fileName += DateTime.Now.ToString("dd-MMM-yyyy_hh_mm_ss") +".xls";
        //    //HttpContext.Current.Response.Clear();
        //    //HttpContext.Current.Response.Buffer = true;
        //    //HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "");
        //    //HttpContext.Current.Response.Charset = "";
        //    //HttpContext.Current.Response.ContentType =  "application/ms-excel";
        //    //HttpContext.Current.Response.ContentEncoding = Encoding.Unicode;
        //    //HttpContext.Current.Response.BinaryWrite(Encoding.Unicode.GetPreamble());
        //    //HttpContext.Current.Response.Write(str);
        //    //HttpContext.Current.Response.Flush();
        //    // HttpContext.Current.Response.End();

        //    try
        //    {
        //        ExcelPackage excel = new ExcelPackage();
        //        var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
        //        workSheet.Cells[2, 1].LoadFromDataTable(dt, true);

        //        workSheet.Cells["A1"].Value =data1[0].Vehicletype;
        //        workSheet.Cells["B1"].Value = data1[0].volumedetails;
        //        workSheet.Cells["C1"].Value = data1[0].Weightdetails;
        //        workSheet.Cells["D1"].Value = data1[0].Dateofgen;
        //        workSheet.Cells["A2"].Value = "Position";
        //        workSheet.Cells["B2"].Value = "Row No";
        //        workSheet.Cells["C2"].Value = "Level*Column";
        //        workSheet.Cells["D2"].Value = "Way of Putting";
        //        workSheet.Cells["E2"].Value = "Length";
        //        workSheet.Cells["F2"].Value = "Width";
        //        workSheet.Cells["G2"].Value = "Height";

        //        workSheet.Cells["H2"].Value = "InvoiceNumber";
        //        workSheet.Cells["I2"].Value = "ItemName";
        //        workSheet.Cells["J2"].Value = "ItemCode";
        //        workSheet.Cells["K2"].Value = "Quantity.";
        //        workSheet.Cells["L2"].Value = "Level";
        //        workSheet.Cells["M2"].Value = "Column";



        //        var HeaderCells = workSheet.Cells["A2,B2,C2,D2,E2,F2,G2,H2,I2,J2,K2,L2,M2"];
        //        HeaderCells.Style.Font.Bold = true;
        //        HeaderCells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //        var HeaderMandatoryCells = workSheet.Cells["P1,Q1,R1,S1,X1,AB1,AD1"];
        //        HeaderMandatoryCells.Style.Font.Color.SetColor(Color.Red);
        //       // var colotex = workSheet.Cells["J1"].Value;
        //       // Color BgColor = ColorTranslator.FromHtml(colotex);
        //        var start = workSheet.Dimension.Start;
        //        var end = workSheet.Dimension.End;
            

        //        for (int row = start.Row; row < end.Row-2; row++)
        //        { // Row by row...
        //            for (int col = start.Column; col <= end.Column; col++)
        //            { // ... Cell by cell...   
        //                workSheet.Cells[row, col].Style.WrapText = true;
        //              // workSheet.Cells[row, col].Style.Font.Color.SetColor(workSheet.Cells[row, col].Value);


        //               workSheet.Cells[row, col].AutoFitColumns();
        //                workSheet.Column(col).Width = 30;
        //                workSheet.Cells[row, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //                workSheet.Cells[row, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //                workSheet.Cells[row, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //                workSheet.Cells[row, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;

        //                if (row-1== end.Row)
        //                {
        //                    workSheet.Cells[row+1, col].AutoFitColumns();
        //                    workSheet.Column(col).Width = 30;
        //                    workSheet.Cells[row+1, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //                    workSheet.Cells[row+1, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //                    workSheet.Cells[row+1, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //                    workSheet.Cells[row+1, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;

        //                }


        //                //Set BgColor for Input fields 
        //                if (col >= 1)
        //                {
        //                    workSheet.Cells[row+2, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                    workSheet.Cells[row+2, col].Style.Fill.BackgroundColor.SetColor(Itemcolors[Convert.ToInt32(dt.Rows[row-1][13].ToString())]); 
        //                }
        //            }
        //        }

        //        string fileNameWithtime = fileName + DateTime.Now.ToString("dd-MMM-yyyy_hh_mm_ss");
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //            Response.AddHeader("content-disposition", "attachment;  filename=" + fileNameWithtime + ".xlsx");
        //            excel.SaveAs(memoryStream);
        //            memoryStream.WriteTo(Response.OutputStream);
        //            Response.Flush();
        //            Response.End();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}





      //  [System.Web.Http.HttpGet]
      //  [ActionName("ManualSequenceReport")]
      //  public void ManualSequenceReport()
      //  {
      //      List<Color> Itemcolors = new List<Color>();
      //      Itemcolors.Add(ColorTranslator.FromHtml("Tomato"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("Orange"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("Violet"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("SlateBlue"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("LightPink"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("Bisque"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("Lavender"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("LightBlue"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("Turquoise"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("PaleTurquoise"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("Wheat"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("Turquoise"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("PaleGreen"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("RosyBrown"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("Green"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("Khaki"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("HotPink"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("BlanchedAlmond"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("LightSteelBlue"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("Plum"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("White"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("Olive"));
      //      Itemcolors.Add(ColorTranslator.FromHtml("Teal"));


      //      // Itemcolors.Add("#FFF0F8FF");

      //      string fileName = "SequenceReport";

      //      var context = System.Web.HttpContext.Current;

            
      //            var SeqRequest = (ExecelDetails)context.Cache["ObjSeqDet"];
      //      // var SeqRequest = (List<ManualCompareLspFTLRowXL>)context.Cache["ObjSeqDet"];
      ////      var SeqRequest = (ExecelDetails)context.Cache["ObjSeqDet"];

      //      List<Vehicletypedetails> data1 = SeqRequest.Vehicletypedet;
      //      List<VehicletypeLoading> data2 = SeqRequest.VehLoad;

      //      List<ManualCompareLspFTLRowXL> data = SeqRequest.ManualCompareLsp; 
      //      if (data == null || data.Count <= 0)
      //      {
      //          data = new List<ManualCompareLspFTLRowXL>();
      //      }
            



      //      DataTable dt = new DataTable("tblData");
            

      //    dt.Columns.Add("NewPosition");
      //      dt.Columns.Add("RowId");
      //      dt.Columns.Add("levcol");          
      //      dt.Columns.Add("WayofPutting");
      //      dt.Columns.Add("Length");
      //      dt.Columns.Add("Width");
      //      dt.Columns.Add("Height");                         
      //      dt.Columns.Add("InvoiceNo");
      //      dt.Columns.Add("ItemName");
      //      dt.Columns.Add("ItemCode");
      //      dt.Columns.Add("Qty");
      //      dt.Columns.Add("Level");
      //      dt.Columns.Add("Column");
      //      dt.Columns.Add("color");    
            
      //      foreach (ManualCompareLspFTLRowXL POD in data)
      //      {
      //          dt.Rows.Add(   POD.NewPosition,
      //                        POD.RowId
      //                       ,POD.levcol
      //                       , POD.WayofPutting
      //                       , POD.Length
      //                       , POD.Width
      //                       , POD.Height                                                                               
      //                       , POD.InvoiceNo
      //                       , POD.ItemName
      //                       , POD.ItemCode
      //                       , POD.Qty
      //                       , POD.Level
      //                       , POD.Column
      //                       , POD.color                       
                            
      //                      );            }
            

      //      try
      //      {
      //          ExcelPackage excel = new ExcelPackage();
      //          var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
      //          workSheet.Cells[2, 1].LoadFromDataTable(dt, true);
      //          workSheet.Cells["A1"].Value = data1[0].Vehicletype;
      //          workSheet.Cells["B1"].Value = data1[0].volumedetails ;
      //          workSheet.Cells["C1"].Value = data1[0].Weightdetails;
      //          workSheet.Cells["D1"].Value = data1[0].Dateofgen;

      //          workSheet.Cells["A2"].Value = "Position";
      //          workSheet.Cells["B2"].Value = "Row No";
      //          workSheet.Cells["C2"].Value = "Level*Column";            
      //          workSheet.Cells["D2"].Value = "Way of Putting";
      //          workSheet.Cells["E2"].Value = "Length";
      //          workSheet.Cells["F2"].Value = "Width";
      //          workSheet.Cells["G2"].Value = "Height";                             
            
      //          workSheet.Cells["H2"].Value = "InvoiceNumber";
      //          workSheet.Cells["I2"].Value = "ItemName";
      //          workSheet.Cells["J2"].Value = "ItemCode";
      //          workSheet.Cells["K2"].Value = "Quantity.";
      //          workSheet.Cells["L2"].Value = "Level";
      //          workSheet.Cells["M2"].Value = "Column";

      //          // workSheet.Cells["M2"].Value = "VehicleTypeName";
      //       //   workSheet.Cells["N2"].Value = "color";




      //          var HeaderCells = workSheet.Cells["A2,B2,C2,D2,E2,F2,G2,H2,I2,J2,K2,L2,M2"];
      //          HeaderCells.Style.Font.Bold = true;
      //          HeaderCells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
      //          var HeaderMandatoryCells = workSheet.Cells["P1,Q1,R1,S1,X1,AB1,AD1"];
      //          HeaderMandatoryCells.Style.Font.Color.SetColor(Color.Red);
      //          // var colotex = workSheet.Cells["J1"].Value;
      //          // Color BgColor = ColorTranslator.FromHtml(colotex);
      //          var start = workSheet.Dimension.Start;
      //          var end = workSheet.Dimension.End;


      //          for (int row = start.Row; row < end.Row-2; row++)
      //          { // Row by row...
      //              for (int col = start.Column; col <= end.Column; col++)
      //              { // ... Cell by cell...   
      //                  workSheet.Cells[row, col].Style.WrapText = true;
      //                  // workSheet.Cells[row, col].Style.Font.Color.SetColor(workSheet.Cells[row, col].Value);


      //                  workSheet.Cells[row, col].AutoFitColumns();
      //                  workSheet.Column(col).Width = 30;
      //                  workSheet.Cells[row, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
      //                  workSheet.Cells[row, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
      //                  workSheet.Cells[row, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
      //                  workSheet.Cells[row, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;

      //                  if (row - 1 == end.Row)
      //                  {
      //                      workSheet.Cells[row + 1, col].AutoFitColumns();
      //                      workSheet.Column(col).Width = 30;
      //                      workSheet.Cells[row + 1, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
      //                      workSheet.Cells[row + 1, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
      //                      workSheet.Cells[row + 1, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
      //                      workSheet.Cells[row + 1, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;

      //                  }


      //                  //Set BgColor for Input fields 
      //                  if (col >= 1)
      //                  {
      //                      workSheet.Cells[row + 2, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
      //                      workSheet.Cells[row + 2, col].Style.Fill.BackgroundColor.SetColor(Itemcolors[Convert.ToInt32(dt.Rows[row - 1][13].ToString())]);
      //                  }
      //              }
      //          }

      //          string fileNameWithtime = fileName + DateTime.Now.ToString("dd-MMM-yyyy_hh_mm_ss");
      //          using (var memoryStream = new MemoryStream())
      //          {
      //              Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
      //              Response.AddHeader("content-disposition", "attachment;  filename=" + fileNameWithtime + ".xlsx");
      //              excel.SaveAs(memoryStream);
      //              memoryStream.WriteTo(Response.OutputStream);
      //              Response.Flush();
      //              Response.End();
      //          }

      //      }
      //      catch (Exception ex)
      //      {

      //      }

      //  }






      //  [System.Web.Http.HttpGet]
      //  [ActionName("GetNCfile")]
      //  public void GetNCfile()
      //  {
      //      NcChargeRepository _NcRepository = new NcChargeRepository();
      //      var context = System.Web.HttpContext.Current;
      //      var NCUploadRequest = (NcUpload)context.Cache["NCUploadRequest"];
      //      List<NcUploadDet> data = _NcRepository.GetNCDetails(NCUploadRequest);
      //      if (data == null || data.Count <= 0)
      //      {
      //          data = new List<NcUploadDet>();
      //      }
      //      DataTable dt = new DataTable("tblData");
      //      dt.Columns.Add("LSPName");
      //      dt.Columns.Add("LSPCode");
      //      dt.Columns.Add("TrnType");
      //      dt.Columns.Add("LRNo");
      //      dt.Columns.Add("LRDate");
      //      dt.Columns.Add("TravelFromDate");
      //      dt.Columns.Add("TravelToDate");
      //      dt.Columns.Add("Origin");
      //      dt.Columns.Add("Destination");
      //      dt.Columns.Add("BusinessUnit");
      //      dt.Columns.Add("NoOfPackage");
      //      dt.Columns.Add("WeightKg");
      //      dt.Columns.Add("VolumetricWeightKg");
      //      dt.Columns.Add("ChargeableWeightKg");
      //      dt.Columns.Add("ExtraCharge");
      //      dt.Columns.Add("remarks");
      //      dt.Columns.Add("DocumentPath");
           
      //      foreach (NcUploadDet NC in data)
      //      {
      //          dt.Rows.Add(
      //                          NC.LSPName
      //                        , NC.LSPCode
      //                        ,(NC.TrnType == "F") ? "Forward" : "Return"
      //                        , NC.LRNo
      //                        , NC.LRDate
      //                        , NC.TravelFromDate
      //                        , NC.TravelToDate
      //                        , NC.Origin
      //                        , NC.Destination
      //                        , NC.BusinessUnit
      //                        , NC.NoOfPackage
      //                        , NC.WeightKg
      //                        , NC.VolumetricWeightKg
      //                        , NC.ChargeableWeightKg
      //                        , NC.ExtraCharge
      //                        , NC.remarks
      //                        , NC.DocumentPath
      //                      );
      //      }
      //      try
      //      {
      //          ExcelPackage excel = new ExcelPackage();
      //          var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
      //          workSheet.Cells[1, 1].LoadFromDataTable(dt, true);
      //          workSheet.Cells["A1"].Value = "LSP Name";
      //          workSheet.Cells["B1"].Value = "LSP Code";
      //          workSheet.Cells["C1"].Value = "Transaction Type";
      //          workSheet.Cells["D1"].Value = "LR No.";
      //          workSheet.Cells["E1"].Value = "LR Date";
      //          workSheet.Cells["F1"].Value = "Travel From Date";
      //          workSheet.Cells["G1"].Value = "Travel End Date";
      //          workSheet.Cells["H1"].Value = "Origin";
      //          workSheet.Cells["I1"].Value = "Destination";
      //          workSheet.Cells["J1"].Value = "Business Unit";
      //          workSheet.Cells["K1"].Value = "Pkg/Box/Bales";
      //          workSheet.Cells["L1"].Value = "Actual Wt.(kg)/ltr.";
      //          workSheet.Cells["M1"].Value = "Volumetric Wt.(kg)";
      //          workSheet.Cells["N1"].Value = "Chargeable Wt.(kg)/ltr.";
      //          workSheet.Cells["O1"].Value = "NC Charge*";
      //          workSheet.Cells["P1"].Value = "NC Charge Reason*";
      //          workSheet.Cells["Q1"].Value = "Upload File Name";

      //          var HeaderCells = workSheet.Cells["A1,B1,C1,D1,E1,F1,G1,H1,I1,J1,K1,L1,M1,N1,O1,P1,Q1"];
      //          HeaderCells.Style.Font.Bold = true;
      //          HeaderCells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
      //          var HeaderMandatoryCells = workSheet.Cells["O1,P1"];
      //          HeaderMandatoryCells.Style.Font.Color.SetColor(Color.Red);

      //          var start = workSheet.Dimension.Start;
      //          var end = workSheet.Dimension.End;

      //          for (int row = start.Row; row <= end.Row; row++)
      //          { // Row by row...
      //              for (int col = start.Column; col <= end.Column; col++)
      //              { // ... Cell by cell...   
      //                  workSheet.Cells[row, col].Style.WrapText = true;
      //                  workSheet.Cells[row, col].AutoFitColumns();
      //                  workSheet.Column(col).Width = 30;
      //                  workSheet.Cells[row, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
      //                  workSheet.Cells[row, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
      //                  workSheet.Cells[row, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
      //                  workSheet.Cells[row, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
      //                  //Set BgColor for Input fields 
      //                  if (col >= 15)
      //                  {
      //                      workSheet.Cells[row, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
      //                      workSheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(BgColorYellow);
      //                  }
      //              }
      //          }
      //          string fileName = "NCUpload_";
      //          string fileNameWithtime = fileName + DateTime.Now.ToString("dd-MMM-yyyy_hh_mm_ss");
      //          using (var memoryStream = new MemoryStream())
      //          {
      //              Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
      //              Response.AddHeader("content-disposition", "attachment;  filename="+ fileNameWithtime+".xlsx");
      //              excel.SaveAs(memoryStream);
      //              memoryStream.WriteTo(Response.OutputStream);
      //              Response.Flush();
      //              Response.End();
      //          }
      //      }
      //      catch (Exception ex)
      //      {

      //      }
      //  }


      //  [System.Web.Http.HttpGet]
      //  [ActionName("GetLRfile")]
      //  public void GetLRfile()
      //  {
      //      NcChargeRepository _NcRepository = new NcChargeRepository();
      //      var context = System.Web.HttpContext.Current;
      //      var OneCompareOneLRnoModel = (OneCompareOneLRnoModel)context.Cache["OneCompareOneLRnoModel"];
      //      OneCompareOneLRnoRepository _objOneCompareOneLRnoRepository = new OneCompareOneLRnoRepository();
      //      //  List<OneCompareOneLRnoDet> data = _objOneCompareOneLRnoRepository.Fetch_OneCompareOneLRno(OneCompareOneLRnoModel);
      //      FinalEwayBillNoList data = _objOneCompareOneLRnoRepository.Fetch_OneCompareOneLRno(OneCompareOneLRnoModel);
      //      if (data == null || data.OneCompareOneLRnoDet.Count <= 0)
      //      {
      //          data.OneCompareOneLRnoDet = new List<OneCompareOneLRnoDet>();
      //      }

      //      DataTable dt = new DataTable("tblData");
      //      dt.Columns.Add("Origin");
      //      dt.Columns.Add("ShipTo");
      //      dt.Columns.Add("Destination");
      //      dt.Columns.Add("CustomerCode");
      //      dt.Columns.Add("CustomerName");
      //      dt.Columns.Add("InvoiceNo");
      //      dt.Columns.Add("InvoiceDate");
      //      dt.Columns.Add("InvoiceValue");
      //      dt.Columns.Add("PackagesBoxBales");
      //      dt.Columns.Add("Qty_Mtrs_Nos");
      //      dt.Columns.Add("NOP");
      //      dt.Columns.Add("TotalChargeableWeight");
      //      dt.Columns.Add("TotalWeight");
      //      //dt.Columns.Add("TotalVolume");
      //      //dt.Columns.Add("VolumetricWeight");//as actual wt.
      //      dt.Columns.Add("LRNo");
      //      dt.Columns.Add("LRDate");
      //      dt.Columns.Add("EWayBillNo");
      //      dt.Columns.Add("EwayBillDate");
      //      dt.Columns.Add("EWayBillValidDate");
      //      dt.Columns.Add("PickAcceptedDate");
      //      dt.Columns.Add("PickUpTime");
      //      dt.Columns.Add("Remarks");

      //      foreach (OneCompareOneLRnoDet LR in data.OneCompareOneLRnoDet)
      //      {
      //          dt.Rows.Add(
      //                          LR.Origin
      //                        , LR.ShipTo
      //                        , LR.Destination
      //                        , LR.CustomerCode
      //                        , LR.CustomerName
      //                        , LR.InvoiceNo
      //                        , LR.InvoiceDate
      //                        , LR.InvoiceValue
      //                        , LR.PackagesBoxBales
      //                        , LR.Qty_Mtrs_Nos
      //                        , LR.NOP
      //                        , LR.TotalChargeableWeight
      //                        , LR.TotalWeight
      //                        // , LR.TotalVolume
      //                        //, LR.TotalWeight
      //                        , LR.LRNo
      //                        , LR.LRDate
      //                        , LR.EWayBillNo
      //                        , LR.EwayBillDate
      //                        , LR.EWayBillValidDate
      //                        , LR.PickAcceptedDate
      //                        , LR.PickUpTime
      //                        , LR.Remarks
      //                      );
      //      }
      //      try
      //      {
      //          ExcelPackage excel = new ExcelPackage();
      //          var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
      //          workSheet.Cells[1, 1].LoadFromDataTable(dt, true);
      //          workSheet.Cells["A1"].Value = "Origin";
      //          workSheet.Cells["B1"].Value = "Ship To";
      //          workSheet.Cells["C1"].Value = "Destination";
      //          workSheet.Cells["D1"].Value = "Customer Code";
      //          workSheet.Cells["E1"].Value = "Customer Name";
      //          workSheet.Cells["F1"].Value = "Invoice No.";
      //          workSheet.Cells["G1"].Value = "Invoice Date";
      //          workSheet.Cells["H1"].Value = "Invoice Value";
      //          workSheet.Cells["I1"].Value = "Pkg/ Box/ Bales";
      //          workSheet.Cells["J1"].Value = "Qty.- Mtr/No.";
      //          workSheet.Cells["K1"].Value = "NOP";
      //          workSheet.Cells["L1"].Value = "Chargeable Wt.";
      //          workSheet.Cells["M1"].Value = "Actual Wt.(kg)/ltr.";//Actual Wt.
      //          workSheet.Cells["N1"].Value = "LR No.";
      //          workSheet.Cells["O1"].Value = "LR Date";
      //          workSheet.Cells["P1"].Value = "E-Way Bill No.";
      //          workSheet.Cells["Q1"].Value = "E-way Bill Date";
      //          workSheet.Cells["R1"].Value = "E-Way Bill Validity Date";
      //          workSheet.Cells["S1"].Value = "Pickup Date*(DD-MM-YYYY)";
      //          workSheet.Cells["T1"].Value = "Pickup Time*(HH:MM)";
      //          workSheet.Cells["U1"].Value = "Remarks";
      //          //workSheet.Cells["V1"].Value = "";
      //          //workSheet.Cells["W1"].Value = "";

      //          var HeaderCells = workSheet.Cells["A1,B1,C1,D1,E1,F1,G1,H1,I1,J1,K1,L1,M1,N1,O1,P1,Q1,R1,S1,T1,U1"];
      //          HeaderCells.Style.Font.Bold = true;
      //          HeaderCells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
      //          var HeaderMandatoryCells = workSheet.Cells["S1,T1"];
      //          HeaderMandatoryCells.Style.Font.Color.SetColor(Color.Red);

      //          var start = workSheet.Dimension.Start;
      //          var end = workSheet.Dimension.End;

      //          for (int row = start.Row; row <= end.Row; row++)
      //          { // Row by row...
      //              for (int col = start.Column; col <= end.Column; col++)
      //              { // ... Cell by cell...   
      //                  workSheet.Cells[row, col].Style.WrapText = true;
      //                  workSheet.Cells[row, col].AutoFitColumns();
      //                  workSheet.Column(col).Width = 30;
      //                  workSheet.Cells[row, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
      //                  workSheet.Cells[row, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
      //                  workSheet.Cells[row, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
      //                  workSheet.Cells[row, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
      //                  //Set BgColor for Input fields 
      //                  if (col >= 19)
      //                  {
      //                      workSheet.Cells[row, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
      //                      workSheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(BgColorYellow);
      //                  }
      //              }
      //          }
      //          string fileName = "LR_Acceptance_";
      //          string fileNameWithtime = fileName + DateTime.Now.ToString("dd-MMM-yyyy_hh_mm_ss");
      //          using (var memoryStream = new MemoryStream())
      //          {
      //              Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
      //              Response.AddHeader("content-disposition", "attachment;  filename=" + fileNameWithtime + ".xlsx");
      //              excel.SaveAs(memoryStream);
      //              memoryStream.WriteTo(Response.OutputStream);
      //              Response.Flush();
      //              Response.End();
      //          }
      //      }
      //      catch (Exception ex)
      //      {

      //      }
      //  }


      //  [System.Web.Http.HttpGet]
      //  [ActionName("GetTripClosurefile")]
      //  public void GetTripClosurefile()
      //  {
      //      var context = System.Web.HttpContext.Current;
      //      var TripClosureRequest = (TripCompletionUpload)context.Cache["objTripCompletionUpload"];
      //      List<TripCompletionUploadDet> data = _TripClosureRepository.Fetch_TripCompletion(TripClosureRequest);
      //      if (data == null || data.Count <= 0)
      //      {
      //          data = new List<TripCompletionUploadDet>();
      //      }
      //      DataTable dt = new DataTable("tblData");
      //      dt.Columns.Add("WoNumber");
      //      dt.Columns.Add("WODate");
      //      dt.Columns.Add("TripDate");
      //      dt.Columns.Add("LSPCode");
      //      dt.Columns.Add("LSPName");
      //      dt.Columns.Add("VehicleType");
      //      dt.Columns.Add("VehicleNumber");
      //      dt.Columns.Add("StartDate");
      //      dt.Columns.Add("EndDate");
      //      dt.Columns.Add("StartTime");
      //      dt.Columns.Add("EndTime");
      //      dt.Columns.Add("StartKM");
      //      dt.Columns.Add("EndKM");

      //      foreach (TripCompletionUploadDet Trip in data)
      //      {
      //          dt.Rows.Add(
      //                        Trip.WoNumber
      //                      , Trip.WODate
      //                      , Trip.TripDate
      //                      , Trip.LSPCode
      //                      , Trip.LSPName
      //                      , Trip.VehicleType
      //                      , Trip.VehicleNumber
      //                      , Trip.StartDate
      //                      , Trip.EndDate
      //                      , Trip.StartTime
      //                      , Trip.EndTime
      //                      , Trip.StartKM
      //                      , Trip.EndKM
      //                      );
      //      }
      //      try
      //      {
      //          ExcelPackage excel = new ExcelPackage();
      //          ExcelTextFormat F = new ExcelTextFormat();
      //          var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
      //          workSheet.Cells[1, 1].LoadFromDataTable(dt, true);
      //          workSheet.Cells["A1"].Value = "WO No.";
      //          workSheet.Cells["B1"].Value = "WO Date (DD/MM/YYYY)";
      //          workSheet.Cells["C1"].Value = "Trip Date (DD/MM/YYYY)";
      //          workSheet.Cells["D1"].Value = "LSP Code";
      //          workSheet.Cells["E1"].Value = "LSP Name";
      //          workSheet.Cells["F1"].Value = "Vehicle Type";
      //          workSheet.Cells["G1"].Value = "Vehicle No.";
      //          workSheet.Cells["H1"].Value = "Start Date (DD/MM/YYYY)";
      //          workSheet.Cells["I1"].Value = "End Date (DD/MM/YYYY)";
      //          workSheet.Cells["J1"].Value = "Start Time (HH:TT:SS)";
      //          workSheet.Cells["K1"].Value = "End Time(HH:TT:SS)";
      //          workSheet.Cells["L1"].Value = "Start Km";
      //          workSheet.Cells["M1"].Value = "End Km";

      //          var HeaderCells = workSheet.Cells["A1,B1,C1,D1,E1,F1,G1,H1,I1,J1,K1,L1,M1"];
      //          HeaderCells.Style.Font.Bold = true;
      //          HeaderCells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
      //          var HeaderMandatoryCells = workSheet.Cells["I1,J1,K1,M1"];
      //          HeaderMandatoryCells.Style.Font.Color.SetColor(Color.Red);



      //          var start = workSheet.Dimension.Start;
      //          var end = workSheet.Dimension.End;

      //          for (int row = start.Row; row <= end.Row; row++)
      //          { // Row by row...
      //              for (int col = start.Column; col <= end.Column; col++)
      //              { // ... Cell by cell...   
      //                  workSheet.Cells[row, col].Style.WrapText = true;
      //                  workSheet.Cells[row, col].AutoFitColumns();
      //                  workSheet.Column(col).Width = 30;
      //                  workSheet.Cells[row, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
      //                  workSheet.Cells[row, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
      //                  workSheet.Cells[row, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
      //                  workSheet.Cells[row, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
      //                  //Set BgColor for Input fields 
      //                  if (col >= 9)
      //                  {
      //                      int row1 = row, col1 = col;
      //                      workSheet.Cells[row1, col1].Style.Fill.PatternType = ExcelFillStyle.LightUp;
      //                      workSheet.Cells[row1, col1].Style.Fill.BackgroundColor.SetColor(BgColorWhite);

      //                      workSheet.Cells[row, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
      //                      workSheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(BgColorYellow);



      //                  }
      //              }
      //          }
      //          string fileName = "TripClosure_";
      //          string fileNameWithtime = fileName + DateTime.Now.ToString("dd-MMM-yyyy_hh_mm_ss");
      //          using (var memoryStream = new MemoryStream())
      //          {
      //              Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
      //              Response.AddHeader("content-disposition", "attachment;  filename=" + fileNameWithtime + ".xlsx");
      //              excel.SaveAs(memoryStream);
      //              memoryStream.WriteTo(Response.OutputStream);
      //              Response.Flush();
      //              Response.End();
      //          }

      //      }
      //      catch (Exception ex)
      //      {

      //      }

      //  }

        //[System.Web.Http.HttpGet]
        //[ActionName("GetTATFile")]
        //public void GetTATFile()
        //{
        //    var context = System.Web.HttpContext.Current;
        //    var TATRequest = (TAT)context.Cache["objTATUpload"];
        //    List<TATDownloadFetch> data = TATResp.DownloadSearch_Fetch(TATRequest);
        //    if (data == null || data.Count <= 0)
        //    {
        //        data = new List<TATDownloadFetch>();
        //    }
        //    DataTable dt = new DataTable("tblData");
        //    dt.Columns.Add("FromLocations");
        //    dt.Columns.Add("ToLocations");
        //    dt.Columns.Add("TATDays");

        //    foreach (TATDownloadFetch Trip in data)
        //    {
        //        dt.Rows.Add(
        //                      Trip.FromLocations
        //                    , Trip.ToLocations
        //                    , Trip.TATDays

        //                    );
        //    }
        //    try
        //    {
        //        ExcelPackage excel = new ExcelPackage();
        //        var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
        //        workSheet.Cells[1, 1].LoadFromDataTable(dt, true);
        //        workSheet.Cells["A1"].Value = "From Locations";
        //        workSheet.Cells["B1"].Value = "To Locations";
        //        workSheet.Cells["C1"].Value = "TAT(Days)";            
               
               
               
                                      
        //        var HeaderCells = workSheet.Cells["A1,B1,C1"];
        //        HeaderCells.Style.Font.Bold = true;
        //        HeaderCells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //        var HeaderMandatoryCells = workSheet.Cells["A1,B1"];
        //        HeaderMandatoryCells.Style.Font.Color.SetColor(Color.Red);


        //        var start = workSheet.Dimension.Start;
        //        var end = workSheet.Dimension.End;

        //        for (int row = start.Row; row <= end.Row; row++)
        //        { // Row by row...
        //            for (int col = start.Column; col <= end.Column; col++)
        //            { // ... Cell by cell...   
        //                workSheet.Cells[row, col].Style.WrapText = true;
        //                workSheet.Cells[row, col].AutoFitColumns();
        //                workSheet.Column(col).Width = 30;
        //                workSheet.Cells[row, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //                workSheet.Cells[row, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //                workSheet.Cells[row, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //                workSheet.Cells[row, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //                //Set BgColor for Input fields 
        //                if (col <= 2)
        //                {
        //                    int row1 = 2, col1 = 2;
        //                    workSheet.Cells[row, col1].Style.Fill.PatternType = ExcelFillStyle.LightUp;
        //                    workSheet.Cells[row, col1].Style.Fill.BackgroundColor.SetColor(BgColorWhite);

        //                    workSheet.Cells[row, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                    workSheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(BgColorYellow);
        //                }
        //            }
        //        }
        //        string fileName = "TATExcel_";
        //        string fileNameWithtime = fileName + DateTime.Now.ToString("dd-MMM-yyyy_hh_mm_ss");
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //            Response.AddHeader("content-disposition", "attachment;  filename=" + fileNameWithtime + ".xlsx");
        //            excel.SaveAs(memoryStream);
        //            memoryStream.WriteTo(Response.OutputStream);
        //            Response.Flush();
        //            Response.End();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}





    }
}
