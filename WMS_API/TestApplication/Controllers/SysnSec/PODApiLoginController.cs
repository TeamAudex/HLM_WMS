using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POM.Entity;
using POMS.Entity;
using POM.Repository;
using POMS.Repository;

namespace TestApplication.Controllers.SysnSec
{
    [RoutePrefix("Api/PODApiLogin")]
    public class PODApiLoginController : ApiController
    {
        PODApiLoginRepository _PODApiLoginRepository = new PODApiLoginRepository();

        [HttpGet]
        [ActionName("LoginGet")]
        [Route("LoginGet")]
        public List<Employee> LoginGet(string UserName, string Password)
        {
            return _PODApiLoginRepository.LoginGet(UserName, Password);
        }
        }
}
