using POMS.Entity;
using POMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestApplication.Controllers
{
    [RoutePrefix("Api/PODDashBoard")]
    public class PODDashboardController : ApiController
    {
        PODDashboardRepository _DashRepository = new PODDashboardRepository();

        [HttpGet]
        [Route("LoadData")]
        public List<PODInvoiceDet> LoadData(int UserSno,string RoleFlag)
        {
            return _DashRepository.LoadData(UserSno, RoleFlag);
        }

        [HttpGet]
        [Route("LogStatus")]
        public string Logoutsts(int UserSno, string Ipaddress)
        {
            return _DashRepository.LogStatus(UserSno, Ipaddress);
        }
    }
}
