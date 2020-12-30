using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class BooleanDropDownValues
    {
        public BooleanDropDownValues()
        {
            RequestsBirequest = new HashSet<Requests>();
            RequestsReadyForBigate = new HashSet<Requests>();
            RequestsReadyForEbsgate = new HashSet<Requests>();
            RequestsReadyForNetgate = new HashSet<Requests>();
            RequestsReadyForOtmgate = new HashSet<Requests>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Requests> RequestsBirequest { get; set; }
        public virtual ICollection<Requests> RequestsReadyForBigate { get; set; }
        public virtual ICollection<Requests> RequestsReadyForEbsgate { get; set; }
        public virtual ICollection<Requests> RequestsReadyForNetgate { get; set; }
        public virtual ICollection<Requests> RequestsReadyForOtmgate { get; set; }
    }
}
