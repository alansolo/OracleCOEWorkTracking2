using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class addingRequestMultiDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestDevelopmentTeam_DevelopmentTeams_DevelopmentTeamId",
                table: "RequestDevelopmentTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestDevelopmentTeam_Requests_RequestId",
                table: "RequestDevelopmentTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestImpactedStream_ImpactedStreams_ImpactedStreamId",
                table: "RequestImpactedStream");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestImpactedStream_Requests_RequestId",
                table: "RequestImpactedStream");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestModule_Modules_ModuleId",
                table: "RequestModule");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestModule_Requests_RequestId",
                table: "RequestModule");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestOraclePreProdEnvironment_OraclePreProdEnvironments_OraclePreProdEnvironmentId",
                table: "RequestOraclePreProdEnvironment");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestOraclePreProdEnvironment_Requests_RequestId",
                table: "RequestOraclePreProdEnvironment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestOraclePreProdEnvironment",
                table: "RequestOraclePreProdEnvironment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestModule",
                table: "RequestModule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestImpactedStream",
                table: "RequestImpactedStream");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestDevelopmentTeam",
                table: "RequestDevelopmentTeam");

            migrationBuilder.RenameTable(
                name: "RequestOraclePreProdEnvironment",
                newName: "RequestOraclePreProdEnvironments");

            migrationBuilder.RenameTable(
                name: "RequestModule",
                newName: "RequestModules");

            migrationBuilder.RenameTable(
                name: "RequestImpactedStream",
                newName: "RequestImpactedStreams");

            migrationBuilder.RenameTable(
                name: "RequestDevelopmentTeam",
                newName: "RequestDevelopmentTeams");

            migrationBuilder.RenameIndex(
                name: "IX_RequestOraclePreProdEnvironment_RequestId",
                table: "RequestOraclePreProdEnvironments",
                newName: "IX_RequestOraclePreProdEnvironments_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestOraclePreProdEnvironment_OraclePreProdEnvironmentId",
                table: "RequestOraclePreProdEnvironments",
                newName: "IX_RequestOraclePreProdEnvironments_OraclePreProdEnvironmentId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestModule_RequestId",
                table: "RequestModules",
                newName: "IX_RequestModules_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestModule_ModuleId",
                table: "RequestModules",
                newName: "IX_RequestModules_ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestImpactedStream_RequestId",
                table: "RequestImpactedStreams",
                newName: "IX_RequestImpactedStreams_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestImpactedStream_ImpactedStreamId",
                table: "RequestImpactedStreams",
                newName: "IX_RequestImpactedStreams_ImpactedStreamId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestDevelopmentTeam_RequestId",
                table: "RequestDevelopmentTeams",
                newName: "IX_RequestDevelopmentTeams_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestDevelopmentTeam_DevelopmentTeamId",
                table: "RequestDevelopmentTeams",
                newName: "IX_RequestDevelopmentTeams_DevelopmentTeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestOraclePreProdEnvironments",
                table: "RequestOraclePreProdEnvironments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestModules",
                table: "RequestModules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestImpactedStreams",
                table: "RequestImpactedStreams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestDevelopmentTeams",
                table: "RequestDevelopmentTeams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDevelopmentTeams_DevelopmentTeams_DevelopmentTeamId",
                table: "RequestDevelopmentTeams",
                column: "DevelopmentTeamId",
                principalTable: "DevelopmentTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDevelopmentTeams_Requests_RequestId",
                table: "RequestDevelopmentTeams",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestImpactedStreams_ImpactedStreams_ImpactedStreamId",
                table: "RequestImpactedStreams",
                column: "ImpactedStreamId",
                principalTable: "ImpactedStreams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestImpactedStreams_Requests_RequestId",
                table: "RequestImpactedStreams",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestModules_Modules_ModuleId",
                table: "RequestModules",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestModules_Requests_RequestId",
                table: "RequestModules",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestOraclePreProdEnvironments_OraclePreProdEnvironments_OraclePreProdEnvironmentId",
                table: "RequestOraclePreProdEnvironments",
                column: "OraclePreProdEnvironmentId",
                principalTable: "OraclePreProdEnvironments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestOraclePreProdEnvironments_Requests_RequestId",
                table: "RequestOraclePreProdEnvironments",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestDevelopmentTeams_DevelopmentTeams_DevelopmentTeamId",
                table: "RequestDevelopmentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestDevelopmentTeams_Requests_RequestId",
                table: "RequestDevelopmentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestImpactedStreams_ImpactedStreams_ImpactedStreamId",
                table: "RequestImpactedStreams");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestImpactedStreams_Requests_RequestId",
                table: "RequestImpactedStreams");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestModules_Modules_ModuleId",
                table: "RequestModules");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestModules_Requests_RequestId",
                table: "RequestModules");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestOraclePreProdEnvironments_OraclePreProdEnvironments_OraclePreProdEnvironmentId",
                table: "RequestOraclePreProdEnvironments");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestOraclePreProdEnvironments_Requests_RequestId",
                table: "RequestOraclePreProdEnvironments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestOraclePreProdEnvironments",
                table: "RequestOraclePreProdEnvironments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestModules",
                table: "RequestModules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestImpactedStreams",
                table: "RequestImpactedStreams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestDevelopmentTeams",
                table: "RequestDevelopmentTeams");

            migrationBuilder.RenameTable(
                name: "RequestOraclePreProdEnvironments",
                newName: "RequestOraclePreProdEnvironment");

            migrationBuilder.RenameTable(
                name: "RequestModules",
                newName: "RequestModule");

            migrationBuilder.RenameTable(
                name: "RequestImpactedStreams",
                newName: "RequestImpactedStream");

            migrationBuilder.RenameTable(
                name: "RequestDevelopmentTeams",
                newName: "RequestDevelopmentTeam");

            migrationBuilder.RenameIndex(
                name: "IX_RequestOraclePreProdEnvironments_RequestId",
                table: "RequestOraclePreProdEnvironment",
                newName: "IX_RequestOraclePreProdEnvironment_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestOraclePreProdEnvironments_OraclePreProdEnvironmentId",
                table: "RequestOraclePreProdEnvironment",
                newName: "IX_RequestOraclePreProdEnvironment_OraclePreProdEnvironmentId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestModules_RequestId",
                table: "RequestModule",
                newName: "IX_RequestModule_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestModules_ModuleId",
                table: "RequestModule",
                newName: "IX_RequestModule_ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestImpactedStreams_RequestId",
                table: "RequestImpactedStream",
                newName: "IX_RequestImpactedStream_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestImpactedStreams_ImpactedStreamId",
                table: "RequestImpactedStream",
                newName: "IX_RequestImpactedStream_ImpactedStreamId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestDevelopmentTeams_RequestId",
                table: "RequestDevelopmentTeam",
                newName: "IX_RequestDevelopmentTeam_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestDevelopmentTeams_DevelopmentTeamId",
                table: "RequestDevelopmentTeam",
                newName: "IX_RequestDevelopmentTeam_DevelopmentTeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestOraclePreProdEnvironment",
                table: "RequestOraclePreProdEnvironment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestModule",
                table: "RequestModule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestImpactedStream",
                table: "RequestImpactedStream",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestDevelopmentTeam",
                table: "RequestDevelopmentTeam",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDevelopmentTeam_DevelopmentTeams_DevelopmentTeamId",
                table: "RequestDevelopmentTeam",
                column: "DevelopmentTeamId",
                principalTable: "DevelopmentTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDevelopmentTeam_Requests_RequestId",
                table: "RequestDevelopmentTeam",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestImpactedStream_ImpactedStreams_ImpactedStreamId",
                table: "RequestImpactedStream",
                column: "ImpactedStreamId",
                principalTable: "ImpactedStreams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestImpactedStream_Requests_RequestId",
                table: "RequestImpactedStream",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestModule_Modules_ModuleId",
                table: "RequestModule",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestModule_Requests_RequestId",
                table: "RequestModule",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestOraclePreProdEnvironment_OraclePreProdEnvironments_OraclePreProdEnvironmentId",
                table: "RequestOraclePreProdEnvironment",
                column: "OraclePreProdEnvironmentId",
                principalTable: "OraclePreProdEnvironments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestOraclePreProdEnvironment_Requests_RequestId",
                table: "RequestOraclePreProdEnvironment",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
