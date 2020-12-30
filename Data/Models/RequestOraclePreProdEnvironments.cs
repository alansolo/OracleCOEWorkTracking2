using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class RequestOraclePreProdEnvironments
    {
        public int Id { get; set; }
        public int OraclePreProdEnvironmentId { get; set; }
        public int RequestId { get; set; }

        public virtual OraclePreProdEnvironments OraclePreProdEnvironment { get; set; }
        public virtual Requests Request { get; set; }
    }
}
