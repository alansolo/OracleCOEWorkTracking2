using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OracleCOEWorkTracking.ViewModels
{
    public class OwningStreamViewModel
    {
        public int Id { get; set; }
        public int AppId { get; set; }

        public string Name { get; set; }
        public string dlEmailAddress { get; set; }

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
