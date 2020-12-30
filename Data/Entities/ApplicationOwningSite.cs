using System;
using System.Collections.Generic;
using System.Text;

namespace OracleCOEWorkTracking.Data.Entities
{
    public class ApplicationOwningSite
    {
        //[Key]
        //[Column(Order = 1)]
        public int AppId { get; set; }
        public Application App { get; set; }

        //[Key]
        //[Column(Order = 2)]
        public int OwningSiteId { get; set; }
        public OwningSite OwningSite { get; set; }

    }
}
