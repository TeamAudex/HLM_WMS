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
    [RoutePrefix("Api/CycleCountAdjustApproval")]
    public class CycleCountAdjustApprovalController : ApiController
    {
        string storagePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "\\BankFormat\\";
        string strConnention = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();

        CycleCountAdjustApprovalRepository _Repository = new CycleCountAdjustApprovalRepository();

        [HttpGet]
        [Route("Edit")]
        public CycleCountAdjustApprovalList Edit(int CycleCountSno)
        {
            return _Repository.Edit(CycleCountSno);
        }

        [HttpPost]
        [Route("Insert")]
        public string Insert(CycleCountAdjustApprovalList objcyclecount)
        {

            return _Repository.Insert(objcyclecount);
        }
        [HttpPost]
        [Route("Search")]
        public Tuple<List<CycleCountAdjustApprovalSearch>, int> Search(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _Repository.Search(pageRequest);
        }
    }
}
