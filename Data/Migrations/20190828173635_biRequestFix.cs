using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class biRequestFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BIRequest",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "BIRequestId",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_BIRequestId",
                table: "Requests",
                column: "BIRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_BooleanDropDownValues_BIRequestId",
                table: "Requests",
                column: "BIRequestId",
                principalTable: "BooleanDropDownValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_BooleanDropDownValues_BIRequestId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_BIRequestId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "BIRequestId",
                table: "Requests");

            migrationBuilder.AddColumn<bool>(
                name: "BIRequest",
                table: "Requests",
                nullable: false,
                defaultValue: false);
        }
    }
}
