using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity.Masters
{
    public class VendorMasterDiv
    {
        public int VendorMasterSno      {get;set;}
        public int VendorTypeSno        {get; set;}
        public string VendorType        {get;set;}
        public string VendorName        {get;set;}
        public string ComDesc          { get; set; }
        public string VendorSoftwareCode{get;set;}
        public string RegistrationNo    {get;set;}
        public int PaymentTypeSno       {get;set;}
        public string PaymentType       {get;set;}
        public string CreditLimit       {get;set;}
        public string CreditDays        {get;set;}
        public string NameOfReport      {get;set;}
        public string PANNo             {get;set;}
        public bool BlackList           {get;set;}
        public bool WithPincode { get; set; }
        public string EmailId           {get;set;}
        public string Website           { get; set;}
        public int AddressSno           {get; set;}
        public string AddressType       {get; set;}
        public int CitySno              {get; set;}
        public string CityName          {get; set;}
        public int CurrencySno          {get; set;}
        public string CurrencyName      {get; set;}
        public string CurrencyCode      {get; set;}
        public bool Sts                 {get; set;}
        public int CreOpr               {get; set;}
        //public DateTime CreDat          {get; set;}
        public string IPNumber          {get; set;}
        public string ActionName { get; set; }
        public string VendorCode        {get; set;}
        public string SbuName { get; set; }
        public int SbuSno { get; set; }
        public string ServerIdName { get; set; }
        public int ServerIdSno { get; set; }
    }
    public class VendorDropDown
    {
        public int VendorTypeSno { get; set; }
        public string VendorType { get; set; }
    }
    public class PaymentTypeDropdown
    {
        public int PaymentTypeSno { get; set; }
        public string PaymentType { get; set; }
    }
    public class VendorMasterdropdown
    {
        public List<VendorDropDown> objVendorDropDown { get; set; }
        public List<PaymentTypeDropdown> objPaymentTypeDropdown { get; set; }
    }
}
