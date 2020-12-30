using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class ApplicationRegion
    {
        public int AppId { get; set; }
        public int RegionId { get; set; }

        public virtual Applications App { get; set; }
        public virtual Regions Region { get; set; }
    }
}
