using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class removesubquery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContainsSubQuery",
                table: "RequestViews");

            migrationBuilder.AddColumn<bool>(
                name: "BIImpactedStream",
                table: "Requests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OTMImpactedStream",
                table: "Requests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BIImpactedStream",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "OTMImpactedStream",
                table: "Requests");

            migrationBuilder.AddColumn<string>(
                name: "ContainsSubQuery",
                table: "RequestViews",
                nullable: true);
        }
    }
}
