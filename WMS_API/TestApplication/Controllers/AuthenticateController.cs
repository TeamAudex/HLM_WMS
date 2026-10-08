using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using TestApplication.Models;
using TestApplication.Results;
using POMS.Entity;
namespace TestApplication.Controllers
{
    public class AuthenticateController : ApiController
    {
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(Employee model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var repository = new AuthRepository())
            {
                Microsoft.AspNet.Identity.IdentityResult result = await repository.RegisterUser(model);

                if (!result.Succeeded)
                {
                    return Ok(false);
                }

                return Ok();
            }

        }

    }
}
