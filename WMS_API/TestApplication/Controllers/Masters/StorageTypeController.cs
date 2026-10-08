using Entity.Masters;
using Librarys.Extenders;
using POMS.Entity;
using Repository.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace TestApplication.Controllers.Masters
{
    [System.Web.Http.RoutePrefix("Api/StorageType")]
    public class StorageTypeController : ApiController
    {
        CommonHelper ch = new CommonHelper();
        string storagePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString;
        StorageTypeRepository _StorageTypeRepository = new StorageTypeRepository();
        string boo;
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Insert")]
        public async Task<HttpResponseMessage> insertstoragetype()
        {
            StorageType objDet = new StorageType();
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

                }
                if (mfdr.FormData["model"] == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                var model = mfdr.FormData["model"];
                objDet = model.JsonToObject<StorageType>();
                objDet.sts = true;

                if (mfdr.FileData.Count > 0)
                {
                    int i = 0;
                    Dictionary<int, string> lstFile = new Dictionary<int, string>();
                    ch.InternalFileUpload(mfdr, storagePath, ref i, ref lstFile);
                    foreach (KeyValuePair<int, string> kvp in lstFile)
                    {
                        objDet.Image = kvp.Value;
                    }
                }
                else
                {
                }
                boo = _StorageTypeRepository.Insertobj(objDet);
            }

            catch (Exception ex)
            {
                Librarys.Logging.Logger.For(this).Error(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, boo);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("DropDownList")]
        public StorageTypeDropDown DropDownList()
        {
            return _StorageTypeRepository.DropDownList();
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Search")]
        public Tuple<List<StorageType>, int> ItemPackageSearch(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _StorageTypeRepository.Search(pageRequest);
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Edit")]
        public StorageType Edit(int StorageTypeSno)
        {
            return _StorageTypeRepository.Edit(StorageTypeSno);
        }
    }
}