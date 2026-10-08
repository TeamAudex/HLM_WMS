using Entity.Operations;
using POMS.Entity;
using Repository.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestApplication.Controllers.Operation
{
    [RoutePrefix("Api/CycleCountPlan")]
    public class CycleCountPlanController : ApiController
    {
        CycleCountPlanRepository _Repository = new CycleCountPlanRepository();

        [HttpPost]
        [Route("Insert")]
        public CycleCountPlanResult Insert(CycleCountPlanList objCycleCountPlanList)
        {
            return _Repository.Insert(objCycleCountPlanList);
        }

        [HttpPost]
        [Route("Search")]
        public Tuple<List<CycleCountPlan>, int> BranchApiSearch(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _Repository.Search(pageRequest);
        }

        [HttpGet]
        [Route("Edit")]
        public CycleCountPlanList Edit(int CycleCountPlanningSno)
        {
            return _Repository.Edit(CycleCountPlanningSno);
        }


        
    }
}
