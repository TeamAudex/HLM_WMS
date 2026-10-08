using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using POMS.Entity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

public class CustomOAuthProvider : OAuthAuthorizationServerProvider
{
    public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
        // Resource owner password credentials does not provide a client ID.
        if (context.ClientId == null)
        {
            context.Validated();
        }

        return Task.FromResult<object>(null);
    }

    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
        var emp = new Employee();

        context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

        using (AuthRepository authRepo = new AuthRepository())
        {

            emp = await authRepo.FindEmployee(context.UserName, context.Password);
            // IdentityUser user = await authRepo.FindUser(context.UserName, context.Password);

            if (emp.sts == false)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            else if (emp.BranchSno == null)
            {
                context.SetError("invalid_grant", "User Shop is not mapped");
                return;
            }
        }

        AuthenticationProperties properties = CreateProperties(emp.UserName, emp.RoleSno, emp.FirstName,emp.UserSno,emp.Lastlogintime,emp.RoleName, emp.Designation,emp.BranchSno,emp.BranchName,emp.RateSts);

        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
        identity.AddClaim(new Claim(ClaimTypes.Name, emp.UserName));
        // Optional : You can add a role based claim by uncommenting the line below.
        identity.AddClaim(new Claim(ClaimTypes.Role, emp.RoleSno));
        AuthenticationTicket ticket = new AuthenticationTicket(identity, properties);
        context.Validated(ticket);
    }

    public override Task TokenEndpoint(OAuthTokenEndpointContext context)
    {
        foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
        {
            context.AdditionalResponseParameters.Add(property.Key, property.Value);
        }

        return Task.FromResult<object>(null);
    }

    public static AuthenticationProperties CreateProperties(string userName, string RoleSno, string FirstName,string UserSno,string Lastlogintime,string RoleName, string Designation, string BranchSno, string BranchName, string RateSts)
    {
        IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName
                },
                {
                 "RoleSno", RoleSno
                },
                 {
                "FirstName" ,FirstName
                }
                  ,
                 {
                "UserSno" ,UserSno
                },
            {
                "Lastlogintime" ,Lastlogintime
            },
            {
                "RoleName",RoleName
            },
            
            {
                "Designation",Designation
            },
           {
                "BranchSno",BranchSno
            },
            {
                "BranchName",BranchName
            },
             {
                "RateSts",RateSts
            }
              
           

                };
        return new AuthenticationProperties(data);
    }
}