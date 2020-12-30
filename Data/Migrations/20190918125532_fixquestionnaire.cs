using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class fixquestionnaire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_NETGateQuestionaireUrl",
                table: "Requests",
                newName: "_NETGateQuestionnaireUrl");

            migrationBuilder.RenameColumn(
                name: "OTMGateQuestionaireUrl",
                table: "Requests",
                newName: "OTMGateQuestionnaireUrl");

            migrationBuilder.RenameColumn(
                name: "EBSGateQuestionaireUrl",
                table: "Requests",
                newName: "EBSGateQuestionnaireUrl");

            migrationBuilder.RenameColumn(
                name: "BIGateQuestionaireUrl",
                table: "Requests",
                newName: "BIGateQuestionnaireUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_NETGateQuestionnaireUrl",
                table: "Requests",
                newName: "_NETGateQuestionaireUrl");

            migrationBuilder.RenameColumn(
                name: "OTMGateQuestionnaireUrl",
                table: "Requests",
                newName: "OTMGateQuestionaireUrl");

            migrationBuilder.RenameColumn(
                name: "EBSGateQuestionnaireUrl",
                table: "Requests",
                newName: "EBSGateQuestionaireUrl");

            migrationBuilder.RenameColumn(
                name: "BIGateQuestionnaireUrl",
                table: "Requests",
                newName: "BIGateQuestionaireUrl");
        }
    }
}
