using Librarys.Extenders;
using POM.Entity;
using POMS.Entity;
using POMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using objErr = POMS.Repository.ErrorEventLog;
using EncryptDecryptAssembly;

namespace TestApplication.Controllers.DriverRoutes
{
    [RoutePrefix("Api/DeliveryRoutes")]
    public class DeliveryRoutesController : ApiController
    {
        public DeliveryRoutesRepository _Routes = new DeliveryRoutesRepository();
        public Cust_PODRepository _CustRoutes = new Cust_PODRepository();
        CommonHelper ch = new CommonHelper();
        string storagePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "\\POD";
        string boo;
        [HttpPost]
        [Route("insertPOD")]
        public async Task<HttpResponseMessage> insertPOD()
        {
            POD objDet = new POD();
            TripMessage objTripSts = new TripMessage();
            try
            {

                var httpRequest = HttpContext.Current.Request;

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
                    objErr.ErrorLogApi(ex.ToString(), "Marg_app_PODController");
                }
                if (mfdr.FormData.Count == 0)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
   
                objDet.Origin                = mfdr.FormData[0];
                objDet.Destination           = mfdr.FormData[1];
                objDet.EntryDate             = mfdr.FormData[2];
                objDet.ORDERSNO              = mfdr.FormData[3];
                objDet.RECEIVED_NOP          = mfdr.FormData[4];
                objDet.RECEIVED_WEIGHT       = mfdr.FormData[5];
                objDet.RECEIVED_VOLUME       = mfdr.FormData[6];
                objDet.DAMAGE_NOP            = mfdr.FormData[7];            
                objDet.DELIVERY_DATE         = mfdr.FormData[8];
                objDet.DELIVERY_Time         = mfdr.FormData[9];
                objDet.RECEIVED_BY           = mfdr.FormData[10];
                objDet.REMARKS               = mfdr.FormData[11];
                objDet.UploadFile            = "";
                objDet.UploadFile1 = "";
                objDet.UploadFile2 = "";
                objDet.UploadFile3 = "";

                if (mfdr.FileData.Count > 0)
                {
                    int i = 0;
                    Dictionary<int, string> lstFile = new Dictionary<int, string>();
                    ch.InternalFileUpload(mfdr, storagePath, ref i, ref lstFile);
                    int filePos = 0;
                    foreach (KeyValuePair<int, string> kvp in lstFile)
                    { 
                        filePos = Convert.ToInt16(kvp.Key.ToString().Split('_')[0]);
                     

                        if (filePos == 0)  objDet.UploadFile  = kvp.Value;
                        if (filePos == 1)  objDet.UploadFile1 = kvp.Value;
                        if (filePos == 2)  objDet.UploadFile2 = kvp.Value;
                        if (filePos == 3)  objDet.UploadFile3 = kvp.Value;
                    }
                }
                else
                {
                }
                 objTripSts = _Routes.SavePOD(objDet);
            }

            catch (Exception ex)
            {
                Librarys.Logging.Logger.For(this).Error(ex);
                objErr.ErrorLogApi(ex.ToString()+" "+ex.StackTrace.ToString(), "Marg_app_PODController");
            }
            return Request.CreateResponse(HttpStatusCode.OK, objTripSts);
        }


        [HttpPost]
        [Route("ActivateAndFetchRoutes")]
        public OrderRoutesMas ActivateAndFetchRoutes(string UserCode, string DeviceID)
        {
            return _Routes.ActivateAndFetchRoutes(UserCode, DeviceID);
        }

        [HttpPost]
        [Route("TrackingGeoFence")]
        public AlertMas TrackingGeoFence(FetchRoute objTrackingRoutes)
        {
            return _Routes.TrackingGeoFence(objTrackingRoutes.request);
        }

        [HttpPost]
        [Route("SaveService")]
        public TripMessage StartService(string UserCode, int OrderSno , int RouteOrderSno)
        {
            return _Routes.StartService(UserCode, OrderSno , RouteOrderSno);
        }
        [HttpGet]
        [Route("FetchOrderDetails")]
        public List<OrderNext> FetchOrderDetails(int OrderSno, string UserCode, int RouteOrderSno)
        {
            return _Routes.FetchOrderDetails(OrderSno, UserCode, RouteOrderSno);
        }
        [HttpGet]
        [Route("SkipPOD")]
        public TripMessage SkipPOD(int OrderSno, string UserCode,string PodFlag)
        {
            return _Routes.SkipPOD(OrderSno, UserCode, PodFlag);
        }

        [HttpGet]
        [Route("AuthenticateOtp")]
        public TripMessage AuthenticateOtp(int OrderSno, string otp)
        {
            return _Routes.AuthenticateOtp(OrderSno, otp);
        }
        [HttpGet]
        [Route("FetchActivationCode")]
        public TripMessage FetchActivationCode(string MobileNo)
        {
            
            return _Routes.FetchActivationCode(MobileNo);
        }
        [HttpGet]
        [Route("OtpForReporting")]
        public TripMessage GenerateOtpforReporting(string MobileNo, int OrderSno, string UserCode)
        {

            return _Routes.GenerateOtpforReporting(MobileNo, OrderSno, UserCode);
        }


        [HttpPost]
        [Route("FindLSP")]
        public List<LSPLogin> FindLSP(string UserName, string Password)
        {
            EncryptDecrypt objEncrypt = new EncryptDecrypt();
            Password = objEncrypt.Encrypt(Password, "");
            //Password = objEncrypt.Decrypt(Password, "");
            return _Routes.LSP_LoginGet(UserName, Password);
        }


        [HttpPost]
        [Route("FindCustomer")]
        public List<CustomerLogin> FindCustomer(string UserName, string Password)
        {
            EncryptDecrypt objEncrypt = new EncryptDecrypt();
            Password = objEncrypt.Encrypt(Password, "");
            return _CustRoutes.Cust_LoginGet(UserName, Password);
        }

        [HttpGet]
        [Route("FetchLRDetails")]
        public List<FetchDetails> FetchLRDetails(int LRSno)
        {
            return _CustRoutes.FetchLRDetails_Repos(LRSno);
        }


        [HttpGet]
        [Route("AfterCustPODFetch")]
        public List<FetchDetails> AfterCustPODFetch(int LRSno)
        {
            return _CustRoutes.AfterCustPODFetch_Repos(LRSno);
        }


        [HttpPost]
        [Route("insertCustomerPOD")]

        public async Task<HttpResponseMessage> insertCustomerPOD()
        {
            Cust_POD objDet = new Cust_POD();
            TripMessage objTripSts = new TripMessage();
            try
            {

                var httpRequest = HttpContext.Current.Request;

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
                    objErr.ErrorLogApi(ex.ToString(), "Marg_app_PODController");
                }
                if (mfdr.FormData.Count == 0)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                objDet.EntryDate = mfdr.FormData[0];
                objDet.Origin = mfdr.FormData[1];
                objDet.Destination = mfdr.FormData[2];
                objDet.LRSno = mfdr.FormData[3];
                objDet.RecNOP = mfdr.FormData[4];
                objDet.RecWeight = mfdr.FormData[5];
                objDet.RecVolume = mfdr.FormData[6];
                objDet.DamagedQty = mfdr.FormData[7];
                objDet.DeliveredDate = mfdr.FormData[8];
                objDet.DeliveredTime = mfdr.FormData[9];
                objDet.ReceivedBy = mfdr.FormData[10];
                objDet.Remarks = mfdr.FormData[11];
                objDet.IPNumber = mfdr.FormData[12];
                objDet.Sts = mfdr.FormData[13];
                objDet.TransactionType = mfdr.FormData[14];
                objDet.Creopr = mfdr.FormData[15];
                objDet.upload = "";
                objDet.upload1 = "";
                objDet.upload2 = "";
                objDet.upload3 = "";

                var model = mfdr.FormData["model"];

                if (mfdr.FileData.Count > 0)
                {
                    int i = 0;
                    Dictionary<int, string> lstFile = new Dictionary<int, string>();
                    ch.InternalFileUpload(mfdr, storagePath, ref i, ref lstFile);
                    int filePos = 0;
                    foreach (KeyValuePair<int, string> kvp in lstFile)
                    {
                        filePos = Convert.ToInt16(kvp.Key.ToString().Split('_')[0]);


                        if (filePos == 0) objDet.upload = kvp.Value;
                        if (filePos == 1) objDet.upload1 = kvp.Value;
                        if (filePos == 2) objDet.upload2 = kvp.Value;
                        if (filePos == 3) objDet.upload3 = kvp.Value;
                    }
                }
                else
                {
                }

                objTripSts = _CustRoutes.Insert_Cust_POD(objDet);
            }

            catch (Exception ex)
            {
                Librarys.Logging.Logger.For(this).Error(ex);
                objErr.ErrorLogApi(ex.ToString() + " " + ex.StackTrace.ToString(), "Marg_app_PODController");
            }
            return Request.CreateResponse(HttpStatusCode.OK, objTripSts);
        }



        [HttpPost]
        [Route("SearchPage_CustPOD")]
        public Tuple<List<FetchDetails>, int> SearchPage_CustPOD(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _CustRoutes.SearchPage_CustPOD(pageRequest);
        }


        [HttpPost]
        [Route("SearchPage_CustPODDone")]
        public Tuple<List<FetchDetails>, int> SearchPage_CustPODDone(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _CustRoutes.Resp_SearchPage_CustPODDone(pageRequest);
        }




    }
}
