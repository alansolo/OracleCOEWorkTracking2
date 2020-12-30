using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class RequestImpactedStreams
    {
        public int Id { get; set; }
        public int ImpactedStreamId { get; set; }
        public int RequestId { get; set; }

        public virtual ImpactedStreams ImpactedStream { get; set; }
        public virtual Requests Request { get; set; }
    }
}
