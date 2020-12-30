using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class DevelopmentTeams
    {
        public DevelopmentTeams()
        {
            RequestDevelopmentTeams = new HashSet<RequestDevelopmentTeams>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool DeleteMark { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RequestDevelopmentTeams> RequestDevelopmentTeams { get; set; }
    }
}
