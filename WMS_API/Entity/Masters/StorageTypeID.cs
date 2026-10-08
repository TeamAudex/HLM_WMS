using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Masters
{
    public class StorageTypeID
    {
        public int StorageTypeIDSno { get; set; }
        public int WarehouseSno { get; set; }
        public string Warehouse { get; set; }
        public int StorageTypeSno { get; set; }
        public string StorageType { get; set; }
        public string UOM { get; set; }
        public string Length { get; set; }
        public string Breadth { get; set; }
        public string Height { get; set; }
        public int CreOpr { get; set; }
        public string IPNumber { get; set; }
        public string ActionName { get; set; }
        public string DocumentFilename { get; set; }
        public string FileUpload { get; set; }
        public bool Sts { get; set; }
        public string StorageIDType { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public int StartPalletIDNo { get; set; }
        public int EndPalletIDNo { get; set; }
        public int NoofUnits { get; set; }
    }
    public class StorageTypeIDDet
    {
        public int StorageTypeIDDetSno { get; set; }
        public int StorageTypeIDSno { get; set; }
        public int StorageIDSno { get; set; }
        public string StorageID { get; set; }
        public string StorageID_Sts { get; set; }
        public int error { get; set; }
        public bool Sts { get; set; }
    }
    public class StorageTypeIDList
    {
        public StorageTypeID StorageTypeID { get; set; }
        public List<StorageTypeIDDet> StorageTypeIDDet { get; set; }
    }

    public class UploadStorageTypeIDList
    {
        public int StorageTypeIDSno { get; set; }
        public int WarehouseSno { get; set; }
        public int StorageTypeSno { get; set; }
        public bool Sts { get; set; }
        public string IPNumber { get; set; }
        public string Creopr { get; set; }
        public string ActionName { get; set; }
        public string DocumentFilename { get; set; }
        public string Err { get; set; }
        public string ErrMsg { get; set; }
        public int LineColumn { get; set; }
        public int error { get; set; }
        public List<StorageTypeIDDet> StorageTypeIDUploadDisplay { get; set; }
        public List<StorageTypeIDDet> StorageTypeIDUploadInsert { get; set; }
    }
    public class StorageTypeIDResult
    {
        public int VehicleScreenSno { get; set; }
        public string Result { get; set; }
    }

    public class StorageTypeIDSearch
    {
        public int StorageTypeIDSno { get; set; }
        public string Warehouse { get; set; }
        public string StorageType { get; set; }
        public string StorageIDType { get; set; }
        public int NoofUnits { get; set; }
    }
}
