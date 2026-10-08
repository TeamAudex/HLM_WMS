using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
   public class ItemPackageDetails
    {
        public ItemPackage ItemPackage { get; set; }
        public List<ItemPackageDet> ItemPackageDet { get; set; }
    }
}
