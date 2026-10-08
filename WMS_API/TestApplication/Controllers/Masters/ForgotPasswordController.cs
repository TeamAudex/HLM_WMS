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
    [RoutePrefix("Api/ForgotPassword")]
    public class ForgotPasswordController : ApiController
    {
        ForgotPasswordRepository _repository = new ForgotPasswordRepository();

        [HttpPost]
        [Route("ForgotPasswordAPI")]
        public string ForgotPasswordAPI(ForgotPassword objForgotPasswordAPI)
        {
            return _repository.ForgotPassword(objForgotPasswordAPI);
        }
    }
}
