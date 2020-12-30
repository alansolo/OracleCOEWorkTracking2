using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BooleanDropDownValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooleanDropDownValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GateStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwningSites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwningSites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwningStreams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    dlEmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwningStreams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestViewProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ControlListQuery = table.Column<string>(nullable: true),
                    ControlType = table.Column<string>(nullable: true),
                    ControlValueQuery = table.Column<string>(nullable: true),
                    QueryColumnName = table.Column<string>(nullable: true),
                    UIDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestViewProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestViews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Query = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestViews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SBUs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BIContact = table.Column<string>(nullable: true),
                    BIGateQuestionaireUrl = table.Column<string>(nullable: true),
                    BIGateStatusId = table.Column<int>(nullable: true),
                    BIRequest = table.Column<bool>(nullable: false),
                    BenefitCase = table.Column<string>(nullable: true),
                    COEPriority = table.Column<int>(nullable: false),
                    CRNo = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DCOEDevelopmentLead = table.Column<string>(nullable: true),
                    DCOEEstimate = table.Column<double>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: false),
                    EBSGateQuestionaireUrl = table.Column<string>(nullable: true),
                    EBSGateStatusId = table.Column<int>(nullable: true),
                    EstimateInfra = table.Column<int>(nullable: false),
                    FrontLineContact = table.Column<string>(nullable: true),
                    FunctionalContact = table.Column<string>(nullable: true),
                    GBSPriority = table.Column<int>(nullable: false),
                    MD_50 = table.Column<string>(nullable: true),
                    MD_50_DueDate = table.Column<DateTime>(nullable: false),
                    MD_70 = table.Column<string>(nullable: true),
                    MD_70_DueDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    NextBIGateId = table.Column<int>(nullable: true),
                    NextEBSGateId = table.Column<int>(nullable: true),
                    NextOTMGateId = table.Column<int>(nullable: true),
                    Next_NETGateId = table.Column<int>(nullable: true),
                    OTMGateQuestionaireUrl = table.Column<string>(nullable: true),
                    OTMGateStatusId = table.Column<int>(nullable: true),
                    OracleDevEstimateOffShore = table.Column<double>(nullable: false),
                    OracleDevEstimateOnShore = table.Column<double>(nullable: false),
                    OracleDevelopmentLead = table.Column<string>(nullable: true),
                    OriginalSystemReference = table.Column<string>(nullable: true),
                    OwningSiteId = table.Column<int>(nullable: false),
                    OwningStreamId = table.Column<int>(nullable: false),
                    Problem = table.Column<string>(nullable: true),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    ReadyForBIGateId = table.Column<int>(nullable: true),
                    ReadyForEBSGateId = table.Column<int>(nullable: true),
                    ReadyForOTMGateId = table.Column<int>(nullable: true),
                    ReadyFor_NETGateId = table.Column<int>(nullable: true),
                    Requestor = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    TIPUrl = table.Column<string>(nullable: true),
                    TestingDate = table.Column<DateTime>(nullable: false),
                    TotalEstimate = table.Column<double>(nullable: false),
                    _NETGateQuestionaireUrl = table.Column<string>(nullable: true),
                    _NETGateStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_GateStatuses_BIGateStatusId",
                        column: x => x.BIGateStatusId,
                        principalTable: "GateStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_GateStatuses_EBSGateStatusId",
                        column: x => x.EBSGateStatusId,
                        principalTable: "GateStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Gates_NextBIGateId",
                        column: x => x.NextBIGateId,
                        principalTable: "Gates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Gates_NextEBSGateId",
                        column: x => x.NextEBSGateId,
                        principalTable: "Gates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Gates_NextOTMGateId",
                        column: x => x.NextOTMGateId,
                        principalTable: "Gates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Gates_Next_NETGateId",
                        column: x => x.Next_NETGateId,
                        principalTable: "Gates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_GateStatuses_OTMGateStatusId",
                        column: x => x.OTMGateStatusId,
                        principalTable: "GateStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_OwningSites_OwningSiteId",
                        column: x => x.OwningSiteId,
                        principalTable: "OwningSites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_OwningStreams_OwningStreamId",
                        column: x => x.OwningStreamId,
                        principalTable: "OwningStreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_BooleanDropDownValues_ReadyForBIGateId",
                        column: x => x.ReadyForBIGateId,
                        principalTable: "BooleanDropDownValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_BooleanDropDownValues_ReadyForEBSGateId",
                        column: x => x.ReadyForEBSGateId,
                        principalTable: "BooleanDropDownValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_BooleanDropDownValues_ReadyForOTMGateId",
                        column: x => x.ReadyForOTMGateId,
                        principalTable: "BooleanDropDownValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_BooleanDropDownValues_ReadyFor_NETGateId",
                        column: x => x.ReadyFor_NETGateId,
                        principalTable: "BooleanDropDownValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_GateStatuses__NETGateStatusId",
                        column: x => x._NETGateStatusId,
                        principalTable: "GateStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DevelopmentTeams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevelopmentTeams_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImpactedStreams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpactedStreams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImpactedStreams_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OraclePreProdEnvironments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OraclePreProdEnvironments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OraclePreProdEnvironments_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attachment = table.Column<byte[]>(nullable: true),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestAttachment_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    RequestId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestAttributes_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestNotes_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestRegions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegionId = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestRegions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestRegions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestRegions_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestSBUs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequestId = table.Column<int>(nullable: false),
                    SBUId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSBUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestSBUs_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestSBUs_SBUs_SBUId",
                        column: x => x.SBUId,
                        principalTable: "SBUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentTeams_RequestId",
                table: "DevelopmentTeams",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ImpactedStreams_RequestId",
                table: "ImpactedStreams",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_RequestId",
                table: "Modules",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_OraclePreProdEnvironments_RequestId",
                table: "OraclePreProdEnvironments",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestAttachment_RequestId",
                table: "RequestAttachment",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestAttributes_RequestId",
                table: "RequestAttributes",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestNotes_RequestId",
                table: "RequestNotes",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestRegions_RegionId",
                table: "RequestRegions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestRegions_RequestId",
                table: "RequestRegions",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_BIGateStatusId",
                table: "Requests",
                column: "BIGateStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_EBSGateStatusId",
                table: "Requests",
                column: "EBSGateStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_NextBIGateId",
                table: "Requests",
                column: "NextBIGateId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_NextEBSGateId",
                table: "Requests",
                column: "NextEBSGateId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_NextOTMGateId",
                table: "Requests",
                column: "NextOTMGateId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_Next_NETGateId",
                table: "Requests",
                column: "Next_NETGateId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OTMGateStatusId",
                table: "Requests",
                column: "OTMGateStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OwningSiteId",
                table: "Requests",
                column: "OwningSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OwningStreamId",
                table: "Requests",
                column: "OwningStreamId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ReadyForBIGateId",
                table: "Requests",
                column: "ReadyForBIGateId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ReadyForEBSGateId",
                table: "Requests",
                column: "ReadyForEBSGateId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ReadyForOTMGateId",
                table: "Requests",
                column: "ReadyForOTMGateId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ReadyFor_NETGateId",
                table: "Requests",
                column: "ReadyFor_NETGateId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StatusId",
                table: "Requests",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests__NETGateStatusId",
                table: "Requests",
                column: "_NETGateStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSBUs_RequestId",
                table: "RequestSBUs",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSBUs_SBUId",
                table: "RequestSBUs",
                column: "SBUId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevelopmentTeams");

            migrationBuilder.DropTable(
                name: "ImpactedStreams");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "OraclePreProdEnvironments");

            migrationBuilder.DropTable(
                name: "RequestAttachment");

            migrationBuilder.DropTable(
                name: "RequestAttributes");

            migrationBuilder.DropTable(
                name: "RequestNotes");

            migrationBuilder.DropTable(
                name: "RequestRegions");

            migrationBuilder.DropTable(
                name: "RequestSBUs");

            migrationBuilder.DropTable(
                name: "RequestViewProperties");

            migrationBuilder.DropTable(
                name: "RequestViews");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "SBUs");

            migrationBuilder.DropTable(
                name: "GateStatuses");

            migrationBuilder.DropTable(
                name: "Gates");

            migrationBuilder.DropTable(
                name: "OwningSites");

            migrationBuilder.DropTable(
                name: "OwningStreams");

            migrationBuilder.DropTable(
                name: "BooleanDropDownValues");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
