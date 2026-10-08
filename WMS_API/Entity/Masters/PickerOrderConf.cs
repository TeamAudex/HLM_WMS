using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Masters
{
  public  class PickerOrderConf
    {
        public int Pickerordercountsno { get; set; }
        public int WarehouseSno { get; set; }
        public string Warehouse { get; set; }
        public int PickerCount { get; set; }
        public string ActionName { get; set; }
        public string ReqLog { get; set; }
        public int CreOpr { get; set; }
        public string IpNumber { get; set; }
        public bool TokenNo { get; set; }
        public bool Sts { get; set; }

    }
}
