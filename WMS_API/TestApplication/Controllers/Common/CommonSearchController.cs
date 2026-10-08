using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Repository;
using POMS.Entity;
using System.Web;
using System.Text;

namespace POMS.API.Controllers
{
    [RoutePrefix("Api/CommonSearch")]
    public class CommonSearchController : ApiController
    {
        CommonSearchRepository _CommonSearchRepository = new CommonSearchRepository();

        [HttpPost]
        [ActionName("GetFilterData")]
        public FilterResponse GetFilterData(FilterRequest filterRequest)
        {
            return _CommonSearchRepository.GetFilterData(filterRequest);
        }

    }
}
