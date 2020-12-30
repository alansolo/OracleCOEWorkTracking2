using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class OwningStreams
    {
        public OwningStreams()
        {
            Requests = new HashSet<Requests>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool DeleteMark { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }
        public string DlEmailAddress { get; set; }
        public int? AppId { get; set; }

        public virtual ICollection<Requests> Requests { get; set; }
    }
}
