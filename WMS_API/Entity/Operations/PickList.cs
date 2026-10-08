using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Operations
{
    public class PickList
    {
        public int PickListSno                    { get; set;}
        public string PickListNo                  { get; set; }
        public int WarehouseSno                   { get; set;}
        public string WarehouseName               { get; set;}
        public string PickListDate                {get; set;}
        public string FromDate                    {get; set;}
        public string ToDate                      {get; set;}
        public int IssueOrderSno                  {get; set;}
        public string IssueOrder                  {get; set;}
        public string TxtIssueOrderSno            {get; set;}
        public string TxtIssueOrder               {get; set;}
        public int TransactionTypeSno             {get; set;}
        public string TransactionType             {get; set;}
        public int StockTypeSno { get; set; }
        public string StockType { get; set; }
        public int BatchSno                       {get; set;}
        public string BatchNo                     {get; set;}
        public string TxtBatchSno                 {get; set;}
        public string TxtBatchNo                  {get; set;}
        public int EmployeeSno                    {get; set;}
        public string Employee                    {get; set;}
        public bool VirtualLocationSts { get; set; }
        public int VirtualLocSno { get; set; }
        public string VirtualLocName { get; set; }
        public int StoragelocationSno { get; set; }
        public string Storagelocation { get; set; }
        public int NoofOrders { get; set; }
        
        public int Creopr                         {get; set;}
        public string IPNumber                    {get; set;}

        public bool Sts                           {get; set;}
    }

    public class PickListOrder
    {
        public Int64 TotalOrder { get; set; }
        public Int64 FilterOrder { get; set; }
    }

    public class PickListDet
    {
        public int PickListDetSno { get; set; }
        public int PickListSno { get; set; }
        public int IssueOrderDetSno { get; set; }
        public int IssueOrderSno { get; set; }
        public string IssueOrderNo { get; set; }
        public string IssueOrderDate { get; set; }
        public string Receiver { get; set; }
        public int ReceiverSno { get; set; }
        public string ReceiverType { get; set; }
        public string TransactionType { get; set; }
        public string ItemName { get; set; }
        public string BatchNo { get; set; }
        public string ExpDate { get; set; }
        public string UOM { get; set; }
        public decimal Qty { get; set; }
        public int ReceivedBySno { get; set; }
        public string ReceivedBy { get; set; }
        public string Location { get; set; }
        public string Pallet { get; set; }
        public bool Sts { get; set; }
        public string StockType { get; set; }
        public int StoragelocationSno { get; set; }
        public string Storagelocation { get; set; }
    }
    public class PickListSTDet
    {
    
        public int IssueOrderDetSno { get; set; }
        public int IssueOrderSno { get; set; }    
        public int ItemSno { get; set; }
        public string BatchNo { get; set; }
        public int UOMSno { get; set; }
        public decimal Qty { get; set; }
        public int ReceivedBySno { get; set; }
        public int FromStoragelocationSno { get; set; }
        public int ToStoragelocationSno { get; set; }
        public bool Sts { get; set; }
    }
    public class PickListResponse
    {
        public string Result { get; set; }
        public int PickListSno { get; set; }
        public bool StockFlag { get; set; }
        public List<PickListDet> objPickListDet { get; set; }
        public int ISTSno { get; set; }
        public int cnt { get; set; }
    }

    public class PickListDropDown
    {
        public List<PickListDD> PickListDD { get; set; }
        public List<StockTypeDD> StockTypeDD { get; set; }
    }

   

    public class StockTypeDD 
    {
        public int StockTypeSno { get; set; }
        public string StockType { get; set; }
    }

    public class PickListDD
    {
        public int TransactionTypeSno { get; set; }
        public string TransactionType { get; set; }
    }
    public class PickListDetails
    {
        public PickList objPickList { get; set; }
        public List<PickListDet> objPickListDet { get; set; }
        public PickListOrder objPickListOrder { get; set; }
        public List<PickListSTDet> objPickListSTDet { get; set; }
    }

    public class PickListDashboard
    {
        public int PickListDetSno { get; set; }
        public int PickListSno { get; set; }
        public int PickListLocSno { get; set; }
        public string PickListNo { get; set; }
        public string PickListDate { get; set; }
        public string WarehouseName { get; set; }
        public string IssueOrderNo { get; set; }
        public string CustomerName { get; set; }
        public string ItemName { get; set; }
        public decimal Qty { get; set; }
        public string UOM { get; set; }
        public string Location { get; set; }
        public string Pallet { get; set; }
        public string PLNo { get; set; }
    }

    public class PickListConfirmation
    {
        public int PickListDetSno { get; set; }
        public int PickListSno { get; set; }
        public int PickListLocSno { get; set; }
        public string PickListNo { get; set; }
        public string PickListDate { get; set; }
        public int WarehouseSno { get; set; }
        public string WarehouseName { get; set; }
        public int IssueOrderDetSno { get; set; }
        public int IssueOrderSno { get; set; }
        public string IssueOrderNo { get; set; }
        public string CustomerName { get; set; }

        public int ItemSno { get; set; }
        public string ItemName { get; set; }
        public string BatchNo { get; set; }
        public decimal Qty { get; set; }
        public string UOM { get; set; }
        public int LocationSno { get; set; }
        public string Location { get; set; }
        public int SubZoneSno { get; set; }
        public int PalletSno { get; set; }
        public string Pallet { get; set; }
        public int PalletTypeSno { get; set; }
        public string Types { get; set; }
        public int StoragelocationSno { get; set; }
        public string Storagelocation { get; set; }
    }
    public class PickListDash
    {
        public int PickListSno { get; set; }
        public int IssueOrderDetSno { get; set; }
        public int SubZoneSno { get; set; }
        public int LocationSno { get; set; }
        public string PickListNo { get; set; }
        public string PickListDate { get; set; }
        public string WarehouseName { get; set; }
        public string IssueOrderNo { get; set; }
        public string CustomerName { get; set; }
        public string ItemName { get; set; }
        public decimal Qty { get; set; }
        public string UOM { get; set; }
        public string Location { get; set; }
        public string Pallet { get; set; }
        public string PLNo { get; set; }
        public int StoragelocationSno { get; set; }
        public string Storagelocation { get; set; }
        public string BatchNo { get; set; }
        public string UOMCnt { get; set; }
    }
    public class PickListConfirmList
    {
        public PickListConfirm PLConfirmation { get; set; }
        public List<PickListConfirmDet> PLConfirmationDet { get; set; }
    }
    public class PickListConfirm
    {
        public int PickListSno { get; set; }
        public string PickListNo { get; set; }
        public string PickListDate { get; set; }
        public int WarehouseSno { get; set; }
        public string WarehouseName { get; set; }
        public int IssueOrderDetSno { get; set; }
        public int IssueOrderSno { get; set; }
        public string IssueOrderNo { get; set; }
        public string CustomerName { get; set; }

        public int ItemSno { get; set; }
        public string ItemName { get; set; }
        public string BatchNo { get; set; }
        public string UOM { get; set; }
        public int LocationSno { get; set; }
        public string Location { get; set; }
        public int SubZoneSno { get; set; }
        public string Types { get; set; }
        public int StoragelocationSno { get; set; }
        public string Storagelocation { get; set; }
        public string LocationFlag { get; set; }
    }
    public class PickListConfirmDet
    {
        public int PickListLocSno { get; set; }
        public int IssueOrderDetSno { get; set; }
        public decimal Qty { get; set; }
        public string UOM { get; set; }
        public int LocationSno { get; set; }
        public string Location { get; set; }
        public int SubZoneSno { get; set; }
        public int PalletSno { get; set; }
        public string Pallet { get; set; }
        public int PalletTypeSno { get; set; }
        public int MovementType { get; set; }
        public bool ToPalletRequired { get; set; }
        public decimal MinQty { get; set; }
    }

    public class IssueOrderConfirmation
    {
        public string Delivery_Number { get; set; }
    }

   

    public class IssueOrderConfirmationResponse
    {
        public string MESS_TYPE { get; set; }
        public string MESSAGE { get; set; }
        public string MESS_ID { get; set; }
        public string MESS_NUM { get; set; }
    }
    public class PLLocData
    {
        public int LocationSno { get; set; }
        public string Location { get; set; }
        public int SubZoneSno { get; set; }
        public int PalletTypeSno { get; set; }
        public int MovementType { get; set; }
    }
    public class PLConfirm
    {
        public int PickListSno { get; set; }
        public int IssueOrderSno { get; set; }
        public string PickListNo { get; set; }
        public string PickListDate { get; set; }
        public string WarehouseName { get; set; }
        public string IssueOrderNo { get; set; }
        public string CustomerName { get; set; }
        public string UOMCnt { get; set; }
    }
    public class PLConfirmDet
    {
        public int PickListSno { get; set; }
        public int IssueOrderSno { get; set; }
        public int IssueOrderDetSno { get; set; }
        public int SubZoneSno { get; set; }
        public int LocationSno { get; set; }
        public string PickListNo { get; set; }
        public string PickListDate { get; set; }
        public string WarehouseName { get; set; }
        public string IssueOrderNo { get; set; }
        public string CustomerName { get; set; }
        public string ItemName { get; set; }
        public decimal Qty { get; set; }
        public string UOM { get; set; }
        public string Location { get; set; }
        public string Pallet { get; set; }
        public string PLNo { get; set; }
        public int StoragelocationSno { get; set; }
        public string Storagelocation { get; set; }
        public string BatchNo { get; set; }
    }
    public class PLConfirmDash
    {
        public List<PLConfirm> objPLConfirm { get; set; }
        public List<PLConfirmDet> objPLConfirmDet { get; set; }
    }

    public class PickListPickerSearch
    {
        public int PickListSno { get; set; }
        public string PickListNo { get; set; }
        public string PickListDate { get; set; }
        public string IssueOrderNo { get; set; }
        public string IssueOrderDate { get; set; }
        public string PickerName { get; set; }
        public string ConfirmationStatus { get; set; }
    }
}
