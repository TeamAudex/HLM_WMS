using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class Common
    {
        public string ActionType { get; set; }
        public string Condition1 { get; set; }
        public int Condition2 { get; set; }
        public int Condition3 { get; set; }
        public int Condition4 { get; set; }
        public DataSet BulkPrint { get; set; }
        public DataSet BulkPrintReport { get; set; }
    }


    public class CommonReport
    {
        public string ActionTypess { get; set; }
        public string ReqSno { get; set; }
        public string RptTypes { get; set; }
        public string TypeofFlag { get; set; }

        public DataSet BulkPrint { get; set; }
        public DataSet BulkPrintReport { get; set; }
    }
}



