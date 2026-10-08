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

namespace WMS.Controllers
{
    [RoutePrefix("Api/WarehouseLayout")]
    public class WhlayoutController : ApiController
    {
        WarehouseLayoutRepository _Repository = new WarehouseLayoutRepository();

        [HttpPost]
        [Route("Insert")]
        public WarehouseLayoutResult Insert(WarehouseLayoutDetList objWarehouseLayoutList)
        {
            return _Repository.Insert(objWarehouseLayoutList);
        }

        [HttpPost]
        [Route("Search")]
        public Tuple<List<WarehouseLayout>, int> BranchApiSearch(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _Repository.Search(pageRequest);
        }

        [HttpGet]
        [Route("Edit")]
        public WarehouseLayoutDetList Edit(int WarehouseLayoutSno)
        {
            return _Repository.Edit(WarehouseLayoutSno);
        }
    }
}