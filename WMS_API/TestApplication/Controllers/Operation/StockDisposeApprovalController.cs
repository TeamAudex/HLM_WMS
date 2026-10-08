using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Entity;
using POMS.Repository;
using Entity.Operations;
using Repository.Operations;

namespace TestApplication.Controllers.Operation
{
    [RoutePrefix("Api/StockDisposeApproval")]
    public class StockDisposeApprovalController : ApiController
    {
        StockDisposeApprovalRepository _repository = new StockDisposeApprovalRepository();
        [HttpPost]
        [Route("Insert")]
        public StockDisposeResponse Insert(StockDisposeDetails objStockDisposeDetails)
        {
            return _repository.Insert(objStockDisposeDetails);
        }


        [HttpGet]
        [Route("Edit")]
        public StockDisposeDetails Edit(int StockDisposeSno)
        {
            return _repository.Edit(StockDisposeSno);
        }

        [HttpPost]
        [Route("Search")]
        public Tuple<List<StockDispose>, int> Search(PageRequest pageRequest)
        {

            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _repository.Search(pageRequest);

        }
    }
}
