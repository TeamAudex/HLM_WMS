using Librarys.Extenders;
using Librarys.Logging;
using POM.Entity;
using POMS.Entity;
using POMS.Entity.Masters;
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

namespace POMS.API.Controllers
{

    [RoutePrefix("Api/ItemMaster")]
    public class ItemMasterController : ApiController
    {
        CommonHelper ch = new CommonHelper();
        string storagePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString;
        ItemMasterRepository _ItemMasterRepository = new ItemMasterRepository();
        string boo;
        [HttpPost]
        [Route("insertItemMaster")]
        public async Task<HttpResponseMessage> insertItemMaster()
        {
            ItemMaster objDet = new ItemMaster();
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
                objDet = model.JsonToObject<ItemMaster>();
                objDet.sts = true;

                if (mfdr.FileData.Count > 0)
                {
                    int i = 0;
                    Dictionary<int, string> lstFile = new Dictionary<int, string>();
                    ch.InternalFileUpload(mfdr, storagePath, ref i, ref lstFile);
                    foreach (KeyValuePair<int, string> kvp in lstFile)
                    {
                        objDet.Documentpath = kvp.Value;
                    }
                }
                else
                {
                }
                boo = _ItemMasterRepository.InsertobjItemMaster(objDet);
            }

            catch (Exception ex)
            {
                Librarys.Logging.Logger.For(this).Error(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, boo);
        }


        [HttpPost]
        [Route("GetItemMasterDetails")]
        public Tuple<List<ItemMaster>, int> GetItemMasterDetails(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _ItemMasterRepository.GetItemMasterDetails(pageRequest);
        }

        [HttpGet]
        [Route("VolumeCalculation")]
        public string VolumeCalculation(decimal Length, decimal Breadth, decimal Height, int UOV)
        {
            return _ItemMasterRepository.VolumeCalculation(Length, Breadth, Height, UOV);
        }


        [HttpGet]
        [Route("GetItemMaster")]
        public List<ItemMaster> GetItemMaster(int ItemMasterSno)
        {
            return _ItemMasterRepository.GetItemMaster(ItemMasterSno);
        }

        [HttpGet]
        [Route("GetItemMasterAutoComplete")]
        public List<ItemMaster> GetItemMasterAutoComplete(string Condition, int Condition1, int Condition2)
        {
            return _ItemMasterRepository.GetItemMasterAutoComplete(Condition, Condition1, Condition2);
        }

        [HttpGet]
        [Route("DropDown2")]
        public ItemCategoryDropdownList DropDown2()
        {
            return _ItemMasterRepository.ItemCategoryDropdown();
        }

        //[HttpGet]
        //[Route("DropDown2")]
        //public RotationDropdownList DropDown2()
        //{
        //    return _ItemMasterRepository.RotationDropdown();
        //}

        [HttpGet]
        [Route("DropDown4")]
        public WeightUOMDropdownList DropDown4()
        {
            return _ItemMasterRepository.WeightUOMDropdown();
        }

        [HttpGet]
        [Route("DropDown5")]
        public MovementDropdownList DropDown5()
        {
            return _ItemMasterRepository.MovementDropdown();
        }

        [HttpGet]
        [Route("DropDown6")]
        public ValueDropdownList DropDown6()
        {
            return _ItemMasterRepository.ValueDropdown();
        }
        [HttpGet]
        [Route("DropDown7")]
        public NeedDropdownList DropDown7()
        {
            return _ItemMasterRepository.NeedDropdown();
        }
        [HttpGet]
        [Route("DropDown1")]
        public lbhUOMDropdownList DropDown1()
        {
            return _ItemMasterRepository.lbhUOMDropdown();
        }
        //[HttpGet]
        //[Route("GetBussinessAuto")]
        //public List<ItemMaster> GetBussinessAuto(string Condition, int Condition1, int Condition2)
        //{
        //    return _ItemMasterRepository.GetBussinessAuto(Condition, Condition1, Condition2);
        //}
    }
}


