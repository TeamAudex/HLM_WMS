using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Entity;
using POMS.Repository;

namespace POMS.API.Controllers
{
    [RoutePrefix("Api/BranchMaster")]
    public class BranchMasterController : ApiController
    {
        BranchMasterRepository _repository = new BranchMasterRepository();
        [HttpPost]
        [Route("BranchApiInsert")]
       public string BranchApiInsert(BranchMaster objapiclass)
        {
            return _repository.BranchInsert(objapiclass);
        }

        [HttpGet]
        [Route("BranchApiEdit")]
        public List<BranchMaster> BranchApiEdit(int BranchSno)
        {
            return _repository.BranchEdit(BranchSno);
        }

        [HttpPost]
        [Route("BranchApiSearch")]
        public Tuple< List<BranchMaster>,int> BranchApiSearch(PageRequest pageRequest)
        {

            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _repository.BranchSearch(pageRequest);

        }

        [HttpGet]
        [Route("AutoCompleteAPI")]
        public List<BranchMaster> AutoCompleteAPI(string Condition, int Condition1, int Condition2)
        {
            return _repository.AutoComplete(Condition, Condition1, Condition2);
        }

        [HttpGet]
        [Route("DropDown1")]
        public Typesdropdownlist DropDown1()
        {
            return _repository.Typesdropdown();
        }






    }
}
