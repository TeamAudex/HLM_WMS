using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class RoleMaster
    {
     public int RoleSno            { get; set;}
     public string RoleName        { get; set;}
     public string RoleDescription { get; set;}
     public string RoleFlag        { get; set;}
     public int Creopr             { get; set;}
     public DateTime? CreatedDate   { get; set;}
     public string IpNumber        { get; set;}
        public string ActionName { get; set; }
        public bool Sts               { get; set; }
     public string MyStatus { get; set; }
    }

    public class RoleSearch
    {
        public List<RoleMaster> CountyList { get; set; }
    }
}
