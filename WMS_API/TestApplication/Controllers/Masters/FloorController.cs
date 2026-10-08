using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Entity;
using POMS.Repository;
using Entity.Masters;
using Repository.Masters;

namespace TestApplication.Controllers.Masters
{
    [RoutePrefix("Api/Floor")]
    public class FloorController : ApiController
    {
        FloorRepository _repository = new FloorRepository();

        [HttpPost]
        [Route("Insert")]
        public string Insert(FloorList objFloorList)
        {
            return _repository.Insert(objFloorList);
        }

        [HttpGet]
        [Route("Edit")]
        public FloorList Edit(int FloorSno)
        {
            return _repository.Edit(FloorSno);
        }

        [HttpPost]
        [Route("Search")]
        public Tuple<List<Floor>, int> Search(PageRequest pageRequest)
        {

            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _repository.Search(pageRequest);


        }
    }
}
