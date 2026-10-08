using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity.Masters
{
    public class ItemMaster
    {
        public int ItemMasterSno { get; set; }
        public string BrandName { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string ItemCommodity { get; set; }
        public string ItemCategoryName { get; set; }
        public string StoreUOM { get; set; }
        public int ItemCommoditySno { get; set; }
        public int ItemCategorySno { get; set; }
        public int StoreUOMSno { get; set; }
        //public int RotationSno { get; set; }
        //public string RotationName { get; set; }
        public string ItemDetails { get; set; }
        public string Remarks { get; set; }
        public decimal Length { get; set; }
        public decimal Breadth { get; set; }
        public decimal Height { get; set; }
        public int lbhUOMSno { get; set; }
        public string lbhUOMName { get; set; }
        public decimal Weight { get; set; }
        public int WeightUOMSno { get; set; }
        public string WeightUOMName { get; set; }
        public decimal Volume { get; set; }
        public int MovementSno { get; set; }
        public string MovementName { get; set; }
        public int ValueSno { get; set; }
        public string ValueName { get; set; }
        public int NeedSno { get; set; }
        public string NeedName { get; set; }
        public decimal Rate { get; set; }
        public string BusinessUnit { get; set; }
        // public int BusinessUnitSno { get; set; }
        public string Documentpath { get; set; }
        public int CreOpr { get; set; }
        public string CreDat { get; set; }
        public string IPNumber { get; set; }
        public string ActionName { get; set; }
        public bool HeightcanDown { get; set; }
        public bool WidthcanUp { get; set; }
        public bool sts { get; set; }

    }
}

