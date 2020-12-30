using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class ApplicationModule
    {
        public int AppId { get; set; }
        public int ModuleId { get; set; }

        public virtual Applications App { get; set; }
        public virtual Modules Module { get; set; }
    }
}
