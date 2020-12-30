using OracleCOEWorkTracking.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OracleCOEWorkTracking.Data.Entities
{
    public class Request : ITrack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }

        public string ProjectName { get; set; }
        public string Problem { get; set; }
        public string BenefitCase { get; set; }
        public int? GBSPriority { get; set; }
        public int? COEPriority { get; set; }
        public Status Status { get; set; }
        [ForeignKey("StatusId")]
        public int StatusId { get; set; }
     
        public List<RequestNote> Notes { get; set; }
        public List<RequestRegion> Regions { get; set; }
        public List<RequestSBU> SBUs { get; set; }
        public List<RequestImpactedStream> ImpactedStreams { get; set; }
        public List<RequestModule> Modules { get; set; }
        public List<RequestDevelopmentTeam> DevelopmentTeams { get; set; }
        public List<RequestOraclePreProdEnvironment> OraclePreProdEnvironments { get; set; }
        public DateTime? MD_50_DueDate { get; set; }
        public DateTime? TestingDate { get; set; }
        public DateTime? MD_70_DueDate { get; set; }
        public DateTime? ProductionDate { get; set; }
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
        public bool OTMImpactedStream { get; set; }
        public bool BIImpactedStream { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public string Attribute5 { get; set; }
        public string Attribute6 { get; set; }
        public string Attribute7 { get; set; }
        public string Attribute8 { get; set; }
        public string Attribute9 { get; set; }
        public DateTime? Attribute10 { get; set; }

        public int? ReadyForEBSGateId { get; set; }
        [ForeignKey("ReadyForEBSGateId")]
        public BooleanDropDown ReadyForEBSGate { get; set; }

        public int? EBSGateStatusId { get; set; }
        [ForeignKey("EBSGateStatusId")]
        public GateStatus EBSGateStatus { get; set; }


        public int? NextEBSGateId { get; set; }
        [ForeignKey("NextEBSGateId")]
        public Gate NextEBSGate { get; set; }


        public int? ReadyForOTMGateId { get; set; }
        [ForeignKey("ReadyForOTMGateId")]
        public BooleanDropDown ReadyForOTMGate { get; set; }


        public int? OTMGateStatusId { get; set; }
        [ForeignKey("OTMGateStatusId")]
        public GateStatus OTMGateStatus { get; set; }

        public int? OTMEBSGateId { get; set; }
        [ForeignKey("OTMEBSGateId")]
        public Gate OTMEBSGate { get; set; }




        public int? ReadyForBIGateId { get; set; }
        [ForeignKey("ReadyForBIGateId")]
        public BooleanDropDown ReadyForBIGate { get; set; }

        public int? BIGateStatusId { get; set; }
        [ForeignKey("BIGateStatusId")]
        public GateStatus BIGateStatus { get; set; }


        public int? NextBIGateId { get; set; }
        [ForeignKey("NextBIGateId")]
        public Gate NextBIGate { get; set; }


        public int? ReadyFor_NETGateId { get; set; }
        [ForeignKey("ReadyFor_NETGateId")]
        public BooleanDropDown ReadyFor_NETGate { get; set; }

        public int? _NETGateStatusId { get; set; }
        [ForeignKey("_NETGateStatusId")]
        public GateStatus _NETGateStatus { get; set; }


        public int? Next_NETGateId { get; set; }
        [ForeignKey("Next_NETGateId")]
        public Gate Next_NETGate { get; set; }

        public int? EstimateInfra { get; set; }
        public string FrontLineContact { get; set; }
        public OwningSite OwningSite { get; set; }
        [ForeignKey("OwningSiteId")]
        public int? OwningSiteId { get; set; }
        public string Requestor { get; set; }
        public OwningStream OwningStream { get; set; }
        [ForeignKey("OwningStreamId")]
        public int OwningStreamId { get; set; }
        //public bool BIRequest { get; set; }
        public int? BIRequestId { get; set; }
        [ForeignKey("BIRequestId")]
        public BooleanDropDown BIRequest { get; set; }
        public string OriginalSystemReference { get; set; }
        public List<RequestAttachment> Attachments { get; set; }
        // ITrack
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool DeleteMark{ get; set; }
    }
}
