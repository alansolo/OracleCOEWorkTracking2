using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class RequestSbus
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int Sbuid { get; set; }

        public virtual Requests Request { get; set; }
        public virtual Sbus Sbu { get; set; }
    }
}
