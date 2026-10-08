using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Masters
{
    public class WarehouseSubZone
    {
        public int warehouseSubZoneSno { get; set; }
        public int WarehouseSno { get; set; }
        public string Warehouse { get; set; }
        public int ZoneNameSno { get; set; }
        public string ZoneName { get; set; }
        public string SubZoneName { get; set; }
        public int UOMSno { get; set; }
        public string UOMName { get; set; }
        public decimal Length { get; set; }
        public decimal Breadth { get; set; }
        public decimal Height { get; set; }
        public decimal Volume { get; set; }
        public decimal Weight { get; set; }
        public decimal Temperature { get; set; }
        public int TemperatureSno { get; set; }
        public string ZoneDetails { get; set; }
        public bool RackBased { get; set; }
        public int StorageTypeSno { get; set; }
        public string StorageType { get; set; }
        public int StorageTypeNewSno { get; set; }
        public string StorageTypeNew { get; set; }
        public bool StorageMappedDevice { get; set; }
        public string StorageMappedDeviceRadio { get; set; }
        public string StorageMethodtype { get; set; }
        public int PalletTypeSno { get; set; }
        public string PalletType { get; set; }
        public bool VirtualLocation { get; set; }
        public int CreOpr { get; set; }
        public string CreDat { get; set; }
        public string IPNumber { get; set; }
        public string ActionName { get; set; }
        public bool sts { get; set; }
        public string ReqLog { get; set; }
    }

    public class SubZoneVendorDet
    {
        public int WarehouseSubZonedetSno { get; set; }
        public int WarehouseSno { get; set; }
        public int VendorSno { get; set; }
        public string Vendor { get; set; }
        public bool sts { get; set; }
    }

    public class SubZoneItemDet
    {
        public int WarehouseSubZonedet1Sno { get; set; }
        public int WarehouseSno { get; set; }
        public int ItemNameSno { get; set; }
        public string ItemName { get; set; }
        public int UOMSno { get; set; }
        public string UOM { get; set; }
        public int ItemtypeSno { get; set; }
        public string Itemtype { get; set; }
        public bool sts { get; set; }
    }
    public class WarehouseSubZoneResult
    {
        public int warehouseSubZoneSno { get; set; }
        public string Result { get; set; }
    }
    public class WarehouseSubZoneDetList
    {
        public WarehouseSubZone objWarehouseSubZone { get; set; }
        public List<SubZoneVendorDet> ObjWarehouseSubZoneDet { get; set; }
        public List<SubZoneItemDet> ObjWarehouseSubZoneDetone { get; set; }
    }
    public class SZUOMDropdown
    {
        public int UOMSno { get; set; }
        public string UOMName { get; set; }
        public decimal MF { get; set; }
    }
    public class tempratureDropdown
    {
        public int TemperatureSno { get; set; }
        public string Temperature { get; set; }
    }
    public class StorageTypeDropdown1
    {
        public int StorageTypeSno { get; set; }
        public string StorageType { get; set; }
    }
    public class StorageTypeNewDropdown
    {
        public int StorageTypeNewSno { get; set; }
        public string StorageTypeNew { get; set; }
    }
    public class SZPalletTypeDropdown
    {
        public int PalletTypeSno { get; set; }
        public string PalletType { get; set; }
    }
    public class warehouseSubZoneDropdownList
    {
        public List<SZUOMDropdown> objUOMDropdown { get; set; }
        public List<StorageTypeDropdown1> objStorageTypeDropdown { get; set; }
        public List<StorageTypeNewDropdown> objStorageTypeNewDropdown { get; set; }
        public List<tempratureDropdown> objtempratureDropdown { get; set; }
        public List<SZPalletTypeDropdown> ObjPalletTypeDropdown { get; set; }


    }

}
