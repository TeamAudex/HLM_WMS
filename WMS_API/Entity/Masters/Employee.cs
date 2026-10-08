using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{

    public class Employee
    {
        public int EmployeeSno { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CreOpr { get; set; }
        public string RoleSno { get; set; }
        public string RoleName { get; set; }
        public string BranchSno { get; set; }
        public string BranchName { get; set; }
        public string BusinessUnitSno { get; set; }
        public string BusinessUnitName { get; set; }
        public string IPNumber { get; set; }
        public bool LoginSts { get; set; }
        public string LoginStatus { get; set; }
        public bool sts { get; set; }
        public string Gendertype { get; set; }
        public string DOB { get; set; }
        public string EmpAdd { get; set; }
        public string EmailID { get; set; }
        public string PhoneNo { get; set; }
        public string Designation { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Lastlogintime { get; set; }
        public string UserSno { get; set; }
        public string RateSts { get; set; }
        public string MOTName { get; set; }
        public string MOTSno { get; set; }
        public string VendorName { get; set; }
        public string VendorSno { get; set; }
        public string LSPName { get; set; }
        public string LSPcode { get; set; }
        public string ActionName { get; set; }
        public string APIkey { get; set; }
        public string RoleFlag { get; set; }

    }
    public class subscribers
    {
        public string MobileNo { get; set; }
        public int SubscriberSno { get; set; }
        public int SubscriptionSno { get; set; }
        public string Name { get; set; }
        public string OTP { get; set; }
        public string MPIN { get; set; }
        public string ConfirmPIN { get; set; }
    }
}
