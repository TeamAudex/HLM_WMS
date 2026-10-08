using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class CityMas
    {
        public CityWithlocation CityWithlocation { get; set; }
        public List<CityWithlocationDet> CityWithlocationDet { get; set; }
    }



    public class CityWithlocation
    {

        public int CitySno { get; set; }
        public int CountrySno { get; set; }
        public string CountryName { get; set; }
        public int StateSno { get; set; }
        public string StateName { get; set; }

        public string CityName { get; set; }

        public string CityCode { get; set; }
        public int ZoneMasSno { get; set; }
        public string ZoneName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }          
        public string ActionName { get; set; }
        public string IPNumber { get; set; }
        public int CreOpr { get; set; }
        public bool Sts { get; set; }

    }

    public class CityWithlocationDet
    {
        public int CityDetSno { get; set; }
        public int CitySno { get; set; }
        public string LocationName  { get; set; }
        public string Pincode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool Sts { get; set; }
    }

}