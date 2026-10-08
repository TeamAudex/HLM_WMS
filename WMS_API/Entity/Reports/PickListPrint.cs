using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Reports
{
   public class PickListPrint
    {
        public int WarehouseSno { get; set; }
        public string WarehouseName { get; set; }
        public string PickListDate { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int IssueOrderSno { get; set; }
        public string IssueOrder { get; set; }
        public string TxtIssueOrderSno { get; set; }
        public string TxtIssueOrder { get; set; }

        public int PLSno { get; set; }
        public string PLNo { get; set; }
        public string TxtPLSno { get; set; }
        public string TxtPLNo { get; set; }


        public int PickerSno { get; set; }
        public string PickerName { get; set; }
        public string TxtPickerSno { get; set; }
        public string TxtPickerName { get; set; }
    }

    public class PickListPrintDet
    {
        public int PickListSno { get; set; }
        public int IssueOrderSno { get; set; }
        public string PicklistNo { get; set; }
        public string PicklistDate { get; set; }
        public string IssueOrderNo { get; set; }
        public string IssueOrderDate { get; set; }
        public string Receiver { get; set; }
        public string PickerName { get; set; }
        public string PrintURL { get; set; }
        public string UOMCnt { get; set; }
    }
}
