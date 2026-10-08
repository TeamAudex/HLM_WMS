using Entity.Masters;
using POMS.Entity;
using POMS.Repository;
using Repository.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace POMS.API.Controllers
{
    [RoutePrefix("Api/CountryMaster")]
    public class CountryMasController : ApiController
    {
       
        CountryMasRepository _CountryMas = new CountryMasRepository();
        [HttpPost]
        [Route("CountryInsert")]
        public string CountryInsert(CountryMaster country)
        {
            return _CountryMas.CountryInsert(country);
        }

        [HttpPost]
        [Route("CountrySearch")]
        public Tuple<List<CountryMaster>, int> CountrySearch(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _CountryMas.CountrySearch(pageRequest);
        }
        [HttpGet]
        [Route("CountryEdit")]
        public List<CountryMaster> CountryEdit(int CountrySno)
        {
            return _CountryMas.CountryEdit(CountrySno);
        }
    }
}
