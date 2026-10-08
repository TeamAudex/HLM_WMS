using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class WarehouseLayout
    {
        public int WarehouseLayoutSno { get; set; }
        public int WarehouseSno { get; set; }
        public string Warehouse { get; set; }
        public int CreOpr { get; set; }
        public string IpNumber { get; set; }
        public bool TokenNo { get; set; }
        public string ActionName { get; set; }
        public string ReqLog { get; set; }
        public bool Sts { get; set; }
    }
    public class WarehouseLayoutDetOne
    {
        public int WH_ROW_SNO { get; set; }
        public int WarehouseSno { get; set; }
        public string Rows { get; set; }
        public bool Bay { get; set; }
        public int RackLevels { get; set; }
        public bool Sts { get; set; }
        public List<WarehouseLayoutDetTwo> WarehouseLayoutDetColumns { get; set; }
    }
    public class WarehouseLayoutDetTwo
    {
        public int WH_COLUMN_SNO { get; set; }
        public int WH_ROW_SNO { get; set; }
        public int WarehouseSno { get; set; }
        public string Columns { get; set; }
        public bool Aisle { get; set; }
        public bool Sts { get; set; }
    }

    public class WarehouseLayoutResult
    {
        public int WarhouseLayoutSno { get; set; }
        public string Result { get; set; }
    }
    public class WarehouseLayoutDetList
    {
        public WarehouseLayout objWarehouseLayout { get; set; }
        public List<WarehouseLayoutDetOne> ObjWarehouseLayoutDetOne { get; set; }
        public List<WarehouseLayoutDetTwo> ObjWarehouseLayoutDetTwo { get; set; }
    }

}
