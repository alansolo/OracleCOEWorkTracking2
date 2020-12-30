using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OracleCOEWorkTracking.Data.Entities
{
    public class RequestRegion 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("RequestId")]
        public int RequestId { get; set; }
        public Region Region { get; set; }
        [ForeignKey("RegionId")]
        public int RegionId { get; set; }
    }
}
