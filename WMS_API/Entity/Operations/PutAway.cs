using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Operations
{
    public class PutAway
    {
        public int PutAwaySno { get; set; }
        public string PutAwayNo { get; set; }
        public string Warehouse { get; set; }
        public int WarehouseSno { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string GrnNo { get; set; }
        public int GrnSno { get; set; }
        public string SelectedGrn { get; set; }
        public string SelectedGrnSno { get; set; }
        public string BatchNo { get; set; }
        public string SelectedBatchNo { get; set; }
        public string LotNo { get; set; }
        public string SelectedLotNo { get; set; }
        public string EntryDate { get; set; }
        public string PutterName { get; set; }
        public int PutterSno { get; set; }
        public int CreOpr { get; set; }
        public string ActionName { get; set; }
        public string IPNumber { get; set; }
        public string PutAwayType { get; set; }
        public bool VirtualLoc { get; set; }
        public int VirtualLocSno { get; set; }
        public string VirtualLocName { get; set; }
        public bool BatchMixingFlag { get; set; }
        public int StoragelocationSno { get; set; }
        public string Storagelocation { get; set; }
        public bool PutawaySts { get; set; }
    }
    public class PutAwayDet
    {
        public int GRNSno { get; set; }
        public int GRNDetSno { get; set; }
        public string GRNNumber { get; set; }
        public string GRNDate { get; set; }
        public string Sender { get; set; }
        public string TrnType { get; set; }
        public string SecondaryTrnNo { get; set; }
        public string SecondaryTrnDate { get; set; }
        public string ItemName { get; set; }
        public string BatchNo { get; set; }
        public string ExpDate { get; set; }
        public string MFGDate { get; set; }
        public string LOTNo { get; set; }
        public string UOM { get; set; }
        public decimal Qty { get; set; }
        public string PutterName { get; set; }
        public int PutterSno { get; set; }
        public bool Sts { get; set; }
        public int StoragelocationSno { get; set; }
        public string Storagelocation { get; set; }
    }
    public class PutAwaySave
    {
        public PutAway objPutAway { get; set; }
        public List<PutAwayDet> ArrPutAwayDet { get; set; }
    }

    public class PutAwayResponse
    {
        public string Result { get; set; }
        public int PutAwaySno { get; set; }
    }
    public class PutAwaySearch
    {
        public int PutAwaySno { get; set; }
        public string PutAwayNo { get; set; }
        public string Warehouse { get; set; }
        public string EntryDate { get; set; }
        public string Status { get; set; }
        public bool PutawaySts { get; set; }
    }
    public class PutAwayDash
    {
        public int PutAwaySno { get; set; }
        public int PutAwayDetSno { get; set; }
        public int PutAwayLocSno { get; set; }
        public string PutAwayNo { get; set; }
        public string PutAwayDate { get; set; }
        public string WarehouseName { get; set; }
        public string GRNNo { get; set; }
        public string SenderName { get; set; }
        public string ItemName { get; set; }
        public string BatchNo { get; set; }
        public decimal Qty { get; set; }
        public string UOM { get; set; }
        public int LocationSno { get; set; }
        public int SubZoneSno { get; set; }
        public string Location { get; set; }
        public int PalletSno { get; set; }
        public int PalletTypeSno { get; set; }
        public string Pallet { get; set; }
        public int EmployeeSno { get; set; }
    }
    public class PutAwayConfirm
    {
        public int PutAwaySno { get; set; }
        public int PutAwayDetSno { get; set; }
        public int PutAwayLocSno { get; set; }
        public string PutAwayNo { get; set; }
        public string PutAwayDate { get; set; }
        public int WarehouseSno { get; set; }
        public string WarehouseName { get; set; }
        public string GRNNo { get; set; }
        public string SenderName { get; set; }
        public string ItemName { get; set; }
        public string BatchNo { get; set; }
        public decimal Qty { get; set; }
        public string UOM { get; set; }
        public int LocationSno { get; set; }
        public int SubZoneSno { get; set; }
        public string Location { get; set; }
        public int PalletSno { get; set; }
        public int PalletTypeSno { get; set; }
        public string Pallet { get; set; }
        public int EmployeeSno { get; set; }
        public int GRNDetSno { get; set; }
        public int ItemSno { get; set; }
        public int StoragelocationSno { get; set; }
        public string Storagelocation { get; set; }
    }
    public class PAConfirm
    {
        public int PutAwaySno { get; set; }
        public int PutAwayDetSno { get; set; }
        public int PutAwayLocSno { get; set; }
        public string PutAwayNo { get; set; }
        public string PutAwayDate { get; set; }
        public int WarehouseSno { get; set; }
        public string WarehouseName { get; set; }
        public string GRNNo { get; set; }
        public string SenderName { get; set; }
        public string ItemName { get; set; }
        public string BatchNo { get; set; }
        public decimal Qty { get; set; }
        public string UOM { get; set; }
        public int LocationSno { get; set; }
        public int SubZoneSno { get; set; }
        public string Location { get; set; }
        public int PalletSno { get; set; }
        public int PalletTypeSno { get; set; }
        public string Pallet { get; set; }
        public int EmployeeSno { get; set; }
        public int GRNDetSno { get; set; }
        public int ItemSno { get; set; }
        public int StoragelocationSno { get; set; }
        public string Storagelocation { get; set; }
        public bool sts { get; set; }
        public string LocationFlag { get; set; }
        public string EntryType { get; set; }
        public int FromLocationSno { get; set; }
        public int FromSubZoneSno { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public int FromPalletSno { get; set; }
        public int FromPalletTypeSno { get; set; }
        public string FromItemName { get; set; }
        public string ToItemName { get; set; }
        public string FromBatchNo { get; set; }
        public string ToBatchNo { get; set; }
    }
    public class PAConfirmDet
    {
        public int PutAwayLocSno { get; set; }
        public decimal Qty { get; set; }
        public int LocationSno { get; set; }
        public int SubZoneSno { get; set; }
        public string Location { get; set; }
        public int PalletSno { get; set; }
        public int PalletTypeSno { get; set; }
        public string Pallet { get; set; }
        public bool sts { get; set; }
    }
    public class PAFetch
    {
        public PAConfirm objPAConfirm { get; set; }
        public List<PAConfirmDet> ArrPutAway { get; set; }
    }
    public class PACDash
    {
        public int PutAwaySno { get; set; }
        public string PutAwayNo { get; set; }
        public string PutAwayDate { get; set; }
        public string WarehouseName { get; set; }
        public int GRNSno { get; set; }
        public string GRNNo { get; set; }
        public string SenderName { get; set; }
    }
    public class PACDashDet
    {
        public int PutAwaySno { get; set; }
        public int PutAwayDetSno { get; set; }
        public int PutAwayLocSno { get; set; }
        public string PutAwayNo { get; set; }
        public string PutAwayDate { get; set; }
        public string WarehouseName { get; set; }
        public int GRNSno { get; set; }
        public string GRNNo { get; set; }
        public string SenderName { get; set; }
        public string ItemName { get; set; }
        public string BatchNo { get; set; }
        public decimal Qty { get; set; }
        public string UOM { get; set; }
        public int LocationSno { get; set; }
        public int SubZoneSno { get; set; }
        public string Location { get; set; }
        public int PalletSno { get; set; }
        public int PalletTypeSno { get; set; }
        public string Pallet { get; set; }
        public int EmployeeSno { get; set; }
    }
    public class PACDashFetch
    {
        public List<PACDash> objPACDash { get; set; }
        public List<PACDashDet> objPACDashDet { get; set; }
    }
    public class LocData
    {
        public int LocationSno { get; set; }
        public string Location { get; set; }
        public int SubZoneSno { get; set; }
        public int PalletTypeSno { get; set; }
    }
}
