using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class StateMaster
    {
        public int StateSno { get; set; }
        public int CountrySno { get; set;}
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public bool Sts { get; set; }
        public string ActionName { get; set; }
        public string IPNumber { get; set; }
        public int CreOpr { get; set; }

    }
}
