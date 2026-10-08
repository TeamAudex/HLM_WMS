using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Masters
{
    public class WarehouseZone
    {
        public int WarehouseZoneSno { get; set; }
        public int WarehouseSno { get; set; }
        public string Warehouse { get; set; }
        public string BranchName { get; set; }
        public int FloorSno { get; set; }
        public string Floor { get; set; }
        public string ZoneName { get; set; }
        public int PickOrder { get; set; }
        public string ZoneDetails { get; set; }
        public int StorageTypeSno { get; set; }
        public string StorageType { get; set; }
        public string ActionName { get; set; }
        public string ReqLog { get; set; }
        public int CreOpr { get; set; }
        public string IpNumber { get; set; }
        public bool TokenNo { get; set; }
        public bool Sts { get; set; }

    }

    public class WarehouseZoneDet
    {
        public int WarehouseZoneDetSno { get; set; }
        public int WarehouseZoneSno { get; set; }
        public int ItemNameSno { get; set; }
        public string ItemName { get; set; }
        public int UOMSno { get; set; }
        public string UOM { get; set; }
        public int ItemTypeSno { get; set; }
        public string ItemType { get; set; }

        //public int NoOfUnits { get; set; }
        //public decimal TriggerValue { get; set; }
        //public decimal MinimumOrderQty { get; set; }
        //public decimal MaximumOrderQty { get; set; }
        public bool Sts { get; set; }

    }

    public class WarehouseZoneMaster
    {
        public WarehouseZone objWarehouseZone { get; set; }
        public List<WarehouseZoneDet> objWarehouseZoneDet { get; set; }
        public string Result { get; set; }
    }
    public class WarehouseZoneResult
    {
        public int WarehouseZoneSno { get; set; }
        public string Result { get; set; }
    }

    public class UOMdropdown
    {
        public int UOMSno { get; set; }
        public string UOM { get; set; }
        public int ItemNameSno { get; set; }
    }

    public class StoragelocationDD
    {
        public int StoragelocationSno { get; set; }
        public string Storagelocation { get; set; }
    }

    public class Storagelocationlist
    {
        public List<StoragelocationDD> StoragelocationDropdown { get; set; }
    }
    public class StockTypedropdown
    {
        public int StorageTypeSno { get; set; }
        public string StorageType { get; set; }
    }
    public class Dropdownlist
    {
        public List<UOMdropdown> objUOMDropdown { get; set; }
        public List<StockTypedropdown> objStockTypeDD { get; set; }
    }
}
