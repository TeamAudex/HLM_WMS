using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
   public class LiveTrack
    {
        public int TotalLR { get; set; }
        public int CompletedLR { get; set; }
        public int OntimeLR { get; set; }
        public int LikelyToDelayLR { get; set; }
        public int DelayedLR { get; set; }
    }
    public class LiveTrackDet
    {
        public LiveTrack objCount { get; set; }
        public List<task> objTask { get; set; }
        public List<process> objProcess { get; set; }
    }

    public class task
    {
        public string label { get; set; }
        public string processid { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string tooltext { get; set; }
        public string color { get; set; }
        public string id { get; set; }
    }
    public class process
    {
        public string label { get ; set; }
        public string id { get; set; }
    }

    public class LiveTrackSearch
    {
        public int LRSno { get; set; }
        public int LSPSno { get; set; }
        public string TrackBy { get; set; }
        public string FilterDate  { get;set;}
        public int UserSno { get; set; }
    }
    public class request
    {
        public LiveTrackSearch objSearch { get; set; }
    }
}
