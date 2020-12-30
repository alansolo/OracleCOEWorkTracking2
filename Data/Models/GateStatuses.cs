using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class GateStatuses
    {
        public GateStatuses()
        {
            RequestsBigateStatus = new HashSet<Requests>();
            RequestsEbsgateStatus = new HashSet<Requests>();
            RequestsNetgateStatus = new HashSet<Requests>();
            RequestsOtmgateStatus = new HashSet<Requests>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool DeleteMark { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Requests> RequestsBigateStatus { get; set; }
        public virtual ICollection<Requests> RequestsEbsgateStatus { get; set; }
        public virtual ICollection<Requests> RequestsNetgateStatus { get; set; }
        public virtual ICollection<Requests> RequestsOtmgateStatus { get; set; }
    }
}
