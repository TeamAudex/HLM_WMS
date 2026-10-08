using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Entity
{
       public class MenuMas
    {
        public int MenuSno { get; set; }
        public string path { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
        public int ParentMenuSno { get; set; }
        public string MenuOrder { get; set; }
      
    }
}
