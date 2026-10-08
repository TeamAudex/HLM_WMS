using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class CommonMasterAuto
    {
        public int CommonSno { get; set; }
        public string ComDesc { get; set; }
        public string ComDesc1 { get; set; }
        public int OwnerShipSno { get; set; }
        public string OwnerShip { get; set; }

        public int Sno1 { get; set; }
        public int Sno2 { get; set; }
        public int Sno3 { get; set; }
        public int Sno4 { get; set; }
        public int Sno5 { get; set; }
        public int Sno6 { get; set; }
        public int Sno7 { get; set; }
        public int Sno8 { get; set; }
        public int Sno9 { get; set; }
        public string Sno10 { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public string Text5 { get; set; }
        public string Text6 { get; set; }
        public string Text7 { get; set; }
        public string Text8 { get; set; }
        public string Text9 { get; set; }
        public string Text10 { get; set; }
        public DateTime Text11 { get; set; }
        public string ServerDate { get; set; }
        public string ServerTime { get; set; }
        public string ServerDateTime { get; set; }


    }

    public class CommondropdownList1
    {
        public List<CommonMasterAuto> objCommonMasterAuto { get; set; }
        public List<CommonMasterAuto> objOwnnership { get; set; }
    }



}
