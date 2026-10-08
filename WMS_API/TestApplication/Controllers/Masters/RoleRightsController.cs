using System;
using System.Collections.Generic;
using System.Web.Http;
using System.IO;
using Repository.Master;
using Newtonsoft.Json;
using Entity.Masters;

namespace SSM_Api.Controllers.Master
{
    [RoutePrefix("Api/Rolerights")]
    public class RoleRightsController : ApiController
    {
        //string LogPath = System.Configuration.ConfigurationManager.ConnectionStrings["ReqResLog"].ConnectionString + "\\ReqLogs\\";

        RoleRightsRepository _Repository = new RoleRightsRepository();

        [HttpGet]
        [Route("Fetch")]
        public List<RolerightsDet> Fetch(int RoleSno)
        {
            return _Repository.Fetch(RoleSno);
        }

        [HttpPost]
        [Route("Insert")]
        public RoleRightResult insert(RoleRightSave objRequest)
        {
             return _Repository.insert(objRequest);
        }
        [HttpGet]
        [Route("GetRights")]
        public ScreenRights GetRights(string UserSno, string URL)
        {
            return _Repository.GetRights(UserSno, URL);
        }
    }
}