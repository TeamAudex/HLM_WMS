using Entity.Masters;
using POMS.Entity;
using Repository.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestApplication.Controllers.Masters
{
    [RoutePrefix("Api/UserStateMap")]
    public class UserStateMapController : ApiController
    {
        UserStateMapRepository _Repository = new UserStateMapRepository();

        [Route("Insert")]
        public string Insert(UserStateMapList UserStateMaplist)
        {
            return _Repository.Insert(UserStateMaplist);
        }

        [HttpPost]
        [Route("Search")]
        public Tuple<List<UserStateMap>, int> Search(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _Repository.Search(pageRequest);
        }

        [HttpGet]
        [Route("Edit")]
        public UserStateMapList Edit(int UserStateMapSno)
        {
            return _Repository.Edit(UserStateMapSno);
        }

        [HttpGet]
        [Route("GetStateDetails")]
        public List<UserStateMapDet> GetStateDetails()
        {
            return _Repository.GetStateDetails();
        }
    }
}
