using OracleCOEWorkTracking.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OracleCOEWorkTracking.Data.Entities
{
    public class RequestNote : ITrack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("RequestId")]
        public int RequestId { get; set; }
        public string Note { get; set; }
        // ITrack
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool DeleteMark { get; set; }
    }
}
