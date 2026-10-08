using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Repository;
using POMS.Entity;
namespace TestApplication.Controllers.Common
{
    [RoutePrefix("Api/CommonMasterAutoComplete")]
    public class CommonMasterAutoCompleteController : ApiController
    {
        CommonRepository _repository = new CommonRepository();
        //[Route("CommonMasterAuto")]
        //[HttpGet]
        //public List<CommonMasterAuto> CommonMasterAuto(string Condition, string Condition1)
        //{
        //    return _repository.CommonMaster(Condition, Condition1);
        //}




        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("AutoCompleteAPI")]
        public List<CommonMasterAuto> AutoCompleteAPI(string SP, int UserSno, string TypeValue, string Condition1 = "", string Condition2 = "", string Condition3 = "", string Condition4 = "", string Condition5 = "", string Condition6 = "")
        {
            return _repository.AutoComplete(SP, UserSno, TypeValue, Condition1, Condition2, Condition3, Condition4, Condition5, Condition6);
        }

        [HttpGet]
        [Route("DropDown1")]
        public CommondropdownList1 DropDown1(string SP)
        {
            return _repository.DropDown1(SP);
        }

        [HttpGet]
        [Route("DropDownSalesReport")]
        public CommondropdownList1 DropDownSalesReport(string SP, int UserSno)
        {
            return _repository.DropDownSalesReport(SP, UserSno);
        }
    }
}
