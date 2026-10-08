using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Masters
{
   public class StorageType
    {
        public int StorageTypeSno { get; set; }
        public string TypeName { get; set; }
        public string TypeCode { get; set; }
        public int CategorySno { get; set; }
        public string Category { get; set; }
        public string Download { get; set; }
        public string Image { get; set; }
        public int UOMSno { get; set; }
        public string UOM { get; set; }
        public decimal Length { get; set; }
        public decimal Breadth { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public int CreOpr { get; set; }
        public string CreDat { get; set; }
        public string IPNumber { get; set; }
        public string ActionName { get; set; }
        public bool sts { get; set; }
    }
    public class CategoryDropDown
    {
        public int CategorySno { get; set; }
        public string Category { get; set; }

    }
    public class UOMDropDown
    {
        public int UOMSno { get; set; }
        public string UOM { get; set; }

    }
    public class StorageTypeDropDown
    {
        public List<CategoryDropDown> ObjCategoryDropDown { get; set; }
        public List<UOMDropDown> ObjUOMDropDown { get; set; }

    }
}
