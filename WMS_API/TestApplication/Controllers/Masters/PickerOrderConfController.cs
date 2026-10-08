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
using Repository.Masters;

namespace TestApplication.Controllers.Masters
{
    [RoutePrefix("Api/PickerOrderConf")]
    public class PickerOrderConfController : ApiController
    {
        PickerOrderConfRepository _PickerOrder = new PickerOrderConfRepository();
        [HttpPost]
        [Route("Insert")]
        public string Insert(PickerOrderConf ObjPickerOrder)
        {
            return _PickerOrder.Insert(ObjPickerOrder);
        }
        [HttpPost]
        [Route("Search")]
        public Tuple<List<PickerOrderConf>, int> Search(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _PickerOrder.Search(pageRequest);
        }
        [HttpGet]
        [Route("Edit")]
        public PickerOrderConf Edit(int Pickerordercountsno)
        {
            return _PickerOrder.Edit(Pickerordercountsno);
        }
        [HttpGet]
        [Route("Fetch")]
        public PickerOrderConf Fetch(int WarehouseSno)
        {
            return _PickerOrder.Fetch(WarehouseSno);
        }
    }
}