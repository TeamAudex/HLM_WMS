using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Repository.Masters;
using POMS.Entity.Masters;
using POMS.Entity;

namespace POMS.API.Controllers.Masters
{
    [RoutePrefix ("Api/CommonMaster")]
    public class CommonMasterController : ApiController
    {
        CommonMasterRepository objCommonMasterRepository = new CommonMasterRepository();
        [HttpPost]
        [Route("InsertCommonMaster")]
        public string InsertCommonMaster(CommonMaster objCommonMaster) {
            return objCommonMasterRepository.InsertCommonMaster(objCommonMaster);
        }

        [HttpGet]
        [Route("Autocomplete_CommonMasterType")]
        public List<CommonMaster> Autocomplete_CommonMasterType(string param)
        {
            return objCommonMasterRepository.CommonMasterType(param);
        }

        [HttpPost]
        [Route("CommonMasterSearch")]
        public Tuple<List<CommonMaster>, int> CommonMasterSearch(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return objCommonMasterRepository.CommonMaster_Search(pageRequest);
        }

        [HttpGet]
        [Route("CommonMasterEdit")]
        public List<CommonMaster> CommonMasterEdit(int COMMONSNO)
        {
            return objCommonMasterRepository.CommonMasterEdit(COMMONSNO);
        }

    }
}
