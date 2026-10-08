using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Entity;
using POM.Repository;

namespace POMS.API.Controllers
{
    [RoutePrefix("Api/StateMaster")]
    public class StateMasterController : ApiController
    {
        StateMasterRepository StateObj = new StateMasterRepository();
        [Route("StateInsert")]
        public string StateInsert(StateMaster State)
        {
            return StateObj.StateInsert(State);
        }
        


        [HttpPost]
        [Route("StateSearch")]
        public Tuple<List<StateMaster>, int> StateSearch(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return StateObj.StateSearch(pageRequest);
        }
        [HttpGet]
        [Route("StateEdit")]
        public List<StateMaster> StateEdit(int StateSno)
        {
            return StateObj.StateEdit(StateSno);
        }
        [HttpGet]
        [Route("StateMasterAutoComplete")]
        public List<StateMaster> StateMasterAutoComplete(string TextType)
       {
            return StateObj.StateMasterAutoComplete(TextType);
        }
    }
}
