using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity.Masters
{
    public class VendorMasterList
    {
        public VendorMasterDiv vendorMasterDiv { get; set; }
        public List<VendorMasterGrid1> objVendorMasterGrid1 { get; set; }
        public List<VendorCategoryLevelMas> objVendorCategoryLevelMas { get; set; }
        public List <VendorMasterGrid3> objGridElements { get; set; }
    }
}
