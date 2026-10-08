using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Masters
{
   public class PickerAttandance
    {
        public int PickerAttandanceSno { get; set; }
        public int WarehouseSno { get; set; }
        public string Warehouse { get; set; }
        public string EntryDate { get; set; }
        public string TypeOfPicker { get; set; }
        public string ActionName { get; set; }
        public string ReqLog { get; set; }
        public int CreOpr { get; set; }
        public string IpNumber { get; set; }
        public bool TokenNo { get; set; }
        public bool Sts { get; set; }
        public bool SubmittedSts { get; set; }

    }
    public class PickerAttandancedet
    {
        public int PickerAtnddetSno { get; set; }
        public int PickerAtndSno { get; set; }
        public int EmployeeSno { get; set; }
        public string Employee { get; set; }
        public bool sts { get; set; }
    }
    public class PickerAttandanceResult
    {
        public int PickerAttandanceSno { get; set; }
        public string Result { get; set; }
    }
    public class PickerAttandancedetList
    {
        public PickerAttandance objPickerAttandance { get; set; }
        public List<PickerAttandancedet> ObjPickerAttandancedet { get; set; }
    }
}
