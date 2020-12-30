using System;
using System.Collections.Generic;
using System.Text;

namespace OracleCOEWorkTracking.Data.Entities
{
    public class ApplicationModule
    {
        public int AppId { get; set; }
        
        public int ModuleId { get; set; }
        public Module Module { get; set; }       

    }
}
