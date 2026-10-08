using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
   public class ItemPackage
    {
        public int ItemPackageSno { get; set; }
        public int ItemSno { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public int ItemUOMSno { get; set; }
        public string ItemUOM { get; set; }
        public decimal ItemWeight { get; set; }
        public int Creopr { get; set; }
        public string IPNumber { get; set; }
        public string ActionName { get; set; }
        public bool Sts { get; set; }

    }
}
