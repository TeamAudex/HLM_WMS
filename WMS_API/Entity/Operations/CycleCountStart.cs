using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Operations
{
  public  class CycleCountStart
    {
        public int CCphysicalSno { get; set; }
        public int CycleCountSno { get; set; }
        public string CycleCountNo { get; set; }
        public string PlanningDate { get; set; }
        public string Warehouse { get; set; }
        public string CycleCountBasedOn { get; set; }
        public int CycleCountPlanningSno { get; set; }
        public int Creopr { get; set; }
        public string StatusFlag { get; set; }

        public string IPNumber { get; set; }
        public string ActionName { get; set; }
        public string Err { get; set; }
        public string ErrMsg { get; set; }
        public string DocumentFilename { get; set; }
        public bool Sts { get; set; }
        public int LineColumn { get; set; }

        public List<CycleCountGrid> CycleCountGrid { get; set; }

        public List<CycleCountUPLOADDisplay> CycleCountUPLOADDisplay { get; set; }

        public List<CycleCountInsert> CycleCountInsert { get; set; }
    }
    public class CycleCountGrid
    {
        public int SubZoneSno { get; set; }
        public int RackLocationSno  { get; set; }
        public int PalletSno { get; set; }
        public int ItemNameSno { get; set; }
        public int PackageSno { get; set; }
        public string BatchNo { get; set; }
        public decimal Qty { get; set; }
        public string StorageLocation { get; set; }
    }
    public class CycleCountUPLOADDisplay
    {
        public string SubZone { get; set; }
        public string SubZone_Status { get; set; }
        public string RackLocation { get; set; }
        public string RackLocation_Status { get; set; }
        public string Pallet { get; set; }
        public string Pallet_Status { get; set; }
        public string ItemName { get; set; }
        public string ItemName_Status { get; set; }
        public string Package { get; set; }
        public string Package_Status { get; set; }
        public string BatchNo { get; set; }
        public string BatchNo_Status { get; set; }
        public decimal Qty { get; set; }
        public string StorageLocation { get; set; }
        public string StorageLocation_Status { get; set; }
        public string Cyclecount_STATUS { get; set; }
        public int error { get; set; }

    }
    public class CycleCountInsert
    {
        public int SubZoneSno { get; set; }
        public int RackLocationSno { get; set; }
        public int PalletSno { get; set; }
        public int ItemNameSno { get; set; }
        public int PackageSno { get; set; }
        public string BatchNo { get; set; }
        public decimal Qty { get; set; }
        public int StorageLocationsno { get; set; }
    }

    public class CycleCountExcel
    {
        public string SubZone { get; set; }
       
        public string RackLocation { get; set; }

        public string Pallet { get; set; }
     
        public string ItemName { get; set; }
 
        public string Package { get; set; }
       
        public string BatchNo { get; set; }
       
        public decimal Qty { get; set; }
        public string StorageLocation { get; set; }
 
      

    }

}
