using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class multidropdownfixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevelopmentTeams_Requests_RequestId",
                table: "DevelopmentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_ImpactedStreams_Requests_RequestId",
                table: "ImpactedStreams");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Requests_RequestId",
                table: "Modules");

            migrationBuilder.DropForeignKey(
                name: "FK_OraclePreProdEnvironments_Requests_RequestId",
                table: "OraclePreProdEnvironments");

            migrationBuilder.DropIndex(
                name: "IX_OraclePreProdEnvironments_RequestId",
                table: "OraclePreProdEnvironments");

            migrationBuilder.DropIndex(
                name: "IX_Modules_RequestId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_ImpactedStreams_RequestId",
                table: "ImpactedStreams");

            migrationBuilder.DropIndex(
                name: "IX_DevelopmentTeams_RequestId",
                table: "DevelopmentTeams");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "OraclePreProdEnvironments");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "ImpactedStreams");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "DevelopmentTeams");

            migrationBuilder.CreateTable(
                name: "RequestDevelopmentTeam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DevelopmentTeamId = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDevelopmentTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestDevelopmentTeam_DevelopmentTeams_DevelopmentTeamId",
                        column: x => x.DevelopmentTeamId,
                        principalTable: "DevelopmentTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestDevelopmentTeam_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestImpactedStream",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImpactedStreamId = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestImpactedStream", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestImpactedStream_ImpactedStreams_ImpactedStreamId",
                        column: x => x.ImpactedStreamId,
                        principalTable: "ImpactedStreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestImpactedStream_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestModule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModuleId = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestModule_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestModule_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestOraclePreProdEnvironment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OraclePreProdEnvironmentId = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOraclePreProdEnvironment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestOraclePreProdEnvironment_OraclePreProdEnvironments_OraclePreProdEnvironmentId",
                        column: x => x.OraclePreProdEnvironmentId,
                        principalTable: "OraclePreProdEnvironments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestOraclePreProdEnvironment_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestDevelopmentTeam_DevelopmentTeamId",
                table: "RequestDevelopmentTeam",
                column: "DevelopmentTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDevelopmentTeam_RequestId",
                table: "RequestDevelopmentTeam",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestImpactedStream_ImpactedStreamId",
                table: "RequestImpactedStream",
                column: "ImpactedStreamId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestImpactedStream_RequestId",
                table: "RequestImpactedStream",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestModule_ModuleId",
                table: "RequestModule",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestModule_RequestId",
                table: "RequestModule",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOraclePreProdEnvironment_OraclePreProdEnvironmentId",
                table: "RequestOraclePreProdEnvironment",
                column: "OraclePreProdEnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOraclePreProdEnvironment_RequestId",
                table: "RequestOraclePreProdEnvironment",
                column: "RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestDevelopmentTeam");

            migrationBuilder.DropTable(
                name: "RequestImpactedStream");

            migrationBuilder.DropTable(
                name: "RequestModule");

            migrationBuilder.DropTable(
                name: "RequestOraclePreProdEnvironment");

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "OraclePreProdEnvironments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Modules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "ImpactedStreams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "DevelopmentTeams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OraclePreProdEnvironments_RequestId",
                table: "OraclePreProdEnvironments",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_RequestId",
                table: "Modules",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ImpactedStreams_RequestId",
                table: "ImpactedStreams",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentTeams_RequestId",
                table: "DevelopmentTeams",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_DevelopmentTeams_Requests_RequestId",
                table: "DevelopmentTeams",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImpactedStreams_Requests_RequestId",
                table: "ImpactedStreams",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Requests_RequestId",
                table: "Modules",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OraclePreProdEnvironments_Requests_RequestId",
                table: "OraclePreProdEnvironments",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
