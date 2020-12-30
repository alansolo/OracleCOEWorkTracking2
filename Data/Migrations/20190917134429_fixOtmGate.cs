using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class fixOtmGate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Gates_NextOTMGateId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "NextOTMGateId",
                table: "Requests",
                newName: "OTMEBSGateId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_NextOTMGateId",
                table: "Requests",
                newName: "IX_Requests_OTMEBSGateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Gates_OTMEBSGateId",
                table: "Requests",
                column: "OTMEBSGateId",
                principalTable: "Gates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Gates_OTMEBSGateId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "OTMEBSGateId",
                table: "Requests",
                newName: "NextOTMGateId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_OTMEBSGateId",
                table: "Requests",
                newName: "IX_Requests_NextOTMGateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Gates_NextOTMGateId",
                table: "Requests",
                column: "NextOTMGateId",
                principalTable: "Gates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
