using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using POMS.Entity;
using POMS.Repository.Masters;
using POM.Repository;
using Repository;
using POMS.Repository;
using Repository.Masters;
using Repository.Operations;
using Repository.master;

namespace POMS.API.Controllers
{
    [RoutePrefix("Api/Download")]
    public class DownloadController : ApiController
    {

        [Route("GetFile")]
        [HttpGet]
        public HttpResponseMessage GetFile(string fileID)
        {
            HttpResponseMessage result = null;
            try
            {
                string strFilePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString;

                var localFilePath = Path.Combine(strFilePath, fileID);

                if (!System.IO.File.Exists(localFilePath))
                {
                    result = Request.CreateResponse(HttpStatusCode.Gone);
                }
                else
                {// serve the file to the client
                    //I have used the x-filename header to send the filename. This is a custom header for convenience.
                    //You should set the content-type mime header for your response too, so the browser knows the data format.
                    var info = System.IO.File.GetAttributes(localFilePath);
                    result = Request.CreateResponse(HttpStatusCode.OK);
                    result.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    result.Content.Headers.Add("x-filename", fileID);
                    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                    result.Content.Headers.ContentDisposition.FileName = fileID;
                }
                return result;
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        [Route("GetFile1")]
        [HttpGet]
        public HttpResponseMessage GetFile1(string fileID, string FilePath)
        {
            HttpResponseMessage result = null;
            try
            {
                string strFilePath = FilePath;

                var localFilePath = Path.Combine(strFilePath, fileID);

                if (!System.IO.File.Exists(localFilePath))
                {
                    result = Request.CreateResponse(HttpStatusCode.Gone);
                }
                else
                {// serve the file to the client
                    //I have used the x-filename header to send the filename. This is a custom header for convenience.
                    //You should set the content-type mime header for your response too, so the browser knows the data format.
                    var info = System.IO.File.GetAttributes(localFilePath);
                    result = Request.CreateResponse(HttpStatusCode.OK);
                    result.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    result.Content.Headers.Add("x-filename", fileID);
                    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                    result.Content.Headers.ContentDisposition.FileName = fileID;
                }
                return result;
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        [Route("GetUploadFiles")]
        [HttpGet]
        public HttpResponseMessage GetUploadFiles(string fileID)
        {
            HttpResponseMessage result = null;
            try
            {
                string strFilePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "\\SunPharmaUpload";

                var localFilePath = Path.Combine(strFilePath, fileID);

                if (!System.IO.File.Exists(localFilePath))
                {
                    result = Request.CreateResponse(HttpStatusCode.Gone);
                }
                else
                {// serve the file to the client
                    //I have used the x-filename header to send the filename. This is a custom header for convenience.
                    //You should set the content-type mime header for your response too, so the browser knows the data format.
                    var info = System.IO.File.GetAttributes(localFilePath);
                    result = Request.CreateResponse(HttpStatusCode.OK);
                    result.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    result.Content.Headers.Add("x-filename", fileID);
                    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                    result.Content.Headers.ContentDisposition.FileName = fileID;
                }
                return result;
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ActionName("ExportData")]
        public bool ExportData(ExportModel exportModel)
        {
            var context = HttpContext.Current;
            var pageRequest = new PageRequest();

            if (context != null)
            {
                context.Cache["ExportList"] = exportModel.ExportList;
                context.Cache["ExportType"] = exportModel.ExportType;
                context.Cache["PageRequest"] = exportModel.PageRequest;
                context.Cache["PageId"] = exportModel.PageId;
                context.Cache["FiltersQuery"] = pageRequest.GetFilterQuery(exportModel.Filters);
                return true;
            }
            return false;
        }

        [HttpGet]
        [ActionName("ExportExcelOrCSV")]
        public HttpResponseMessage ExportExcelOrCSV()
        {
            HttpResponseMessage result = null;
            var context = HttpContext.Current;
            var exportList = (List<Export>)context.Cache["ExportList"];
            var exportType = (ExportType)Convert.ToInt32(context.Cache["ExportType"]);
            //exportType = ExportType.Excel;
            string fileName = String.Empty;
            var InboundReport = (InboundReport)context.Cache["InboundReportList"];
            var OutboundReportSearch = (OutboundReportSearch)context.Cache["OutboundReportList"];
            var fileContent = GetExportContent(ref fileName, exportList, InboundReport, OutboundReportSearch);
            try
            {
                //result = Request.CreateResponse(HttpStatusCode.OK);
                ////result.Content = new StreamContent(new FileStream(fileContent, FileMode.Open, FileAccess.Read));
                //using (Stream stream = GenerateStreamFromString(fileContent))
                //{
                //    result.Content = new StreamContent(stream);
                //    result.Content.Headers.ContentType = new MediaTypeHeaderValue((exportType == ExportType.CSV) ? "application/text" : "application/ms-excel");
                //    result.Content.Headers.Add("x-filename", fileName += DateTime.Now.ToString("dd-MMM-yyyy_hh_mm_ss") + (exportType == ExportType.CSV ? ".csv" : ".xls"));
                //    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                //    result.Content.Headers.ContentDisposition.FileName = fileName += DateTime.Now.ToString("dd-MMM-yyyy_hh_mm_ss") + (exportType == ExportType.CSV ? ".csv" : ".xls");
                //}
                fileName += DateTime.Now.ToString("dd-MMM-yyyy_hh_mm_ss") + (exportType == ExportType.CSV ? ".csv" : ".xls");
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "");
                HttpContext.Current.Response.Charset = "";
                HttpContext.Current.Response.ContentType = (exportType == ExportType.CSV) ? "application/text" : "application/ms-excel";
                HttpContext.Current.Response.ContentEncoding = Encoding.Unicode;
                HttpContext.Current.Response.BinaryWrite(Encoding.Unicode.GetPreamble());
                HttpContext.Current.Response.Write(fileContent);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();

                return result;

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        private string GetExportContent(ref string fileName, List<Export> exportList, InboundReport InboundReport, OutboundReportSearch OutboundReportSearch)
        {
            var context = HttpContext.Current;
            var pageRequest = (PageRequest)context.Cache["PageRequest"];
            pageRequest.Query = Convert.ToString(context.Cache["FiltersQuery"]);
            pageRequest.PageNumber = 1;
            pageRequest.PageSize = Int32.MaxValue;
            // var inboundreport = (InboundReport)context.Cache["InboundReport"];

            var pageId = (PageId)Convert.ToInt32(context.Cache["PageId"]);

            dynamic list = GetExportList(pageRequest, pageId, ref fileName, InboundReport, OutboundReportSearch);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("<table><tr>");
            foreach (var columns in exportList)
            {
                if (columns.Visible)
                {
                    stringBuilder.Append("<td>");
                    var title = columns.Title;
                    title = !string.IsNullOrEmpty(title) ? title : columns.Name;
                    stringBuilder.Append(title);
                    stringBuilder.Append("</td>");
                }
            }

            stringBuilder.Append("</tr>");

            string[] propertyNames = exportList.Where(x => x.Visible).Select(x => x.Name).ToArray();

            foreach (var item in list)
            {
                stringBuilder.Append("<tr>");
                var temp = new Dictionary<string, object>();
                foreach (var prop in propertyNames)
                {
                    stringBuilder.Append("<td style='align:left;'>");
                    var value = item.GetType().GetProperty(prop).GetValue(item, null);
                    value = (value != null) ? value : "";
                    if (value.GetType().Name == "DateTime")
                    {
                        value = string.Format("{0:dd-MMM-yyyy}", value);
                    }
                    else
                    {
                        value = value.ToString();
                    }

                    stringBuilder.Append(value);
                    stringBuilder.Append("</td>");

                }
                stringBuilder.Append("</tr>");
            }

            stringBuilder.Append("</table>");
            return stringBuilder.ToString();
        }
        private dynamic GetExportList(PageRequest pageRequest, PageId pageId, ref string fileName, InboundReport InboundReport, OutboundReportSearch OutboundReportSearch)
        {
            dynamic result = null;
            switch (pageId)
            {
               
                case PageId.CommonRef:
                    {
                        CommonRefRepository _Repository = new CommonRefRepository();
                        result = _Repository.ComRefSearch(pageRequest).Item1;
                        fileName = "CommonRef";
                        break;
                    }
                case PageId.CommonMaster:
                    {
                        CommonMasterRepository _Repository = new CommonMasterRepository();
                        result = _Repository.CommonMaster_Search(pageRequest).Item1;
                        fileName = "CommonMaster";
                        break;
                    }
             
                case PageId.EmployeeMaster:
                    {
                        EmployeeRepository _Repository = new EmployeeRepository();
                        result = _Repository.EmployeeSearch(pageRequest).Item1;
                        fileName = "EmployeeMaster";
                        break;
                    }
                case PageId.StateMaster:
                    {
                        StateMasterRepository _Repository = new StateMasterRepository();
                        result = _Repository.StateSearch(pageRequest).Item1;
                        fileName = "StateMaster";
                        break;
                    }
                case PageId.BranchMaster:
                    {
                        BranchMasterRepository _Repository = new BranchMasterRepository();
                        result = _Repository.BranchSearch(pageRequest).Item1;
                        fileName = "Warehouse";
                        break;
                    }
                case PageId.CountryMaster:
                    {
                        CountryMasRepository _Repository = new CountryMasRepository();
                        result = _Repository.CountrySearch(pageRequest).Item1;
                        fileName = "CountryMaster";
                        break;
                    }
                case PageId.UserWarehouseMapping:
                    {
                        UserwarehousemapRepository _Repository = new UserwarehousemapRepository();
                        result = _Repository.UserBranchMapSearch(pageRequest).Item1;
                        fileName = "UserWarehouseMapping";
                        break;
                    }
                case PageId.VendorMaster:
                    {
                        VendorMasterRepository _Repository = new VendorMasterRepository();
                        result = _Repository.SearchPage_VendorMaster(pageRequest).Item1;
                        fileName = "VendorMaster";
                        break;
                    }
                case PageId.ItemMaster:
                    {
                        ItemMasterRepository _Repository = new ItemMasterRepository();
                        result = _Repository.GetItemMasterDetails(pageRequest).Item1;
                        fileName = "ItemMaster";
                        break;
                    }
                case PageId.StorageTypeID:
                    {
                        StorageTypeIDRepository _Repository = new StorageTypeIDRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "StorageTypeID";
                        break;
                    }
                case PageId.Floor:
                    {
                        FloorRepository _Repository = new FloorRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "Floor";
                        break;
                    }
                case PageId.Customer:
                    {
                        CustomerRepository _Repository = new CustomerRepository();
                        result = _Repository.SearchCustomer(pageRequest).Item1;
                        fileName = "Customer";
                        break;
                    }
                case PageId.StorageType:
                    {
                        StorageTypeRepository _Repository = new StorageTypeRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "StorageType";
                        break;
                    }
                case PageId.CityWithLocation:
                    {
                        CityMasterRepository _Repository = new CityMasterRepository();
                        result = _Repository.CityMasterSearch(pageRequest).Item1;
                        fileName = "CityWithLocation";
                        break;
                    }
                case PageId.ItemPackage:
                    {
                        ItemPackageRepository _Repository = new ItemPackageRepository();
                        result = _Repository.ItemPackageSearch(pageRequest).Item1;
                        fileName = "ItemPackage";
                        break;
                    }
                case PageId.StoragePallettype:
                    {
                        StoragePalletTypeRepository _Repository = new StoragePalletTypeRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "StoragePallettype";
                        break;
                    }
                case PageId.WarehouseZoneMaster:
                    {
                        WarehouseZoneRepository _Repository = new WarehouseZoneRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "WarehousezoneMaster";
                        break;
                    }
                case PageId.PickList:
                    {
                        SystematicPickListRepository _Repository = new SystematicPickListRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "SystematicPickList";
                        break;
                    }
                case PageId.IST:
                    {
                        InternalStockTransferRepository _Repository = new InternalStockTransferRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "InternalStockTransfer";
                        break;
                    }
                case PageId.WarehouseLayout:
                    {
                        WarehouseLayoutRepository _Repository = new WarehouseLayoutRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "WarehouseLayout";
                        break;
                    }

                case PageId.Dispatch:
                    {
                        DispatchRepository _Repository = new DispatchRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "Dispatch";
                        break;
                    }
                case PageId.CycleCountPlan:
                    {
                        CycleCountPlanRepository _Repository = new CycleCountPlanRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "CycleCountPlan_";
                        break;
                    }
                case PageId.CycleCountStart:
                    {
                        CycleCountStartRepository _Repository = new CycleCountStartRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "CycleCountStart_";
                        break;
                    }
                case PageId.CycleCountAdjust:
                    {
                        CycleCountAdjustRepository _Repository = new CycleCountAdjustRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "CycleCountAdjust";
                        break;
                    }
                case PageId.PutAway:
                    {
                        PutAwayRepository _Repository = new PutAwayRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "Putaway";
                        break;
                    }
                case PageId.WarehouseSubZone:
                    {
                        warehouseSubzoneRepository _Repository = new warehouseSubzoneRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "WarehouseSubZone";
                        break;
                    }
                case PageId.PickerAttendance:
                    {
                        PickerAttandanceRepository _Repository = new PickerAttandanceRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "PickerAttendance";
                        break;
                    }
                case PageId.PickerOrderConf:
                    {
                        PickerOrderConfRepository _Repository = new PickerOrderConfRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "PickerOrderConf";
                        break;
                    }

                case PageId.ST:
                    {
                        ISTRepository _Repository = new ISTRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "InternalStockTransfer";
                        break;
                    }
                case PageId.ISTPosting:
                    {
                        InternalStockTransferRepository _Repository = new InternalStockTransferRepository();
                        result = _Repository.PostingSearch(pageRequest).Item1;
                        fileName = "InternalStockTransferPosting";
                        break;
                    }
                case PageId.CycleCountAdjustApproval:
                    {
                        CycleCountAdjustApprovalRepository _Repository = new CycleCountAdjustApprovalRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "CycleCountAdjustApproval_";
                        break;
                    }
                case PageId.PicklistST:
                    {
                        SystematicPickListRepository _Repository = new SystematicPickListRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "SystematicPickList";
                        break;
                    }
                case PageId.StockDisposes:
                    {
                        StockDisposeRepository _Repository = new StockDisposeRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "StockDispose";
                        break;
                    }
                case PageId.StockDisposesApproval:
                    {
                        StockDisposeApprovalRepository _Repository = new StockDisposeApprovalRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "StockDisposeApproval";
                        break;
                    }

                case PageId.StockDisposalDispatch:
                    {
                        StockDisposeDispatchRepository _Repository = new StockDisposeDispatchRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "StockDisposalDispatch";
                        break;
                    }
                case PageId.PickListPickerSearch:
                    {
                        SystematicPickListRepository _Repository = new SystematicPickListRepository();
                        result = _Repository.PickListPickerSearch(pageRequest).Item1;
                        fileName = "PickListPickerSearch_";
                        break;
                    }

                case PageId.ISTSplitting:
                    {
                        InternalStockTransferRepository _Repository = new InternalStockTransferRepository();
                        result = _Repository.SplittingSearch(pageRequest).Item1;
                        fileName = "ISTSplitting";
                        break;
                    }
                case PageId.UpdateExpiryDate:
                    {
                        UpdateExpiryDateRepository _Repository = new UpdateExpiryDateRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "UpdateExpiryDate";
                        break;
                    }
                case PageId.UserStateMap:
                    {
                        UserStateMapRepository _Repository = new UserStateMapRepository();
                        result = _Repository.Search(pageRequest).Item1;
                        fileName = "UserStateMap_";
                        break;
                    }
            }
            



            return result;
        }


    }
}
