using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class OraclePreProdEnvironments
    {
        public OraclePreProdEnvironments()
        {
            RequestOraclePreProdEnvironments = new HashSet<RequestOraclePreProdEnvironments>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool DeleteMark { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }
        public int? ApplicationId { get; set; }

        public virtual Applications Application { get; set; }
        public virtual ICollection<RequestOraclePreProdEnvironments> RequestOraclePreProdEnvironments { get; set; }
    }
}
