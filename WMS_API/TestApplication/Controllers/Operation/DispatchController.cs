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
    [RoutePrefix("Api/Dispatch")]
    public class DispatchController : ApiController
    {
        DispatchRepository _repository = new DispatchRepository();

        [HttpPost]
        [Route("Fetch")]
        public List<DispatchDet> Fetch(Dispatch objDispatch)
        {
            return _repository.Fetch(objDispatch);
        }

        [HttpPost]
        [Route("Insert")]
        public DispatchResponse Insert(DispatchList objDispatchList)
        {
            return _repository.Insert(objDispatchList);
        }

        [HttpGet]
        [Route("Edit")]
        public DispatchList Edit(int DispatchSno)
        {
            return _repository.Edit(DispatchSno);
        }

        [HttpPost]
        [Route("Search")]
        public Tuple<List<Dispatch>, int> Search(PageRequest pageRequest)
        {

            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _repository.Search(pageRequest);


        }
    }
}
