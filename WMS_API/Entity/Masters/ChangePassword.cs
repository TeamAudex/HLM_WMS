using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class ChangePassword
    {
        public int EmployeeSno { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        
        public int Creopr { get; set; }
        public DateTime? CreDat { get; set; }
        public string IPNumber { get; set; } 
        public string ActionName { get; set; } 
        public string RoleFlag { get; set; }
        public bool sts { get; set; }
    }
}
