using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Entity;
using POMS.Entity.Masters;
using POMS.Repository;
using POMS.Repository.Masters;

namespace POMS.API.Controllers.Masters
{
    [RoutePrefix("Api/VendorMaster")]
    public class VendorMasterController : ApiController
    {
        VendorMasterRepository objVendorMasterRepository = new VendorMasterRepository();

        [HttpGet]
        [Route("DropDownVendorMasterDiv")]
        public VendorMasterdropdown DropDownVendorMasterDiv()
        {
            return objVendorMasterRepository.DropDownVendorMasterDiv();
        }

        //[HttpGet]
        //[Route("AutoCompleteVendorMasterDiv")]
        //public List<VendorMasterDiv> AutoCompleteVendorMasterDiv(string AutoCount, string TypedValue)
        //{
        //    return objVendorMasterRepository.AutoCompleteVendorMasterDiv(AutoCount, TypedValue);
        //}

        [HttpGet]
        [Route("AutoCompleteVendorMasterFirstGird")]
        public List<VendorMasterGrid1> AutoCompleteVendorMasterFirstGird(string AutoCount, string TypedValue)
        {
            return objVendorMasterRepository.AutoComplete_VendorMasterFirstGird(AutoCount, TypedValue);
        }

        [HttpGet]
        [Route("AutoCompleteVendorMasterSecondGird")]
        public List<VendorCategoryLevelMas> AutoCompleteVendorMasterSecondGird(string AutoCount, string TypeOfSno, string TypedValue)
        {
            return objVendorMasterRepository.AutoCompleteVendorMasterSecondGird(AutoCount, TypeOfSno, TypedValue);
        }


        [HttpPost]
        [Route("SearchPage_VendorMaster")]
        public Tuple<List<VendorMasterDiv>, int> SearchPage_VendorMaster(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return objVendorMasterRepository.SearchPage_VendorMaster(pageRequest);
        }

        [HttpPost]
        [Route("Insert_VendorMaster")]
        public string Insert_VendorMaster(VendorMasterList objVendorMasterList)
        {
            return objVendorMasterRepository.Insert_VendorMaster(objVendorMasterList);
        }
        [HttpGet]
        [Route("Edit_VendorMaster")]
        public VendorMasterList Edit_VendorMaster(int VendorMasterSno)
        {
            return objVendorMasterRepository.Edit_VendorMaster(VendorMasterSno);
        }


    }
}
