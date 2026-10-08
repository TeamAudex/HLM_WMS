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

namespace TestApplication.Controllers.Masters
{
    [RoutePrefix("Api/StoragePalletType")]
    public class StoragePalletTypeController : ApiController
    {
        StoragePalletTypeRepository _StoragePallet = new StoragePalletTypeRepository();
        [HttpPost]
        [Route("Insert")]
        public string Insert(StoragePalletType StoragePallet)
        {
            return _StoragePallet.Insert(StoragePallet);
        }
        [HttpPost]
        [Route("Search")]
        public Tuple<List<StoragePalletType>, int> Search(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _StoragePallet.Search(pageRequest);
        }
        [HttpGet]
        [Route("Edit")]
        public StoragePalletType Edit(int StoragepallettypeSno)
        {
            return _StoragePallet.Edit(StoragepallettypeSno);
        }
    }
}