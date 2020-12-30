using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OracleCOEWorkTracking.ViewModels
{
    public class DropDownDataViewModel
    {
        public List<AppNameViewModel> AppNames { get; set; }

        public List<RegionViewModel> Regions { get; set; }
        public List<SBUViewModel> SBUs { get; set; }
        public List<OwningSiteViewModel> OwningSites { get; set; }
        public List<BooleanDropDownViewModel> BooleanDropDowns { get; set; }
        public List<DevelopmentTeamViewModel> DevelopmentTeams { get; set; }
        public List<GateStatusViewModel> GateStatuses { get; set; }
        public List<GateViewModel> Gates { get; set; }
        public List<OwningStreamViewModel> OwningStreams { get; set; }
        public List<ImpactedStreamViewModel> ImpactedStreams { get; set; }
        public List<ModuleViewModel> Modules { get; set; }
        public List<OraclePreProdEnvironmentViewModel> OraclePreProdEnvironments { get; set; }
        public List<StatusViewModel> Statuses { get; set; }
        public List<ApplicationAttributeViewModel> ApplicationAttributes { get; set; }
        public ApplicationAttributeViewModel ApplicationAttributesSelect { get; set; }
    }
}
