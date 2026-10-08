using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Operations
{
   public class InternalStockTransfer
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
    }
    public class InternalStockTransferDet
    {
        public int InternalStockTransferDetSno {get; set;}
        public int InternalStockTransferSno    {get; set;}
        public int PutAwayLocSno { get; set; }
        public int GRNDetSno               {get; set;}
        //public string IssueOrderNo             {get; set;}
        //public string IssueOrderDate           {get; set;}
        public int ReceiverSno                 {get; set;}
        public string Receiver                 {get; set;}
        public string ReceiverType             {get; set;}
        //public string TransactionType          { get; set; }
        public int ItemSno                     {get; set;}
        public string ItemName                 {get; set;}
        public int BatchSno { get; set; }
        public string BatchNo                  {get; set;}
        public string ExpDate                  {get; set;}
        public int Qty                         {get; set;}
        public string UOM                      {get; set;}
        public int LocationSno                 {get; set;}
        public int SubZoneSno                  {get; set;}
        public string Location                 {get; set;}
        public int PalletSno                   {get; set;}
        public int PalletTypeSno               {get; set;}
        public string Pallet                   {get; set;}
        public int ToLocationSno               {get; set;}
        public int ToSubZoneSno                {get; set;}
        public string ToLocation               {get; set;}
        public int ToPalletSno                 {get; set;}
        public int ToPalletTypeSno             {get; set;}
        public string ToPallet                 {get; set;}
        public int ToQty                       {get; set;}
        public string Remarks { get; set; }
        public int ReceivedBySno { get; set; }
        public string ReceivedBy { get; set; }
        public bool Sts                        {get; set;}
        public int UOMSno { get; set; }
    }
    public class ISTList
    {
        public InternalStockTransfer objIST { get; set; }
        public List<InternalStockTransferDet> objISTDet { get; set; }
    }

    public class ISTResponse
    {
        public string Result { get; set; }
        public string PostingLogFile { get; set; }
        public int ISTSno { get; set; }
    }
    public class ISTConfirmation
    {
        public List<ISTMatCreate> MatCreate { get; set; }
    }

    public class ISTMatCreate
    {
      public string warehouse { get; set;}
      public string trans_type { get; set;}
      public string ist_number { get; set;}
      public string ist_date { get; set;}
      public string stor_loc_from { get; set;}
      public string stor_loc_to { get; set;}
      public string item_code_from { get; set;}
      public string item_code_to { get; set; }
      public string batch_num_from { get; set;}
      public string batch_num_to { get; set;}
      public string uom { get; set;}
      public string quan { get; set; }
    }

    public class ISTConfirmationResponse
    {
        public string MESS_TYPE { get; set; }
        public string MESSAGE { get; set; }
        public string MESS_ID { get; set; }
        public string MESS_NUM { get; set; }
        public string Result { get; set; }
        public string ErrorFlag { get; set; }
    }
    public class ISTConfirmRespDetails
    {
        public string Result { get; set; }
        public string ErrorFlag { get; set; }
        public List<ISTConfirmationResponse> objISTConfirmationResponse { get; set; }
    }
}
