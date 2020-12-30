using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class fixotmebsgateviewcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NextOTMGate",
                table: "RequestViews",
                newName: "OTMEBSGate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OTMEBSGate",
                table: "RequestViews",
                newName: "NextOTMGate");
        }
    }
}
