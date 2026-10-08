using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using TestApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartup(typeof(TestApplication.Startup))]

namespace TestApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Install-package Microsoft.Owin.Cors
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
            //createRolesandUsers();
        }
        //private void createRolesandUsers()
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();

        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        //    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


        //    // In Startup iam creating first Admin Role and creating a default Admin User     
        //    if (!roleManager.RoleExists("Admin3"))
        //    {
        //        // first we create Admin rool    
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "Admin3";
        //        roleManager.Create(role);

        //        //Here we create a Admin super user who will maintain the website                   
        //        var user = new ApplicationUser();
        //        user.UserName = "audex3";
        //        user.Email = "audex2@gmail.com";
        //        user.FirstName = "Audex";
        //        user.password = "password";

        //        string userPWD = "password";

        //        var chkUser = UserManager.Create(user, userPWD);

                 
        //        //Add default User to Role Admin    
        //        if (chkUser.Succeeded)
        //        {
        //            var result1 = UserManager.AddToRole(user.Id, "Admin2");

        //        }
        //    }
        //}
    }
}




