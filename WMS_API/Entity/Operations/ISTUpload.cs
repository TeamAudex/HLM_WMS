using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Operations
{
  public class ISTUpload
    {
        public int InternalStockTransferSno { get; set; }
        public string ISTNo { get; set; }
        public int WarehouseSno { get; set; }
        public string WarehouseName { get; set; }
        public string TransferDate { get; set; }
        public string Remarks { get; set; }
        public int EmployeeSno { get; set; }
        public string Employee { get; set; }
        public int TypeofStockSno { get; set; }
        public string TypeofStock { get; set; }
        public int FromSTSno { get; set; }
        public int ToSTSno { get; set; }
        public int Creopr { get; set; }
        public string IPNumber { get; set; }
        public bool Sts { get; set; }
        public bool PostingSts { get; set; }
        public string Status { get; set; }
        public int MovementTypeSno { get; set; }
        public string TypeFlag { get; set; }
        public string MovementType { get; set; }
        public string UploadFileName { get; set; }
        public bool Error { get; set; }
        public string ErrMsg { get; set; }
        public bool ErrSts { get; set; }
    }

    public class ISTUploadDet
    {
        public int InternalStockTransferDetSno { get; set; }
        public int InternalStockTransferSno { get; set; }
        public int PutAwayLocSno { get; set; }
        public int GRNDetSno { get; set; }
        //public string IssueOrderNo             {get; set;}
        //public string IssueOrderDate           {get; set;}
        public int ReceiverSno { get; set; }
        public string Receiver { get; set; }
        public string ReceiverType { get; set; }
        //public string TransactionType          { get; set; }
        public int ItemSno { get; set; }
        public string ItemName { get; set; }
        public int BatchSno { get; set; }
        public string BatchNo { get; set; }
        public string ExpDate { get; set; }
        public decimal Qty { get; set; }
        public string UOM { get; set; }
        public int LocationSno { get; set; }
        public int SubZoneSno { get; set; }
        public string Location { get; set; }
        public int PalletSno { get; set; }
        public int PalletTypeSno { get; set; }
        public string Pallet { get; set; }
        public int ToLocationSno { get; set; }
        public int ToSubZoneSno { get; set; }
        public string ToLocation { get; set; }
        public int ToPalletSno { get; set; }
        public int ToPalletTypeSno { get; set; }
        public string ToPallet { get; set; }
        public decimal ToQty { get; set; }
        public string Remarks { get; set; }
        public int ReceivedBySno { get; set; }
        public string ReceivedBy { get; set; }
        public bool Sts { get; set; }
        public int UOMSno { get; set; }
        public int ToItemSno { get; set; }
        public string ToItemName { get; set; }
        public int ToUOMSno { get; set; }
        public int ToBatchSno { get; set; }
        public string ToBatchNo { get; set; }
        public string ToExpDate { get; set; }
        public decimal CodeVal { get; set; }
    }

    public class ISTUploadDisplay
    {
        public int InternalStockTransferDetSno { get; set; }
        public int InternalStockTransferSno { get; set; }
        public int PutAwayLocSno { get; set; }
        public int GRNDetSno { get; set; }
        //public string IssueOrderNo             {get; set;}
        //public string IssueOrderDate           {get; set;}
        public int ReceiverSno { get; set; }
        public string Receiver { get; set; }
        public string ReceiverType { get; set; }
        //public string TransactionType          { get; set; }
        public int ItemSno { get; set; }
        public string ItemName { get; set; }
        public int BatchSno { get; set; }
        public string BatchNo { get; set; }
        public string ExpDate { get; set; }
        public decimal Qty { get; set; }
        public string UOM { get; set; }
        public int LocationSno { get; set; }
        public int SubZoneSno { get; set; }
        public string Location { get; set; }
        public int PalletSno { get; set; }
        public int PalletTypeSno { get; set; }
        public string Pallet { get; set; }
        public int ToLocationSno { get; set; }
        public int ToSubZoneSno { get; set; }
        public string ToLocation { get; set; }
        public int ToPalletSno { get; set; }
        public int ToPalletTypeSno { get; set; }
        public string ToPallet { get; set; }
        public decimal ToQty { get; set; }
        public string Remarks { get; set; }
        public int ReceivedBySno { get; set; }
        public string ReceivedBy { get; set; }
        public bool Sts { get; set; }
        public int UOMSno { get; set; }
        public int ToItemSno { get; set; }
        public string ToItemName { get; set; }
        public int ToUOMSno { get; set; }
        public int ToBatchSno { get; set; }
        public string ToBatchNo { get; set; }
        public string ToExpDate { get; set; }
        public bool Error { get; set; }
        public decimal CodeVal { get; set; }

        public string ItemName_Status { get; set; }
        public string BatchNo_Status { get; set; }
        public string UOM_Status { get; set; }
        public string ToQty_Status { get; set; }
        public string ToItemName_Status { get; set; }
        public string ToBatchNo_Status { get; set; }
        public string Stock_Status { get; set; }
        public string ToExpDate_Status { get; set; }
    }

    public class ISTUploadList
    {
        public ISTUpload objISTUpload { get; set; }
        public List<ISTUploadDet> objISTUploadDet { get; set; }
        public List<ISTUploadDisplay> objISTUploadDisplay { get; set; }
        public List<ISTUploadDetails> objISTUploadDetails { get; set; }
    }

    public class ISTUploadDetails
    {
        public int ItemSno { get; set; }
        public string ItemName { get; set; }
        public string BatchNo { get; set; }
        public int UOMSno { get; set; }
        public string UOM { get; set; }
        public decimal ToQty { get; set; }
        public int ToItemSno { get; set; }
        public string ToItemName { get; set; }
        public string ToBatchNo { get; set; }
        public int ToUOMSno { get; set; }
        public string ToExpDate { get; set; }
        public int ReceivedBySno { get; set; }
        public string ReceivedBy { get; set; }
        public decimal CodeVal { get; set; }
    }
}
