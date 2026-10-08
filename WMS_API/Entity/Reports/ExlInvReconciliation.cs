using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class ExlInvReconBoth
    {
        public ExlInvReconciliation ParentClass { get; set; }
        public List<ExlInvReconciliationDet> ChildClass { get; set; }
        public List<ExlInvReconciliationDet> ExlInvReconciliationDet { get; set; }
    }
    public class ExlInvReconciliation
    {
        public int PrimarySno { get; set; }
        public int ButtonCheck { get; set; }
        public int BranchSno { get; set; }
        public string Branch { get; set; }
        public int BusinessUnitSno { get; set; }
        public string BusinessUnit { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int InvoiceSno { get; set; }
        public int InvStsSno { get; set; }
        public string InvSts { get; set; }
        public int InvoiceNoSno { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public bool sts { get; set; }
        public string URL { get; set; }
        public string ActionName { get; set; }
        public int Creopr { get; set; }
        public DateTime CREDAT { get; set; }
        public string IPNumber { get; set; }


        public string DocumentFilename { get; set; }
        public string FilePath { get; set; }
        public List<ExlInvReconciliationDet> ExlInvReconciliationDet { get; set; }
        public bool Err { get; set; }
        public string ErrMsg { get; set; }
    }

    public class ExlInvReconciliationDet
    {
    public string DocumentFilename { get; set; }
    public string FilePath { get; set; }
    public string PrimarySno { get; set; }
    public string InvoiceNo { get; set; }
    public string InvoiceNoSts { get; set; }
    public string InvoiceDate { get; set; }
    public string InvoiceDateSts { get; set; }
    public string InvoiceStatus { get; set; }
    public string InvoiceStatusSts { get; set; }
    public string FMSStatus { get; set; }
    public string FMSStatusSts { get; set; }
    public bool sts { get; set; }
}
}
