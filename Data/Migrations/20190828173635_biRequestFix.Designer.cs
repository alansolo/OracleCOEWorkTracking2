﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using OracleCOEWorkTracking.Data;
using System;

namespace OracleCOEWorkTracking.Data.Migrations
{
    [DbContext(typeof(WorkTrackingContext))]
    [Migration("20190828173635_biRequestFix")]
    partial class biRequestFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.BooleanDropDown", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("BooleanDropDownValues");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.DevelopmentTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("DeleteMark");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DevelopmentTeams");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.Gate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("DeleteMark");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Gates");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.GateStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("DeleteMark");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("GateStatuses");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.ImpactedStream", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("DeleteMark");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ImpactedStreams");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("DeleteMark");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.OraclePreProdEnvironment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("DeleteMark");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("OraclePreProdEnvironments");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.OwningSite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("DeleteMark");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("OwningSites");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.OwningStream", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("DeleteMark");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<string>("dlEmailAddress");

                    b.HasKey("Id");

                    b.ToTable("OwningStreams");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("DeleteMark");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BIContact");

                    b.Property<string>("BIGateQuestionaireUrl");

                    b.Property<int?>("BIGateStatusId");

                    b.Property<int?>("BIRequestId");

                    b.Property<string>("BenefitCase");

                    b.Property<int>("COEPriority");

                    b.Property<double>("CRNo");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DCOEDevelopmentLead");

                    b.Property<double>("DCOEEstimate");

                    b.Property<bool>("DeleteMark");

                    b.Property<string>("EBSGateQuestionaireUrl");

                    b.Property<int?>("EBSGateStatusId");

                    b.Property<int>("EstimateInfra");

                    b.Property<string>("FrontLineContact");

                    b.Property<string>("FunctionalContact");

                    b.Property<int>("GBSPriority");

                    b.Property<string>("MD_50");

                    b.Property<DateTime>("MD_50_DueDate");

                    b.Property<string>("MD_70");

                    b.Property<DateTime>("MD_70_DueDate");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<int?>("NextBIGateId");

                    b.Property<int?>("NextEBSGateId");

                    b.Property<int?>("NextOTMGateId");

                    b.Property<int?>("Next_NETGateId");

                    b.Property<string>("OTMGateQuestionaireUrl");

                    b.Property<int?>("OTMGateStatusId");

                    b.Property<double>("OracleDevEstimateOffShore");

                    b.Property<double>("OracleDevEstimateOnShore");

                    b.Property<string>("OracleDevelopmentLead");

                    b.Property<string>("OriginalSystemReference");

                    b.Property<int>("OwningSiteId");

                    b.Property<int>("OwningStreamId");

                    b.Property<string>("Problem");

                    b.Property<DateTime>("ProductionDate");

                    b.Property<string>("ProjectName");

                    b.Property<int?>("ReadyForBIGateId");

                    b.Property<int?>("ReadyForEBSGateId");

                    b.Property<int?>("ReadyForOTMGateId");

                    b.Property<int?>("ReadyFor_NETGateId");

                    b.Property<string>("Requestor");

                    b.Property<int>("StatusId");

                    b.Property<string>("TIPUrl");

                    b.Property<DateTime>("TestingDate");

                    b.Property<double>("TotalEstimate");

                    b.Property<string>("_NETGateQuestionaireUrl");

                    b.Property<int?>("_NETGateStatusId");

                    b.HasKey("Id");

                    b.HasIndex("BIGateStatusId");

                    b.HasIndex("BIRequestId");

                    b.HasIndex("EBSGateStatusId");

                    b.HasIndex("NextBIGateId");

                    b.HasIndex("NextEBSGateId");

                    b.HasIndex("NextOTMGateId");

                    b.HasIndex("Next_NETGateId");

                    b.HasIndex("OTMGateStatusId");

                    b.HasIndex("OwningSiteId");

                    b.HasIndex("OwningStreamId");

                    b.HasIndex("ReadyForBIGateId");

                    b.HasIndex("ReadyForEBSGateId");

                    b.HasIndex("ReadyForOTMGateId");

                    b.HasIndex("ReadyFor_NETGateId");

                    b.HasIndex("StatusId");

                    b.HasIndex("_NETGateStatusId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Attachment");

                    b.Property<int>("RequestId");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestAttachment");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("RequestId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestAttributes");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestDevelopmentTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DevelopmentTeamId");

                    b.Property<int>("RequestId");

                    b.HasKey("Id");

                    b.HasIndex("DevelopmentTeamId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestDevelopmentTeam");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestImpactedStream", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ImpactedStreamId");

                    b.Property<int>("RequestId");

                    b.HasKey("Id");

                    b.HasIndex("ImpactedStreamId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestImpactedStream");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ModuleId");

                    b.Property<int>("RequestId");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestModule");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("DeleteMark");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Note");

                    b.Property<int>("RequestId");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestNotes");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestOraclePreProdEnvironment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OraclePreProdEnvironmentId");

                    b.Property<int>("RequestId");

                    b.HasKey("Id");

                    b.HasIndex("OraclePreProdEnvironmentId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestOraclePreProdEnvironment");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RegionId");

                    b.Property<int>("RequestId");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestRegions");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestSBU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RequestId");

                    b.Property<int>("SBUId");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("SBUId");

                    b.ToTable("RequestSBUs");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestView", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Query");

                    b.HasKey("Id");

                    b.ToTable("RequestViews");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestViewProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ControlListQuery");

                    b.Property<string>("ControlType");

                    b.Property<string>("ControlValueQuery");

                    b.Property<string>("QueryColumnName");

                    b.Property<string>("UIDisplayName");

                    b.HasKey("Id");

                    b.ToTable("RequestViewProperties");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.SBU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("DeleteMark");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SBUs");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("DeleteMark");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.Request", b =>
                {
                    b.HasOne("OracleCOEWorkTracking.Data.Entities.GateStatus", "BIGateStatus")
                        .WithMany()
                        .HasForeignKey("BIGateStatusId");

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.BooleanDropDown", "BIRequest")
                        .WithMany()
                        .HasForeignKey("BIRequestId");

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.GateStatus", "EBSGateStatus")
                        .WithMany()
                        .HasForeignKey("EBSGateStatusId");

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Gate", "NextBIGate")
                        .WithMany()
                        .HasForeignKey("NextBIGateId");

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Gate", "NextEBSGate")
                        .WithMany()
                        .HasForeignKey("NextEBSGateId");

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Gate", "NextOTMGate")
                        .WithMany()
                        .HasForeignKey("NextOTMGateId");

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Gate", "Next_NETGate")
                        .WithMany()
                        .HasForeignKey("Next_NETGateId");

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.GateStatus", "OTMGateStatus")
                        .WithMany()
                        .HasForeignKey("OTMGateStatusId");

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.OwningSite", "OwningSite")
                        .WithMany()
                        .HasForeignKey("OwningSiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.OwningStream", "OwningStream")
                        .WithMany()
                        .HasForeignKey("OwningStreamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.BooleanDropDown", "ReadyForBIGate")
                        .WithMany()
                        .HasForeignKey("ReadyForBIGateId");

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.BooleanDropDown", "ReadyForEBSGate")
                        .WithMany()
                        .HasForeignKey("ReadyForEBSGateId");

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.BooleanDropDown", "ReadyForOTMGate")
                        .WithMany()
                        .HasForeignKey("ReadyForOTMGateId");

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.BooleanDropDown", "ReadyFor_NETGate")
                        .WithMany()
                        .HasForeignKey("ReadyFor_NETGateId");

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.GateStatus", "_NETGateStatus")
                        .WithMany()
                        .HasForeignKey("_NETGateStatusId");
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestAttachment", b =>
                {
                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Request")
                        .WithMany("Attachments")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestAttribute", b =>
                {
                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Request")
                        .WithMany("RequestAttributes")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestDevelopmentTeam", b =>
                {
                    b.HasOne("OracleCOEWorkTracking.Data.Entities.DevelopmentTeam", "DevelopmentTeam")
                        .WithMany()
                        .HasForeignKey("DevelopmentTeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Request")
                        .WithMany("DevelopmentTeams")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestImpactedStream", b =>
                {
                    b.HasOne("OracleCOEWorkTracking.Data.Entities.ImpactedStream", "ImpactedStream")
                        .WithMany()
                        .HasForeignKey("ImpactedStreamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Request")
                        .WithMany("ImpactedStreams")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestModule", b =>
                {
                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Request")
                        .WithMany("Modules")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestNote", b =>
                {
                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Request")
                        .WithMany("Notes")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestOraclePreProdEnvironment", b =>
                {
                    b.HasOne("OracleCOEWorkTracking.Data.Entities.OraclePreProdEnvironment", "OraclePreProdEnvironment")
                        .WithMany()
                        .HasForeignKey("OraclePreProdEnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Request")
                        .WithMany("OraclePreProdEnvironments")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestRegion", b =>
                {
                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Request")
                        .WithMany("Regions")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OracleCOEWorkTracking.Data.Entities.RequestSBU", b =>
                {
                    b.HasOne("OracleCOEWorkTracking.Data.Entities.Request")
                        .WithMany("SBUs")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OracleCOEWorkTracking.Data.Entities.SBU", "SBU")
                        .WithMany()
                        .HasForeignKey("SBUId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
