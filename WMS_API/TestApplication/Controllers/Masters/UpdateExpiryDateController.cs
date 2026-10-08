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
    [RoutePrefix("Api/UpdateExpiryDate")]
    public class UpdateExpiryDateController : ApiController
    {
        // GET: UpdateExpiryDate
        UpdateExpiryDateRepository _UpdateExpiryDate = new UpdateExpiryDateRepository();
        [HttpPost]
        [Route("Insert")]
        public string Insert(UpdateExpiryDate ObjUpdateExpiryDate)
        {
            return _UpdateExpiryDate.Insert(ObjUpdateExpiryDate);
        }
        [HttpPost]
        [Route("Search")]
        public Tuple<List<UpdateExpiryDate>, int> Search(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _UpdateExpiryDate.Search(pageRequest);
        }
        
    }
}