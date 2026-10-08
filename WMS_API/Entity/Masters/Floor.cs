using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Masters
{
   public class Floor
    {
        public int FloorSno           { get; set; }
        public int WarehouseSno       { get; set; }
        public string WarehouseName      { get; set; }
        public int Creopr             { get; set; }
        public string IPNumber           { get; set; }
        public bool Sts                { get; set; }
    }

    public class FloorDet
    {
        public int FloorDetSno   {get; set;}
        public int FloorSno      {get; set;}
        public string FloorName     {get; set;}
        public string FloorCode     {get; set;}
        public bool Sts { get; set; }
    }

    public class FloorList
    {
        public Floor objFloor { get; set; }
        public List<FloorDet> objFloorDet { get; set; }
    }
}
