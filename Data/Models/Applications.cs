using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class Applications
    {
        public Applications()
        {
            ApplicationAttribute = new HashSet<ApplicationAttribute>();
            ApplicationModule = new HashSet<ApplicationModule>();
            ApplicationOwningSite = new HashSet<ApplicationOwningSite>();
            ApplicationRegion = new HashSet<ApplicationRegion>();
            OraclePreProdEnvironments = new HashSet<OraclePreProdEnvironments>();
            Requests = new HashSet<Requests>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool DeleteMark { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ApplicationAttribute> ApplicationAttribute { get; set; }
        public virtual ICollection<ApplicationModule> ApplicationModule { get; set; }
        public virtual ICollection<ApplicationOwningSite> ApplicationOwningSite { get; set; }
        public virtual ICollection<ApplicationRegion> ApplicationRegion { get; set; }
        public virtual ICollection<OraclePreProdEnvironments> OraclePreProdEnvironments { get; set; }
        public virtual ICollection<Requests> Requests { get; set; }
    }
}
