using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Operations
{
    public class CycleCountPlan
    {
        public int CycleCountPlanningSno { get; set; }
        public string CycleCountNo { get; set; }
        public int WarehouseSno { get; set; }
        public string Warehouse { get; set; }
        public string PlanningDate { get; set; }
        public string TypeOfCycleCount { get; set; }
        public string CycleCountDate { get; set; }
        public string CycleCountBasedOn { get; set; }
        public string StartDate { get; set; }
        public int NoOfMonth { get; set; }
        public string ActionName { get; set; }
        public int CreOpr { get; set; }
        public string IPNumber { get; set; }
        public bool Sts { get; set; }
        public bool SubmittedSts { get; set; }
    }
    public class CycleCountPlanDet
    {
        public int CycleCountPlanningDetSno { get; set; }
        public int CycleCountPlanningSno { get; set; }
        public int ItemSno { get; set; }
        public string ItemName { get; set; }
        public int ItemTypeSno { get; set; }
        public string ItemType { get; set; }
        public int SubZoneSno { get; set; }
        public string SubZone { get; set; }
        public int RackLocationSno { get; set; } 
        public string RackLocation { get; set; }
        public int StockTypeSno { get; set; }
        public string StockType { get; set; }
        public int UOMSno { get; set; }
        public string UOM { get; set; }
        public string BatchNo { get; set; }
        public bool Sts { get; set; }
    }    

    public class CycleCountPlanResult
    {
        public int CycleCountPlanningSno { get; set; }
        public string Result { get; set; }
    }
    public class CycleCountPlanList
    {
        public CycleCountPlan objCycleCountPlan { get; set; }
        public List<CycleCountPlanDet> ObjCycleCountPlanDet { get; set; }
    }
}
