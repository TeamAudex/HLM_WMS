using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POMS.Entity
{
    public class ForgotPassword
    {
        public int EmployeeSno { get; set; }
        public string UserName { get; set; }
        public string REGARDS_BY { get; set;}
        public int Creopr { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string IpNumber { get; set; }
        public bool Sts { get; set; }

        public string Condition { get; set; }
        public string Condition1 { get; set; }
    }
}
