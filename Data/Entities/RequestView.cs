using OracleCOEWorkTracking.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OracleCOEWorkTracking.Data.Entities
{
    public class RequestView 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Application { get; set; }

        public bool ProjectName { get; set; }
        public bool Problem { get; set; }
        public bool BenefitCase { get; set; }
        public bool GBSPriority { get; set; }
        public bool COEPriority { get; set; }
        public bool Status { get; set; }
        public bool Notes { get; set; }
        public bool Regions { get; set; }
        public bool SBUs { get; set; }
        public bool ImpactedStreams { get; set; }
        public bool Modules { get; set; }
        public bool DevelopmentTeams { get; set; }
        public bool OraclePreProdEnvironments { get; set; }
        public bool MD_50_DueDate { get; set; }
        public bool TestingDate { get; set; }
        public bool MD_70_DueDate { get; set; }
        public bool ProductionDate { get; set; }
        public bool TotalEstimate { get; set; }
        public bool OracleDevEstimateOffShore { get; set; }
        public bool OracleDevEstimateOnShore { get; set; }
        public bool DCOEEstimate { get; set; }
        public bool CRNo { get; set; }
        public bool FunctionalContact { get; set; }
        public bool BIContact { get; set; }
        public bool OracleDevelopmentLead { get; set; }
        public bool DCOEDevelopmentLead { get; set; }
        public bool MD_70 { get; set; }
        public bool MD_50 { get; set; }
        public bool TIPUrl { get; set; }
        public bool EBSGateQuestionaireUrl { get; set; }
        public bool BIGateQuestionaireUrl { get; set; }
        public bool _NETGateQuestionaireUrl { get; set; }
        public bool OTMGateQuestionaireUrl { get; set; }
        public bool ReadyForEBSGate { get; set; }
        public bool EBSGateStatus { get; set; }
        public bool NextEBSGate { get; set; }
        public bool ReadyForOTMGate { get; set; }
        public bool OTMGateStatus { get; set; }
        public bool OTMEBSGate { get; set; }
        public bool ReadyForBIGate { get; set; }
        public bool BIGateStatus { get; set; }
        public bool NextBIGate { get; set; }
        public bool ReadyFor_NETGate { get; set; }
        public bool _NETGateStatus { get; set; }
        public bool Next_NETGate { get; set; }
        public bool Attribute1 { get; set; }
        public bool Attribute2 { get; set; }
        public bool Attribute3 { get; set; }
        public bool Attribute4 { get; set; }
        public bool Attribute5 { get; set; }
        public bool Attribute6 { get; set; }
        public bool Attribute7 { get; set; }
        public bool Attribute8 { get; set; }
        public bool Attribute9 { get; set; }
        public bool Attribute10 { get; set; }
        public bool EstimateInfra { get; set; }
        public bool FrontLineContact { get; set; }
        public bool OwningSite { get; set; }
        public bool Requestor { get; set; }
        public bool OwningStream { get; set; }
        public bool BIRequest { get; set; }
        public bool OriginalSystemReference { get; set; }
        public bool Attachments { get; set; }
        public bool CreatedBy { get; set; }
        public bool CreatedOn { get; set; }
        public bool ModifiedBy { get; set; }
        public bool ModifiedOn { get; set; }
        public string WhereClaus { get; set; }
        public string OrderBy { get; set; }
    }
}
 