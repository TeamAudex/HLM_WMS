

using Entity.Masters;
using POMS.Entity;
using POMS.Repository;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace POMS.API.Controllers
{
    [RoutePrefix("Api/WarehouseZone")]
    public class WarehouseZoneController : ApiController

    {
        WarehouseZoneRepository _repository = new WarehouseZoneRepository();

        [HttpGet]
        [Route("DropDown")]
        public Storagelocationlist DropDown1()
        {
            return _repository.StoragelocationDD();
        }

        [HttpGet]
        [Route("DropDown1")]
        public Dropdownlist DropDown()
        {
            return _repository.StockTypedropdown();
        }
        [HttpPost]

        [Route("Insert")]

        public WarehouseZoneResult Insert(WarehouseZoneMaster objclass)
        {
            return _repository.Insert(objclass);
        }

        [HttpPost]
        [Route("Search")]
        public Tuple<List<WarehouseZone>, int> Search(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _repository.Search(pageRequest);
        }

        [HttpGet]
        [Route("Edit")]
        public WarehouseZoneMaster Edit(int WarehouseZoneSno)
        {
            return _repository.Edit(WarehouseZoneSno);
        }
    }
}