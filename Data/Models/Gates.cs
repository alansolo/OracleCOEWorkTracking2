using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class Gates
    {
        public Gates()
        {
            RequestsNextBigate = new HashSet<Requests>();
            RequestsNextEbsgate = new HashSet<Requests>();
            RequestsNextNetgate = new HashSet<Requests>();
            RequestsOtmebsgate = new HashSet<Requests>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool DeleteMark { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Requests> RequestsNextBigate { get; set; }
        public virtual ICollection<Requests> RequestsNextEbsgate { get; set; }
        public virtual ICollection<Requests> RequestsNextNetgate { get; set; }
        public virtual ICollection<Requests> RequestsOtmebsgate { get; set; }
    }
}
