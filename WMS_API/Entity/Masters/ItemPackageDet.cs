using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
   public class ItemPackageDet
    {
        public int ItemPackageDetSno { get; set; }
        public int ItemPackageSno { get; set; }
        public int PackageUOMSno { get; set; }
        public string PackageUOM { get; set; }
        public int Quantity { get; set; }
        public string ItemUOM { get; set; }
        public int UOMSno { get; set; }
        public string UOM { get; set; }
        public decimal DimensionLength { get; set; }
        public decimal DimensionBreath { get; set; }
        public decimal DimensionHeight { get; set; }
        public decimal Volume { get; set; }
        public decimal Weight { get; set; }
        public int VolumetricFactorSno { get; set; }
        public string VolumetricFactor { get; set; }
        public decimal VolumetricWeight { get; set; }
        public int AllowedRotation { set; get; }
        public bool Sts { set; get; }
    }

    public class PackageUOMDropdownList
    {
        public int PackageUOMSno { get; set; }
        public string PackageUOM { get; set; }
    }

    public class UOMDropdownList
    {
        public int UOMSno { get; set; }
        public string UOM { get; set; }
    }

    public class VolumetricFactorList
    {
        public int VolumetricFactorSno { get; set; }
        public string VolumetricFactor { get; set; }
    }

    public class ItemPackageDropDown
    {
        public List<PackageUOMDropdownList> PackageUOMDropdownList { get; set; }
        public List<UOMDropdownList> UOMDropdownList { get; set; }
        public List<VolumetricFactorList> VolumetricFactorList { get; set; }

    }

    public class Volumes
    {
        public decimal Volume { get; set;}
    }
}
