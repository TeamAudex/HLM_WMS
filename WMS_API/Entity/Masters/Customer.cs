using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class Customer
    {
        public int CustomerSno { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public int CustomerGroupSno { get; set; }
        public string CustomerGroup { get; set; }
        public string RegistrationNumber { get; set; }
        public string CustomerNo { get; set; }
        public string ComDesc { get; set; }
        public string SoftwareCode { get; set; }
        public string NameReport { get; set; }
        public string CustomerSoftwareCode { get; set; }
        public int PaymentDetailsSno { get; set; }
        public string PaymentDetails { get; set; }
        public int CreditLimitAmountSno { get; set; }
        public string CreditLimitAmounttype { get; set; }
        public decimal CreditLimitAmount { get; set; }
        public int CreditLimitDays { get; set; }
        public string NameInTheReport { get; set; }
        public string PANNumber { get; set; }
        public string EmailID { get; set; }
        public string Website { get; set; }
        public bool Blocksts { get; set; }
        public int CreOpr { get; set; }
        public string CreDat { get; set; }
        public string IPNumber { get; set; }
        public string ActionName { get; set; }
        public bool sts { get; set; }
        public string SbuName { get; set; }
        public int SbuSno { get; set; }
        public string ServerIdName { get; set; }
        public int ServerIdSno { get; set; }
        public int Types { get; set; }
        public int EntityTypeSno { get; set; }

        //    public string EntityTypeName { get; set; }

    }



}
