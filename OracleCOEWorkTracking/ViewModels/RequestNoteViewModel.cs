using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OracleCOEWorkTracking.ViewModels
{
    public class RequestNoteViewModel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string Note { get; set; }
        // ITrack
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public bool DeleteMark { get; set; }
    }
}
