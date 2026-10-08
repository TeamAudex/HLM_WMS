using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity.Masters
{
    public class VendorCategoryLevelMas
    {
        public int vendorMasCatSno      { get;set;}
        public int VendorMasterSno      { get; set; }
        public bool Sts                 {get;set;}
        public int CommoditySno         { get;set;}        
        public string CommodityName     {get;set;}
        public int SubCommoditySno      { get;set;}
        public string SubCommodityName  {get;set;}        
        public int ItemFieldConfSno     { get;set;}
        public string CatLevelThree     {get;set;}
        public int ItemSno              {get;set;}
        public string ItemName          {get;set;}
    }
}
