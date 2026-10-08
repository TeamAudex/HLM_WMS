using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication.Models
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }

        public string LoginPassword { get; set; }

        public string Address1 { get; set; }

        public int RoleId { get; set; }
    }
}