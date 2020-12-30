using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class ViewQueryRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Attachments",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BIContact",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BIGateQuestionaireUrl",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BIGateStatus",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BIRequest",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BenefitCase",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "COEPriority",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CRNo",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CreatedBy",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CreatedOn",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DCOEDevelopmentLead",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DCOEEstimate",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DevelopmentTeams",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EBSGateQuestionaireUrl",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EBSGateStatus",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EstimateInfra",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FrontLineContact",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FunctionalContact",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GBSPriority",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ImpactedStreams",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MD_50",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MD_50_DueDate",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MD_70",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MD_70_DueDate",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ModifiedBy",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ModifiedOn",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Modules",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NextBIGate",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NextEBSGate",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NextOTMGate",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Next_NETGate",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Notes",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OTMGateQuestionaireUrl",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OTMGateStatus",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OracleDevEstimateOffShore",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OracleDevEstimateOnShore",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OracleDevelopmentLead",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OraclePreProdEnvironments",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OrderBy",
                table: "RequestViews",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OriginalSystemReference",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OwningSite",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OwningStream",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Problem",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProductionDate",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProjectName",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReadyForBIGate",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReadyForEBSGate",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReadyForOTMGate",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReadyFor_NETGate",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Regions",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RequestAttributes",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Requestor",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SBUs",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StatusId",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TIPUrl",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TestingDate",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TotalEstimate",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WhereClaus",
                table: "RequestViews",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "_NETGateQuestionaireUrl",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "_NETGateStatus",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachments",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "BIContact",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "BIGateQuestionaireUrl",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "BIGateStatus",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "BIRequest",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "BenefitCase",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "COEPriority",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "CRNo",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "DCOEDevelopmentLead",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "DCOEEstimate",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "DevelopmentTeams",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "EBSGateQuestionaireUrl",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "EBSGateStatus",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "EstimateInfra",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "FrontLineContact",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "FunctionalContact",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "GBSPriority",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "ImpactedStreams",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "MD_50",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "MD_50_DueDate",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "MD_70",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "MD_70_DueDate",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Modules",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "NextBIGate",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "NextEBSGate",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "NextOTMGate",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Next_NETGate",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "OTMGateQuestionaireUrl",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "OTMGateStatus",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "OracleDevEstimateOffShore",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "OracleDevEstimateOnShore",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "OracleDevelopmentLead",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "OraclePreProdEnvironments",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "OrderBy",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "OriginalSystemReference",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "OwningSite",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "OwningStream",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Problem",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "ReadyForBIGate",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "ReadyForEBSGate",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "ReadyForOTMGate",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "ReadyFor_NETGate",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Regions",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "RequestAttributes",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Requestor",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "SBUs",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "TIPUrl",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "TestingDate",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "TotalEstimate",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "WhereClaus",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "_NETGateQuestionaireUrl",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "_NETGateStatus",
                table: "RequestViews");
        }
    }
}
