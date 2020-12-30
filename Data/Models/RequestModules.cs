using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class RequestModules
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int RequestId { get; set; }

        public virtual Modules Module { get; set; }
        public virtual Requests Request { get; set; }
    }
}
