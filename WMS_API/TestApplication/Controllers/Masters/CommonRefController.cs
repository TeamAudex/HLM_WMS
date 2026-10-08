using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using POMS.Entity;
using POMS.Repository;


namespace POMS.API.Controllers
{
    [RoutePrefix("Api/CommonRef")]
    public class CommonRefController : ApiController
    {
        CommonRefRepository _Repository = new CommonRefRepository();
        [HttpPost]
        [Route("PostComref")]

        public string PostComref(CommonRef objcomref)
        {
            return _Repository.ComRefInsert(objcomref);
        }

        [HttpGet]
        [Route("GetEdit")]

        public List<CommonRef> GetEdit(int RefID)
        {
            return _Repository.ComRefEdit(RefID);
        }

        [HttpPost]
        [Route("Search")]

        public Tuple<List<CommonRef>, int> Search (PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _Repository.ComRefSearch(pageRequest);
        }


    }
}