using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Masters
{
   public class UserBranchMap
    {
        public int UserBranchMapSno { get; set; }
        public int EmployeeSno { get; set; }
        public string EmployeeName { get; set; }
        public string UserName { get; set; }
        public string BranchName { get; set; }
        public string UserBranchMapNo { get; set; }
        public string DefaultAddress { get; set; }
        public bool? DefaultFlag { get; set; }
        public int Creopr { get; set; }
        public bool? Sts { get; set; }
        public string IPNumber { get; set; }
        public string ActionName { get; set; }
        public string url { get; set; }
    }
    public class UserBranchMapGrid
    {
        public int UserBranchMapGridSno { get; set; }
        public int UserBranchMapSno { get; set; }

        public int BranchSno { get; set; }
        public string BranchName { get; set; }
        public int Creopr { get; set; }
        public bool? DefaultFlag { get; set; }
        public bool? Sts { get; set; }
        public string IPNumber { get; set; }
    }
    public class UserBranchMapSearch
    {
        public UserBranchMap UserBranchMap { get; set; }
        public List<UserBranchMapGrid> UserBranchMapWiseDetails { get; set; }
    }
}
