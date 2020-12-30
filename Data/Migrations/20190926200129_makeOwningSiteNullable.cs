using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class makeOwningSiteNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_OwningSites_OwningSiteId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "OwningSiteId",
                table: "Requests",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_OwningSites_OwningSiteId",
                table: "Requests",
                column: "OwningSiteId",
                principalTable: "OwningSites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_OwningSites_OwningSiteId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "OwningSiteId",
                table: "Requests",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_OwningSites_OwningSiteId",
                table: "Requests",
                column: "OwningSiteId",
                principalTable: "OwningSites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
