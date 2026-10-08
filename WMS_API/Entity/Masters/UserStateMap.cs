using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Masters
{
    public class UserStateMap
    {
        public int UserStateMapSno { get; set; }
        public int UserSno { get; set; }
        public string UserName { get; set; }
        public int CreOpr { get; set; }
        public string IPNumber { get; set; }
        public string ActionName { get; set; }
        public bool? Sts { get; set; }
    }
    public class UserStateMapDet
    {
        public int UserStateMapDetSno { get; set; }
        public int UserStateMapSno { get; set; }
        public int StateSno { get; set; }
        public string StateName { get; set; }
        public bool? Sts { get; set; }
    }
    public class UserStateMapList
    {
        public UserStateMap UserStateMap { get; set; }
        public List<UserStateMapDet> UserStateMapDet { get; set; }
    }
}
