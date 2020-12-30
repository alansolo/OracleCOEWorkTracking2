using OracleCOEWorkTracking.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OracleCOEWorkTracking.Data.Entities
{
    public class ApplicationRegion
    {
        //[Key]
        //[Column(Order = 1)]
        public int AppId { get; set; }
        public Application App { get; set; }

        //[Key]
        //[Column(Order = 2)]
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}