using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Masters
{
  public class CountryMaster
    {
        public int CountrySno { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public int CreOpr { get; set; }
        public DateTime CreDat { get; set; }
        public bool Sts { get; set; }

        public string ActionName { get; set; }

        public string IPNumber { get; set; }
    }
    public class CountrySearch
    {
        public List<CountryMaster> CountyList { get; set; }
    }
}

