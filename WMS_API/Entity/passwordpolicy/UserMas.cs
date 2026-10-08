using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class UserMas
    {
        public int UserSno { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public string Type { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string IPNumber { get; set; }
        public string URLpath { get; set; }
        public bool sts { get; set; }
        public string Opassword { get; set; }
    }
}
