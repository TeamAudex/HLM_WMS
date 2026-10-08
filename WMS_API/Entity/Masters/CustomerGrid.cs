using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class CustomerGrid
    {
        public Customer objCustomer { get; set; }
        public List<CustomerDet> objCustomerDet { get; set; }
        public List<Bisnussdet> objBisnussdet { get; set; }

    }
}
