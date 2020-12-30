using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OracleCOEWorkTracking.Data.Entities
{
    public class RequestSBU
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("RequestId")]
        public int RequestId { get; set; }

        public SBU SBU { get; set; }
        [ForeignKey("SBUId")]
        public int SBUId { get; set; }
    }
}
