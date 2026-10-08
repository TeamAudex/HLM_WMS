using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Operations
{
   public class Dispatch
    {
        public int DispatchSno { get; set; }
        public string DispatchNo { get; set; }
        public int WarehouseSno { get; set; }
        public string WarehouseName { get; set; }
        public string DispatchDate { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int IssueOrderSno { get; set; }
        public string IssueOrder { get; set; }
        public string TxtIssueOrderSno { get; set; }
        public string TxtIssueOrder { get; set; }
        public int StockTypeSno { get; set; }
        public string StockType { get; set; }
 
        public int Creopr { get; set; }
        public string IPNumber { get; set; }

        public bool Sts { get; set; }
    }

    public class DispatchDet
    {
        public int DispatchDetSno { get; set; }
        public int DispatchSno { get; set; }
        public int IssueOrderDetSno { get; set; }
        public int IssueOrderSno { get; set; }
        public string IssueOrderNo { get; set; }
        public string IssueOrderDate { get; set; }
        public decimal TotQty { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public bool Sts { get; set; }
       
    }

    public class DispatchList
    {
        public Dispatch objDispatch { get; set; }
        public List<DispatchDet> objDispatchDet { get; set; }
    }

    public class DispatchResponse
    {
        public string Result { get; set; }
        public int DispatchSno { get; set; }
    }
}
