using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class BranchMaster
    {
     public int      BranchSno          { get; set; }
     public string   BranchName         { get; set; }
     public string   BranchCode         { get; set; }
     public string   ShortName          { get; set; }
     public string  EstablishedDate { get; set; }
     public string   PhoneNumber        { get; set; }
     public string   FaxNumber          { get; set; }
     public string   EmailID            { get; set; }
     public int      CitySno            { get; set; }
     public string   CityName           { get; set; }
     public string   PANNumber          { get; set; }
     public string   GSTINNumber        { get; set; }
     public int      InChargeSno        { get; set; }
     public string   InCharge           { get; set; }
     public string   ContactPerson      { get; set; }
     public string   BranchAddress      { get; set; }
     public string   Pincode            { get; set; }
     public decimal Latitude            { get; set; }
     public decimal Longitude           { get; set; }
     public decimal GeoFence            { get; set; }
     public int      CreOpr             { get; set; }
     public string   CreDat             { get; set; }
     public string   IPNumber           { get; set; }
     public bool     sts                { get; set; }
     public  int  Types       { get; set; }
        public string ActionName { get; set; }
    }


    public class Typesdropdown

    {
        public  int EntityTypeSno { get; set; }
     
        public int  Types { get; set; }
        public string EntityTypeName { get; set; }
    }
    public class Typesdropdownlist 
    {
        public List<Typesdropdown> objTypesDropdown { get; set; }
    }



}
