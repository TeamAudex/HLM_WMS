using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
   public class CustomerLatLng
    {
        public int CustomerDetSno { get; set; }
        public string CustomerAddress { get; set; }
        public bool Sts { get; set; }

    }

    public class LatLng
    {
        public int CustomerDetSno { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class CustomerLatLngList
    {
        public List<CustomerLatLng> CustomerLatLng { get; set; }
       // public List<LatLng> LatLng { get; set; }
    }
}
