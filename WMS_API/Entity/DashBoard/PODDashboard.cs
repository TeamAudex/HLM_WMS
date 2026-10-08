using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class PODDashboard
    {
    }
    public class PODInvoiceDet
    {
        public string CrnNo { get; set; }
        public int NoofInv { get; set; }
        public string LRNo { get; set; }
        public int LRSno { get; set; }
        public int InvoiceSno { get; set; }
        public string InvoiceNo { get; set; }
        public string ShipTo { get; set; }
        public string ETADate { get; set; }
        public string ETATime { get; set; }
    }
}
