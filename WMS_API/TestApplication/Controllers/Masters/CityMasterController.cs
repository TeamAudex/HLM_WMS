using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Repository.Masters;
using POMS.Entity.Masters;
using POMS.Entity;

namespace POMS.API.Controllers
{
    [RoutePrefix("Api/CityMaster")]
    public class CityMasterController : ApiController
    {
        CityMasterRepository objCityMasterRepository = new CityMasterRepository();

        [HttpPost]
        [Route("InsertCityMaster")]
        public string InsertCityMaster(CityMas objCityMaster)
        {
            return objCityMasterRepository.InsertCityMaster(objCityMaster);
        }

        [HttpPost]
        [Route("CityMasterSearch")]
        public Tuple<List<CityMaster>, int> CityMasterSearch(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return objCityMasterRepository.CityMasterSearch(pageRequest);
        }
        [HttpGet]
        [Route("CityMasterEdit")]
        public CityMas CityMasterEdit(int CitySno)
        {
            return objCityMasterRepository.CityMasterEdit(CitySno);
        }

        [HttpGet]
        [Route("Autocomplete_CountryName")]
        public List<CityMaster> Autocomplete_CountryName(string param1)
        {
            return objCityMasterRepository.Autocomplete_CountryName(param1);
        }

        [HttpGet]
        [Route("Autocomplete_StateName")]
        public List<CityWithlocation> Autocomplete_StateName(string param1, string param2)
        {
            return objCityMasterRepository.Autocomplete_StateName(param1, param2);
        }

        [HttpGet]
        [Route("Autocomplete_StateName")]
        public List<CityWithlocation> Autocomplete_StateName(string param1, string param2, string param3)
        {
            return objCityMasterRepository.Autocomplete_StateName(param1, param2, param3);
        }


    }
}
