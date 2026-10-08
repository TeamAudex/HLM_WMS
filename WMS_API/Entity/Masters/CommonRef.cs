using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class CommonRef
    {
      public int RefID          {get;set;}
      public string RefCode     {get;set;}
      public string RefDesc     {get;set;}
      public int Creopr         {get;set;}
      public DateTime? CredatedDate{get;set;}
      public string IpNumber    {get;set;}
      public bool Sts           {get; set;}
    }
}
