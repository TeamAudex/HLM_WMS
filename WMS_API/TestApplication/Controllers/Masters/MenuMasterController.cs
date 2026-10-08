using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POMS.Entity;
using POMS.Repository;


namespace POMS.API.Controllers
{
    [RoutePrefix("Api/MenuMaster")]
    public class MenuMasterController : ApiController
    {
        MenuMasterRepository _repository = new MenuMasterRepository();

        [HttpPost]
        [Route ("MenuApiInsert")]
        public string MenuApiInsert(MenuMaster objApi)
        {
            return _repository.MenuMasterInsert(objApi);
        }

        [HttpGet]
        [Route ("MenuApiEdit")]
        public List<MenuMaster> MenuApiEdit(int MenuSno)
        {
            return _repository.MenuMasterEdit(MenuSno);
        }

        [HttpPost]
        [Route("MenuApiSearch")]
        public List<MenuMaster> MenuApiSearch(PageRequest pageRequest)
        {
            pageRequest.Query = pageRequest.GetFilterQuery(pageRequest.Filters);
            return _repository.MenuMasterSearch(pageRequest);
        }

        [HttpGet]
        [Route("MenuApiAutoComplete")]
        public List<MenuMaster> MenuApiAutoComplete(string TextType)
        {
            return _repository.AutoComplete(TextType);
        }

    }
}
