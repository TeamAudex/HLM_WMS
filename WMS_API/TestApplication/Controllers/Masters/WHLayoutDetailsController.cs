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
    [RoutePrefix("Api/WHLayoutDetails")]
    public class WHLayoutDetailsController : ApiController
    {
        WHLayoutDetailsRepository _Repository = new WHLayoutDetailsRepository();

        [HttpGet]
        [Route("Fetch")]
        public WHLayoutDetailsList Fetch(int WarehouseSno,int RowsSno)
        {
            return _Repository.Fetch(WarehouseSno, RowsSno);
        }

        [HttpPost]
        [Route("Insert")]
        public WHLayoutDetailsResult Insert(WHLayoutDetailsList objWHLayoutDetailsList)
        {
            return _Repository.Insert(objWHLayoutDetailsList);
        }

        [HttpGet]
        [Route("PalletTypeFetch")]
        public WHLayoutDetailsList PalletTypeFetch(int PalletTypeSno)
        {
            return _Repository.PalletTypeFetch(PalletTypeSno);
        }

        [HttpPost]
        [Route("Search")]
        public Tuple<List<WHLayoutDetails>, int> Search(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _Repository.Search(pageRequest);
        }

        [HttpGet]
        [Route("Edit")]
        public WHLayoutDetailsList Edit(int WHLayoutDetailsSno)
        {
            return _Repository.Edit(WHLayoutDetailsSno);
        }

        [HttpGet]
        [Route("WHLDDropDown")]
        public WHLayoutDetailDropdownlist WHLDDropDown(int WarehouseSno)
        {
            return _Repository.WHLDDropDown(WarehouseSno);
        }
    }
}
