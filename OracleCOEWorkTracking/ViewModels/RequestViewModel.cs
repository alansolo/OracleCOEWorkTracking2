using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OracleCOEWorkTracking.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }

        public AppNameViewModel AppName { get; set; }
        
        //public int? ApplicationId { get; set; }
        public string ProjectName { get; set; }
        public string Problem { get; set; }
        public string BenefitCase { get; set; }
        public int? GBSPriority { get; set; }
        public int? COEPriority { get; set; }
        public int StatusId { get; set; }
        public StatusViewModel Status { get; set; }

        
        public List<RegionViewModel> Regions { get; set; }
        public List<SBUViewModel> SBUs { get; set; }
        public List<ImpactedStreamViewModel> ImpactedStreams { get; set; }
        public List<ModuleViewModel> Modules { get; set; }
        public List<DevelopmentTeamViewModel> DevelopmentTeams { get; set; }
        public List<OraclePreProdEnvironmentViewModel> OraclePreProdEnvironments { get; set; }

        public List<RequestAttachmentViewModel> Attachments { get; set; }

        public string MD_50_DueDate { get; set; }
        public string TestingDate { get; set; }
        public string MD_70_DueDate { get; set; }
        public string ProductionDate { get; set; }
        public double? TotalEstimate { get; set; }
        public double? OracleDevEstimateOffShore { get; set; }
        public double? OracleDevEstimateOnShore { get; set; }
        public double? DCOEEstimate { get; set; }
        public int? CRNo { get; set; }
        public string FunctionalContact { get; set; }
        public string BIContact { get; set; }
        public string OracleDevelopmentLead { get; set; }
        public string DCOEDevelopmentLead { get; set; }
        public string MD_70 { get; set; }
        public string MD_50 { get; set; }
        public string TIPUrl { get; set; }
        public string EBSGateQuestionnaireUrl { get; set; }
        public string BIGateQuestionnaireUrl { get; set; }
        public string _NETGateQuestionnaireUrl { get; set; }
        public string OTMGateQuestionnaireUrl { get; set; }
        public int? ReadyForEBSGateId { get; set; }
        public BooleanDropDownViewModel ReadyForEBSGate { get; set; }
        public int? EBSGateStatusId { get; set; }

        public GateStatusViewModel EBSGateStatus { get; set; }
        public int? NextEBSGateId { get; set; }
        public GateViewModel NextEBSGate { get; set; }
        public int? ReadyForOTMGateId { get; set; }
        public BooleanDropDownViewModel ReadyForOTMGate { get; set; }
        public int? OTMGateStatusId { get; set; }
        public GateStatusViewModel OTMGateStatus { get; set; }
        public int? OTMEBSGateId { get; set; }
        public GateViewModel OTMEBSGate { get; set; }
        public int? ReadyForBIGateId { get; set; }

        public BooleanDropDownViewModel ReadyForBIGate { get; set; }
        public int? BIGateStatusId { get; set; }
        public GateStatusViewModel BIGateStatus { get; set; }
        public int? NextBIGateId { get; set; }
        public GateViewModel NextBIGate { get; set; }
        public int? ReadyFor_NETGateId { get; set; }
        public BooleanDropDownViewModel ReadyFor_NETGate { get; set; }
        public int? _NETGateStatusId { get; set; }
        public GateStatusViewModel _NETGateStatus { get; set; }
        public int? Next_NETGateId { get; set; }
        public GateViewModel Next_NETGate { get; set; }



        public int? EstimateInfra { get; set; }
        public string FrontLineContact { get; set; }
        public int? OwningSiteId { get; set; }
        public OwningSiteViewModel OwningSite { get; set; }
        public string Requestor { get; set; }
        public int? OwningStreamId { get; set; }
        public OwningStreamViewModel OwningStream { get; set; }
        public int? BIRequestId { get; set; }
        public BooleanDropDownViewModel BIRequest { get; set; }
        public string OriginalSystemReference { get; set; }

        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public string Attribute5 { get; set; }
        public string Attribute6 { get; set; }
        public string Attribute7 { get; set; }
        public string Attribute8 { get; set; }
        public string Attribute9 { get; set; }
        //date
        public string Attribute10 { get; set; }

        // ITrack
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }

    }
}
