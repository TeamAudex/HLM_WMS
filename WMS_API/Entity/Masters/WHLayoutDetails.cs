using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Masters
{
    public class WHLayoutDetails
    {
        public int WHLayoutDetailsSno { get; set; }
        public int WarehouseSno { get; set; }
        public string Warehouse { get; set; }
        public int RowsSno { get; set; }
        public string RowsName { get; set; }
        public string ActionName { get; set; }
        public int UOMSno { get; set; }
        public string UOM { get; set; }
        public string Length { get; set; }
        public string Breadth { get; set; }
        public string Height { get; set; }
        public string TotalVolume { get; set; }
        public string MaxWeight { get; set; }
        public int ZoneSno { get; set; }
        public string ZoneName { get; set; }
        public int SubZoneSno { get; set; }
        public string SubZone { get; set; }
        public int StockTypeSno { get; set; }
        public string StockType { get; set; }
        public int StorageTypeSno { get; set; }
        public string StorageType { get; set; }
        public bool StorageMappedDevice { get; set; }
        public string StorageMappedDeviceRadio { get; set; }
        public string StorageMethod { get; set; }
        public int PalletTypeSno { get; set; }
        public string PalletType { get; set; }
        public string ReqLog { get; set; }
        public int CreOpr { get; set; }
        public string IPNumber { get; set; }
        public string TokenNo { get; set; }
        public string URL { get; set; }
        public bool Sts { get; set; }
    }

    public class WarehouseLayoutDetailsLevelDet
    {
        public int WHLoyoutDetailsLevelDetSno { get; set; }
        public string LevelNameReadonly { get; set; }
        public string LevelName { get; set; }
        public bool Sts { get; set; }
    }
    public class WarehouseLayoutDetailsRackDet
    {
        public int WHLoyoutDetailsRackDetSno { get; set; }
        public string LevelName { get; set; }
        public string Rack { get; set; }
        public bool NonStorageArea { get; set; }
        public decimal Length { get; set; }
        public decimal Breadth { get; set; }
        public decimal Height { get; set; }
        public decimal TotalVolume { get; set; }
        public decimal MaxWeight { get; set; }
        public int ZoneSno { get; set; }
        public string ZoneName { get; set; }
        public int SubZoneSno { get; set; }
        public string SubZone { get; set; }
        public int StockTypeSno { get; set; }
        public string StockType { get; set; }
        public int StorageTypeSno { get; set; }
        public string StorageType { get; set; }
        public bool StorageMappedDevice { get; set; }
        public string StorageMappedDeviceRadio { get; set; }
        public string StorageMethod { get; set; }
        public int PalletTypeSno { get; set; }
        public string PalletType { get; set; }
        public int UOMSno { get; set; }
        public string UOM { get; set; }
        public bool Sts { get; set; }
        public bool BAY_FLAG { get; set; }
        public bool AISLE_FLAG { get; set; }
    }

    public class RowDropdown
    {
        public int RowsSno { get; set; }
        public string RowsName { get; set; }
    }
    public class WHDUOMDropdown
    {
        public int UOMSno { get; set; }
        public string UOM { get; set; }
        public decimal MF { get; set; }
    }
    public class ZoneDropdown
    {
        public int ZoneSno { get; set; }
        public string ZoneName { get; set; }
    }
    public class SubzoneDropdown
    {
        public int SubZoneSno { get; set; }
        public string SubZone { get; set; }
    }
    public class StockTypeDropdown
    {
        public int StockTypeSno { get; set; }
        public string StockType { get; set; }
    }
    public class StorageTypeDropdown
    {
        public int StorageTypeSno { get; set; }
        public string StorageType { get; set; }
    }
    public class WLDPalletTypeDropdown
    {
        public int PalletTypeSno { get; set; }
        public string PalletType { get; set; }
    }
    public class WHLayoutDetailDropdownlist
    {
        public List<RowDropdown> ObjRow { get; set; }
        public List<WHDUOMDropdown> ObjUOM { get; set; }
        public List<ZoneDropdown> ObjZone { get; set; }
        public List<SubzoneDropdown> ObjSubzone { get; set; }
        public List<StockTypeDropdown> ObjStockType { get; set; }
        public List<StorageTypeDropdown> ObjStorageType { get; set; }
        public List<WLDPalletTypeDropdown> ObjPalletType { get; set; }
    }
    public class WHLayoutDetailsResult
    {
        public int WHLayoutDetailsSno { get; set; }
        public string Result { get; set; }
    }
    public class WHLayoutDetailsList
    {
        public WHLayoutDetails ObjWHLayoutDetails { get; set; }
        public List<WarehouseLayoutDetailsLevelDet> ObjWarehouseLayoutDetailsLevelDet { get; set; }
        public List<WarehouseLayoutDetailsRackDet> ObjWarehouseLayoutDetailsRackDet { get; set; }
    }
}
