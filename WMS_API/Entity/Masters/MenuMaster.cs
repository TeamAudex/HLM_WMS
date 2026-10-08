using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class MenuMaster
    {
        public int      MenuSno         { get; set; }    
        public string   MenuName        { get; set; }
        public string   MenuDescription { get; set; }
        public int      ParentMenuSno   { get; set; }
        public string   ParentMenu      { get; set; }
        public int      MenuOrder       { get; set; }
        public string   URLPath         { get; set; }
        public string   IconCSSClass    { get; set; }
        public string   MenuFlag        { get; set; }
        public bool     Sts             { get; set; }

    }
}
