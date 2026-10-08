using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class CustomerDet
    {
        public int CustomerDetSno { get; set; }
        public int CustomerSno { get; set; }
        public int AddressTypeSno { get; set; }
        public string AddressTypeName { get; set; }
        public string BranchName { get; set; }
        public int CitySno { get; set; }
        public string CityName { get; set; }
        public int StateSno { get; set; }
        public string StateName { get; set; }
        public string GSTINNo { get; set; }
        public string ContactPerson { get; set; }
        public string MobileNo { get; set; }
        public string MailID { get; set; }
        public string Address { get; set; }
        public string PINCODE { get; set; }
        public bool DefaultAddress { get; set; }
        public string Remarks { get; set; }
        public bool sts { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Geofence { get; set; }


    }


    public class Bisnussdet
    {


        public int CustomerSBUMapSno { get; set; }
        public int CustomerSno { get; set; }
        public int SBUSno { get; set; }
        public string BisnussUnitName { get; set; }
        public int DistibutorChannelSno { get; set; }
        public string DistibutorChannelName { get; set; }
        public bool sts { get; set; }



       ///// public bool sts { get; set; }


    }


}
