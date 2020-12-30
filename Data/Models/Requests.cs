using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class Requests
    {
        public Requests()
        {
            RequestAttachments = new HashSet<RequestAttachments>();
            RequestDevelopmentTeams = new HashSet<RequestDevelopmentTeams>();
            RequestImpactedStreams = new HashSet<RequestImpactedStreams>();
            RequestModules = new HashSet<RequestModules>();
            RequestNotes = new HashSet<RequestNotes>();
            RequestOraclePreProdEnvironments = new HashSet<RequestOraclePreProdEnvironments>();
            RequestRegions = new HashSet<RequestRegions>();
            RequestSbus = new HashSet<RequestSbus>();
        }

        public int Id { get; set; }
        public string Bicontact { get; set; }
        public string BigateQuestionnaireUrl { get; set; }
        public int? BigateStatusId { get; set; }
        public string BenefitCase { get; set; }
        public int? Coepriority { get; set; }
        public int? Crno { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string DcoedevelopmentLead { get; set; }
        public double? Dcoeestimate { get; set; }
        public bool DeleteMark { get; set; }
        public string EbsgateQuestionnaireUrl { get; set; }
        public int? EbsgateStatusId { get; set; }
        public int? EstimateInfra { get; set; }
        public string FrontLineContact { get; set; }
        public string FunctionalContact { get; set; }
        public int? Gbspriority { get; set; }
        public string Md50 { get; set; }
        public DateTime? Md50DueDate { get; set; }
        public string Md70 { get; set; }
        public DateTime? Md70DueDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? NextBigateId { get; set; }
        public int? NextEbsgateId { get; set; }
        public int? OtmebsgateId { get; set; }
        public int? NextNetgateId { get; set; }
        public string OtmgateQuestionnaireUrl { get; set; }
        public int? OtmgateStatusId { get; set; }
        public double? OracleDevEstimateOffShore { get; set; }
        public double? OracleDevEstimateOnShore { get; set; }
        public string OracleDevelopmentLead { get; set; }
        public string OriginalSystemReference { get; set; }
        public int? OwningSiteId { get; set; }
        public int OwningStreamId { get; set; }
        public string Problem { get; set; }
        public DateTime? ProductionDate { get; set; }
        public string ProjectName { get; set; }
        public int? ReadyForBigateId { get; set; }
        public int? ReadyForEbsgateId { get; set; }
        public int? ReadyForOtmgateId { get; set; }
        public int? ReadyForNetgateId { get; set; }
        public string Requestor { get; set; }
        public int StatusId { get; set; }
        public string Tipurl { get; set; }
        public DateTime? TestingDate { get; set; }
        public double? TotalEstimate { get; set; }
        public string NetgateQuestionnaireUrl { get; set; }
        public int? NetgateStatusId { get; set; }
        public int? BirequestId { get; set; }
        public string Attribute1 { get; set; }
        public DateTime? Attribute10 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public string Attribute5 { get; set; }
        public string Attribute6 { get; set; }
        public string Attribute7 { get; set; }
        public string Attribute8 { get; set; }
        public string Attribute9 { get; set; }
        public bool BiimpactedStream { get; set; }
        public bool OtmimpactedStream { get; set; }
        public int? ApplicationId { get; set; }

        public virtual Applications Application { get; set; }
        public virtual GateStatuses BigateStatus { get; set; }
        public virtual BooleanDropDownValues Birequest { get; set; }
        public virtual GateStatuses EbsgateStatus { get; set; }
        public virtual GateStatuses NetgateStatus { get; set; }
        public virtual Gates NextBigate { get; set; }
        public virtual Gates NextEbsgate { get; set; }
        public virtual Gates NextNetgate { get; set; }
        public virtual Gates Otmebsgate { get; set; }
        public virtual GateStatuses OtmgateStatus { get; set; }
        public virtual OwningSites OwningSite { get; set; }
        public virtual OwningStreams OwningStream { get; set; }
        public virtual BooleanDropDownValues ReadyForBigate { get; set; }
        public virtual BooleanDropDownValues ReadyForEbsgate { get; set; }
        public virtual BooleanDropDownValues ReadyForNetgate { get; set; }
        public virtual BooleanDropDownValues ReadyForOtmgate { get; set; }
        public virtual Statuses Status { get; set; }
        public virtual ICollection<RequestAttachments> RequestAttachments { get; set; }
        public virtual ICollection<RequestDevelopmentTeams> RequestDevelopmentTeams { get; set; }
        public virtual ICollection<RequestImpactedStreams> RequestImpactedStreams { get; set; }
        public virtual ICollection<RequestModules> RequestModules { get; set; }
        public virtual ICollection<RequestNotes> RequestNotes { get; set; }
        public virtual ICollection<RequestOraclePreProdEnvironments> RequestOraclePreProdEnvironments { get; set; }
        public virtual ICollection<RequestRegions> RequestRegions { get; set; }
        public virtual ICollection<RequestSbus> RequestSbus { get; set; }
    }
}
