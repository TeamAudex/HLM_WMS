using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity.Masters
{
    public class CommonMaster
    {

        public int COMMONSNO { get; set; }
        public string COMDESC { get; set; }
        public string REFDESC { get; set; }
        public string CodeFlag { get; set; }
        public double CodeVal { get; set; }
        public int CommonID { get; set; }
        public int Creopr { get; set; }
        public string IpNumber { get; set; }
        public string StsDesc { get; set; }
        public float CodeValue { get; set; }        
        public int RefID { get; set; }
        public bool? Sts { get; set; }
        public int AssetCategorySno { get; set; }
        public string AssetCategory { get; set; }
    }
}
