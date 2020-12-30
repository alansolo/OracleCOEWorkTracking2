using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class ApplicationOwningSite
    {
        public int AppId { get; set; }
        public int OwningSiteId { get; set; }

        public virtual Applications App { get; set; }
        public virtual OwningSites OwningSite { get; set; }
    }
}
