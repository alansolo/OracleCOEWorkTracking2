using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Threading.Tasks;
using OracleCOEWorkTracking.Data.Entities;

namespace OracleCOEWorkTracking.ViewModels
{
    public class AddRequestViewModel
    {
        public int? Id { get; set; }
        public Application AppName { get; set; }
        public string ProjectName { get; set; }
        public string Problem { get; set; }
        public string BenefitCase { get; set; }
        public List<RegionViewModel> Regions { get; set; }
        public List<SBUViewModel> SBUs { get; set; }
        public OwningSiteViewModel OwningSite { get; set; }
        public OwningStreamViewModel OwningStream { get; set; }
        public int BiRequestId { get; set; }
        public string OriginalSystemReference { get; set; }
        public string Requestor { get; set; }

        // ITrack
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}
