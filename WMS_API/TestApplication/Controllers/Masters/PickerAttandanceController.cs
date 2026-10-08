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

namespace WMS.Controllers
{
    [RoutePrefix("Api/PickerAttandance")]
    public class PickerAttandanceController : ApiController
    {
        PickerAttandanceRepository _Repository = new PickerAttandanceRepository();
        [HttpPost]
        [Route("Insert")]
        public PickerAttandanceResult Insert(PickerAttandancedetList objPickerAttandance)
        {
            return _Repository.Insert(objPickerAttandance);
        }
        [HttpPost]
        [Route("Search")]
        public Tuple<List<PickerAttandance>, int> Search(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _Repository.Search(pageRequest);
        }

        [HttpGet]
        [Route("Edit")]
        public PickerAttandancedetList Edit(int PickerAttandanceSno)
        {
            return _Repository.Edit(PickerAttandanceSno);
        }
    }
}