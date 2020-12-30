using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class OracleWorkMgmtContext : DbContext
    {
        public OracleWorkMgmtContext()
        {
        }

        public OracleWorkMgmtContext(DbContextOptions<OracleWorkMgmtContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationAttribute> ApplicationAttribute { get; set; }
        public virtual DbSet<ApplicationModule> ApplicationModule { get; set; }
        public virtual DbSet<ApplicationOwningSite> ApplicationOwningSite { get; set; }
        public virtual DbSet<ApplicationRegion> ApplicationRegion { get; set; }
        public virtual DbSet<Applications> Applications { get; set; }
        public virtual DbSet<BooleanDropDownValues> BooleanDropDownValues { get; set; }
        public virtual DbSet<DevelopmentTeams> DevelopmentTeams { get; set; }
        public virtual DbSet<EnvironmentSettings> EnvironmentSettings { get; set; }
        public virtual DbSet<GateStatuses> GateStatuses { get; set; }
        public virtual DbSet<Gates> Gates { get; set; }
        public virtual DbSet<ImpactedStreams> ImpactedStreams { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<OraclePreProdEnvironments> OraclePreProdEnvironments { get; set; }
        public virtual DbSet<OwningSites> OwningSites { get; set; }
        public virtual DbSet<OwningStreams> OwningStreams { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<RequestAttachments> RequestAttachments { get; set; }
        public virtual DbSet<RequestDevelopmentTeams> RequestDevelopmentTeams { get; set; }
        public virtual DbSet<RequestImpactedStreams> RequestImpactedStreams { get; set; }
        public virtual DbSet<RequestModules> RequestModules { get; set; }
        public virtual DbSet<RequestNotes> RequestNotes { get; set; }
        public virtual DbSet<RequestOraclePreProdEnvironments> RequestOraclePreProdEnvironments { get; set; }
        public virtual DbSet<RequestRegions> RequestRegions { get; set; }
        public virtual DbSet<RequestSbus> RequestSbus { get; set; }
        public virtual DbSet<RequestViews> RequestViews { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Sbus> Sbus { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=SGOFCORPSQL52;User ID=OracleWorkMgmtDBO;Password=8D5dAeqpU7F6&Zdy");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<ApplicationAttribute>(entity =>
            {
                entity.Property(e => e.Attribute1).HasMaxLength(50);

                entity.Property(e => e.Attribute10).HasMaxLength(50);

                entity.Property(e => e.Attribute2).HasMaxLength(50);

                entity.Property(e => e.Attribute3).HasMaxLength(50);

                entity.Property(e => e.Attribute4).HasMaxLength(50);

                entity.Property(e => e.Attribute5).HasMaxLength(50);

                entity.Property(e => e.Attribute6).HasMaxLength(50);

                entity.Property(e => e.Attribute7).HasMaxLength(50);

                entity.Property(e => e.Attribute8).HasMaxLength(50);

                entity.Property(e => e.Attribute9).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationAttribute)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_ApplicationAttribute_Applications");
            });

            modelBuilder.Entity<ApplicationModule>(entity =>
            {
                entity.HasKey(e => new { e.AppId, e.ModuleId })
                    .HasName("PK__Applicat__EC9BB083DA43E038");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.ApplicationModule)
                    .HasForeignKey(d => d.AppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationModule_ToApplications");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.ApplicationModule)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationModule_ToModules");
            });

            modelBuilder.Entity<ApplicationOwningSite>(entity =>
            {
                entity.HasKey(e => new { e.AppId, e.OwningSiteId })
                    .HasName("PK__Applicat__FC86DE0033B51DBC");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.ApplicationOwningSite)
                    .HasForeignKey(d => d.AppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationOwningSites_ToApplications");

                entity.HasOne(d => d.OwningSite)
                    .WithMany(p => p.ApplicationOwningSite)
                    .HasForeignKey(d => d.OwningSiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationOwningSites_ToOwningSites");
            });

            modelBuilder.Entity<ApplicationRegion>(entity =>
            {
                entity.HasKey(e => new { e.AppId, e.RegionId })
                    .HasName("PK__Applicat__A4E173B398235281");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.ApplicationRegion)
                    .HasForeignKey(d => d.AppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationRegions_ToApplications");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.ApplicationRegion)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationRegions_ToRegions");
            });

            modelBuilder.Entity<Applications>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<DevelopmentTeams>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<EnvironmentSettings>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AddRequestsAdgroup).HasColumnName("AddRequestsADGroup");

                entity.Property(e => e.ManageRequestsAdgroup).HasColumnName("ManageRequestsADGroup");
            });

            modelBuilder.Entity<GateStatuses>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Gates>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<ImpactedStreams>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Modules>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<OraclePreProdEnvironments>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.OraclePreProdEnvironments)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_OraclePreProdEnvironments_Applications");
            });

            modelBuilder.Entity<OwningSites>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<OwningStreams>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DlEmailAddress).HasColumnName("dlEmailAddress");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<RequestAttachments>(entity =>
            {
                entity.HasIndex(e => e.RequestId);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestAttachments)
                    .HasForeignKey(d => d.RequestId);
            });

            modelBuilder.Entity<RequestDevelopmentTeams>(entity =>
            {
                entity.HasIndex(e => e.DevelopmentTeamId);

                entity.HasIndex(e => e.RequestId);

                entity.HasOne(d => d.DevelopmentTeam)
                    .WithMany(p => p.RequestDevelopmentTeams)
                    .HasForeignKey(d => d.DevelopmentTeamId);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestDevelopmentTeams)
                    .HasForeignKey(d => d.RequestId);
            });

            modelBuilder.Entity<RequestImpactedStreams>(entity =>
            {
                entity.HasIndex(e => e.ImpactedStreamId);

                entity.HasIndex(e => e.RequestId);

                entity.HasOne(d => d.ImpactedStream)
                    .WithMany(p => p.RequestImpactedStreams)
                    .HasForeignKey(d => d.ImpactedStreamId);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestImpactedStreams)
                    .HasForeignKey(d => d.RequestId);
            });

            modelBuilder.Entity<RequestModules>(entity =>
            {
                entity.HasIndex(e => e.ModuleId);

                entity.HasIndex(e => e.RequestId);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.RequestModules)
                    .HasForeignKey(d => d.ModuleId);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestModules)
                    .HasForeignKey(d => d.RequestId);
            });

            modelBuilder.Entity<RequestNotes>(entity =>
            {
                entity.HasIndex(e => e.RequestId);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestNotes)
                    .HasForeignKey(d => d.RequestId);
            });

            modelBuilder.Entity<RequestOraclePreProdEnvironments>(entity =>
            {
                entity.HasIndex(e => e.OraclePreProdEnvironmentId);

                entity.HasIndex(e => e.RequestId);

                entity.HasOne(d => d.OraclePreProdEnvironment)
                    .WithMany(p => p.RequestOraclePreProdEnvironments)
                    .HasForeignKey(d => d.OraclePreProdEnvironmentId);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestOraclePreProdEnvironments)
                    .HasForeignKey(d => d.RequestId);
            });

            modelBuilder.Entity<RequestRegions>(entity =>
            {
                entity.HasIndex(e => e.RegionId);

                entity.HasIndex(e => e.RequestId);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.RequestRegions)
                    .HasForeignKey(d => d.RegionId);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestRegions)
                    .HasForeignKey(d => d.RequestId);
            });

            modelBuilder.Entity<RequestSbus>(entity =>
            {
                entity.ToTable("RequestSBUs");

                entity.HasIndex(e => e.RequestId);

                entity.HasIndex(e => e.Sbuid);

                entity.Property(e => e.Sbuid).HasColumnName("SBUId");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestSbus)
                    .HasForeignKey(d => d.RequestId);

                entity.HasOne(d => d.Sbu)
                    .WithMany(p => p.RequestSbus)
                    .HasForeignKey(d => d.Sbuid);
            });

            modelBuilder.Entity<RequestViews>(entity =>
            {
                entity.Property(e => e.Bicontact).HasColumnName("BIContact");

                entity.Property(e => e.BigateQuestionaireUrl).HasColumnName("BIGateQuestionaireUrl");

                entity.Property(e => e.BigateStatus).HasColumnName("BIGateStatus");

                entity.Property(e => e.Birequest).HasColumnName("BIRequest");

                entity.Property(e => e.Coepriority).HasColumnName("COEPriority");

                entity.Property(e => e.Crno).HasColumnName("CRNo");

                entity.Property(e => e.DcoedevelopmentLead).HasColumnName("DCOEDevelopmentLead");

                entity.Property(e => e.Dcoeestimate).HasColumnName("DCOEEstimate");

                entity.Property(e => e.EbsgateQuestionaireUrl).HasColumnName("EBSGateQuestionaireUrl");

                entity.Property(e => e.EbsgateStatus).HasColumnName("EBSGateStatus");

                entity.Property(e => e.Gbspriority).HasColumnName("GBSPriority");

                entity.Property(e => e.Md50).HasColumnName("MD_50");

                entity.Property(e => e.Md50DueDate).HasColumnName("MD_50_DueDate");

                entity.Property(e => e.Md70).HasColumnName("MD_70");

                entity.Property(e => e.Md70DueDate).HasColumnName("MD_70_DueDate");

                entity.Property(e => e.NetgateQuestionaireUrl).HasColumnName("_NETGateQuestionaireUrl");

                entity.Property(e => e.NetgateStatus).HasColumnName("_NETGateStatus");

                entity.Property(e => e.NextBigate).HasColumnName("NextBIGate");

                entity.Property(e => e.NextEbsgate).HasColumnName("NextEBSGate");

                entity.Property(e => e.NextNetgate).HasColumnName("Next_NETGate");

                entity.Property(e => e.Otmebsgate).HasColumnName("OTMEBSGate");

                entity.Property(e => e.OtmgateQuestionaireUrl).HasColumnName("OTMGateQuestionaireUrl");

                entity.Property(e => e.OtmgateStatus).HasColumnName("OTMGateStatus");

                entity.Property(e => e.ReadyForBigate).HasColumnName("ReadyForBIGate");

                entity.Property(e => e.ReadyForEbsgate).HasColumnName("ReadyForEBSGate");

                entity.Property(e => e.ReadyForNetgate).HasColumnName("ReadyFor_NETGate");

                entity.Property(e => e.ReadyForOtmgate).HasColumnName("ReadyForOTMGate");

                entity.Property(e => e.Sbus).HasColumnName("SBUs");

                entity.Property(e => e.Tipurl).HasColumnName("TIPUrl");
            });

            modelBuilder.Entity<Requests>(entity =>
            {
                entity.HasIndex(e => e.BigateStatusId);

                entity.HasIndex(e => e.BirequestId);

                entity.HasIndex(e => e.EbsgateStatusId);

                entity.HasIndex(e => e.NetgateStatusId);

                entity.HasIndex(e => e.NextBigateId);

                entity.HasIndex(e => e.NextEbsgateId);

                entity.HasIndex(e => e.NextNetgateId);

                entity.HasIndex(e => e.OtmebsgateId);

                entity.HasIndex(e => e.OtmgateStatusId);

                entity.HasIndex(e => e.OwningSiteId);

                entity.HasIndex(e => e.OwningStreamId);

                entity.HasIndex(e => e.ReadyForBigateId);

                entity.HasIndex(e => e.ReadyForEbsgateId);

                entity.HasIndex(e => e.ReadyForNetgateId);

                entity.HasIndex(e => e.ReadyForOtmgateId);

                entity.HasIndex(e => e.StatusId);

                entity.Property(e => e.Bicontact).HasColumnName("BIContact");

                entity.Property(e => e.BigateQuestionnaireUrl).HasColumnName("BIGateQuestionnaireUrl");

                entity.Property(e => e.BigateStatusId).HasColumnName("BIGateStatusId");

                entity.Property(e => e.BiimpactedStream).HasColumnName("BIImpactedStream");

                entity.Property(e => e.BirequestId).HasColumnName("BIRequestId");

                entity.Property(e => e.Coepriority).HasColumnName("COEPriority");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Crno).HasColumnName("CRNo");

                entity.Property(e => e.DcoedevelopmentLead).HasColumnName("DCOEDevelopmentLead");

                entity.Property(e => e.Dcoeestimate).HasColumnName("DCOEEstimate");

                entity.Property(e => e.EbsgateQuestionnaireUrl).HasColumnName("EBSGateQuestionnaireUrl");

                entity.Property(e => e.EbsgateStatusId).HasColumnName("EBSGateStatusId");

                entity.Property(e => e.Gbspriority).HasColumnName("GBSPriority");

                entity.Property(e => e.Md50).HasColumnName("MD_50");

                entity.Property(e => e.Md50DueDate).HasColumnName("MD_50_DueDate");

                entity.Property(e => e.Md70).HasColumnName("MD_70");

                entity.Property(e => e.Md70DueDate).HasColumnName("MD_70_DueDate");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.NetgateQuestionnaireUrl).HasColumnName("_NETGateQuestionnaireUrl");

                entity.Property(e => e.NetgateStatusId).HasColumnName("_NETGateStatusId");

                entity.Property(e => e.NextBigateId).HasColumnName("NextBIGateId");

                entity.Property(e => e.NextEbsgateId).HasColumnName("NextEBSGateId");

                entity.Property(e => e.NextNetgateId).HasColumnName("Next_NETGateId");

                entity.Property(e => e.OtmebsgateId).HasColumnName("OTMEBSGateId");

                entity.Property(e => e.OtmgateQuestionnaireUrl).HasColumnName("OTMGateQuestionnaireUrl");

                entity.Property(e => e.OtmgateStatusId).HasColumnName("OTMGateStatusId");

                entity.Property(e => e.OtmimpactedStream).HasColumnName("OTMImpactedStream");

                entity.Property(e => e.ReadyForBigateId).HasColumnName("ReadyForBIGateId");

                entity.Property(e => e.ReadyForEbsgateId).HasColumnName("ReadyForEBSGateId");

                entity.Property(e => e.ReadyForNetgateId).HasColumnName("ReadyFor_NETGateId");

                entity.Property(e => e.ReadyForOtmgateId).HasColumnName("ReadyForOTMGateId");

                entity.Property(e => e.Tipurl).HasColumnName("TIPUrl");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_Requests_Applications");

                entity.HasOne(d => d.BigateStatus)
                    .WithMany(p => p.RequestsBigateStatus)
                    .HasForeignKey(d => d.BigateStatusId);

                entity.HasOne(d => d.Birequest)
                    .WithMany(p => p.RequestsBirequest)
                    .HasForeignKey(d => d.BirequestId);

                entity.HasOne(d => d.EbsgateStatus)
                    .WithMany(p => p.RequestsEbsgateStatus)
                    .HasForeignKey(d => d.EbsgateStatusId);

                entity.HasOne(d => d.NetgateStatus)
                    .WithMany(p => p.RequestsNetgateStatus)
                    .HasForeignKey(d => d.NetgateStatusId);

                entity.HasOne(d => d.NextBigate)
                    .WithMany(p => p.RequestsNextBigate)
                    .HasForeignKey(d => d.NextBigateId);

                entity.HasOne(d => d.NextEbsgate)
                    .WithMany(p => p.RequestsNextEbsgate)
                    .HasForeignKey(d => d.NextEbsgateId);

                entity.HasOne(d => d.NextNetgate)
                    .WithMany(p => p.RequestsNextNetgate)
                    .HasForeignKey(d => d.NextNetgateId);

                entity.HasOne(d => d.Otmebsgate)
                    .WithMany(p => p.RequestsOtmebsgate)
                    .HasForeignKey(d => d.OtmebsgateId);

                entity.HasOne(d => d.OtmgateStatus)
                    .WithMany(p => p.RequestsOtmgateStatus)
                    .HasForeignKey(d => d.OtmgateStatusId);

                entity.HasOne(d => d.OwningSite)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.OwningSiteId);

                entity.HasOne(d => d.OwningStream)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.OwningStreamId);

                entity.HasOne(d => d.ReadyForBigate)
                    .WithMany(p => p.RequestsReadyForBigate)
                    .HasForeignKey(d => d.ReadyForBigateId);

                entity.HasOne(d => d.ReadyForEbsgate)
                    .WithMany(p => p.RequestsReadyForEbsgate)
                    .HasForeignKey(d => d.ReadyForEbsgateId);

                entity.HasOne(d => d.ReadyForNetgate)
                    .WithMany(p => p.RequestsReadyForNetgate)
                    .HasForeignKey(d => d.ReadyForNetgateId);

                entity.HasOne(d => d.ReadyForOtmgate)
                    .WithMany(p => p.RequestsReadyForOtmgate)
                    .HasForeignKey(d => d.ReadyForOtmgateId);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.StatusId);
            });

            modelBuilder.Entity<Sbus>(entity =>
            {
                entity.ToTable("SBUs");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            });
        }
    }
}
