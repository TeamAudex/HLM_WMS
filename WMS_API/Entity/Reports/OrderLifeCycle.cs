using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class OrderLifeCycleRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int UserSno { get; set; }
        public int CompanySno { get; set; }
        public int BranchSno { get; set; }
        public int SBUSno { get; set; }
        public int OrderSno { get; set; }
        public string OrderFromDate { get; set; }
        public string OrderToDate { get; set; }
        public int CustomerSno { get; set; }
        public int InvoiceSno { get; set; }
        public string InvoiceFromDate { get; set; }
        public string InvoiceToDate { get; set; }
        public decimal InvoiceFromValue { get; set; }
        public decimal InvoiceToValue { get; set; }
        public int CommoditySno { get; set; }
        public int ApprovedBySno { get; set; }
        public string ApprovedStatus { get; set; }
        public string ApproveFromDate { get; set; }
        public string ApproveToDate { get; set; }
        public string TripFromDate { get; set; }
        public string TripToDate { get; set; }
        public string LRFromDate { get; set; }
        public string LRToDate { get; set; }
        public int LSPSno { get; set; }
        public int PODSno { get; set; }
        public string PODFromDate { get; set; }
        public string PODToDate { get; set; }
        public string PODDelivery { get; set; }
        public string DisputeForPOD { get; set; }
        public string DisputeForBill { get; set; }
        public string TrnType { get; set; }
        public string FileName { get; set; }
        public bool AppendTime { get; set; }
        public List<KeyValuePair<string, string>> ExportList { get; set; }
    }
    public class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class OrderLifeCycleGrid
    {
        public string CompanyName { get; set; }
        public string BranchName { get; set; }
        public string SBUName { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string Customer { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string MobileNo { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public decimal InvoiceValue { get; set; }
        public string CommodityName { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public int NOP { get; set; }
        public decimal VolumetricWeight { get; set; }
        public decimal ChargeableWeight { get; set; }
        public string FOCApprovalBy { get; set; }
        public string FOCApprovalStatus { get; set; }
        public string FOCApprovalDate { get; set; }
        public string FOCApprovalRemarks { get; set; }
        public string LSPName { get; set; }
        public string LRNo { get; set; }
        public string LRDate { get; set; }
        public string PickDispatchDate { get; set; }
        public string EDD { get; set; }
        public string PODActualDeliveryDate { get; set; }
        public string PODDateDiff { get; set; }
        public int PODRecPkgs { get; set; }
        public decimal PODRecVol { get; set; }
        public decimal PODRecWgt { get; set; }
        public decimal NcCharges { get; set; }
        public string ApprovalStatusNcCharges { get; set; }
        public string LSPBillStatus { get; set; }
        public string sysBillDate      {get;set;}
        public string sysBillNo        {get;set;}
        public string vendorsubBillNo  {get;set;}
        public string vendorsubBillDate {get;set;}
        public decimal NcApprovedAmount { get; set; }
        public int CURecPkgs { get; set; }
        public decimal CURecVol { get; set; }
        public decimal CURecWgt { get; set; }
        public int CUDamagePkgs { get; set; }
        public decimal CUDamageVol { get; set; }
        public decimal CUDamageWgt { get; set; }
        public int CUPilferagePkgs { get; set; }
        public decimal CUPilferageVol { get; set; }
        public decimal CUPilferageWgt { get; set; }
        public string  cuApprovedFlag   { get; set; }
        public string  cuApprovedBy    { get; set; }
        public string  cuRemarks        { get; set; }
        public decimal cuCreditAmount  { get; set; }
    } 
}
