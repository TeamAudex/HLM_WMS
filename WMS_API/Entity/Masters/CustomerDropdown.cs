


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class CustomerGroupDropdown
    {
        public int CustomerGroupSno { get; set; }
        public string CustomerGroup { get; set; }
    }

    public class CustomerPaymentDropdown
    {
        public int PaymentDetailsSno { get; set; }
        public string PaymentDetails { get; set; }

    }

    public class CustomerCreditAmountDropdown
    {
        public int CreditLimitAmountSno { get; set; }
        public string CreditLimitAmounttype { get; set; }

    }

    public class CustomerAddressTypeDropdown
    {

        public int AddressTypeSno { get; set; }
        public string AddressTypeName { get; set; }
    }

    public class typedropdown
    {

        public int EntityTypeSno { get; set; }
        public int Types { get; set; }
        public string EntityTypeName { get; set; }
    }

    public class dropdownList1
    {
        public List<CustomerGroupDropdown> objCustomerGroupDropdown { get; set; }
    }
    public class dropdownList2
    {
        public List<CustomerPaymentDropdown> objCustomerPaymentDropdown { get; set; }
    }
    public class dropdownList3
    {
        public List<CustomerCreditAmountDropdown> objCustomerCreditAmountDropdown { get; set; }
    }
    public class dropdownList4
    {
        public List<CustomerAddressTypeDropdown> objCustomerAddressTypeDropdown { get; set; }
    }


    public class dropdownList5
    {
        public List<typedropdown> objTypeDropdown { get; set; }
    }
}
