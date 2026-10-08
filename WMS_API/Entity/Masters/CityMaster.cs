using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity.Masters
{
    public class CityMaster
    {
        public int CitySno { get; set; }

        public int CountrySno { get; set; }
        public string CountryName { get; set; }
        public int StateSno { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public int Creopr { get; set; }
        public DateTime? CreatedDate { get; set; }
        //public string IpNumber { get; set; }
        public bool? Sts { get; set; }
        public int CityID { get; set; }

    }
}
