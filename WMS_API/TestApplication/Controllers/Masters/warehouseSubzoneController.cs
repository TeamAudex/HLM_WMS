using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repository;
using System.Web;
using Entity;
using POMS.Entity;
using Entity.Masters;
using Repository.master;

namespace WMS.Controllers
{
    [RoutePrefix("Api/WarehouseSubZone")]
    public class warehouseSubzoneController : ApiController
    {
        warehouseSubzoneRepository _Repository = new warehouseSubzoneRepository();
        [HttpPost]
        [Route("Insert")]
        public WarehouseSubZoneResult Insert(WarehouseSubZoneDetList objWarehouseSubZone)
        {
            return _Repository.Insert(objWarehouseSubZone);
        }
        [HttpPost]
        [Route("Search")]
        public Tuple<List<WarehouseSubZone>, int> Search(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _Repository.Search(pageRequest);
        }

        [HttpGet]
        [Route("Edit")]
        public WarehouseSubZoneDetList Edit(int warehouseSubZoneSno)
        {
            return _Repository.Edit(warehouseSubZoneSno);
        }

        [HttpGet]
        [Route("DropDown1")]
        public warehouseSubZoneDropdownList DropDown1(int WarehouseSno)
        {
            return _Repository.warehouseSubZoneDropdown(WarehouseSno);
        }

        [HttpGet]
        [Route("GetItems")]
        public List<SubZoneItemDet> GetItems(int ZoneSno)
        {
            return _Repository.GetItems(ZoneSno);
        }
    }
}