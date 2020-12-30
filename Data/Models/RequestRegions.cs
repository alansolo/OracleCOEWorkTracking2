using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class RequestRegions
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public int RequestId { get; set; }

        public virtual Regions Region { get; set; }
        public virtual Requests Request { get; set; }
    }
}
