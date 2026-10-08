using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Masters
{
  public class StoragePalletType
    {
        public int StoragepallettypeSno { get; set; }
        public int WarehouseSno { get; set; }
        public string Warehouse { get; set; }
        public int customerSno { get; set; }
        public string customer { get; set; }
        public int ItemCategorySno { get; set; }
        public string ItemCategoryName { get; set; }
        public int StorageTypeSno { get; set; }
        public string StorageType { get; set; }
        public string categorytype { get; set; }
        public bool StorageRequired { get; set; }
        public string ActionName { get; set; }
        public int CreOpr { get; set; }
        public string IPNumber { get; set; }
        public bool Sts { get; set; }
    }
}
