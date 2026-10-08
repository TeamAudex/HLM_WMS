using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class DshFHITot
    {
        public int DcSno { get; set; }
        public string DCName { get; set; }
        public decimal TotalInvoiceValue { get; set; }
        public decimal PTLInvoiceValue { get; set; } 
        public decimal FTLInvoiceValue { get; set; } 
        public decimal DedicatedInvoiceValue { get; set; } 
        public decimal TotalFreightValue { get; set; } 
        public decimal TotalAPFreightValue { get; set; }
        public decimal TotalProvFreightValue { get; set; }
        public decimal TotalPTLFreightValue { get; set; }
        public decimal PTLAPFreightValue { get; set; }
        public decimal PTLProvFreightValue { get; set; }
        public decimal TotalFTLFreightValue { get; set; }
        public decimal FTLAPFreightValue { get; set; }
        public decimal FTLProvFreightValue { get; set; }
        public decimal TotalDedicateFreightValue { get; set; }
        public decimal DedicateAPFreightValue { get; set; }
        public decimal DedicateProvFreightValue { get; set; }
        public decimal PTLInvoicePercent { get; set; }
        public decimal FTLInvoicePercent { get; set; }
        public decimal DedicatedInvoicePercent { get; set; }
        public decimal TotalFreightPercent { get; set; }
        public decimal TotalAPFreightPercent { get; set; }
        public decimal TotalProvFreightPercent { get; set; }
        public decimal TotalPTLFreightPercent { get; set; }
        public decimal PTLAPFreightPercent { get; set; }
        public decimal PTLProvFreightPercent { get; set; }
        public decimal TotalFTLFreightPercent { get; set; }
        public decimal FTLAPFreightPercent { get; set; }
        public decimal FTLProvFreightPercent { get; set; }
        public decimal TotalDedicateFreightPercent { get; set; }
        public decimal DedicateAPFreightPercent { get; set; }
        public decimal DedicateProvFreightPercent { get; set; }
    }
}
