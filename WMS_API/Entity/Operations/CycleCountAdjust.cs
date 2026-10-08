using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Operations
{
    public class CycleCountAdjust
    {
        public int CycleCountSno { get; set; }
        public string CycleCountNo { get; set; }
        public string CycleCountDate { get; set; }
        public string WarehouseName { get; set; }
        public string AdjustDate { get; set; }
        public string ReqLog { get; set; }
        public int CreOpr { get; set; }
        public string IpNumber { get; set; }
        public bool Sts { get; set; }
        public string ApprovalStatus { get; set; }
        public bool SubmittedSts { get; set; }

    }

    public class CycleCountAdjustDet
    {
        public int CCphysicalSno { get; set; }
        public int LocStockSno { get; set; }
        public int SubZoneSno { get; set; }
        public string SubZone { get; set; }
        public int WHRowColumnSno { get; set; }
        public string WHRowColumn { get; set; }
        public string Pallet { get; set; }
        public int StockTypeSno { get; set; }
        public string StockType { get; set; }
        public string StockCode { get; set; }
        public string ItemName { get; set; }
        public string ItemPackage { get; set; }
        public string BatchNo { get; set; }
        public string ExpDate { get; set; }
        public decimal SystemCount { get; set; }
        public decimal PhysicalCount { get; set; }
        public decimal DifferenceCount { get; set; }
        public string Reason { get; set; }
        public int StorageLocationSno { get; set; }
        public string StoragelocationName { get; set; }
        public string ApproverRemarks { get; set; }
    }

    public class CycleCountList
    {
        public CycleCountAdjust objCycleCount { get; set; }
        public List<CycleCountAdjustDet> ArrCycleCountDet { get; set; }

    }
    public class CycleCountAdjustSearch
    {
        public string CycleCountNo { get; set; }
        public int CycleCountSno { get; set; }
        public string Warehouse { get; set; }
        public string CyclecountDate { get; set; }
        public string StartDate { get; set; }
        public string FromDate { get; set; }
        public string Status { get; set; }

    }

    public class STDD
    {
        public int StockTypeSno { get; set; }
        public string StockType { get; set; }
        public string StockCode { get; set; }
    }
}
