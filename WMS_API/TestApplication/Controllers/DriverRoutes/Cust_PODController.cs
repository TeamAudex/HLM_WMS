using Librarys.Extenders;
using POM.Entity;
using POMS.Entity;
using POMS.Repository;
using POM.Repository;
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
using EncryptDecryptAssembly;
using objErr = POMS.Repository.ErrorEventLog;

namespace TestApplication.Controllers.DriverRoutes
{
    [RoutePrefix("Api/Cust_DeliveryRoutes")]
    public class Cust_PODController : ApiController
    {
        public Cust_PODRepository _Routes = new Cust_PODRepository();
        CommonHelper ch = new CommonHelper();
        string storagePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "\\POD";
        string boo;

        [HttpPost]
        [Route("FindCustomer")]
        public List<CustomerLogin> FindCustomer(string UserName, string Password)
        {
            EncryptDecrypt objEncrypt = new EncryptDecrypt();
            Password = objEncrypt.Encrypt(Password, "");
            return _Routes.Cust_LoginGet(UserName, Password);
        }


        [HttpGet]
        [Route("FetchLRDetails")]
        public List<FetchDetails> FetchLRDetails(int LRSno)
        {
            return _Routes.FetchLRDetails_Repos(LRSno);
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

                objTripSts = _Routes.Insert_Cust_POD(objDet);
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
            return _Routes.SearchPage_CustPOD(pageRequest);
        }


        [HttpPost]
        [Route("SearchPage_CustPODDone")]
        public Tuple<List<FetchDetails>, int> SearchPage_CustPODDone(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _Routes.Resp_SearchPage_CustPODDone(pageRequest);
        }

    }





}
